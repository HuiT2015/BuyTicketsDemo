using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Web;


namespace BuyTrainTickets.Utils
{
    class HttpRequestProcess
    {
        private String url;//url地址
        private String data;//数据
        private String response;//响应结果
        private string referer;
        private CookieContainer cookieContainer;
        private IDictionary<String, String> postData;
        private CookieCollection cookies;
        private string cookieStr;
        private string host;
        private string accept;

        public HttpRequestProcess()
        {
            this.url = null;
            this.data = null;
            this.response = null;
            this.cookieContainer = new CookieContainer();
            this.postData = null;
        }

        public HttpRequestProcess(String url, String data) 
        {
            this.url = url;
            this.data = data;
            this.response = null;
            this.cookieContainer = new CookieContainer();
            this.postData = null;
        }

        public String Url {
            get { 
                return url; 
            }
           set{
               url=value;
           }
        }

        public String Data {
            get { 
                return data; 
            }
            set {
                data = value;
            }
        }

        public String Response {
            get {
                return response; 
            }
            set { 
                response = value;
            }
        }

        public string Accept {
            get { return this.accept; }
            set { this.accept = value; }
        }

        public String Host {
            get { return this.host; }
            set { this.host = value; }
        }

        public IDictionary<String, String> PostData {
            get { return this.postData; }
            set { postData = value; }
        }

        public CookieCollection Cookies {
            get { return cookies; }
            set { cookies = value; }
        }


        public string CookieStr {
            get { return cookieStr; }
            set { cookieStr = value; }
        }

        public string Referer {
            get { return referer; }
            set { this.referer = value; }
        }

        public CookieContainer CookieContainer {
            get { return cookieContainer; }
            set { this.cookieContainer = value; }
        }

        /// <summary>
        /// 将字典数据转换为string
        /// </summary>
        /// <returns></returns>
        private String convertPostDataToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<String, String> kv in postData)
            {
                sb.Append(HttpUtility.UrlEncode(kv.Key));
                sb.Append("=");
                sb.Append(HttpUtility.UrlEncode(kv.Value));
                sb.Append("&");
            }
            return sb.ToString().TrimEnd('&');
        }

        /// <summary>
        /// 处理get请求
        /// </summary>
        public void doGet()
        {
            if (string.IsNullOrEmpty(url))
                return;
            if (data == null&&postData!=null)
            {
                this.data = convertPostDataToString();
            }
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(this.url + (this.data == "" ? "" : "?") + this.data);
            req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.113 Safari/537.36";
            req.Referer = referer;
            req.Host = host;

            if (this.cookieContainer.Count != 0)
            {
                req.CookieContainer = cookieContainer;
            }
            req.Method = "GET";
            try
            {
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                cookieStr = "";
                if (resp.Cookies != null && resp.Cookies.Count != 0)
                {
                    cookies = resp.Cookies;
                    cookieStr = toCookieString(cookies);
                    this.cookieContainer.Add(resp.Cookies);
                }
                if (cookieStr==""&&resp.Headers["Set-Cookie"] != null)
                {
                    parseCookies2(resp.Headers["Set-Cookie"]);
                }
                Stream stream = resp.GetResponseStream();
                StreamReader sr = new StreamReader(stream, Encoding.GetEncoding("utf-8"));
                this.response = sr.ReadToEnd();
                sr.Close();
                stream.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                this.response = null;
            }
        }

       
        /// <summary>
        /// 处理post请求
        /// </summary>
        public void doPost()
        {
            if (string.IsNullOrEmpty(url))
                return;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            if (this.cookieContainer.Count != 0)
            {
                req.CookieContainer = cookieContainer;
            }
            if (data == null&&postData!=null)
            {
                this.data = convertPostDataToString();
            }
            byte[] byteArray = Encoding.UTF8.GetBytes(data);
          
            req.Method = "POST";
            req.Accept = "*/*";
        
            req.Host = host;
            req.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            req.ContentLength = byteArray.Length;
            req.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Win64; x64; Trident/4.0; .NET CLR 2.0.50727; SLCC2; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; Tablet PC 2.0)";
         
            req.Referer = referer;
            req.Headers.Add("Cookie", cookieStr);

            try
            {
                Stream reqStream = req.GetRequestStream();
                reqStream.Write(byteArray, 0, byteArray.Length);
                reqStream.Close();

                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                cookieStr = "";
                if (resp.Cookies != null&&resp.Cookies.Count!=0)
                {
                    cookies = resp.Cookies;
                    cookieStr = toCookieString(cookies);
                    this.cookieContainer.Add(resp.Cookies);
                }
                if (cookieStr == "" && resp.Headers.Get("Set-Cookie") != null)
                {
                    //cookies= parseCookies(resp.Headers["Set-Cookie"]);
                    //this.cookieContainer.Add(cookies);
                    parseCookies2(resp.Headers["Set-Cookie"]);
                }

                Stream respStream = resp.GetResponseStream();
                StreamReader sr = new StreamReader(respStream, Encoding.GetEncoding("utf-8"));
                response = sr.ReadToEnd();
                sr.Close();
                respStream.Close();
            }
            catch (Exception ex) {
                Console.Write(ex.ToString());
                this.response = null;
            }
        }

        /// <summary>
        /// 从字符串解析cookie
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        private CookieCollection parseCookies(string cookie)
        {
            cookieStr = cookie;
            CookieCollection cc = new CookieCollection();
            Cookie ck = null;
            string[] tmpArr = cookie.Trim().Split(';');
            foreach (string ckv in tmpArr)
            {
                string[] tmpArr1= ckv.Split(',');
                foreach (string tmp in tmpArr1)
                {
                    if (tmp.Contains("path") || tmp.Contains("Path"))
                        continue;
                    string key = tmp.Substring(0, tmp.IndexOf("="));
                    string value = tmp.Substring(tmp.IndexOf("=") + 1);
                    ck = new Cookie(key, value);
                    cc.Add(ck);
                }
              
            }
            return cc;
        }

        /// <summary>
        /// 从字符串中解析cookie
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="firstSeparator"></param>
        /// <param name="secondSeparator"></param>
        private void parseCookies2(string cookie,char firstSeparator=',',char secondSeparator=';')
        {
            cookieStr = cookie;
            Cookie ck = null;
            string[] tmpArr = cookie.Trim().Split(firstSeparator);//cookie分割方式
            foreach (string ckv in tmpArr)
            {
                string[] tmpArr1 = ckv.Split(secondSeparator);//cookie和path的分割方式
                foreach (string tmp in tmpArr1)
                {
                    if (tmp.Contains("path") || tmp.Contains("Path"))
                        continue;
                    string key = tmp.Substring(0, tmp.IndexOf("="));
                    string value = tmp.Substring(tmp.IndexOf("=") + 1);
                    ck = new Cookie(key, value);
                    ck.Domain = "kyfw.12306.cn";
                    this.cookieContainer.Add(ck);
                }

            }
        }

        /// <summary>
        /// 返回字符串类型的cookie
        /// </summary>
        /// <param name="cc"></param>
        /// <returns></returns>
        private string toCookieString(CookieCollection cc)
        {
            string cookies = "";
            foreach (Cookie c in cc)
            {
                if (cookies == "")
                    cookies = c.Name + "=" + c.Value;
                else
                    cookies = cookies + ";" + c.Name + "=" + c.Value;
            }
            return cookies;

        }
    }
}

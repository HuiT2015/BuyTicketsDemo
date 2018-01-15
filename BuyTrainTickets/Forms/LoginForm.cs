using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using BuyTrainTickets.Entity;
using BuyTrainTickets.Utils;
using ServiceStack.Text;



namespace BuyTrainTickets.Forms
{
    public partial class LoginForm : Form
    {
        private string username;
        private string password;
        private Random random;
        private List<CPoint> clickPoints;
        private Image tagImg;
        private HttpRequestProcess httpReqProc;
        private CookieContainer cookieContainer;


        public CookieContainer CookieContainer
        {
            get { return this.cookieContainer; }
            set { this.cookieContainer = value; }
        }

        public LoginForm()
        {
            InitializeComponent();
            if (loadLoginInfo() == true)
                this.checkBoxRemember.Checked = true;
            clickPoints = new List<CPoint>();
            tagImg = null;
            httpReqProc = new HttpRequestProcess();
            random = new Random();
            beforeLogin();
        }


        public void beforeLogin()
        {
            string url = "https://kyfw.12306.cn/otn/login/init";
            httpReqProc.Url = url;
            httpReqProc.Host = "kyfw.12306.cn";
            httpReqProc.Accept = "text/html, application/xhtml+xml, */*";
            httpReqProc.Data = "";
            httpReqProc.doGet();
       
            setCaptchaInPicBox();
        }

        /// <summary>
        /// 点击记住我
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxRemember_CheckedChanged(object sender, EventArgs e)
        {
            string usrInfoFilePath = "./usrInfo.ini";
            if (this.checkBoxRemember.Checked)
            {
                this.username = this.textBoxUsername.Text;
                this.password = this.textBoxPassword.Text;
                if (File.Exists(usrInfoFilePath) == false)//不存在则保存
                {
                    StreamWriter sw = new StreamWriter(new FileStream(usrInfoFilePath, FileMode.Create));
                    sw.WriteLine(username);
                    sw.WriteLine(password);
                    sw.Close();
                }
                else
                {
                    StreamReader sr = new StreamReader(new FileStream(usrInfoFilePath, FileMode.Open));
                    string username_old = sr.ReadLine().Trim();
                    sr.Close();
                    if (username_old != this.username)//如果文件中存储的信息比输入的老则更新
                    {
                        File.Delete(usrInfoFilePath);
                        StreamWriter sw = new StreamWriter(new FileStream(usrInfoFilePath, FileMode.Create));
                        sw.WriteLine(username);
                        sw.WriteLine(password);
                        sw.Close();
                    }
                }
            }
            else
            {
                if (File.Exists(usrInfoFilePath))
                    File.Delete(usrInfoFilePath);
            }
        }

        /// <summary>
        /// 加载登录信息
        /// </summary>
        /// <returns></returns>
        private bool loadLoginInfo()
        {
            string usrInfoFilePath = "./usrInfo.ini";
            if (!File.Exists(usrInfoFilePath))
                return false;
            StreamReader sr = new StreamReader(new FileStream(usrInfoFilePath, FileMode.Open));
            this.username = sr.ReadLine().Trim();
            this.password = sr.ReadLine().Trim();
            this.textBoxUsername.Text = this.username;
            this.textBoxPassword.Text = this.password;
            sr.Close();
            return true;
        }

        /// <summary>
        /// 刷新验证码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            this.clickPoints.Clear();
            setCaptchaInPicBox();
        }

        /// <summary>
        /// 点击登录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (doLogin())
            {
                this.DialogResult = DialogResult.OK;
                this.CookieContainer = httpReqProc.CookieContainer;//保存cookie
            }
            else {
                this.textBoxWarning.Text = "登录失败!";
            }
        }


        /// <summary>
        /// 处理登录    
        /// </summary>
        private bool doLogin()
        {
            string url = "https://kyfw.12306.cn/passport/captcha/captcha-check";
            IDictionary<string, string> postData = new Dictionary<string, string>();

            string clickData = "";
            foreach (CPoint pt in clickPoints)
            {
                if (clickData == "")
                    clickData = Convert.ToString(pt.X) + "," + Convert.ToString(pt.Y-40);
                else
                    clickData +=","+Convert.ToString(pt.X) + "," + Convert.ToString(pt.Y-40);
            }

            postData.Add("answer", clickData);
            postData.Add("login_site", "E");
            postData.Add("rand", "sjrand");
            httpReqProc.Data = null;
            httpReqProc.PostData = postData;
            httpReqProc.Accept = "application/json, text/javascript, */*; q=0.01";
            httpReqProc.Referer = "https://kyfw.12306.cn/otn/login/init";
            httpReqProc.Host = "kyfw.12306.cn";
            httpReqProc.Url = url;
            //httpReqProc.Data = "answer=" + clickData + "&login_site=E&rand=sjrand"; ;
            httpReqProc.doPost();

            Console.WriteLine(httpReqProc.Response);

            JsonObject result = JsonObject.Parse(httpReqProc.Response);
            if (result.Get<string>("result_message").IndexOf("成功") == -1)
            {
                // MessageBox.Show("验证码不正确!");
                this.textBoxWarning.Text = "验证码不正确!";
                buttonRefresh_Click(null, null);
                return false;
            }

            url = "https://kyfw.12306.cn/passport/web/login";

            postData.Clear();
            postData.Add("appid", "otn");
            postData.Add("username", this.username);
            postData.Add("password", password);
            httpReqProc.Data = null;
            httpReqProc.PostData = postData;
            httpReqProc.Host = "kyfw.12306.cn";
            httpReqProc.Accept = "application/json, text/javascript, */*; q=0.01";
            httpReqProc.Referer = "https://kyfw.12306.cn/otn/login/init";
            httpReqProc.Url = url;
         
            httpReqProc.doPost();

            Console.WriteLine(httpReqProc.Response);
            result = JsonObject.Parse(httpReqProc.Response);

            if (result.Get<string>("result_message").IndexOf("登录成功") != -1)
            {
                url = "https://kyfw.12306.cn/otn/passport?redirect=/otn/login/userLogin";
                httpReqProc.Url = url;
                httpReqProc.Data = "";
                httpReqProc.doGet();


                url = "https://kyfw.12306.cn/passport/web/auth/uamtk";
                httpReqProc.Referer = "https://kyfw.12306.cn/otn/passport?redirect=/otn/login/userLogin";
                httpReqProc.Url = url;
                postData.Clear();
                postData.Add("appid", "otn");
           
                httpReqProc.PostData = postData;
                httpReqProc.Data = null;
                httpReqProc.doPost();

                if (httpReqProc.Response.Contains("验证通过") == true)
                {
                    JsonObject retJson = JsonObject.Parse(httpReqProc.Response);
                    string newapptk = retJson.Get("newapptk");

                    url = "https://kyfw.12306.cn/otn/uamauthclient";
                    httpReqProc.Url = url;
                    postData.Clear();
                    httpReqProc.Referer = "https://kyfw.12306.cn/otn/passport?redirect=/otn/login/userLogin";
                    postData.Add("tk", newapptk);
                    httpReqProc.PostData = postData;
                    httpReqProc.Data = null;
                    httpReqProc.doPost();

                    if (httpReqProc.Response.Contains("验证通过"))
                    {
                        return true;
                    }
                    else
                        return true;
                }
                else {
                    return false;
                }

            }
            else
                return false;
        }


        /// <summary>
        /// 设置验证码到picturebox中
        /// </summary>
        private void setCaptchaInPicBox()
        {
            string captchaUrl = "https://kyfw.12306.cn/passport/captcha/captcha-image?login_site=E&module=login&rand=sjrand&" + random.NextDouble();
            Image image;
            HttpWebRequest hreq = (HttpWebRequest)HttpWebRequest.Create(captchaUrl);
            hreq.Method = "GET";
            hreq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.113 Safari/537.36";
           // hreq.CookieContainer = httpReqProc.CookieContainer;
            HttpWebResponse hres = (HttpWebResponse)hreq.GetResponse();
            using (var stream = hres.GetResponseStream())
            {
                image = Image.FromStream(stream);
            }
            hres.Close();
            this.pictureBoxCaptcha.Image = image;

        }

        /// <summary>
        /// 点击取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 鼠标点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxCaptcha_MouseClick(object sender, MouseEventArgs e)
        {
            Image captchaImg = pictureBoxCaptcha.Image;
            Graphics g = Graphics.FromImage(captchaImg);
            if (tagImg == null)
            {
                tagImg = Image.FromFile(@"./train.jpg");
            }
            CPoint pt = new CPoint(e.X, e.Y);
            if (pt.X + tagImg.Width > captchaImg.Width || pt.Y + tagImg.Height > captchaImg.Height)
            {
                MessageBox.Show("对不起，你点击的区域无效!");
                return;
            }
            this.clickPoints.Add(pt);
            Rectangle srcRect = new Rectangle(0, 0, tagImg.Width, tagImg.Height);
            Rectangle destRect = new Rectangle((int)pt.X, (int)pt.Y,tagImg.Width,tagImg.Height);
            g.DrawImage(tagImg, destRect, srcRect, GraphicsUnit.Pixel);
            g.Dispose();
            pictureBoxCaptcha.Image = captchaImg;
          //  tagImg.Dispose();
        }
    }
}

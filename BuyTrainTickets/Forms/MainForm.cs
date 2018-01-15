using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BuyTrainTickets.Utils;
using System.Net;

namespace BuyTrainTickets.Forms
{
    public partial class MainForm : Form
    {
        private AutoSizeForm asf;
        private CookieContainer cookieContainer;
        private HttpRequestProcess httpReqProc;

        public CookieContainer CookieContainer {
            get { return this.cookieContainer; }
            set { this.cookieContainer = value; }
        }

        public MainForm()
        {
            InitializeComponent();
            asf = new AutoSizeForm();
            this.dateTimePickerStartOff.CustomFormat = "yyyy-MM-dd";
            httpReqProc = new HttpRequestProcess();
            this.comboBoxStartStation.Items.Add("BJP");
            this.comboBoxStartStation.SelectedIndex = 0;
            this.comboBoxEndStation.Items.Add("WHN");
            this.comboBoxEndStation.SelectedIndex = 0;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            asf.controllInitializeSize(this);
            httpReqProc.Url = "https://kyfw.12306.cn/otn/leftTicket/init";
            httpReqProc.Data = "";
            httpReqProc.Referer = "https://kyfw.12306.cn/otn/index/initMy12306";
            httpReqProc.CookieContainer = this.cookieContainer;
            httpReqProc.Host = "kyfw.12306.cn";
            httpReqProc.doGet();
            Console.WriteLine(httpReqProc.Response);
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            asf.controlAutoSize(this);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonQuery_Click(object sender, EventArgs e)
        {
            httpReqProc.Url = "https://kyfw.12306.cn/otn/leftTicket/log";
            DateTime selDateTime = this.dateTimePickerStartOff.Value;
            string train_date = selDateTime.ToString("yyyy-MM-dd");
            string startStation = this.comboBoxStartStation.SelectedItem.ToString();
            string endStation = this.comboBoxEndStation.SelectedItem.ToString();
            httpReqProc.Data = "leftTicketDTO.train_date="+ train_date + "&leftTicketDTO.from_station="+startStation+"&leftTicketDTO.to_station="+endStation+"&purpose_codes=ADULT";

            httpReqProc.doGet();

            Console.Write(httpReqProc.Response);

        }
    }
}

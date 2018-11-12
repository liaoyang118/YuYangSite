using Site.Untity;
using Site.Videos.DataAccess.Model;
using Site.Videos.DataAccess.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Watch.Main
{
    public partial class main : Form
    {
        /// <summary>
        /// html解析器
        /// </summary>
        HtmlAgilityPack.HtmlDocument htmlDoc = null;

        List<Info> list = new List<Info>();

        bool isStart = false;


        public main()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            htmlDoc = new HtmlAgilityPack.HtmlDocument();
            isStart = true;
            //定时刷新
            timer1.Start();

            btn_start.Enabled = false;
            btn_recoder.Enabled = false;

        }

        private void main_Load(object sender, EventArgs e)
        {
            web_browser.Navigate(txt_url.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            web_browser.Navigate("https://consumeprod.alipay.com/record/advanced.htm");
        }

        private void Web_browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (isStart)
            {

                if (web_browser.ReadyState < WebBrowserReadyState.Complete) return;

                System.IO.StreamReader getReader = new System.IO.StreamReader(this.web_browser.DocumentStream, System.Text.Encoding.GetEncoding("gb2312"));
                string htmlContent = getReader.ReadToEnd();

                htmlDoc.LoadHtml(htmlContent);

                // 
                HtmlAgilityPack.HtmlNodeCollection nodes = htmlDoc.DocumentNode.SelectNodes("//*[@id=\"tradeRecordsIndex\"]/tbody[1]/tr");

                string time = string.Empty;
                string money = string.Empty;
                string code = string.Empty;


                Info obj = null;
                ActiveVipInfo avInfo = null;
                UserInfo uInfo = null;
                foreach (HtmlAgilityPack.HtmlNode item in nodes)
                {
                    try
                    {
                        time = item.SelectSingleNode("child::td[1]/p[1]").InnerText + " " + item.SelectSingleNode("child::td[1]/p[2]").InnerText.ToSafeString();
                        code = item.SelectSingleNode("child::td[3]/p[1]").InnerText.ToSafeString().Trim(' ');
                        money = item.SelectSingleNode("child::td[6]/span[1]").InnerText.ToSafeString().Replace("+", "").Trim(' ');

                        if (list.Count >= 10)
                        {
                            list.Clear();
                        }
                        obj = new Info()
                        {
                            Time = time,
                            Money = money,
                            OnlyCode = code
                        };

                        if (code.ToLower().Contains("vip"))
                        {
                            list.Add(obj);
                            //检测Vip
                            avInfo = ActiveVipInfoService.Select(string.Format(" where active_code='{0}' and IsPay=0 ", code.ToLower())).FirstOrDefault();
                            if (avInfo != null)
                            {
                                decimal currentMoney = decimal.Parse(money.Trim(' '));
                                if (currentMoney >= avInfo.c_num)
                                {
                                    avInfo.IsPay = true;
                                    avInfo.pay_time = DateTime.Now;

                                    uInfo = UserInfoService.SelectObject(avInfo.u_id);
                                    uInfo.u_expriseTime = DateTime.Now.AddDays(avInfo.c_days);
                                    uInfo.u_status = (int)SiteEnum.BasicStatus.有效;
                                    switch (avInfo.c_days)
                                    {
                                        case 3:
                                            uInfo.u_level = (int)SiteEnum.AccountLevel.试用用户;
                                            break;
                                        case 7:
                                            uInfo.u_level = (int)SiteEnum.AccountLevel.周用户;
                                            break;
                                        case 30:
                                            uInfo.u_level = (int)SiteEnum.AccountLevel.月用户;
                                            break;
                                        case 365:
                                            uInfo.u_level = (int)SiteEnum.AccountLevel.年用户;
                                            break;
                                    }
                                    UserInfoService.Update(uInfo);
                                    ActiveVipInfoService.Update(avInfo);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }

                dataGridView1.DataSource = list;
                dataGridView1.Refresh();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            web_browser.Navigate("https://consumeprod.alipay.com/record/advanced.htm");
        }
    }

    public class Info
    {
        public string OnlyCode { get; set; }
        public string Money { get; set; }
        public string Time { get; set; }
    }
}

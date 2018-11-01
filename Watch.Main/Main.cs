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


                foreach (HtmlAgilityPack.HtmlNode item in nodes)
                {
                    time = item.SelectSingleNode("child::td[1]/p[1]").InnerText + " " + item.SelectSingleNode("child::td[1]/p[2]").InnerText;
                    code = item.SelectSingleNode("child::td[3]/p[1]").InnerText;
                    money = item.SelectSingleNode("child::td[6]/span[1]").InnerText;

                    if (list.Count >= 10)
                    {
                        list.Clear();
                    }
                    list.Add(new Info()
                    {
                        Time = time,
                        Money = money,
                        OnlyCode = code
                    });
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

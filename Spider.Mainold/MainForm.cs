using Spider.Main.Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Spider.Main.Core;
using Spider.Main.Model;
using System.IO;
using System.Xml.Serialization;
using Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using Unity.Resolution;
using Spider.Main.Core.Communicant;

namespace Spider.Main
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            dgv_Task.AutoGenerateColumns = false;
        }


        #region 变量

        //清屏行数
        private const int clearNums = 3000;

        /// <summary>
        /// 日志输出委托
        /// </summary>
        ConsoleLog WriteLog;

        /// <summary>
        /// IOC容器
        /// </summary>
        IUnityContainer container = null;

        /// <summary>
        /// 当前选中行的任务信息
        /// </summary>
        TaskInfo CurrentRowInfo = null;

        /// <summary>
        /// 是否输出日志
        /// </summary>
        bool IsConsoleOutLog = true;

        /// <summary>
        /// 任务通知者
        /// </summary>
        MainController controller = null;

        /// <summary>
        /// 开启的任务列表
        /// key ioc名称
        /// value 任务
        /// </summary>
        Dictionary<string, ISpider> dic = new Dictionary<string, ISpider>();

        #endregion

        #region 日志输出

        public void WriteSuccessLog(string log)
        {
            WriteLog = new ConsoleLog(SuccessLog);
            this.Invoke(WriteLog, new object[] { log });
        }
        public void WriteErrorLog(string log)
        {
            WriteLog = new ConsoleLog(ErrorLog);
            this.Invoke(WriteLog, new object[] { log });
        }

        public void WriteNotifyLog(string log, bool isBigShow = false)
        {
            if (isBigShow)
            {
                WriteLog = new ConsoleLog(BigNotifyLog);
            }
            else
            {
                WriteLog = new ConsoleLog(NotifyLog);
            }
            this.Invoke(WriteLog, new object[] { log });
        }


        private void SuccessLog(string log)
        {
            if (IsConsoleOutLog)
            {
                this.txt_log.SelectionColor = Color.Blue;
                this.txt_log.AppendText(log);
                this.txt_log.AppendText("\r\n");

            }

            if (this.txt_log.Lines.Length >= clearNums)
            {
                this.txt_log.Clear();
            }
        }

        private void NotifyLog(string log)
        {
            if (IsConsoleOutLog)
            {
                this.txt_log.SelectionColor = Color.Green;
                this.txt_log.AppendText(log);
                this.txt_log.AppendText("\r\n");

            }

            if (this.txt_log.Lines.Length >= clearNums)
            {
                this.txt_log.Clear();
            }
        }

        private void BigNotifyLog(string log)
        {
            if (IsConsoleOutLog)
            {
                this.txt_log.SelectionColor = Color.Green;
                Font font = new Font(FontFamily.GenericMonospace, 12, FontStyle.Regular);
                this.txt_log.SelectionFont = font;
                this.txt_log.AppendText(log);
                this.txt_log.AppendText("\r\n");

            }

            if (this.txt_log.Lines.Length >= clearNums)
            {
                this.txt_log.Clear();
            }
        }

        private void ErrorLog(string log)
        {
            if (IsConsoleOutLog)
            {
                this.txt_log.SelectionColor = Color.Red;
                this.txt_log.AppendText(log);
                this.txt_log.AppendText("\r\n");

            }

            if (this.txt_log.Lines.Length >= clearNums)
            {
                this.txt_log.Clear();
            }
        }
        #endregion


        public void StartMainThread()
        {
            //任务线程
            Thread t = new Thread(StartSpider);
            t.IsBackground = true;
            t.Start();
        }

        public void StartSpider()
        {
            try
            {
                ISpider spider = IOC_GetInstance(container, CurrentRowInfo.IocName);

                //任务加入列表
                dic[CurrentRowInfo.IocName] = spider;
                //加入通知者
                controller.StopTaskEvent += new StopTask(spider.Stop);

                spider.SpiderRun();
            }
            catch (Exception ex)
            {
                WriteErrorLog("启动任务失败:" + ex.Message);
            }
        }

        #region 01 获取IOC对象
        /// <summary>
        /// 获取IOC对象
        /// </summary>
        /// <param name="container"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private ISpider IOC_GetInstance(IUnityContainer container, string name)
        {
            //指定命名解析对象
            ISpider handle = null;

            //获取错误章节任务
            if (name == "5858XS_Error")
            {

                handle = container.Resolve<ISpider>(name, new ParameterOverrides{
                {"form", this},
                {"pageCount", 1000}
                });
            }
            else
            {
                handle = container.Resolve<ISpider>(name, new ParameterOverrides{
                {"form", this},
                {"PageNums", CurrentRowInfo.PageNums},
                {"FictionNums", CurrentRowInfo.FictionNums},
                {"Nums", CurrentRowInfo.Nums},
                {"UpdateGrowNums", CurrentRowInfo.UpdateGrowNums}
                });
            }

            return handle;
        }
        #endregion


        #region 02 重启任务
        /// <summary>
        /// 重启任务
        /// </summary>
        public void ResetTask(string iocName)
        {
            //重新启动任务

            var list = dgv_Task.Rows;
            foreach (DataGridViewRow item in list)
            {
                if (item.Cells["IocName"].Value.ToString() == iocName)
                {
                    TaskInfo tInfo = item.DataBoundItem as TaskInfo;
                    //当前行
                    CurrentRowInfo = tInfo;
                    StartTask();
                    break;
                }
            }
        }

        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                TaskList info = Common.ReadConfig();
                dgv_Task.DataSource = info.TaskInfos;
                dgv_Task.Rows[0].Selected = false;
                dgv_Task.Rows[0].Cells[0].Selected = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //加载IOC容器
                container = new UnityContainer();
                //获取指定名称的配置节
                UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
                //载入名称为SpiderClass 的container节点
                container.LoadConfiguration(section, "SpiderClass");
                //实例化任务通知者
                controller = new MainController();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = dgv_Task.CurrentRow;
                TaskInfo tInfo = row.DataBoundItem as TaskInfo;
                //当前行
                CurrentRowInfo = tInfo;

                //设置按钮
                SetOperateBtn();
            }
        }

        /// <summary>
        /// 设置按钮状态
        /// </summary>
        private void SetOperateBtn()
        {
            this.btn_start.Enabled = CurrentRowInfo.IsStart == 1 ? false : true;
            this.btn_stop.Enabled = CurrentRowInfo.IsStart == 1 ? true : false;
            this.dgv_Task.ReadOnly = CurrentRowInfo.IsStart == 1 ? true : false;
        }

        //启动任务
        private void btn_start_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentRowInfo != null)
                {
                    if (CurrentRowInfo.IsStart == 0)
                    {
                        StartTask();
                    }
                }
                else
                {
                    MessageBox.Show("未选择任务", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                WriteErrorLog("启动任务错误:" + ex.Message);
            }
        }

        private void StartTask()
        {
            StartMainThread();

            (dgv_Task.CurrentRow.DataBoundItem as TaskInfo).IsStart = 1;
            (dgv_Task.CurrentRow.DataBoundItem as TaskInfo).LastUpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.dgv_Task.Refresh();

            //更新当前行对象
            CurrentRowInfo = dgv_Task.CurrentRow.DataBoundItem as TaskInfo;
            SetOperateBtn();
        }

        //停止任务
        private void btn_stop_Click(object sender, EventArgs e)
        {
            if (CurrentRowInfo != null)
            {
                if (CurrentRowInfo.IsStart == 1)
                {
                    try
                    {
                        //更新列表状态
                        (this.dgv_Task.CurrentRow.DataBoundItem as TaskInfo).IsStart = 0;
                        (this.dgv_Task.CurrentRow.DataBoundItem as TaskInfo).LastUpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        this.dgv_Task.Refresh();

                        //更新当前行对象
                        CurrentRowInfo = this.dgv_Task.CurrentRow.DataBoundItem as TaskInfo;
                        SetOperateBtn();

                        //TODO:停止线程，当前只能通知到页级别，待完善到章节级别
                        controller.Notify(dic[CurrentRowInfo.IocName].GetType());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("未选择任务", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_isConsoleLog_Click(object sender, EventArgs e)
        {
            if (IsConsoleOutLog == true)
            {
                IsConsoleOutLog = false;
                this.btn_isConsoleLog.Text = "开启输出日志";
            }
            else
            {
                IsConsoleOutLog = true;
                this.btn_isConsoleLog.Text = "暂停输出日志";
            }
        }

        private void dgv_Task_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            (dgv_Task.CurrentRow.DataBoundItem as TaskInfo).PredictThreadNums = (dgv_Task.CurrentRow.DataBoundItem as TaskInfo).PageNums * 8 * (dgv_Task.CurrentRow.DataBoundItem as TaskInfo).FictionNums * (dgv_Task.CurrentRow.DataBoundItem as TaskInfo).Nums;

            this.dgv_Task.Refresh();
        }
    }
}

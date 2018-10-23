namespace Spider.Main
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_Task = new System.Windows.Forms.DataGridView();
            this.grb = new System.Windows.Forms.GroupBox();
            this.btn_isConsoleLog = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_log = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PageNums = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FictionNums = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nums = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateGrowNums = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PredictThreadNums = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IocName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Task)).BeginInit();
            this.grb.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgv_Task);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(675, 236);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "爬虫任务";
            // 
            // dgv_Task
            // 
            this.dgv_Task.AllowUserToAddRows = false;
            this.dgv_Task.AllowUserToDeleteRows = false;
            this.dgv_Task.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Task.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Task.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TaskName,
            this.PageNums,
            this.FictionNums,
            this.Nums,
            this.UpdateGrowNums,
            this.PredictThreadNums,
            this.IsStart,
            this.IocName,
            this.LastUpdateTime});
            this.dgv_Task.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Task.Location = new System.Drawing.Point(3, 17);
            this.dgv_Task.MultiSelect = false;
            this.dgv_Task.Name = "dgv_Task";
            this.dgv_Task.RowHeadersVisible = false;
            this.dgv_Task.RowTemplate.Height = 23;
            this.dgv_Task.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_Task.Size = new System.Drawing.Size(669, 216);
            this.dgv_Task.TabIndex = 0;
            this.dgv_Task.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dgv_Task.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Task_CellEndEdit);
            // 
            // grb
            // 
            this.grb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grb.Controls.Add(this.btn_isConsoleLog);
            this.grb.Controls.Add(this.btn_stop);
            this.grb.Controls.Add(this.btn_start);
            this.grb.Location = new System.Drawing.Point(12, 263);
            this.grb.Name = "grb";
            this.grb.Size = new System.Drawing.Size(669, 264);
            this.grb.TabIndex = 2;
            this.grb.TabStop = false;
            this.grb.Text = "操作区";
            // 
            // btn_isConsoleLog
            // 
            this.btn_isConsoleLog.Location = new System.Drawing.Point(180, 20);
            this.btn_isConsoleLog.Name = "btn_isConsoleLog";
            this.btn_isConsoleLog.Size = new System.Drawing.Size(99, 34);
            this.btn_isConsoleLog.TabIndex = 1;
            this.btn_isConsoleLog.Text = "暂停输出日志";
            this.btn_isConsoleLog.UseVisualStyleBackColor = true;
            this.btn_isConsoleLog.Click += new System.EventHandler(this.btn_isConsoleLog_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(93, 20);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(81, 34);
            this.btn_stop.TabIndex = 0;
            this.btn_stop.Text = "停止";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(6, 20);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(81, 34);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "启动";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txt_log);
            this.groupBox2.Location = new System.Drawing.Point(693, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(572, 515);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "日志输出";
            // 
            // txt_log
            // 
            this.txt_log.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_log.Location = new System.Drawing.Point(3, 17);
            this.txt_log.Name = "txt_log";
            this.txt_log.Size = new System.Drawing.Size(566, 495);
            this.txt_log.TabIndex = 0;
            this.txt_log.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 541);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1277, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(33, 17);
            this.toolStripStatusLabel1.Text = "V1.0";
            // 
            // TaskName
            // 
            this.TaskName.DataPropertyName = "TaskName";
            this.TaskName.HeaderText = "任务";
            this.TaskName.Name = "TaskName";
            this.TaskName.ReadOnly = true;
            // 
            // PageNums
            // 
            this.PageNums.DataPropertyName = "PageNums";
            this.PageNums.HeaderText = "并发页";
            this.PageNums.Name = "PageNums";
            // 
            // FictionNums
            // 
            this.FictionNums.DataPropertyName = "FictionNums";
            this.FictionNums.HeaderText = "并发条";
            this.FictionNums.Name = "FictionNums";
            // 
            // Nums
            // 
            this.Nums.DataPropertyName = "Nums";
            this.Nums.HeaderText = "并发子条";
            this.Nums.Name = "Nums";
            // 
            // UpdateGrowNums
            // 
            this.UpdateGrowNums.DataPropertyName = "UpdateGrowNums";
            this.UpdateGrowNums.HeaderText = "更新增量";
            this.UpdateGrowNums.Name = "UpdateGrowNums";
            // 
            // PredictThreadNums
            // 
            this.PredictThreadNums.DataPropertyName = "PredictThreadNums";
            this.PredictThreadNums.HeaderText = "预估线程";
            this.PredictThreadNums.Name = "PredictThreadNums";
            this.PredictThreadNums.ReadOnly = true;
            // 
            // IsStart
            // 
            this.IsStart.DataPropertyName = "IsStart";
            this.IsStart.HeaderText = "启动";
            this.IsStart.Name = "IsStart";
            this.IsStart.ReadOnly = true;
            // 
            // IocName
            // 
            this.IocName.DataPropertyName = "IocName";
            this.IocName.HeaderText = "IOC";
            this.IocName.Name = "IocName";
            this.IocName.ReadOnly = true;
            // 
            // LastUpdateTime
            // 
            this.LastUpdateTime.DataPropertyName = "LastUpdateTime";
            this.LastUpdateTime.HeaderText = "开始时间";
            this.LastUpdateTime.Name = "LastUpdateTime";
            this.LastUpdateTime.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 563);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grb);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "爬虫";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Task)).EndInit();
            this.grb.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_Task;
        private System.Windows.Forms.GroupBox grb;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox txt_log;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_isConsoleLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PageNums;
        private System.Windows.Forms.DataGridViewTextBoxColumn FictionNums;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nums;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateGrowNums;
        private System.Windows.Forms.DataGridViewTextBoxColumn PredictThreadNums;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn IocName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdateTime;
    }
}


namespace SFS_FV
{
    partial class ScanAddIP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._tbRangeEnd = new System.Windows.Forms.TextBox();
            this._tbRangeStart = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this._prgScanProgress = new NetPinger.ProgressBarEx();
            this._lvAliveHosts = new NetPinger.ListViewDB();
            this._colQuality = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colIPAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colAvgResponseTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colLosses = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colHostName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbLog = new System.Windows.Forms.ListBox();
            this.bntScan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPortIp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _tbRangeEnd
            // 
            this._tbRangeEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._tbRangeEnd.Location = new System.Drawing.Point(103, 5);
            this._tbRangeEnd.Name = "_tbRangeEnd";
            this._tbRangeEnd.Size = new System.Drawing.Size(66, 20);
            this._tbRangeEnd.TabIndex = 38;
            this._tbRangeEnd.Text = "10.20.7.255";
            // 
            // _tbRangeStart
            // 
            this._tbRangeStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._tbRangeStart.Location = new System.Drawing.Point(30, 5);
            this._tbRangeStart.Name = "_tbRangeStart";
            this._tbRangeStart.Size = new System.Drawing.Size(56, 20);
            this._tbRangeStart.TabIndex = 37;
            this._tbRangeStart.Text = "10.20.7.1";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(59, -93);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(130, 20);
            this.textBox1.TabIndex = 43;
            this.textBox1.Text = "10.20.7.255";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(-79, -93);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(130, 20);
            this.textBox2.TabIndex = 42;
            this.textBox2.Text = "10.20.7.1";
            // 
            // _prgScanProgress
            // 
            this._prgScanProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._prgScanProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._prgScanProgress.Location = new System.Drawing.Point(1, 32);
            this._prgScanProgress.Name = "_prgScanProgress";
            this._prgScanProgress.Size = new System.Drawing.Size(238, 35);
            this._prgScanProgress.TabIndex = 41;
            this._prgScanProgress.Text = "Scanner is not running!";
            this._prgScanProgress.TextColor = System.Drawing.Color.Navy;
            // 
            // _lvAliveHosts
            // 
            this._lvAliveHosts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lvAliveHosts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._colQuality,
            this._colIPAddress,
            this._colAvgResponseTime,
            this._colLosses,
            this._colHostName});
            this._lvAliveHosts.FullRowSelect = true;
            this._lvAliveHosts.GridLines = true;
            this._lvAliveHosts.Location = new System.Drawing.Point(2, 73);
            this._lvAliveHosts.MultiSelect = false;
            this._lvAliveHosts.Name = "_lvAliveHosts";
            this._lvAliveHosts.Size = new System.Drawing.Size(314, 293);
            this._lvAliveHosts.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this._lvAliveHosts.TabIndex = 39;
            this._lvAliveHosts.UseCompatibleStateImageBehavior = false;
            this._lvAliveHosts.View = System.Windows.Forms.View.Details;
            this._lvAliveHosts.SelectedIndexChanged += new System.EventHandler(this._lvAliveHosts_SelectedIndexChanged);
            // 
            // _colQuality
            // 
            this._colQuality.Text = "Q";
            this._colQuality.Width = 20;
            // 
            // _colIPAddress
            // 
            this._colIPAddress.Text = "IP Address";
            this._colIPAddress.Width = 92;
            // 
            // _colAvgResponseTime
            // 
            this._colAvgResponseTime.Text = "Avg. Resp. Time";
            this._colAvgResponseTime.Width = 91;
            // 
            // _colLosses
            // 
            this._colLosses.Text = "Losses";
            this._colLosses.Width = 56;
            // 
            // _colHostName
            // 
            this._colHostName.Text = "Host Name";
            this._colHostName.Width = 161;
            // 
            // lbLog
            // 
            this.lbLog.Location = new System.Drawing.Point(1, 372);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(315, 108);
            this.lbLog.TabIndex = 44;
            // 
            // bntScan
            // 
            this.bntScan.Enabled = false;
            this.bntScan.Location = new System.Drawing.Point(245, 4);
            this.bntScan.Name = "bntScan";
            this.bntScan.Size = new System.Drawing.Size(71, 63);
            this.bntScan.TabIndex = 45;
            this.bntScan.Text = "Scan IP";
            this.bntScan.UseVisualStyleBackColor = true;
            this.bntScan.Click += new System.EventHandler(this.bntScan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "To";
            // 
            // txtPortIp
            // 
            this.txtPortIp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPortIp.Location = new System.Drawing.Point(205, 4);
            this.txtPortIp.Name = "txtPortIp";
            this.txtPortIp.Size = new System.Drawing.Size(34, 20);
            this.txtPortIp.TabIndex = 48;
            this.txtPortIp.Text = "8500";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Port";
            // 
            // ScanAddIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 492);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPortIp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bntScan);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this._prgScanProgress);
            this.Controls.Add(this._lvAliveHosts);
            this.Controls.Add(this._tbRangeEnd);
            this.Controls.Add(this._tbRangeStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ScanAddIP";
            this.Text = "ScanAddIP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScanAddIP_FormClosing);
            this.Load += new System.EventHandler(this.ScanAddIP_Load_2);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _tbRangeEnd;
        private System.Windows.Forms.TextBox _tbRangeStart;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private NetPinger.ProgressBarEx _prgScanProgress;
     //   private System.Windows.Forms.ListBox _lbLog;
        private NetPinger.ListViewDB _lvAliveHosts;
        private System.Windows.Forms.ColumnHeader _colQuality;
        private System.Windows.Forms.ColumnHeader _colIPAddress;
        private System.Windows.Forms.ColumnHeader _colAvgResponseTime;
        private System.Windows.Forms.ColumnHeader _colLosses;
        private System.Windows.Forms.ColumnHeader _colHostName;
        private System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.Button bntScan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPortIp;
        private System.Windows.Forms.Label label3;
    }
}
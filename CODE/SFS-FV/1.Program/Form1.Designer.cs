namespace SFS_FV
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Variables");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Tool");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Chart");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Project: TMB", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.mouseRight = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNew = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClearMap = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSaves = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.variableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.globalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.chartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cycleTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.developerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dtEdit = new System.Windows.Forms.DataGridView();
            this.mouseLeft = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClear = new System.Windows.Forms.ToolStripMenuItem();
            this.cbTab = new System.Windows.Forms.ComboBox();
            this._colQuality = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colIPAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colAvgResponseTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colLosses = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colHostName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tmScanIp = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnOnline = new System.Windows.Forms.ToolStripButton();
            this.btnStart = new System.Windows.Forms.ToolStripButton();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtIPMC = new System.Windows.Forms.ToolStripTextBox();
            this.btnSacnIp = new System.Windows.Forms.ToolStripButton();
            this.btnNewDevice = new System.Windows.Forms.ToolStripButton();
            this.btnNewVariable = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGraphic = new System.Windows.Forms.ToolStripButton();
            this.btnCreateChart = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tmCancelConnect = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.tree = new System.Windows.Forms.TreeView();
            this.picMap = new System.Windows.Forms.PictureBox();
            this.mouseRight.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdit)).BeginInit();
            this.mouseLeft.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).BeginInit();
            this.SuspendLayout();
            // 
            // mouseRight
            // 
            this.mouseRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpen,
            this.btnNew,
            this.btnSave,
            this.btnClearMap});
            this.mouseRight.Name = "mouseRight";
            this.mouseRight.Size = new System.Drawing.Size(129, 92);
            // 
            // btnOpen
            // 
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(128, 22);
            this.btnOpen.Text = "Open File";
            // 
            // btnNew
            // 
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(128, 22);
            this.btnNew.Text = "New Map";
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(128, 22);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClearMap
            // 
            this.btnClearMap.Name = "btnClearMap";
            this.btnClearMap.Size = new System.Drawing.Size(128, 22);
            this.btnClearMap.Text = "Clear Map";
            this.btnClearMap.Click += new System.EventHandler(this.btnClearMap_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolToolStripMenuItem,
            this.developerToolStripMenuItem,
            this.programToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1370, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewFile,
            this.btnOpenFile,
            this.btnSaves,
            this.saveFileAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // btnNewFile
            // 
            this.btnNewFile.Image = ((System.Drawing.Image)(resources.GetObject("btnNewFile.Image")));
            this.btnNewFile.Name = "btnNewFile";
            this.btnNewFile.Size = new System.Drawing.Size(135, 22);
            this.btnNewFile.Text = "New File";
            this.btnNewFile.Click += new System.EventHandler(this.btnNewFile_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenFile.Image")));
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(135, 22);
            this.btnOpenFile.Text = "Open File";
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnSaves
            // 
            this.btnSaves.Image = ((System.Drawing.Image)(resources.GetObject("btnSaves.Image")));
            this.btnSaves.Name = "btnSaves";
            this.btnSaves.Size = new System.Drawing.Size(135, 22);
            this.btnSaves.Text = "Save File";
            this.btnSaves.Click += new System.EventHandler(this.btnSaves_Click);
            // 
            // saveFileAsToolStripMenuItem
            // 
            this.saveFileAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveFileAsToolStripMenuItem.Image")));
            this.saveFileAsToolStripMenuItem.Name = "saveFileAsToolStripMenuItem";
            this.saveFileAsToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.saveFileAsToolStripMenuItem.Text = "Save File As";
            // 
            // toolToolStripMenuItem
            // 
            this.toolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.variableToolStripMenuItem,
            this.graphicToolStripMenuItem,
            this.cycleTimeToolStripMenuItem});
            this.toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            this.toolToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.toolToolStripMenuItem.Text = "Tool";
            // 
            // variableToolStripMenuItem
            // 
            this.variableToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemsToolStripMenuItem,
            this.globalToolStripMenuItem,
            this.localToolStripMenuItem});
            this.variableToolStripMenuItem.Name = "variableToolStripMenuItem";
            this.variableToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.variableToolStripMenuItem.Text = "Variable";
            // 
            // systemsToolStripMenuItem
            // 
            this.systemsToolStripMenuItem.Name = "systemsToolStripMenuItem";
            this.systemsToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.systemsToolStripMenuItem.Text = "Systems";
            // 
            // globalToolStripMenuItem
            // 
            this.globalToolStripMenuItem.Name = "globalToolStripMenuItem";
            this.globalToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.globalToolStripMenuItem.Text = "Global";
            // 
            // localToolStripMenuItem
            // 
            this.localToolStripMenuItem.Name = "localToolStripMenuItem";
            this.localToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.localToolStripMenuItem.Text = "Local";
            // 
            // graphicToolStripMenuItem
            // 
            this.graphicToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolToolStripMenuItem1,
            this.chartToolStripMenuItem});
            this.graphicToolStripMenuItem.Name = "graphicToolStripMenuItem";
            this.graphicToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.graphicToolStripMenuItem.Text = "Graphic";
            // 
            // toolToolStripMenuItem1
            // 
            this.toolToolStripMenuItem1.Name = "toolToolStripMenuItem1";
            this.toolToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.toolToolStripMenuItem1.Text = "Tool";
            // 
            // chartToolStripMenuItem
            // 
            this.chartToolStripMenuItem.Name = "chartToolStripMenuItem";
            this.chartToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.chartToolStripMenuItem.Text = "Chart";
            // 
            // cycleTimeToolStripMenuItem
            // 
            this.cycleTimeToolStripMenuItem.Name = "cycleTimeToolStripMenuItem";
            this.cycleTimeToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.cycleTimeToolStripMenuItem.Text = "Cycle Time";
            // 
            // developerToolStripMenuItem
            // 
            this.developerToolStripMenuItem.Name = "developerToolStripMenuItem";
            this.developerToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.developerToolStripMenuItem.Text = "Developer";
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onlineToolStripMenuItem,
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.connectToolStripMenuItem1});
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.programToolStripMenuItem.Text = "Project";
            // 
            // onlineToolStripMenuItem
            // 
            this.onlineToolStripMenuItem.Name = "onlineToolStripMenuItem";
            this.onlineToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.onlineToolStripMenuItem.Text = "Online";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.startToolStripMenuItem.Text = "Start";
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            // 
            // connectToolStripMenuItem1
            // 
            this.connectToolStripMenuItem1.Name = "connectToolStripMenuItem1";
            this.connectToolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.connectToolStripMenuItem1.Text = "Connect";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dtEdit
            // 
            this.dtEdit.AllowUserToResizeRows = false;
            this.dtEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtEdit.ColumnHeadersHeight = 25;
            this.dtEdit.GridColor = System.Drawing.Color.DarkKhaki;
            this.dtEdit.Location = new System.Drawing.Point(237, 79);
            this.dtEdit.Name = "dtEdit";
            this.dtEdit.RowHeadersVisible = false;
            this.dtEdit.RowHeadersWidth = 20;
            this.dtEdit.Size = new System.Drawing.Size(432, 671);
            this.dtEdit.TabIndex = 25;
            this.dtEdit.DataSourceChanged += new System.EventHandler(this.dtEdit_DataSourceChanged);
            this.dtEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtEdit_KeyDown);
            // 
            // mouseLeft
            // 
            this.mouseLeft.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInsert,
            this.btnGo,
            this.btnDelete,
            this.btnUpdate,
            this.btnClear});
            this.mouseLeft.Name = "mouseLeft";
            this.mouseLeft.Size = new System.Drawing.Size(129, 114);
            // 
            // btnInsert
            // 
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(128, 22);
            this.btnInsert.Text = "Insert";
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnGo
            // 
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(128, 22);
            this.btnGo.Text = "GO";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(128, 22);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(128, 22);
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(128, 22);
            this.btnClear.Text = "Clear Map";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cbTab
            // 
            this.cbTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTab.FormattingEnabled = true;
            this.cbTab.Location = new System.Drawing.Point(220, 52);
            this.cbTab.Name = "cbTab";
            this.cbTab.Size = new System.Drawing.Size(449, 21);
            this.cbTab.TabIndex = 30;
            this.cbTab.Text = "TAB";
            this.cbTab.SelectedIndexChanged += new System.EventHandler(this.cbTab_SelectedIndexChanged);
            // 
            // tmScanIp
            // 
            this.tmScanIp.Enabled = true;
            this.tmScanIp.Interval = 1000;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 728);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1370, 22);
            this.statusStrip1.TabIndex = 31;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOnline,
            this.btnStart,
            this.btnStop,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.txtIPMC,
            this.btnSacnIp,
            this.btnNewDevice,
            this.btnNewVariable,
            this.toolStripSeparator3,
            this.btnGraphic,
            this.btnCreateChart,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1370, 25);
            this.toolStrip1.TabIndex = 32;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnOnline
            // 
            this.btnOnline.Image = ((System.Drawing.Image)(resources.GetObject("btnOnline.Image")));
            this.btnOnline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOnline.Name = "btnOnline";
            this.btnOnline.Size = new System.Drawing.Size(62, 22);
            this.btnOnline.Text = "Online";
            this.btnOnline.Click += new System.EventHandler(this.btnOnline_Click);
            // 
            // btnStart
            // 
            this.btnStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStart.Enabled = false;
            this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
            this.btnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(23, 22);
            this.btnStart.Text = "Start Read";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStop.Enabled = false;
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(23, 22);
            this.btnStop.Text = "Stop";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(49, 22);
            this.toolStripLabel1.Text = "IP of PC";
            // 
            // txtIPMC
            // 
            this.txtIPMC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIPMC.Name = "txtIPMC";
            this.txtIPMC.Size = new System.Drawing.Size(100, 25);
            // 
            // btnSacnIp
            // 
            this.btnSacnIp.Image = ((System.Drawing.Image)(resources.GetObject("btnSacnIp.Image")));
            this.btnSacnIp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSacnIp.Name = "btnSacnIp";
            this.btnSacnIp.Size = new System.Drawing.Size(65, 22);
            this.btnSacnIp.Text = "Scan IP";
            this.btnSacnIp.Click += new System.EventHandler(this.btnSacnIp_Click);
            // 
            // btnNewDevice
            // 
            this.btnNewDevice.Image = ((System.Drawing.Image)(resources.GetObject("btnNewDevice.Image")));
            this.btnNewDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewDevice.Name = "btnNewDevice";
            this.btnNewDevice.Size = new System.Drawing.Size(89, 22);
            this.btnNewDevice.Text = "New Device";
            this.btnNewDevice.Click += new System.EventHandler(this.btnNewDevice_Click);
            // 
            // btnNewVariable
            // 
            this.btnNewVariable.Image = ((System.Drawing.Image)(resources.GetObject("btnNewVariable.Image")));
            this.btnNewVariable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewVariable.Name = "btnNewVariable";
            this.btnNewVariable.Size = new System.Drawing.Size(96, 22);
            this.btnNewVariable.Text = "New Variable";
            this.btnNewVariable.Click += new System.EventHandler(this.btnNewVariable_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.BackColor = System.Drawing.Color.Lime;
            this.toolStripSeparator3.ForeColor = System.Drawing.Color.Coral;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnGraphic
            // 
            this.btnGraphic.Image = ((System.Drawing.Image)(resources.GetObject("btnGraphic.Image")));
            this.btnGraphic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGraphic.Name = "btnGraphic";
            this.btnGraphic.Size = new System.Drawing.Size(68, 22);
            this.btnGraphic.Text = "Graphic";
            this.btnGraphic.Click += new System.EventHandler(this.btnGraphic_Click);
            // 
            // btnCreateChart
            // 
            this.btnCreateChart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCreateChart.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateChart.Image")));
            this.btnCreateChart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateChart.Name = "btnCreateChart";
            this.btnCreateChart.Size = new System.Drawing.Size(77, 22);
            this.btnCreateChart.Text = "Create Chart";
            this.btnCreateChart.Click += new System.EventHandler(this.btnCreateTool_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tmCancelConnect
            // 
            this.tmCancelConnect.Interval = 1000;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // tree
            // 
            this.tree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tree.Location = new System.Drawing.Point(0, 52);
            this.tree.Name = "tree";
            treeNode1.Name = "Variables";
            treeNode1.Text = "Variables";
            treeNode2.Name = "Tool";
            treeNode2.Text = "Tool";
            treeNode3.Name = "Chart";
            treeNode3.Text = "Chart";
            treeNode4.Name = "project";
            treeNode4.Text = "Project: TMB";
            this.tree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.tree.Size = new System.Drawing.Size(231, 673);
            this.tree.TabIndex = 33;
            // 
            // picMap
            // 
            this.picMap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picMap.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.picMap.Location = new System.Drawing.Point(675, 52);
            this.picMap.Name = "picMap";
            this.picMap.Size = new System.Drawing.Size(695, 673);
            this.picMap.TabIndex = 7;
            this.picMap.TabStop = false;
            this.picMap.Paint += new System.Windows.Forms.PaintEventHandler(this.picMap_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 750);
            this.ContextMenuStrip = this.mouseLeft;
            this.Controls.Add(this.tree);
            this.Controls.Add(this.cbTab);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dtEdit);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.picMap);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "SFS v2.7";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mouseRight.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdit)).EndInit();
            this.mouseLeft.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip mouseRight;
        private System.Windows.Forms.ToolStripMenuItem btnOpen;
        private System.Windows.Forms.ToolStripMenuItem btnNew;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnNewFile;
        private System.Windows.Forms.ToolStripMenuItem btnOpenFile;
        private System.Windows.Forms.ToolStripMenuItem btnSaves;
        private System.Windows.Forms.ToolStripMenuItem saveFileAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnClearMap;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip mouseLeft;
        private System.Windows.Forms.ToolStripMenuItem btnInsert;
        private System.Windows.Forms.ToolStripMenuItem btnGo;
        private System.Windows.Forms.ToolStripMenuItem btnDelete;
        private System.Windows.Forms.ToolStripMenuItem btnUpdate;
        private System.Windows.Forms.ToolStripMenuItem btnClear;
        private System.Windows.Forms.ComboBox cbTab;
       // private NetPinger.ListViewDB _lvAliveHosts;
        private System.Windows.Forms.ColumnHeader _colQuality;
        private System.Windows.Forms.ColumnHeader _colIPAddress;
        private System.Windows.Forms.ColumnHeader _colAvgResponseTime;
        private System.Windows.Forms.ColumnHeader _colLosses;
        private System.Windows.Forms.ColumnHeader _colHostName;
        private System.Windows.Forms.Timer tmScanIp;
        private System.Windows.Forms.StatusStrip statusStrip1;
        internal System.Windows.Forms.PictureBox picMap;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSacnIp;
        private System.Windows.Forms.ToolStripTextBox txtIPMC;
        public System.Windows.Forms.DataGridView dtEdit;
        public System.Windows.Forms.ToolStripButton btnStart;
        public System.Windows.Forms.ToolStripButton btnNewDevice;
        public System.Windows.Forms.ToolStripButton btnNewVariable;
        public System.Windows.Forms.ToolStripButton btnStop;
        public System.Windows.Forms.ToolStripButton btnOnline;
        private System.Windows.Forms.ToolStripButton btnGraphic;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnCreateChart;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripMenuItem toolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem variableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem globalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem chartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cycleTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem developerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem1;
        private System.Windows.Forms.Timer tmCancelConnect;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TreeView tree;
    }
}


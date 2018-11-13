namespace SFS_FV
{
    partial class NewVariable
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
            this.cbTypeBit = new System.Windows.Forms.ComboBox();
            this.txtVal = new System.Windows.Forms.TextBox();
            this.btnAddVari = new System.Windows.Forms.Button();
            this.txtbit = new System.Windows.Forms.TextBox();
            this.cbArea = new System.Windows.Forms.ComboBox();
            this.cbDevice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numScan_change_V = new System.Windows.Forms.NumericUpDown();
            this.txtNameVari = new System.Windows.Forms.ComboBox();
            this.listNG = new System.Windows.Forms.ListBox();
            this.listOK = new System.Windows.Forms.ListBox();
            this.btnNGplus = new System.Windows.Forms.Button();
            this.btnOKplus = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNameNew = new System.Windows.Forms.TextBox();
            this.btnOKsub = new System.Windows.Forms.Button();
            this.btnNGsub = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numScan_change_V)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbTypeBit
            // 
            this.cbTypeBit.FormattingEnabled = true;
            this.cbTypeBit.Items.AddRange(new object[] {
            "KEYENCE",
            "MISUBISHI",
            "OMRON"});
            this.cbTypeBit.Location = new System.Drawing.Point(98, 216);
            this.cbTypeBit.Name = "cbTypeBit";
            this.cbTypeBit.Size = new System.Drawing.Size(165, 21);
            this.cbTypeBit.TabIndex = 38;
            // 
            // txtVal
            // 
            this.txtVal.Location = new System.Drawing.Point(98, 175);
            this.txtVal.Name = "txtVal";
            this.txtVal.Size = new System.Drawing.Size(164, 20);
            this.txtVal.TabIndex = 37;
            this.txtVal.Text = "-1";
            // 
            // btnAddVari
            // 
            this.btnAddVari.Location = new System.Drawing.Point(23, 315);
            this.btnAddVari.Name = "btnAddVari";
            this.btnAddVari.Size = new System.Drawing.Size(272, 34);
            this.btnAddVari.TabIndex = 34;
            this.btnAddVari.Text = "Thêm biến";
            this.btnAddVari.UseVisualStyleBackColor = true;
            this.btnAddVari.Click += new System.EventHandler(this.btnAddVari_Click);
            // 
            // txtbit
            // 
            this.txtbit.Location = new System.Drawing.Point(98, 132);
            this.txtbit.Name = "txtbit";
            this.txtbit.Size = new System.Drawing.Size(164, 20);
            this.txtbit.TabIndex = 32;
            this.txtbit.Text = "10012";
            // 
            // cbArea
            // 
            this.cbArea.FormattingEnabled = true;
            this.cbArea.Items.AddRange(new object[] {
            ""});
            this.cbArea.Location = new System.Drawing.Point(98, 93);
            this.cbArea.Name = "cbArea";
            this.cbArea.Size = new System.Drawing.Size(165, 21);
            this.cbArea.TabIndex = 31;
            this.cbArea.SelectedIndexChanged += new System.EventHandler(this.cbArea_SelectedIndexChanged);
            // 
            // cbDevice
            // 
            this.cbDevice.FormattingEnabled = true;
            this.cbDevice.Location = new System.Drawing.Point(98, 50);
            this.cbDevice.Name = "cbDevice";
            this.cbDevice.Size = new System.Drawing.Size(165, 21);
            this.cbDevice.TabIndex = 30;
            this.cbDevice.SelectedIndexChanged += new System.EventHandler(this.cbDevice_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Tên Thiết bị";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Vùng nhớ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Bit thứ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "Giá trị bit defaut";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = " Biến";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Kiểu biến";
            // 
            // numScan_change_V
            // 
            this.numScan_change_V.Location = new System.Drawing.Point(152, 170);
            this.numScan_change_V.Name = "numScan_change_V";
            this.numScan_change_V.Size = new System.Drawing.Size(102, 20);
            this.numScan_change_V.TabIndex = 47;
            this.numScan_change_V.Value = new decimal(new int[] {
            72,
            0,
            0,
            0});
            // 
            // txtNameVari
            // 
            this.txtNameVari.FormattingEnabled = true;
            this.txtNameVari.Location = new System.Drawing.Point(98, 244);
            this.txtNameVari.Name = "txtNameVari";
            this.txtNameVari.Size = new System.Drawing.Size(164, 21);
            this.txtNameVari.TabIndex = 45;
            this.txtNameVari.SelectedIndexChanged += new System.EventHandler(this.txtNameVari_SelectedIndexChanged);
            // 
            // listNG
            // 
            this.listNG.FormattingEnabled = true;
            this.listNG.Location = new System.Drawing.Point(99, 15);
            this.listNG.Name = "listNG";
            this.listNG.Size = new System.Drawing.Size(107, 56);
            this.listNG.TabIndex = 49;
            // 
            // listOK
            // 
            this.listOK.FormattingEnabled = true;
            this.listOK.Location = new System.Drawing.Point(99, 77);
            this.listOK.Name = "listOK";
            this.listOK.Size = new System.Drawing.Size(107, 56);
            this.listOK.TabIndex = 51;
            // 
            // btnNGplus
            // 
            this.btnNGplus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNGplus.Location = new System.Drawing.Point(224, 15);
            this.btnNGplus.Name = "btnNGplus";
            this.btnNGplus.Size = new System.Drawing.Size(30, 30);
            this.btnNGplus.TabIndex = 52;
            this.btnNGplus.Text = "+";
            this.btnNGplus.UseVisualStyleBackColor = true;
            this.btnNGplus.Click += new System.EventHandler(this.btnNGplus_Click);
            // 
            // btnOKplus
            // 
            this.btnOKplus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOKplus.Location = new System.Drawing.Point(224, 87);
            this.btnOKplus.Name = "btnOKplus";
            this.btnOKplus.Size = new System.Drawing.Size(30, 29);
            this.btnOKplus.TabIndex = 53;
            this.btnOKplus.Text = "x";
            this.btnOKplus.UseVisualStyleBackColor = true;
            this.btnOKplus.Click += new System.EventHandler(this.btnOKplus_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.listNG);
            this.groupBox1.Controls.Add(this.listOK);
            this.groupBox1.Controls.Add(this.btnNGplus);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.btnNGsub);
            this.groupBox1.Controls.Add(this.txtNameNew);
            this.groupBox1.Controls.Add(this.btnOKplus);
            this.groupBox1.Controls.Add(this.btnOKsub);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.numScan_change_V);
            this.groupBox1.Location = new System.Drawing.Point(307, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 246);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 222);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 58;
            this.label11.Text = "Tên Biến mới";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 57;
            this.label9.Text = "Biến NG";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 56;
            this.label8.Text = "Biến OK";
            // 
            // txtNameNew
            // 
            this.txtNameNew.Location = new System.Drawing.Point(99, 212);
            this.txtNameNew.Name = "txtNameNew";
            this.txtNameNew.Size = new System.Drawing.Size(164, 20);
            this.txtNameNew.TabIndex = 57;
            this.txtNameNew.TextChanged += new System.EventHandler(this.txtNameNew_TextChanged);
            // 
            // btnOKsub
            // 
            this.btnOKsub.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOKsub.Location = new System.Drawing.Point(224, 122);
            this.btnOKsub.Name = "btnOKsub";
            this.btnOKsub.Size = new System.Drawing.Size(30, 27);
            this.btnOKsub.TabIndex = 59;
            this.btnOKsub.Text = ":";
            this.btnOKsub.UseVisualStyleBackColor = true;
            this.btnOKsub.Click += new System.EventHandler(this.btnOKsub_Click);
            // 
            // btnNGsub
            // 
            this.btnNGsub.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNGsub.Location = new System.Drawing.Point(224, 51);
            this.btnNGsub.Name = "btnNGsub";
            this.btnNGsub.Size = new System.Drawing.Size(30, 30);
            this.btnNGsub.TabIndex = 58;
            this.btnNGsub.Text = "-";
            this.btnNGsub.UseVisualStyleBackColor = true;
            this.btnNGsub.Click += new System.EventHandler(this.btnNGsub_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 55;
            this.label7.Text = "Time Update";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 55;
            this.label10.Text = "Kiểu Biến";
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(98, 10);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(165, 21);
            this.cbType.TabIndex = 56;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(289, 177);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(12, 13);
            this.label12.TabIndex = 62;
            this.label12.Text = "s";
            // 
            // NewVariable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 507);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtNameVari);
            this.Controls.Add(this.btnAddVari);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbTypeBit);
            this.Controls.Add(this.txtVal);
            this.Controls.Add(this.txtbit);
            this.Controls.Add(this.cbArea);
            this.Controls.Add(this.cbDevice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "NewVariable";
            this.Text = "NewVariable";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewVariable_FormClosing);
            this.Load += new System.EventHandler(this.NewVariable_Load);
            this.Shown += new System.EventHandler(this.NewVariable_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numScan_change_V)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTypeBit;
        private System.Windows.Forms.TextBox txtVal;
        private System.Windows.Forms.Button btnAddVari;
        private System.Windows.Forms.TextBox txtbit;
        private System.Windows.Forms.ComboBox cbArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox cbDevice;
        private System.Windows.Forms.NumericUpDown numScan_change_V;
        public System.Windows.Forms.ComboBox txtNameVari;
        private System.Windows.Forms.ListBox listNG;
        private System.Windows.Forms.ListBox listOK;
        private System.Windows.Forms.Button btnNGplus;
        private System.Windows.Forms.Button btnOKplus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.TextBox txtNameNew;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnOKsub;
        private System.Windows.Forms.Button btnNGsub;
        private System.Windows.Forms.Label label12;
    }
}
namespace SFS_FV
{
    partial class NewDevice
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
            this.cbType = new System.Windows.Forms.ComboBox();
            this.cbPara = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbVia = new System.Windows.Forms.ComboBox();
            this.cbModel = new System.Windows.Forms.ComboBox();
            this.cbCo = new System.Windows.Forms.ComboBox();
            this.btnSeach = new System.Windows.Forms.Button();
            this.btnPicPLC = new System.Windows.Forms.Button();
            this.btnPicVia = new System.Windows.Forms.Button();
            this.btnPicModel = new System.Windows.Forms.Button();
            this.picReview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picReview)).BeginInit();
            this.SuspendLayout();
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(10, 12);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(136, 21);
            this.cbType.TabIndex = 38;
            this.cbType.Text = "Loại Thiết bị";
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // cbPara
            // 
            this.cbPara.FormattingEnabled = true;
            this.cbPara.Location = new System.Drawing.Point(10, 124);
            this.cbPara.Name = "cbPara";
            this.cbPara.Size = new System.Drawing.Size(105, 21);
            this.cbPara.TabIndex = 37;
            this.cbPara.Text = "Thông số k.nối";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(9, 151);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(137, 20);
            this.txtName.TabIndex = 31;
            this.txtName.Text = "       Tên Thiêt bị";
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(11, 177);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(305, 23);
            this.btnAdd.TabIndex = 30;
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cbVia
            // 
            this.cbVia.FormattingEnabled = true;
            this.cbVia.Location = new System.Drawing.Point(10, 97);
            this.cbVia.Name = "cbVia";
            this.cbVia.Size = new System.Drawing.Size(105, 21);
            this.cbVia.TabIndex = 29;
            this.cbVia.Text = "Kiểu kết nối";
            this.cbVia.SelectedIndexChanged += new System.EventHandler(this.cbVia_SelectedIndexChanged);
            // 
            // cbModel
            // 
            this.cbModel.FormattingEnabled = true;
            this.cbModel.Location = new System.Drawing.Point(10, 70);
            this.cbModel.Name = "cbModel";
            this.cbModel.Size = new System.Drawing.Size(105, 21);
            this.cbModel.TabIndex = 28;
            this.cbModel.Text = "Model";
            this.cbModel.SelectedIndexChanged += new System.EventHandler(this.cbModel_SelectedIndexChanged);
            // 
            // cbCo
            // 
            this.cbCo.FormattingEnabled = true;
            this.cbCo.Location = new System.Drawing.Point(9, 43);
            this.cbCo.Name = "cbCo";
            this.cbCo.Size = new System.Drawing.Size(106, 21);
            this.cbCo.TabIndex = 27;
            this.cbCo.Text = "Hãng Sản xuất";
            this.cbCo.SelectedIndexChanged += new System.EventHandler(this.cbCo_SelectedIndexChanged);
            // 
            // btnSeach
            // 
            this.btnSeach.BackgroundImage = global::SFS_FV.Properties.Resources.radar;
            this.btnSeach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSeach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeach.Location = new System.Drawing.Point(122, 122);
            this.btnSeach.Name = "btnSeach";
            this.btnSeach.Size = new System.Drawing.Size(24, 23);
            this.btnSeach.TabIndex = 36;
            this.btnSeach.UseVisualStyleBackColor = true;
            this.btnSeach.Click += new System.EventHandler(this.btnSeach_Click);
            // 
            // btnPicPLC
            // 
            this.btnPicPLC.BackgroundImage = global::SFS_FV.Properties.Resources.PICTURE;
            this.btnPicPLC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPicPLC.Location = new System.Drawing.Point(122, 40);
            this.btnPicPLC.Name = "btnPicPLC";
            this.btnPicPLC.Size = new System.Drawing.Size(25, 25);
            this.btnPicPLC.TabIndex = 35;
            this.btnPicPLC.UseVisualStyleBackColor = true;
            this.btnPicPLC.Click += new System.EventHandler(this.btnPicPLC_Click);
            // 
            // btnPicVia
            // 
            this.btnPicVia.BackgroundImage = global::SFS_FV.Properties.Resources.PICTURE;
            this.btnPicVia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPicVia.Location = new System.Drawing.Point(122, 94);
            this.btnPicVia.Name = "btnPicVia";
            this.btnPicVia.Size = new System.Drawing.Size(25, 25);
            this.btnPicVia.TabIndex = 34;
            this.btnPicVia.UseVisualStyleBackColor = true;
            this.btnPicVia.Click += new System.EventHandler(this.btnPicVia_Click);
            // 
            // btnPicModel
            // 
            this.btnPicModel.BackgroundImage = global::SFS_FV.Properties.Resources.PICTURE;
            this.btnPicModel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPicModel.Location = new System.Drawing.Point(122, 67);
            this.btnPicModel.Name = "btnPicModel";
            this.btnPicModel.Size = new System.Drawing.Size(25, 25);
            this.btnPicModel.TabIndex = 33;
            this.btnPicModel.UseVisualStyleBackColor = true;
            this.btnPicModel.Click += new System.EventHandler(this.btnPicModel_Click);
            // 
            // picReview
            // 
            this.picReview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.picReview.Location = new System.Drawing.Point(166, 12);
            this.picReview.Name = "picReview";
            this.picReview.Size = new System.Drawing.Size(150, 150);
            this.picReview.TabIndex = 32;
            this.picReview.TabStop = false;
            this.picReview.Paint += new System.Windows.Forms.PaintEventHandler(this.picReview_Paint);
            // 
            // NewDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 216);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.cbPara);
            this.Controls.Add(this.btnSeach);
            this.Controls.Add(this.btnPicPLC);
            this.Controls.Add(this.btnPicVia);
            this.Controls.Add(this.btnPicModel);
            this.Controls.Add(this.picReview);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cbVia);
            this.Controls.Add(this.cbModel);
            this.Controls.Add(this.cbCo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewDevice";
            this.Text = "NewDevice";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewDevice_FormClosing);
            this.Load += new System.EventHandler(this.NewDevice_Load);
            this.Shown += new System.EventHandler(this.NewDevice_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.picReview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.ComboBox cbPara;
        private System.Windows.Forms.Button btnSeach;
        private System.Windows.Forms.Button btnPicPLC;
        private System.Windows.Forms.Button btnPicVia;
        private System.Windows.Forms.Button btnPicModel;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cbVia;
        private System.Windows.Forms.ComboBox cbModel;
        private System.Windows.Forms.ComboBox cbCo;
        public System.Windows.Forms.PictureBox picReview;
    }
}
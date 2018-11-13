namespace SFS_FV
{
    partial class Error
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
            this.txtError = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pError = new System.Windows.Forms.Panel();
            this.picError = new System.Windows.Forms.PictureBox();
            this.tmAutosize = new System.Windows.Forms.Timer(this.components);
            this.pError.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).BeginInit();
            this.SuspendLayout();
            // 
            // txtError
            // 
            this.txtError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtError.ForeColor = System.Drawing.Color.Brown;
            this.txtError.Location = new System.Drawing.Point(4, 520);
            this.txtError.Multiline = true;
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(816, 48);
            this.txtError.TabIndex = 1;
            this.txtError.Text = "ERROR 0x00";
            this.txtError.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Cornsilk;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(826, 520);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 48);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pError
            // 
            this.pError.BackColor = System.Drawing.Color.LightGray;
            this.pError.Controls.Add(this.txtError);
            this.pError.Controls.Add(this.button1);
            this.pError.Controls.Add(this.picError);
            this.pError.Location = new System.Drawing.Point(2, 2);
            this.pError.Name = "pError";
            this.pError.Size = new System.Drawing.Size(934, 571);
            this.pError.TabIndex = 3;
            // 
            // picError
            // 
            this.picError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picError.BackColor = System.Drawing.Color.White;
            this.picError.Location = new System.Drawing.Point(3, 3);
            this.picError.Name = "picError";
            this.picError.Size = new System.Drawing.Size(927, 510);
            this.picError.TabIndex = 0;
            this.picError.TabStop = false;
            // 
            // tmAutosize
            // 
            this.tmAutosize.Enabled = true;
            this.tmAutosize.Interval = 200;
            this.tmAutosize.Tick += new System.EventHandler(this.tmAutosize_Tick);
            // 
            // Error
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Crimson;
            this.ClientSize = new System.Drawing.Size(936, 574);
            this.Controls.Add(this.pError);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Error";
            this.Text = "Error";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Error_FormClosing);
            this.Load += new System.EventHandler(this.Error_Load);
            this.pError.ResumeLayout(false);
            this.pError.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox picError;
        private System.Windows.Forms.Panel pError;
        private System.Windows.Forms.Timer tmAutosize;
    }
}
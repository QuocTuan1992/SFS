using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trestan;

namespace SFS_FV
{
    public partial class Error : Form
    {
        public Error()
        {
            InitializeComponent();
            TCResize resizeNote = new TCResize(this.pError);
        }

        private void Error_Load(object sender, EventArgs e)
        {
            this.Location = new Point(G.wScreen / 2 - this.Width / 2, G.hScreen / 2 - this.Height / 2);
            picError.SizeMode = PictureBoxSizeMode.StretchImage;
            picError.Image = G.imgError;
            txtError.Text = G.sError;
        }
        bool blError = false;
        private void tmAutosize_Tick(object sender, EventArgs e)
        {
            if(blError==false)
            {
                this.BackColor = Color.White;
            }
            else
            {
                this.BackColor = Color.Red;
            }
            this.Location = new Point(G.wScreen / 2 - this.Width / 2, G.hScreen / 2 - this.Height / 2);
            blError = !blError;
            this.Size = pError.Size;
            this.Width +=4;
            this.Height += 4;
        }
        Main Main;
        private void button1_Click(object sender, EventArgs e)
        {
            Main = new Main();
          //  Graphic.Close();
            this.Close();
            Main.Show();
        }
      //  Graphic Graphic;
        private void Error_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;
        }
    }
}

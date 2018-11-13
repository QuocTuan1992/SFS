using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using SFS_FV.SQL;

namespace SFS_FV
{
    public partial class Browser : Form
    {
        Form1 Form1;
        public Browser(Form1 Form1)
        {
            InitializeComponent();
           
            this.Form1 = Form1;
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();

            folderDlg.ShowNewFolderButton = true;

            // Show the FolderBrowserDialog.

            DialogResult result = folderDlg.ShowDialog();

            if (result == DialogResult.OK)

            {

                txtPath.Text = folderDlg.SelectedPath;

                Environment.SpecialFolder root = folderDlg.RootFolder;

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      
        // string con = "Data source =Data.sqlite;Version=3;New=False;Compress=True;SetPassword=12345678";
        SQLITE SQLITE=new SQLITE();
        private void btnCreateSFS_Click(object sender, EventArgs e)
        {
           
          
           // MessageBox.Show("Bạn đã tạo thành công dự án" + txtName.Text + " tại : " + Environment.NewLine + "Đường dẫn : " + txtPath.Text);

          
              DialogResult dialogResult = MessageBox.Show("Bạn muốn giữ nguyên DỮ LIỆU cũ không" , "Project mới", MessageBoxButtons.YesNo);
              if (dialogResult == DialogResult.No)
              {
                  G.sourceSQL = G.VariableSQL;
                  SQLITE.DeleteAll("DEVICE");
                  SQLITE.DeleteAll("CycleTime");
                  SQLITE.DeleteAll("Global");
                  SQLITE.DeleteAll("LostTime");
                  SQLITE.DeleteAll("Yield");
                  G.sourceSQL = G.ToolSQL;
                  SQLITE.DeleteAll("Quantity");
                  SQLITE.DeleteAll("TOOL");
                  SQLITE.DeleteAll("Time");
                  G.sourceSQL = G.ChartSQL;
                  SQLITE.DeleteAll("CHART");
              }
            //INSERT INTO INFOR VALUES ('0','12/09/2018','EMTY','');"; //gancau lech cmd
                 G.sourceSQL=G.defautSQL;
              if (!SQLITE.CHECK("*", "INFOR", "NMAE='" + txtName.Text.Trim() + "'"))
              {
                  Dictionary<string, string> dic = new Dictionary<string, string>();
                  dic.Add("SELECTS","0");
                  SQLITE.Update("INFOR", dic, "", G.defautSQL);
                  System.IO.Directory.CreateDirectory(txtPath.Text + "\\" + txtName.Text + "\\");
                  G.pathSQL = txtPath.Text + "\\" + txtName.Text;
                  List<string> list = new List<string>();
                  list.Add( DateTime.Now.ToString("dd/MM/yyyy"));
                  list.Add( txtName.Text.Trim());
                  list.Add(G.pathSQL);
                  list.Add("1");
                  SQLITE.Insert("INFOR", list);
                  this.Close();
                  Form1 = new Form1();
                  Form1.btnNewDevice.Enabled = true;
                  Form1.Text = "Program :" + txtName.Text;
                  Form1.Show();
                  this.Hide();
              }
            else
              {
                  MessageBox.Show("VUI LÒNG ĐẶT TÊN KHÁC ! ");
              }
        }

        private void Browser_Load(object sender, EventArgs e)
        {
            this.Location = G.localMain;
        }
    }
}

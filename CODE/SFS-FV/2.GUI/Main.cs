using Microsoft.VisualBasic.Devices;
using Microsoft.VisualBasic.FileIO;
using SFS_FV.SQL;
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
    public partial class Main : Form
    {
        Form1 Form1;
        public Main()
        {
            InitializeComponent();
           
            TCResize resizeMan = new TCResize(this.panel1);
            cbProgram.Items.Add("New Program");
            cbProgram.SelectedIndex = 0;
            cbMod.SelectedIndex = 0;
          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    
    bool isFirst4;
    bool toBlock4;
    Point prevLeftClick4;
    private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (isFirst4 == true)
                {
                    prevLeftClick4 = new Point(e.X, e.Y);
                    isFirst4 = false;
                }
                else
                {
                    if (toBlock4 == false)
                        this.Location = new Point(this.Location.X + e.X - prevLeftClick4.X, this.Location.Y + e.Y - prevLeftClick4.Y);

                    prevLeftClick4 = new Point(e.X, e.Y);
                    toBlock4 = !toBlock4;
                }
            }
            else
                isFirst4 = true;
        
    }
        Graphic Graphic = new Graphic();
       
        Browser Browser ;
        LoadSQL LoadSQL = new LoadSQL();
        private void btnGo_Click(object sender, EventArgs e)
        {
            G.localMain = this.Location;
            Form1 = new Form1();
            if (cbMod.SelectedIndex == 1)
            {
                if (cbProgram.SelectedIndex == cbProgram.Items.Count - 1)
                {
                    Browser = new Browser(this.Form1);
                    Browser.ShowDialog();
                    
                }
                else
                {
                    try
                    {
                        string[] files = System.IO.Directory.GetFiles(G.pathSQL+ "\\DATA", " *.sfs");
                    }
                    catch(Exception)
                    {
                X:        DialogResult dialogResult1 = MessageBox.Show("Dự án :" + G.editTile + Environment.NewLine + "Không tồn tại với đường link :" + G.pathSQL + Environment.NewLine
                     + "Bạn muốn thay đổi đường dẫn khác ?", "Editor", MessageBoxButtons.YesNo);
                        if (dialogResult1 == DialogResult.Yes)
                        {
                            FolderBrowserDialog OpenPJ = new FolderBrowserDialog();

                            OpenPJ.ShowNewFolderButton = true;

                            DialogResult result = OpenPJ.ShowDialog();

                            if (result == DialogResult.OK)
                            {
                                G.pathSQL = OpenPJ.SelectedPath;
                                try
                                {
                                    string[] files = System.IO.Directory.GetFiles(G.pathSQL+"\\DATA.sfs");
                                }
                                catch (Exception)
                                {
                                    goto X;
                                }
                                    Dictionary<string, string> dic = new Dictionary<string, string>();
                                dic.Add("PATH", G.pathSQL);
                                SQLITE.Update("INFOR", dic, "NAME='" + G.editTile + "'", G.defautSQL);
                               
                            }
                    
                        Computer comp = new Computer();

                        DialogResult dialogResult = MessageBox.Show("Bạn muốn Sửa chương trình", "Editor", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            try
                            {
                                // System.IO.File.Delete("SQL\\Data.sqlite");
                                System.IO.File.Delete("SQL\\TOOL.sfs");
                                System.IO.File.Delete("SQL\\CHART.sfs");
                                 System.IO.File.Delete("SQL\\DATA.sfs");              
                                System.IO.File.Delete("SQL\\Variables.sfs");
                            }
                            catch (Exception)
                            {

                            }
                            comp.FileSystem.CopyFile(G.pathSQL + "\\DATA.sfs", "SQL\\DATA.sfs", UIOption.AllDialogs, UICancelOption.DoNothing);
                            comp.FileSystem.CopyFile(G.pathSQL + "\\TOOL.sfs", "SQL\\TOOL.sfs", UIOption.AllDialogs, UICancelOption.DoNothing);
                            comp.FileSystem.CopyFile(G.pathSQL + "\\CHART.sfs", "SQL\\CHART.sfs", UIOption.AllDialogs, UICancelOption.DoNothing);
                            comp.FileSystem.CopyFile(G.pathSQL + "\\Variables.sfs", "SQL\\Variables.sfs", UIOption.AllDialogs, UICancelOption.DoNothing);

                            Form1.Show();

                        }

                        }
                    }
                }
            }
            else
            {
                LoadSQL = new LoadSQL();
                G.Shift = cbShift.SelectedIndex ;
                Graphic.ShowDialog();
            }
           
           // this.Hide();
        }
        SQLITE SQLITE=new SQLITE();
        List<string> listPath, listPro;
        private void Main_Load(object sender, EventArgs e)
        {
           // G.sourceSQL = G.defautSQL;
           // SQLITE.DeleteAll("INFOR");
            lbDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cbShift.SelectedIndex = 0;
            G.wScreen = Screen.PrimaryScreen.Bounds.Width;
            G.hScreen = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(G.wScreen / 2 - this.Width / 2, G.hScreen / 2 - this.Height / 2);
           listPro = new List<string>();
            G.sourceSQL = G.defautSQL;
            DataTable dt=SQLITE.SQL_Table("*", "INFOR", "");
            listPro = SQLITE.SQL_List(1, dt);
            listPath = new List<string>();
            listPath = SQLITE.SQL_List(2, dt);
            List<string> listSelect = new List<string>();
            listSelect = SQLITE.SQL_List(3, dt);
            cbProgram.Items.Clear();
            int i = 0;
            foreach(string s in listPro)
            {
                cbProgram.Items.Add(s);
                if(listSelect[i]=="1")
                {
                    cbProgram.SelectedIndex=i;
                    G.pathSQL = listPath[i];
                    G.editTile = listPro[i];
                }
                i++;
            }
            cbProgram.Items.Add("New Program");
        }

        private void cbMod_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnBrower_Click(object sender, EventArgs e)
        {
            Computer comp = new Computer();


            FolderBrowserDialog OpenPJ = new FolderBrowserDialog();

            OpenPJ.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.
            DialogResult result = OpenPJ.ShowDialog();

            if (result == DialogResult.OK)

            {
                string[] s = OpenPJ.SelectedPath.Split('\\');
                cbProgram.Items.Add(s[s.Count()-1]);
                cbProgram.SelectedIndex = cbProgram.Items.Count - 1;
            }
            }
       
        private void cbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///if (cbProgram.SelectedIndex == 0)
              //  cbMod.SelectedIndex = 1;

            if (cbProgram.SelectedIndex != -1 && listPath != null && listPath.Count != 0)
            {
                try
                {
                    G.pathSQL = listPath[cbProgram.SelectedIndex];
                    G.editTile = listPro[cbProgram.SelectedIndex];
                }
                catch(Exception)
                {

                }
               
            }
            else
            {
                //cbProgram.Enabled = true;
                // cbShift.Enabled = true;
            }
        }

        private void btnVN_Click(object sender, EventArgs e)
        {
            btnVN.BackColor = Color.Cornsilk;
            btnEN.BackColor = Color.White;
        }

        private void btnEN_Click(object sender, EventArgs e)
        {
            btnEN.BackColor = Color.Cornsilk;
            btnVN.BackColor = Color.White;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxDATABUILDERAXLibEx;
using DATABUILDERAXLibEx;
using System.Data.SQLite;
using SFS_FV.KEYENCE;
using System.IO.Ports;
using SFS_FV.SQL;

namespace SFS_FV
{
    public partial class NewDevice : Form
    {
        SQLiteConnection connect;
        SQLiteCommand cmd;
        DataTable dt;
        string con = "Data source =Data.sqlite;Version=3;New=False;Compress=True;SetPassword=12345678";
        string SQL = "SELECT NAME FROM AREA WHERE MOD='KV3000' ";
        public NewDevice(Form1 form1 )
        {
            InitializeComponent();
            this.fm1 = form1;
            
          //  this.fm1.Paint += btnAdd_Click;
        }
        #region Funtion_SQL
      
        private int CountDrawing(string id, string table, string w1, string w2)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand cmd;
            sqlite_conn = new SQLiteConnection("");
            sqlite_conn.Open();
            cmd = sqlite_conn.CreateCommand();
            cmd.CommandText = "select count('" + id + "') from " + table + " where " + w1 + " = '" + w2 + "';";
            // cmd.CommandType = CommandType.Text;
            int RowCount = 0;

            RowCount = Convert.ToInt32(cmd.ExecuteScalar());

            return RowCount;
        }
      
      
       
      
     
        public DataTable SQL_Table(string Get, string Table, string Where)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(G.sourceSQL))
                {
                    cnn.Open();

                    using (SQLiteCommand mycommand = new SQLiteCommand(cnn))
                    {
                        if (Where != "")
                            mycommand.CommandText = "SELECT " + Get + " FROM " + Table + " WHERE " + Where + " ";
                        else
                            mycommand.CommandText = "SELECT " + Get + " FROM " + Table + "";
                        using (SQLiteDataReader reader = mycommand.ExecuteReader())
                        {
                            //  reader.StepCount
                            dt.Load(reader);

                            reader.Close();
                        }
                    }
                    //  cnn.Close();
                }
            }
            catch (Exception e)
            {
                //  MessageBox.Show("VUI LÒNG KI?M TRA K?T N?I M?NG V?I ? SHARE!");

            }
            return dt;
        }

     
        public Tuple<bool, String> CHECK_VAL(string sql, string conn)
        {
            DataTable dt = new DataTable();
            string value = "";
            try
            {
                using (SQLiteConnection cnn = new SQLiteConnection(conn))
                {
                    cnn.Open();
                    using (SQLiteCommand mycommand = new SQLiteCommand(cnn))
                    {
                        mycommand.CommandText = sql;
                        using (SQLiteDataReader reader = mycommand.ExecuteReader())
                        {
                            dt.Load(reader);
                            reader.Close();

                        }
                    }


                    string[] array = dt.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray();
                    value = array[0];
                    if (dt.Rows.Count == 0) return Tuple.Create(false, "");


                }
            }
            catch (Exception e)
            {

            }
            return Tuple.Create(true, value);
        }
        public List<String> SQL_List(int num, DataTable dt)
        {
            List<String> value = new List<String>();
            try
            {
                string[] array = dt.Rows.OfType<DataRow>().Select(k => k[num].ToString()).ToArray();

                foreach (String arr in array)
                {
                    value.Add(arr);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return value;
        }
        public Dictionary<int, List<String>> GetMulTiList(int num, DataTable dt)
        {
            Dictionary<int, List<String>> dic = new Dictionary<int, List<String>>();

            try
            {
                for (int i = 0; i < num; i++)
                {
                    string[] array = dt.Rows.OfType<DataRow>().Select(k => k[i].ToString()).ToArray();
                    List<String> value = new List<String>();
                    foreach (String arr in array)
                    {
                        value.Add(arr);
                    }
                    dic.Add(i, value);


                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return dic;
        }
        #endregion
        Form1 fm1 = new Form1();
        SQLITE cSQL = new SQLITE();
        NewVariable NewVariable ;
        private void LoadDevice()
        {

           
        }
  
        private void btnAdd_Click(object sender, EventArgs e)
        {
            G.sourceSQL = G.VariableSQL;
            if (!cSQL.CHECK("*", "DEVICE", "DEVICE='" + txtName.Text + "' OR PARAMETER ='" + cbPara.Text.Trim() +G.portIP+ "'"))
            {
                if (cbPara.Text != "")
                {
                    dynamic itModel = cbModel.Items[cbModel.SelectedIndex];
                    DBPlcId eModel = (DBPlcId)int.Parse(itModel.Value);
                    dynamic itVia = cbVia.Items[cbVia.SelectedIndex];
                    Via eVia = (Via)int.Parse(itVia.Value);
                    AxDBCommManager plcTemp = new AxDBCommManager();
                    // cbModel.Items

                    plcTemp = KEYENCEs.Create(eModel, eVia, cbPara.Text.Trim() + G.portIP);
                    // G.ListKey.Add(new ListKey("", plcTemp, isConnect.Connected, img, new Point(0, 0)));
                    G.LisPLC.Add(new LisPLC(txtName.Text, cbCo.Text, cbModel.Text, eVia, cbPara.Text.Trim() + G.portIP, plcTemp, G.isConnect, picModel, picVia, G.pPen));
                    List<string> List = new List<string>();
                    List.Add(G.LisPLC[G.LisPLC.Count - 1].name);
                    List.Add("PLC");
                    List.Add(G.LisPLC[G.LisPLC.Count - 1].Co.ToString());
                    List.Add(G.LisPLC[G.LisPLC.Count - 1].Mod.ToString());
                    List.Add(G.LisPLC[G.LisPLC.Count - 1].Via.ToString());
                    List.Add(G.LisPLC[G.LisPLC.Count - 1].Para.ToString());
                    List.Add(G.LisPLC[G.LisPLC.Count - 1].isConnect.ToString());
                    cSQL.Insert("DEVICE", List);
                   
                    // fm1.PicMap.Invalidate();
                    fm1.picMap.Invalidate();
                   
                  //  LoadDevice();
                    G.pPen.X += picReview.Width + 10;
                    if (G.pPen.X + picReview.Width >= fm1.PicMap.Width)
                    {
                        G.pPen.Y += picReview.Height + 50;
                        G.pPen.X = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng quét thông số kết nối trước khi thêm thiết bị mới !");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng đặt tên khác hoặc thông số khác !");
            }
            G.sourceSQL = G.defautSQL;
            //   int A = plcTemp.ReadDevice(DBPlcDevice.DKV3000_DM, "110");
        }
        bool blChoose;
        Image picModel = Image.FromFile("pic1.png");
        Image picVia = Image.FromFile("pic1.png");
        Image picPLC = Image.FromFile("pic1.png");
        private void cbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (blChoose == false && cbModel.SelectedIndex != -1)
            {
                try
                {
                    picModel = Image.FromFile(cbModel.Text + ".png");
                    picReview.Invalidate();
                }
                catch (Exception)
                {
                    picModel = Image.FromFile("pic.png");
                }

                G.curColumn = cbModel.Items[cbModel.SelectedIndex].ToString();
                G.MODEL = G.curColumn;
                dt = SQL_Table("*", "AREA", "MOD='" + cbModel.Items[cbModel.SelectedIndex].ToString() + "'");
                fm1.DTedit.Columns.Clear();
                fm1.DTedit.DataSource = dt;
                for (int i = 0; i < fm1.DTedit.Columns.Count; i++)
                {
                    fm1.DTedit.Columns[i].Width = 80;
                }
                blChoose = true;
                G.curTab = "AREA";

                // cbArea.DataSource = new BindingSource(SQL_List(1, dt), null);
                // cbArea.SelectedIndex = -1;
            }
            blChoose = false;
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (blChoose == false && cbType.SelectedIndex != -1)
            {
                G.curColumn = cbType.Items[cbType.SelectedIndex].ToString();
                G.TYPE = G.curColumn;
                dt = SQL_Table("*", "CO", "TYPE='" + cbType.Items[cbType.SelectedIndex].ToString() + "'");
               fm1.DTedit.Columns.Clear();
                fm1.DTedit.DataSource = dt;
                for (int i = 0; i < fm1.DTedit.Columns.Count; i++)
                {
                    fm1.DTedit.Columns[i].Width = 80;
                }
                blChoose = true;
                G.curTab = "CO";
                cbCo.DataSource = new BindingSource(SQL_List(1, dt), null);
                cbCo.SelectedIndex = -1;
            }
            blChoose = false;
        }

        private void cbCo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (blChoose == false && cbCo.SelectedIndex != -1)
            {
                G.curColumn = cbCo.Items[cbCo.SelectedIndex].ToString();
                G.CO = G.curColumn;
                dt = SQL_Table("*", "MOD", "CO='" + cbCo.Items[cbCo.SelectedIndex].ToString() + "'");
                fm1.DTedit.Columns.Clear();
                fm1.DTedit.DataSource = dt;
                for (int i = 0; i < fm1.DTedit.Columns.Count; i++)
                {
                    fm1.DTedit.Columns[i].Width = 80;
                }
                blChoose = true;
                G.curTab = "MOD";
                // cbModel.DataSource = new BindingSource(SQL_List(1, dt), null);
                // cbModel.SelectedIndex = -1;

                List<string> LisMod = new List<string>();
                LisMod = SQL_List(1, dt);
                cbModel.Items.Clear();
                cbModel.DisplayMember = "Text";
                cbModel.ValueMember = "Value";
                foreach (string s in LisMod)
                {
                    if (s != "KV-7000")
                        cbModel.Items.Add(new { Text = s, Value = "515" });
                    else
                        cbModel.Items.Add(new { Text = s, Value = "525" });

                }
                cbModel.SelectedIndex = -1;
            }
            // LoadData(G.curTab);
            blChoose = false;
        }
       
        private void NewDevice_Load(object sender, EventArgs e)
        {
            G.sourceSQL = G.defautSQL;
            G.curTab = "TYPE";
            NewVariable = new NewVariable(fm1);
            G.pNewDevice = new Point(this.Width, this.Height);
            this.Location = new Point(fm1.Location.X +10, fm1.Location.Y +80);
            this.TopMost = true;
            cbVia.Items.Clear();
            cbVia.DisplayMember = "Text";
            cbVia.ValueMember = "Value";
            cbVia.Items.Add(new { Text = "USB", Value = "0" });
            cbVia.Items.Add(new { Text = "SERIALPORT", Value = "1" });
            cbVia.Items.Add(new { Text = "ENTHERNET", Value = "2" });

            cbVia.SelectedIndex = 0;
            LoadData(G.curTab);
            G.spicReview.X = picReview.Width;
            G.spicReview.Y = picReview.Height;
            /*
               cbArea.Items.Clear();
               cbArea.DisplayMember = "Text";
               cbArea.ValueMember = "Value";
               cbArea.Items.Add(new { Text = "R", Value = "0" });
               cbArea.Items.Add(new { Text = "MR", Value = "1" });
               cbArea.Items.Add(new { Text = "DM", Value = "2" });
               cbArea.Items.Add(new { Text = "EM", Value = "3" });
               cbArea.Items.Add(new { Text = "FM", Value = "4" });
               cbArea.Items.Add(new { Text = "W", Value = "5" });
               cbArea.SelectedIndex = 0;
               */


        }

        private void picReview_Paint(object sender, PaintEventArgs e)
        {
            Rectangle recModel = new Rectangle(0, 0, picReview.Width, 7 * picReview.Height / 8);
            //  Rectangle recModel = new Rectangle(3 * picReview.Width / 4, 0, picReview.Width/4, picReview.Height/4);
            Rectangle recVia = new Rectangle(0, 5 * picReview.Width / 8, picReview.Width / 4, picReview.Height / 4);
            Rectangle recVia2 = new Rectangle(picReview.Width / 4, 3 * picReview.Width / 4, 7 * picReview.Width / 8, picReview.Height / 8);
            Rectangle recName = new Rectangle(0, 7 * picReview.Height / 8, picReview.Width, picReview.Height / 8);
            Rectangle recPLC = new Rectangle(picReview.Width / 4, 5 * picReview.Width / 8, 7 * picReview.Width / 8, picReview.Height / 8);
            e.Graphics.DrawImage(picModel, recModel);
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(110, 224, 224, 224)), recVia);
            e.Graphics.DrawImage(picVia, recVia);
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, 255, 255, 255)), recVia2);
            e.Graphics.DrawString(cbPara.Text, new Font("Segoe Marker", 12, FontStyle.Bold), new SolidBrush(Color.SkyBlue), recVia2);
            e.Graphics.FillRectangle(Brushes.LightGreen, recName);
            e.Graphics.DrawString(txtName.Text, new Font("Segoe Marker", 12, FontStyle.Bold), new SolidBrush(Color.White), recName);
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(90, 192, 255, 255)), recPLC);
            e.Graphics.DrawString(cbCo.Text + " : " + cbModel.Text, new Font("Segoe Marker", 10, FontStyle.Bold), new SolidBrush(Color.White), recPLC);

        }

        private void cbVia_SelectedIndexChanged(object sender, EventArgs e)
        {
            picVia = Image.FromFile(cbVia.Text + ".png");
            picReview.Invalidate();
            cbPara.Text = "";
            if (cbVia.SelectedIndex == 0)
            {
                G.portIP = "";
                btnSeach.Enabled = false;
                cbPara.Enabled = false;
                cbPara.Text = cbCo.Text + "-USB";
            }
            if (cbVia.SelectedIndex == 1)
            {
                G.portIP = "";
                cbPara.Enabled = true;
                btnSeach.Enabled = false;
                string[] sPort = SerialPort.GetPortNames();

                cbPara.DataSource = null;
                cbPara.DisplayMember = "Text";
                cbPara.ValueMember = "Value";
                foreach (string s in sPort)
                {
                    for (int i = 0; i < G.LisPLC.Count(); i++)
                    {
                        cbPara.Items.Add(new { Text = s, Value = i + "" });
                    }
                    cbPara.SelectedIndex = 0;
                }
                btnSeach.Enabled = true;
            }
            if (cbVia.SelectedIndex == 2)
            {
                btnSeach.Enabled = true;
                cbPara.Enabled = true;
            }
        }
        string PathFile;
        private void btnPicPLC_Click(object sender, EventArgs e)
        {
            OpenFileDialog thisDialog = new OpenFileDialog();
            thisDialog.Filter = "Image (*.png*)|*.png*";
            thisDialog.FilterIndex = 2;
            thisDialog.RestoreDirectory = true;
            thisDialog.Multiselect = true;
            thisDialog.Title = "Chọn Picture";

            if (thisDialog.ShowDialog() == DialogResult.OK)
            {

                PathFile = thisDialog.FileName;

                try
                {
                    picModel = Image.FromFile(PathFile);
                    picReview.Invalidate();
                }
                catch (Exception)
                {

                }
            }
        }

        private void btnPicModel_Click(object sender, EventArgs e)
        {
            OpenFileDialog thisDialog = new OpenFileDialog();
            thisDialog.Filter = "Image (*.png*)|*.png*";
            thisDialog.FilterIndex = 2;
            thisDialog.RestoreDirectory = true;
            thisDialog.Multiselect = true;
            thisDialog.Title = "Chọn Picture";

            if (thisDialog.ShowDialog() == DialogResult.OK)
            {

                PathFile = thisDialog.FileName;

                try
                {
                    picModel = Image.FromFile(PathFile);
                    picReview.Invalidate();
                }
                catch (Exception)
                {

                }
            }
        }

        private void btnPicVia_Click(object sender, EventArgs e)
        {
            OpenFileDialog thisDialog = new OpenFileDialog();
            thisDialog.Filter = "Image (*.png*)|*.png*";
            thisDialog.FilterIndex = 2;
            thisDialog.RestoreDirectory = true;
            thisDialog.Multiselect = true;
            thisDialog.Title = "Chọn Picture";

            if (thisDialog.ShowDialog() == DialogResult.OK)
            {

                PathFile = thisDialog.FileName;

                try
                {
                    picVia = Image.FromFile(PathFile);
                    picReview.Invalidate();
                }
                catch (Exception)
                {

                }
            }
        }
        ScanAddIP ScanAddIP=new ScanAddIP();
        private void btnSeach_Click(object sender, EventArgs e)
        {
            if (cbVia.SelectedIndex == 0)
            {
                btnSeach.Enabled = false;
            }
            if (cbVia.SelectedIndex == 2)
            {
                ScanAddIP.ShowDialog();
                cbPara.DataSource = G.ListIp;
            }
        }
        private void LoadData(string Tab)
        {

            dt = SQL_Table("*", "" + Tab + "", "");
            blChoose = true;
            
            if (Tab == "TYPE")
            {
                cbType.DataSource = new BindingSource(SQL_List(0, dt), null);
                cbType.SelectedIndex = 0;
            }
            else if (Tab == "CO")
            {
                cbCo.DataSource = new BindingSource(SQL_List(1, dt), null);
                cbCo.SelectedIndex = 0;
            }
            else if (Tab == "MOD")
            {
            }
            else if (Tab == "AREA")
            {

             //   cbArea.DataSource = new BindingSource(SQL_List(1, dt), null);
              //  cbArea.SelectedIndex = -1;
            }
            
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            picReview.Invalidate();
        }

        private void NewDevice_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;
        }

        private void NewDevice_Shown(object sender, EventArgs e)
        {
            G.sourceSQL = G.defautSQL;
        }
    }
}

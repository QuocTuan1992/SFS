using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SFS_FV.KEYENCE;
using AxDATABUILDERAXLibEx;
using DATABUILDERAXLibEx;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.Ports;
using System.Net.NetworkInformation;
using System.Threading;
using System.Diagnostics;
using System.Net;
using System.Data.SQLite;

using NetUtils;
using System.Collections;
using SFS_FV.SQL;
using SFS_FV.GRAPHIC;
using SFS_FV.Local;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.Devices;
using Microsoft.VisualBasic.FileIO;
using SFS_FV.Data;

namespace SFS_FV
{
 
    public partial class Form1 : Form
    {
        SQLiteConnection connect;
        SQLiteCommand cmd;
        DataTable dt;
       
        SQLITE SQLITE = new SQLITE();
        Refresh Refresh1;
        public Form1()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            LoadData(G.curTab);
  //Create();

           
        }
#region Recycle
        private void Create()
        {

            connect = new SQLiteConnection("Data source =SQL\\DATA.sfs;Version=3;New=false;Compress=True;SetPassword=12345678");
            connect.Open();

            cmd = connect.CreateCommand();//khoi tao khong gian lam viec
            //cmd.CommandText = " DROP Table 'INFOR'";
            //  cmd.ExecuteNonQuery();
           // cmd.CommandText = " CREATE TABLE PIC ( NAME nvachar(50));"; //gancau lech cmd
          //  cmd.ExecuteNonQuery();//thuc thi 
          ///  cmd.CommandText = " INSERT INTO PIC VALUES ('12/09/2018','EMTY','','0');"; //gancau lech cmd
          //  cmd.ExecuteNonQuery();//thuc thi 
                                 //  cmd.CommandText = " CREATE TABLE DATEHOUR (DATE nvachar(50),SHIFT nvachar(50),HOUR nvachar(50),VARIABLE nvachar(50), VALUE nvachar(50));"; //gancau lech cmd
                                 //  cmd.ExecuteNonQuery();//thuc thi 
                                  //  cmd.CommandText = " INSERT INTO TIME VALUES ('1','','');"; //gancau lech cmd
                                  //  cmd.ExecuteNonQuery();
                                  //  cmd.CommandText = " INSERT INTO TIME VALUES ('2','','');"; //gancau lech cmd
                                  //  cmd.ExecuteNonQuery();
                                  //   cmd.CommandText = " INSERT INTO TIME VALUES ('3','','');"; //gancau lech cmd
                                  //  cmd.ExecuteNonQuery();
                                  //cmd.CommandText = " CREATE TABLE TIME (SHIFT nvachar(50),TIME nvachar(50),DELAY nvachar(50));"; //gancau lech cmd
                                  //cmd.ExecuteNonQuery();//thuc thi 
                                  // cmd.CommandText = " DROP Table 'LINE'";
                                  // cmd.ExecuteNonQuery();
                                  // cmd.CommandText = " DROP Table 'DATADATE'";
                                  // cmd.ExecuteNonQuery();
                                  //cmd.CommandText = " CREATE TABLE MOD (MOD nvachar(50));"; //gancau lech cmd
                                  //cmd.ExecuteNonQuery();//thuc thi 
                                  //cmd.CommandText = " CREATE TABLE DATADATE (DATE nvachar(50), LINE nvachar(50),MOD nvachar(50),Shift nvachar(50),Man nvachar(50),OP nvachar(50),OT nvachar(50),TargetDate nvachar(50),OK nvachar(50),NG nvachar(50),YIELD nvachar(50));"; //gancau lech cmd
                                  //  cmd.ExecuteNonQuery();//thuc thi 
                                  //  cmd.CommandText = " CREATE TABLE LISTTIME (SHIFT nvachar(50),TIME nvachar(50),TARGET nvachar(50));"; //gancau lech cmd
                                  // cmd.ExecuteNonQuery();//thuc thi 
                                  // cmd.CommandText = " CREATE TABLE LINE (ID nvachar(50),LINE nvachar(50),MOD nvachar(50),maxMan nvachar(50),maxOP nvachar(50),maxOT nvachar(50),maxTargetDate nvachar(50),maxTargetHour nvachar(50),varOK nvachar(50),varNG nvachar(50),timeUpdate nvachar(50));"; //gancau lech cmd
                                  // cmd.ExecuteNonQuery();//thuc thi 
                                  // cmd.CommandText = " INSERT INTO LINE VALUES ('ID','','','','','','','','','','');"; //gancau lech cmd
                                  // cmd.ExecuteNonQuery();
                                  // cmd.CommandText = " CREATE TABLE DATADATE (LINE nvachar(50),MOD nvachar(50),Shift nvachar(50),Man nvachar(50),OP nvachar(50),OT nvachar(50),TargetDate nvachar(50),OK nvachar(50),NG nvachar(50),YIELD nvachar(50));"; //gancau lech cmd
                                  //   cmd.ExecuteNonQuery();//thuc thi 
                                  //(string Name, ListVariables ListVariables, string cycleTime,int tempValue, int numScan, DateTime dtBegin, DateTime dtEnd, isCycle isCycle,bool blStartCycle)
                                  //   cmd.CommandText = " CREATE TABLE TOOL (NAME nvachar(50),TYPE nvachar(50));"; //gancau lech cmd
                                  //cmd.ExecuteNonQuery();//thuc thi 
                                  //  cmd.CommandText = " CREATE TABLE Quantity (NAME nvachar(50),TYPE nvachar(50),Variables nvachar(50),TEXT nvachar(50),SIZE nvachar(50),COLOR nvachar(50),FONT nvachar(50),TCOLOR nvachar(50),isVAL nvachar(10),isLAB nvachar(10),isCONST nvachar(10),DEFAUT nvachar(50));"; //gancau lech cmd
                                  //   cmd.ExecuteNonQuery();//thuc thi 
                                  //    cmd.CommandText = " CREATE TABLE Time (NAME nvachar(50),TYPE nvachar(50),Variables nvachar(50),TEXT nvachar(50),SIZE nvachar(50),COLOR nvachar(50),FONT nvachar(50),TCOLOR nvachar(50),isVAL nvachar(10),isLAB nvachar(10),isCONST nvachar(10),DEFAUT nvachar(50),MAXTIME nvachar(50));"; //gancau lech cmd
                                  //    cmd.ExecuteNonQuery();//thuc thi 
                                  //  cmd.CommandText = " CREATE TABLE CHART (NAME nvachar(50),ToolChart nvachar(50),TimeBegin nvachar(50),TimeReset nvachar(50),TimeUpdate nvachar(50),Max nvachar(50),TPOINT nvachar(50),CPOINT nvachar(50),MIN nvachar(50),GIRD nvachar(50) );"; //gancau lech cmd
                                  //  cmd.ExecuteNonQuery();//thuc thi 
                                  //string Name,List<ToolChart> ToolChart,List<List<ListData>> ListData, DateTime TimeBegin, double TimeReset, int TimeUpdate,int Max 
                                  //  cmd.CommandText = " CREATE TABLE Yield (NAME nvachar(50),Yield nvachar(50),ListOK nvachar(50),ListNG nvachar(50));"; //gancau lech cmd
                                  // cmd.ExecuteNonQuery();//thuc thi
                                  // cmd.CommandText = " CREATE TABLE Global (NAME nvachar(50),DEVICE nvachar(50),AREA nvachar(50),BIT nvachar(50),TYPE nvachar(10),VALUE nvachar(50),STATUS nvachar(50));"; //gancau lech cmd
                                  //  cmd.ExecuteNonQuery();//thuc thi 
                                  //    cmd.CommandText = " CREATE TABLE LostTime(NAME nvachar(50),Variables nvachar(50),LostTime nvachar(50),TempValue nvachar(50),timeMax nvachar(10),dtBegin nvachar(50),dtEnd nvachar(10),isLost nvachar(10),blStart nvachar(10));"; //gancau lech cmd
                                  //      cmd.ExecuteNonQuery();//thuc thi 
                                  // cmd.CommandText = " CREATE TABLE Yield (NAME nvachar(50),Yield nvachar(50),ListOK nvachar(50),ListNG nvachar(50));"; //gancau lech cmd
                                  //cmd.ExecuteNonQuery();//thuc thi 
                                  // cmd.CommandText = " CREATE TABLE DEVICE (DEVICE nvachar(50),TYPE nvachar(50),CO nvachar(50),MOD nvachar(50),WITH nvachar(50),PARAMETER nvachar(50),STATUS nvachar(10));"; //gancau lech cmd
                                  // cmd.ExecuteNonQuery();//thuc thi 
                                  // cmd.CommandText = " DROP Table 'BIT'";
                                  // cmd.ExecuteNonQuery();
                                  /* cmd.CommandText = " CREATE TABLE TYPE (TYPE nvachar(50));"; //gancau lech cmd
                                   cmd.ExecuteNonQuery();//thuc thi 
                                   cmd.CommandText = " CREATE TABLE CO (TYPE nvachar(50),CO nvachar(50));"; //gancau lech cmd
                                   cmd.ExecuteNonQuery();//thuc thi 
                                   cmd.CommandText = " CREATE TABLE MOD (CO nvachar(50),MOD nvachar(50));"; //gancau lech cmd
                                   cmd.ExecuteNonQuery();//thuc thi 
                                   cmd.CommandText = " CREATE TABLE AREA (MOD nvachar(50),AREA nvachar(50),WORD_START nvachar(50),WORD_STOP nvachar(50),STEP_WORD nvachar(50),STEP_BIT nvachar(50));"; //gancau lech cmd
                                   cmd.ExecuteNonQuery();//thuc thi 
                                   cmd.CommandText = " CREATE TABLE BIT (MOD nvachar(50),AREA nvachar(50),BIT nvachar(50));"; //gancau lech cmd
                                  cmd.ExecuteNonQuery();//thuc thi 

                                   cmd.CommandText = " INSERT INTO TYPE VALUES ('PLC');"; //gancau lech cmd
                                   cmd.ExecuteNonQuery();//thuc thi 
                                   cmd.CommandText = " INSERT INTO TYPE VALUES ('VDK');"; //gancau lech cmd
                                   cmd.ExecuteNonQuery();//thuc thi 
                                   cmd.CommandText = " INSERT INTO TYPE VALUES ('VISION');"; //gancau lech cmd
                                   cmd.ExecuteNonQuery();//thuc thi */

        }
        #endregion
        #region Funtion
        #region LinkForm
        public DataGridView DTedit
        {
            set { this.dtEdit = value; }
            get { return this.dtEdit; }
        }
        public PictureBox PicMap
        {
            set { this.picMap = value; }
            get { return this.picMap; }

        }
        #endregion
        #region Load
        private void LoadData(string Tab)
        {

            dt = SQLITE.SQL_Table("*", "" + Tab + "", "");
            dtEdit.Columns.Clear();
            dtEdit.DataSource = dt;
            for (int i = 0; i < dtEdit.Columns.Count; i++)
            {
                dtEdit.Columns[i].Width = 80;
            }
            blChoose = true;

        }
        #endregion
        #region Copy_paste
        private void CopyToClipboard()
        {

            DataObject dataObj = dtEdit.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        private Dictionary<int, Dictionary<int, string>> ClipBoardValues(string clipboardValue)
        {
            Dictionary<int, Dictionary<int, string>> copyValues = new Dictionary<int, Dictionary<int, string>>();

            String[] lines = clipboardValue.Split('\n');

            for (int i = 0; i <= lines.Length - 1; i++)
            {
                copyValues[i] = new Dictionary<int, string>();
                String[] lineContent = lines[i].Split('\t');

                //if an empty cell value copied, then set the dictionay with an empty string
                //else Set value to dictionary
                if (lineContent.Length == 0)
                    copyValues[i][0] = string.Empty;
                else
                {
                    for (int j = 0; j <= lineContent.Length - 1; j++)
                        copyValues[i][j] = lineContent[j];
                }
            }
            return copyValues;
        }
        private void PasteClipboardValue()
        {
            //Show Error if no cell is selected
            if (dtEdit.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select a cell", "Paste", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Get the satring Cell
            DataGridViewCell startCell = GetStartCell(dtEdit);
            //Get the clipboard value in a dictionary
            Dictionary<int, Dictionary<int, string>> cbValue = ClipBoardValues(Clipboard.GetText());

            int iRowIndex = startCell.RowIndex;
            foreach (int rowKey in cbValue.Keys)
            {
                int iColIndex = startCell.ColumnIndex;
                foreach (int cellKey in cbValue[rowKey].Keys)
                {
                    //Check if the index is with in the limit
                    if (iColIndex <= dtEdit.Columns.Count - 1 && iRowIndex <= dtEdit.Rows.Count - 1)
                    {
                        DataGridViewCell cell = dtEdit[iColIndex, iRowIndex];

                        //Copy to selected cells if 'chkPasteToSelectedCells' is checked

                        cell.Value = cbValue[rowKey][cellKey];
                    }
                    iColIndex++;
                }
                iRowIndex++;
            }
        }
        #endregion
        #region SQL
        private void Insert_SQL(string Tab)
        {
            List<string> nameColumns = new List<string>();
            List<string> ValueColumn = new List<string>();
            List<int> indexSelect = new List<int>();
            for (int i = 0; i < dtEdit.Columns.Count; i++)
            {
                nameColumns.Add(dtEdit.Columns[i].Name);
            }
            foreach (DataGridViewCell cell in dtEdit.SelectedCells)
            {
                indexSelect.Add(cell.RowIndex);
                //ListRowIndexMOD.Add(cell.RowIndex);
            }
            indexSelect = indexSelect.Distinct().ToList();
            // float a = 12;
            // float a = 1.2;
            foreach (int selectedrowindex in indexSelect)
            {
                DataGridViewRow selectedRow = dtEdit.Rows[selectedrowindex];
                ValueColumn.Clear();
                foreach (string nameColumn in nameColumns)
                {
                    ValueColumn.Add(Convert.ToString(selectedRow.Cells[nameColumn].Value));
                    // string VA

                }
                bool blcheck = true;
                bool blcheck1 = true;
                try
                {
                    blcheck1 = SQLITE.CHECK("*", G.curTab, "" + nameColumns[0] + "='" + ValueColumn[0] + "'");
                    blcheck = SQLITE.CHECK("*", G.curTab, "" + nameColumns[1] + "='" + ValueColumn[1] + "'");
                }
                catch (Exception)
                {

                }
                if (blcheck == false || blcheck1 == false)
                    SQLITE.Insert(Tab, ValueColumn);
                else
                    MessageBox.Show("the same!");



            }
            LoadData(G.curTab);
        }
        private void Delect_SQL(string Tab)
        {
            List<string> nameColumns = new List<string>();
            List<string> ValueColumn = new List<string>();
            List<int> delectSelect = new List<int>();
            for (int i = 0; i < dtEdit.Columns.Count; i++)
            {
                nameColumns.Add(dtEdit.Columns[i].Name);
            }
            foreach (DataGridViewCell cell in dtEdit.SelectedCells)
            {
                delectSelect.Add(cell.RowIndex);
                //ListRowIndexMOD.Add(cell.RowIndex);
            }
            delectSelect = delectSelect.Distinct().ToList();

            foreach (int selectedrowindex in delectSelect)
            {
                DataGridViewRow selectedRow = dtEdit.Rows[selectedrowindex];
                foreach (string nameColumn in nameColumns)
                {
                    ValueColumn.Add(Convert.ToString(selectedRow.Cells[nameColumn].Value));
                    // string VA

                }
                if (Tab != "DEVICE")
                    SQLITE.Delete(Tab, "" + nameColumns[dtEdit.Columns.Count - 1] + "='" + ValueColumn[dtEdit.Columns.Count - 1] + "'");
                else
                    SQLITE.Delete(Tab, "" + nameColumns[0] + "='" + ValueColumn[0] + "'");

                //  Insert(Tab, nameColumns, ValueColumn);

                LoadData(G.curTab);
            }
        }
        private void UPDATE_SQL(string Tab)
        {
            List<string> nameColumns = new List<string>();
            List<string> ValueColumn = new List<string>();
            List<int> delectSelect = new List<int>();
            for (int i = 0; i < dtEdit.Columns.Count; i++)
            {
                nameColumns.Add(dtEdit.Columns[i].Name);
            }
            foreach (DataGridViewCell cell in dtEdit.SelectedCells)
            {
                delectSelect.Add(cell.RowIndex);
                //ListRowIndexMOD.Add(cell.RowIndex);
            }
            delectSelect = delectSelect.Distinct().ToList();

            foreach (int selectedrowindex in delectSelect)
            {
                DataGridViewRow selectedRow = dtEdit.Rows[selectedrowindex];
                foreach (string nameColumn in nameColumns)
                {
                    ValueColumn.Add(Convert.ToString(selectedRow.Cells[nameColumn].Value));
                    // string VA

                }
                dic = new Dictionary<string, string>();
                dic.Add("VALUE", ValueColumn[5] + "");
                SQLITE.Update("Global", dic, "NAME='" + ValueColumn[0] + "'",G.VariableSQL);
                string Model = G.ListVariables[selectedrowindex].Device.plcKey.PLC.ToString().Split('_')[1] + "_" + G.ListVariables[selectedrowindex].Area;
                eModel = (DBPlcDevice)Enum.Parse(typeof(DBPlcDevice), Model);
                G.ListVariables[selectedrowindex].Device.plcKey.WriteDevice((DBPlcDevice)eModel, G.ListVariables[selectedrowindex].bit, int.Parse(ValueColumn[5]));

                //  Insert(Tab, nameColumns, ValueColumn);

                LoadData(G.curTab);
            }
        }
        #endregion
#endregion 
        #region Variable

        #endregion






        bool blChoose;
   
      
        private DataGridViewCell GetStartCell(DataGridView dgView)
        {
            //get the smallest row,column index
            if (dgView.SelectedCells.Count == 0)
                return null;

            int rowIndex = dgView.Rows.Count - 1;
            int colIndex = dgView.Columns.Count - 1;

            foreach (DataGridViewCell dgvCell in dgView.SelectedCells)
            {
                if (dgvCell.RowIndex < rowIndex)
                    rowIndex = dgvCell.RowIndex;
                if (dgvCell.ColumnIndex < colIndex)
                    colIndex = dgvCell.ColumnIndex;
            }

            return dgView[colIndex, rowIndex];
        }
     
      
        Bitmap bm;
   
        NewDevice NewDevice;
        private void FormLoad()
        {
           
            NewDevice = new NewDevice(this);
            NewVariable = new NewVariable(this);
            G.pPen = new Point(0, 0);
            cbTab.DataSource = Enum.GetValues(typeof(typeVariable));
            bm = new Bitmap(picMap.Width, picMap.Height);
            IPHostEntry ip = Dns.GetHostByName(Dns.GetHostName());
            G.AddIPLoacal = ip.AddressList[0].ToString();
            txtIPMC.Text = G.AddIPLoacal;
            G.pForm1 = this.Location;
            G.sForm1 = new Point(this.Width, this.Height);
            Data.LoadSQLITE LoadSQL =new Data.LoadSQLITE(PicMap.Width);
            picMap.Invalidate();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            FormLoad();
           
        }


        private void UpdateGraphic(int MinReset,int MinUpdate)
        {
            G.ixData = 0;

            foreach (ToolChart ListToolChart in G.ListToolChart)
            {
                G.ListData.Add(new List<ListData>());
                int numDrawing = Convert.ToInt32(MinReset / MinUpdate);


                if (ListToolChart.ToolGr.TypeGr == TypeGr.Rectanger)
                {
                    int index = 0;
                    while (index < numDrawing)
                    {
                        G.ListData[G.ixData].Add(new ListData(ListToolChart, 0, 0));
                        index++;
                    }
                }
                else if (ListToolChart.ToolGr.TypeGr == TypeGr.Line)
                {
                    List<Point> values = new List<Point>();
                    if (ListToolChart.ToolGr.isConst == true)
                    {
                        for (int i = 0; i < numDrawing; i++)
                        {
                            values.Add(new Point(0, ListToolChart.ToolGr.defaut));
                        }
                        G.ListData[G.ixData].Add(new ListData(ListToolChart, values));
                    }
                    else
                    {
                        for (int i = 0; i < numDrawing; i++)
                        {
                            values.Add(new Point(0, 0));
                        }
                        G.ListData[G.ixData].Add(new ListData(ListToolChart, values));
                    }

                }
                else if (ListToolChart.ToolGr.TypeGr == TypeGr.Cycle)
                {
                    List<double> timer = new List<double>();
                    List<double> cycle = new List<double>();
                    List<Point> pDrawing = new List<Point>();
                    List<double> lost = new List<double>();
                    List<double> timelost = new List<double>();
                    G.ListData[G.ixData].Add(new ListData(ListToolChart, pDrawing, timer, cycle, lost, timelost));
                }
                else if (ListToolChart.ToolGr.TypeGr == TypeGr.Yield)
                {
                    List<double> value = new List<double>();
                    List<int> tempOK = new List<int>();
                    List<int> tempNG = new List<int>();
                    List<Point> pDrawing = new List<Point>();
                    for (int i = 0; i < numDrawing; i++)
                    {
                        tempOK.Add(0);
                        tempNG.Add(0);
                        value.Add(100);
                        pDrawing.Add(new Point(0, 0));
                    }
                    G.ListData[G.ixData].Add(new ListData(ListToolChart, value, tempOK, tempNG, pDrawing));
                }
                G.ixData++;


            }

        }


        public  void picMap_Paint(object sender, PaintEventArgs e)
        {
           
            foreach (LisPLC LisPLC in G.LisPLC)
            {
                Rectangle rec = new Rectangle(0 + LisPLC.pMap.X, 0 + LisPLC.pMap.Y,NewDevice.picReview.Width, NewDevice.picReview.Height );
                Rectangle recModel = new Rectangle(0+ LisPLC.pMap.X, 0+ LisPLC.pMap.Y, NewDevice.picReview.Width, 7 * NewDevice.picReview.Height / 8);
                //  Rectangle recModel = new Rectangle(3 * picReview.Width / 4, 0, picReview.Width/4, picReview.Height/4);
                Rectangle recVia = new Rectangle(0 + LisPLC.pMap.X, 5 * NewDevice.picReview.Width / 8 + LisPLC.pMap.Y, NewDevice.picReview.Width / 4, NewDevice.picReview.Height / 4);
                Rectangle recVia2 = new Rectangle(NewDevice.picReview.Width / 4 + LisPLC.pMap.X, 3 * NewDevice.picReview.Width / 4 + LisPLC.pMap.Y, 7 * NewDevice.picReview.Width / 8, NewDevice.picReview.Height / 8);
                Rectangle recName = new Rectangle(0 + LisPLC.pMap.X, 7 * NewDevice.picReview.Height / 8 + LisPLC.pMap.Y, NewDevice.picReview.Width, NewDevice.picReview.Height / 8);
                Rectangle recPLC = new Rectangle(NewDevice.picReview.Width / 4 + LisPLC.pMap.X, 5 * NewDevice.picReview.Width / 8 + LisPLC.pMap.Y, 7 * NewDevice.picReview.Width / 8, NewDevice.picReview.Height / 8);
                e.Graphics.DrawImage(LisPLC.imgModel, recModel);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(110, 224, 224, 224)), recVia);
                e.Graphics.DrawImage(LisPLC.imgVia, recVia);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, 255, 255, 255)), recVia2);
                e.Graphics.DrawString(LisPLC.Para, new Font("Segoe Marker", 12, FontStyle.Bold), new SolidBrush(Color.SkyBlue), recVia2);
                if (LisPLC.isConnect != isConnect.Disconnected)
                    e.Graphics.FillRectangle(Brushes.LightGreen, recName);
                else
                    e.Graphics.FillRectangle(Brushes.Orange, recName);
                e.Graphics.DrawString(LisPLC.name, new Font("Segoe Marker", 12, FontStyle.Bold), new SolidBrush(Color.White), recName);
                
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(90, 192, 255, 255)), recPLC);
                e.Graphics.DrawString(LisPLC.Co+" : "+LisPLC.Mod, new Font("Segoe Marker", 10, FontStyle.Bold), new SolidBrush(Color.White), recPLC);
                if(LisPLC.isConnect==isConnect.Disconnected)
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(80, 255, 128, 128)), rec);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
       
        SaveFileDialog SaveFile = new SaveFileDialog();
        private void btnSaves_Click(object sender, EventArgs e)
        {
            Computer comp = new Computer();

            try
            {
               // System.IO.File.Delete(G.pathSQL + "\\Data.sqlite");
                System.IO.File.Delete(G.pathSQL + "\\TOOL.sfs");
                System.IO.File.Delete(G.pathSQL + "\\CHART.sfs");
               
                System.IO.File.Delete(G.pathSQL + "\\Variables.sfs");
            }
            catch(Exception)
            {

            }
            //   System.IO.File.Delete(G.AddSQL + G.sUserIDs + ".png");
          //  comp.FileSystem.CopyFile("SQL\\Data.sqlite",G.pathSQL+ "\\Data.sqlite", UIOption.AllDialogs, UICancelOption.DoNothing);
            comp.FileSystem.CopyFile("SQL\\TOOL.sfs", G.pathSQL + "\\TOOL.sfs", UIOption.AllDialogs, UICancelOption.DoNothing);
            comp.FileSystem.CopyFile("SQL\\CHART.sfs", G.pathSQL + "\\CHART.sfs", UIOption.AllDialogs, UICancelOption.DoNothing);
            comp.FileSystem.CopyFile("SQL\\Variables.sfs", G.pathSQL + "\\Variables.sfs", UIOption.AllDialogs, UICancelOption.DoNothing);
            MessageBox.Show("Đã lưu dự án thành công tại " + Environment.NewLine + G.pathSQL);
        }
        OpenFileDialog OpenFile = new OpenFileDialog();
        
        Enum eModel;

        private void btnClearMap_Click(object sender, EventArgs e)
        {
            G.LisPLC.Clear();
            G.pPen = new Point(0, 0);
            picMap.Invalidate();
        }
        DataTable dtDevice,dtVariable;
        SQLITE cSQL = new SQLITE();
        Image picModel = Image.FromFile("pic1.png");
        Image picVia = Image.FromFile("pic1.png");
        Image picPLC = Image.FromFile("pic1.png");
        bool blConnect = true;

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            Computer comp = new Computer();

            
            FolderBrowserDialog OpenPJ = new FolderBrowserDialog();

            OpenPJ.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.
            DialogResult result = OpenPJ.ShowDialog();

            if (result == DialogResult.OK)

            {
                try
                {
                   // System.IO.File.Delete("SQL\\Data.sqlite");
                    System.IO.File.Delete("SQL\\TOOL.sfs");
                    System.IO.File.Delete("SQL\\CHART.sfs");
                    System.IO.File.Delete("SQL\\Data.sqlite");
                    System.IO.File.Delete("SQL\\Variables.sfs");
                }
                catch (Exception)
                {

                }
               // comp.FileSystem.CopyFile(OpenPJ.SelectedPath + "\\Data.sqlite", "SQL\\Data.sqlite", UIOption.AllDialogs, UICancelOption.DoNothing);
                comp.FileSystem.CopyFile(OpenPJ.SelectedPath+ "\\TOOL.sfs", "SQL\\TOOL.sfs", UIOption.AllDialogs, UICancelOption.DoNothing);
                comp.FileSystem.CopyFile(OpenPJ.SelectedPath + "\\CHART.sfs", "SQL\\CHART.sfs", UIOption.AllDialogs, UICancelOption.DoNothing);
                comp.FileSystem.CopyFile(OpenPJ.SelectedPath + "\\Variables.sfs","SQL\\Variables.sfs", UIOption.AllDialogs, UICancelOption.DoNothing);
                FormLoad();
            

            }
        }
      
      

      
        void ListAllIpLanUseNetview()
        {
            Process netUtility = new Process();
            netUtility.StartInfo.FileName = "net.exe";
            netUtility.StartInfo.CreateNoWindow = true;
            netUtility.StartInfo.Arguments = "view";
            netUtility.StartInfo.RedirectStandardOutput = true;
            netUtility.StartInfo.UseShellExecute = false;
            netUtility.StartInfo.RedirectStandardError = true;
            netUtility.Start();
            StreamReader streamReader = new StreamReader(netUtility.StandardOutput.BaseStream, netUtility.StandardOutput.CurrentEncoding);
            string line = "";
            while ((line = streamReader.ReadLine()) != null)
            {
                if (line.StartsWith("\\"))
                {
                    string howtogeek = line.Substring(2).Substring(0, line.Substring(2).IndexOf(" ")).ToUpper();
                    string ads = "";
                    Application.DoEvents();
                    try
                    {
                        Application.DoEvents();
                        IPAddress[] addresslist = Dns.GetHostAddresses(howtogeek);
                        ads = addresslist[0].ToString();
                    }
                    catch (Exception ex)
                    {
                        ads = "Unknown";
                    }
                    Application.DoEvents();
                    ListViewItem item = new ListViewItem();
                    item.Text = ads;
                    item.SubItems.Add(howtogeek);
                    List.Add(item.Text);
                }
            }
            streamReader.Close();
            netUtility.WaitForExit(1000);
        }
        List<string> List = new List<string>();


     
        private void btnReadBit_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        Dictionary<string, string> dic;
        ReadData ReadData;
        private void timer1_Tick(object sender, EventArgs e)
        {
            ReadData = new ReadData();
         }

    
        private void dtEdit_DataSourceChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dtEdit.Rows)
            {

                int selectedrowindex = item.Index;
                DataGridViewRow selectedRow = dtEdit.Rows[selectedrowindex];
                // string a = Convert.ToString(selectedRow.Cells["STATUS"].Value);
                if (selectedrowindex != dtEdit.Rows.Count - 1)
                    this.dtEdit.Rows[selectedrowindex].DefaultCellStyle.BackColor = Color.LemonChiffon;


            }
        }

        private void dtEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                CopyToClipboard();
            }
            if (e.Control && e.KeyCode == Keys.V)
            {
                PasteClipboardValue();
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Insert_SQL(G.curTab);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {

            DataGridViewRow selectedRow1 = dtEdit.Rows[dtEdit.Rows.Count - 2];


            DataGridViewRow selectedRow = dtEdit.Rows[dtEdit.SelectedCells[0].RowIndex];


            string Column = dtEdit.Columns[dtEdit.SelectedCells[0].ColumnIndex].Name;
            string goTable = "";
            if (G.curTab == "TYPE")
            {
                goTable = "CO";
                G.curTab = "CO";
                goto X;
            }

            if (G.curTab == "CO")
            {
                goTable = "MOD";
                G.curTab = "MOD";
                goto X;
            }
            if (G.curTab == "MOD")
            {
                goTable = "AREA";
                G.curTab = "AREA";
                goto X;
            }
            if (G.curTab == "AREA")
            {
                goTable = "Global";
                G.curTab = "Global";
                // ValueColumn.Add(Convert.ToString(selectedRow.Cells[nameColumn].Value));
                ///MOD nvachar(50),AREA nvachar(50),WORD_START nvachar(50),WORD_STOP nvachar(50),STEP_WORD nvachar(50),STEP_BIT nvachar(50));"; //gancau lech cmd
                G.w_Start = Convert.ToDouble(selectedRow.Cells["WORD_START"].Value);
                G.w_Stop = Convert.ToDouble(selectedRow.Cells["WORD_STOP"].Value);
                G.st_Word = Convert.ToDouble(selectedRow.Cells["STEP_WORD"].Value);
                G.st_Bit = Convert.ToDouble(selectedRow.Cells["STEP_BIT"].Value);
                goto X;
            }

            X: dt = SQLITE.SQL_Table("*", "" + goTable + "", "" + Column + "='" + selectedRow.Cells[dtEdit.SelectedCells[0].ColumnIndex].Value + "'");
            dtEdit.Columns.Clear();
            dtEdit.DataSource = dt;
            blChoose = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delect_SQL(G.curTab);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            G.LisPLC.Clear();
            G.pPen = new Point(0, 0);
            picMap.Invalidate();
        }

      
        Browser Browser;
        private void btnNewFile_Click(object sender, EventArgs e)
        {
            Browser = new Browser(this);
            Browser.ShowDialog();
        }

      

      
        typeVariable typeVariable = new typeVariable();
        private void cbTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            typeVariable = (typeVariable)Enum.Parse(typeof(typeVariable), cbTab.Text);
            if (typeVariable == typeVariable.Global|| typeVariable == typeVariable.CycleTime|| typeVariable == typeVariable.Yield|| typeVariable == typeVariable.DEVICE || typeVariable == typeVariable.LostTime)
            {
                G.sourceSQL = G.VariableSQL;
                LoadData(cbTab.Items[cbTab.SelectedIndex].ToString());
                G.curTab = cbTab.Items[cbTab.SelectedIndex].ToString();
            }
            else
            {
                G.sourceSQL = G.defautSQL;
                LoadData(cbTab.Items[cbTab.SelectedIndex].ToString());
                G.curTab = cbTab.Items[cbTab.SelectedIndex].ToString();
            }
        }

     

      
 
        

        private void btnNewDevice_Click(object sender, EventArgs e)
        {
            NewDevice.Show();
           
        }
        ScanAddIP ScanAddIP = new ScanAddIP();
        private void btnSacnIp_Click(object sender, EventArgs e)
        {
            ScanAddIP.Show();
        }
        NewVariable NewVariable ;
        private void btnNewVariable_Click(object sender, EventArgs e)
        {
            NewVariable.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DeleteAll("DEVICE");
            //DeleteAll("Global");
        }

        private void btnOnline_Click(object sender, EventArgs e)
        {
            int index = 0; bool blConnect = false;
            foreach (LisPLC LisPLC in G.LisPLC)
            {
                // AxDBCommManager plcTemp = new AxDBCommManager();

                DBPlcId eModel = (DBPlcId)Enum.Parse(typeof(MOD), LisPLC.Mod.Replace("-", ""));

                Via eVia = LisPLC.Via;


                G.LisPLC[index].plcKey = KEYENCEs.Create(eModel, eVia, LisPLC.Para);
                // G.LisPLC[index].plcKey = KEYENCE.KEYENCEs.Connnect(LisPLC.plcKey);
                G.LisPLC[index].isConnect = G.isConnect;
                if (G.isConnect == isConnect.Disconnected) blConnect = false;
                else blConnect = true;
                index++;
            }
            if (blConnect == true)
            { btnOnline.Image = Properties.Resources.online; btnStart.Enabled = true; }
            else{ btnOnline.Image = Properties.Resources.offline; btnStart.Enabled = false; }
            picMap.Invalidate();
            Refresh1 = new SFS_FV.SQL.Refresh();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            btnStop.Enabled = false;
            btnStart.Enabled = true;
        }
        Graphic Graphic = new Graphic();
        private void btnGraphic_Click(object sender, EventArgs e)
        {
            Graphic.Show();
        }
        CreateGraphic CreateGraphic = new CreateGraphic();
        private void btnCreateTool_Click(object sender, EventArgs e)
        {
            CreateGraphic.Show();
        }
        //CreateTool CreateTool = new CreateTool();
        private void btnCreateTool_Click_1(object sender, EventArgs e)
        {
            //CreateTool.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UPDATE_SQL(G.curTab);
        }

       

      
        TimeSpan span;

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer2.Enabled = true;
        }

       

        int number = 0;
       

        private void btnStart_Click(object sender, EventArgs e)
        {
            
            timer1.Enabled = true;
            LoadData("Global");
            btnStop.Enabled = true;

            btnStart.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            picMap.Invalidate();
          
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }
      
       
     
    }
}

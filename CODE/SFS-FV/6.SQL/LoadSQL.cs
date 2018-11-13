using AxDATABUILDERAXLibEx;
using DATABUILDERAXLibEx;
using SFS_FV.GRAPHIC;
using SFS_FV.Local;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SFS_FV.SQL
{
   public class LoadSQL
    {
        public  LoadSQL()
        {
            SQLITE SQLITE = new SQLITE();
            G.LisDevice = new List<string>();
            G.LisPLC = new List<LisPLC>();
            G.ListGraphic = new List<ListGraphic>();
            G.ListVariables = new List<ListVariables>();
            G.ListToolGr = new List<ToolGr>();
            G.ListToolChart = new List<GRAPHIC.ToolChart>();
            G.ListToolTemp = new List<ToolGr>();
         
            G.pPen = new Point(0, 0);
            





            G.sourceSQL = G.VariableSQL;
            DataTable dtDevice = new DataTable();
            DataTable dtVariable = new DataTable();
            DataTable dtCycleTime = new DataTable();
            DataTable dtYield = new DataTable();
            DataTable dtLostTime = new DataTable();
            DataTable dtToolQua = new DataTable();
            DataTable dtToolTime = new DataTable();
            DataTable dtChart = new DataTable();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("isCycle", isCycle.open.ToString());
            SQLITE.Update("CycleTime", dic, "", G.VariableSQL);
            dtDevice = SQLITE.SQL_Table("*", "DEVICE", "");
            dtVariable = SQLITE.SQL_Table("*", "Global", "");
            dtCycleTime = SQLITE.SQL_Table("*", "CycleTime", "");
            dtYield = SQLITE.SQL_Table("*", "Yield", "");
            dtLostTime = SQLITE.SQL_Table("*", "LostTime", "");
            G.sourceSQL = G.ToolSQL;
            bool blConnect = false;
            // SQLITE.DeleteAll("CHART");
            //   SQLITE.DeleteAll("Quantity");
            //   SQLITE.DeleteAll("Time");
            //SQLITE.DeleteAll("TOOL");
            //SQLITE.Delete("TOOL", "TYPE='Yield'");
            dtToolQua = SQLITE.SQL_Table("*", "Quantity", "");
            dtToolTime = SQLITE.SQL_Table("*", "Time", "");
            G.sourceSQL = G.ChartSQL;
            dtChart = SQLITE.SQL_Table("*", "CHART", "");
            G.sourceSQL = G.VariableSQL;
            // G.ListToolChart.Add(new ToolChart(G.ListToolTemp[cbTool.SelectedIndex], pOffset));
            foreach (DataRow DataRow in dtDevice.Rows)
            {
                AxDBCommManager plcTemp = new AxDBCommManager();

                DBPlcId eModel = (DBPlcId)Enum.Parse(typeof(MOD), DataRow[3].ToString().Replace("-", ""));

                Via eVia = (Via)Enum.Parse(typeof(Via), DataRow[4].ToString());


                //   plcTemp = KEYENCEs.Create(eModel, eVia, DataRow[5].ToString());
                if (G.isConnect == isConnect.Disconnected) blConnect = false;


                Image picModel = Image.FromFile(DataRow[3].ToString() + ".png");
                  Image picVia = Image.FromFile(DataRow[4].ToString() + ".png");
                G.LisPLC.Add(new LisPLC(DataRow[0].ToString(), DataRow[2].ToString(), DataRow[3].ToString(), eVia, DataRow[5].ToString(), plcTemp, G.isConnect, picModel, picVia, G.pPen));               
            }
            foreach (DataRow DataRow in dtVariable.Rows)
            {
                isBit isBit = (isBit)Enum.Parse(typeof(isBit), DataRow[6].ToString());
                typeBit typeBit = (typeBit)Enum.Parse(typeof(typeBit), DataRow[4].ToString());
                int i = 0;
                int index = 0;
                foreach (DataRow DataRow1 in dtDevice.Rows)
                {
                    if (DataRow1[0].ToString() == DataRow[1].ToString())
                    {
                        index = i;
                    }
                    i++;
                }
                G.ListVariables.Add(new ListVariables(DataRow[0].ToString(), G.LisPLC[index], DataRow[2].ToString(), DataRow[3].ToString(), DataRow[5].ToString(), isBit, typeBit, typeVariable2.Global));
            }
            foreach (DataRow DataRow in dtCycleTime.Rows)
            {

                int i = 0;
                int index = 0;
                foreach (DataRow DataRow1 in dtVariable.Rows)
                {
                    if (DataRow1[0].ToString() == DataRow[1].ToString())
                    {
                        index = i;
                    }
                    i++;
                }

                G.ListVariables.Add(new ListVariables(new CycleTime(DataRow[0].ToString(), G.ListVariables[index], DataRow[2].ToString(), int.Parse(DataRow[3].ToString()), int.Parse(DataRow[4].ToString()), new DateTime(), new DateTime(), isCycle.open, false), typeVariable2.CycleTime));
                //  LoadData("CycleTime");
            }
            foreach (DataRow DataRow in dtLostTime.Rows)
            {

                int i = 0;
                int index = 0;
                foreach (DataRow DataRow1 in dtVariable.Rows)
                {
                    if (DataRow1[0].ToString() == DataRow[1].ToString())
                    {
                        index = i;
                    }
                    i++;
                }
                G.ListVariables.Add(new ListVariables(new LostTime(DataRow[0].ToString(), G.ListVariables[index], DataRow[2].ToString(), int.Parse(DataRow[3].ToString()), int.Parse(DataRow[4].ToString()), new DateTime(), new DateTime(), isLost.open, false), typeVariable2.LostTime));
            }

            foreach (DataRow DataRow in dtYield.Rows)
            {

                int i = 0;
                int index = 0;
                string ListOKsql = "", ListNGsql = "";
                ListOKsql = DataRow[2].ToString();
                ListNGsql = DataRow[3].ToString();
                string[] ListOKsplit = ListOKsql.Split(',');
                string[] ListNGsplit = ListNGsql.Split(',');
                List<ListVariables> ListYieldOK = new List<ListVariables>();
                List<ListVariables> ListYieldNG = new List<ListVariables>();
                foreach (ListVariables ListVariables in G.ListVariables)
                {
                    foreach (string ListOK in ListOKsplit)
                    {
                        if (ListVariables.Name == ListOK)
                            ListYieldOK.Add(ListVariables);
                    }
                    foreach (string ListNG in ListNGsplit)
                    {
                        if (ListVariables.Name == ListNG)
                            ListYieldNG.Add(ListVariables);
                    }
                }
                foreach (DataRow DataRow1 in dtVariable.Rows)
                {

                    if (DataRow1[0].ToString() == DataRow[1].ToString())
                    {
                        index = i;
                    }
                    i++;
                }
                //Color red = Color.FromName("Red"); 
                G.ListVariables.Add(new ListVariables(new Yield(DataRow[0].ToString(), DataRow[1].ToString(), ListYieldOK, ListYieldNG), typeVariable2.Yield));
            }
            foreach (DataRow DataRow in dtToolQua.Rows)
            {
                var cvt = new FontConverter();
                String color = DataRow[5].ToString();
                Font fonts;
                try
                {
                     fonts = cvt.ConvertFromString(DataRow[6].ToString()) as Font;
                }
                catch
                {
                    fonts = new Font("Arial", 8);
                }
                String Fcolor = DataRow[7].ToString();
                color = color.Replace("Color [A=", "");
                color = color.Replace("]", "");
                color = color.Replace("Color [", "");
                color = color.Replace("R=", "");
                color = color.Replace("G=", "");
                color = color.Replace("B=", "");

                Fcolor = Fcolor.Replace("Color ", "");
                Fcolor = Fcolor.Replace("]", "");
                Fcolor = Fcolor.Replace("[", "");



                string[] splColor = color.Split(',');
                // string[] splFcolor = Fcolor.Split(',');

                SolidBrush backcolor;
                try
                {
                    backcolor = new SolidBrush(Color.FromArgb(int.Parse(splColor[0]), int.Parse(splColor[1]), int.Parse(splColor[2]), int.Parse(splColor[3])));
                }
                catch (Exception)
                {
                    backcolor = new SolidBrush(Color.FromName(color));
                }
                Color fontColor = Color.FromName(Fcolor);
                FontDialog fontDlg = new FontDialog();
                fontDlg.Color = fontColor;
                fontDlg.Font = fonts;
                int i = 0;
                int index = 0;
                foreach (ListVariables ListVariables in G.ListVariables)
                {
                    if (ListVariables.Name != null)
                    {
                        if (ListVariables.Name.ToString() == DataRow[2].ToString())
                        {

                            index = i;
                        }
                    }
                    else
                    {
                        if (ListVariables.Yield != null)
                        {
                            if (ListVariables.Yield.Name.ToString() == DataRow[2].ToString())
                            {

                                index = i;
                            }
                        }
                    }
                    i++;
                }
                //string Name,string sShow,TypeGr TypeGr,ListVariables ListVariables, Brush brFont,Color BackColor,int sizeFont,int defaut,Font font,bool isChar,bool isVal,bool isConst)
                TypeGr typeGr = (TypeGr)Enum.Parse(typeof(TypeGr), DataRow[1].ToString());
                G.ListToolGr.Add(new ToolGr(DataRow[0].ToString(), DataRow[3].ToString(), typeGr, G.ListVariables[index], new SolidBrush(fontDlg.Color), backcolor, int.Parse(DataRow[4].ToString()), int.Parse(DataRow[11].ToString()), fontDlg.Font, Boolean.Parse(DataRow[8].ToString()), Boolean.Parse(DataRow[9].ToString()), Boolean.Parse(DataRow[10].ToString())));
            }
            foreach (DataRow DataRow in dtToolTime.Rows)
            {
                var cvt = new FontConverter();
                String color = DataRow[5].ToString();
                Font fonts ;
                try
                {
                    fonts = cvt.ConvertFromString(DataRow[6].ToString()) as Font;
                }
                catch
                {
                    fonts = new Font("Arial", 8);
                }
                String Fcolor = DataRow[7].ToString();
                color = color.Replace("Color [A=", "");
                color = color.Replace("]", "");
                color = color.Replace("Color [", "");
                color = color.Replace("R=", "");
                color = color.Replace("G=", "");
                color = color.Replace("B=", "");

                Fcolor = Fcolor.Replace("Color ", "");
                Fcolor = Fcolor.Replace("]", "");
                Fcolor = Fcolor.Replace("[", "");



                string[] splColor = color.Split(',');
                // string[] splFcolor = Fcolor.Split(',');

                SolidBrush backcolor;
                try
                {
                    backcolor = new SolidBrush(Color.FromArgb(int.Parse(splColor[0]), int.Parse(splColor[1]), int.Parse(splColor[2]), int.Parse(splColor[3])));
                }
                catch (Exception)
                {
                    backcolor = new SolidBrush(Color.FromName(color));
                }
                Color fontColor = Color.FromName(Fcolor);
                FontDialog fontDlg = new FontDialog();
                fontDlg.Color = fontColor;
                fontDlg.Font = fonts;
                int i = 0;
                int index = 0;
                foreach (ListVariables ListVariables in G.ListVariables)
                {
                    if (ListVariables.CycleTime != null)
                    {
                        if (ListVariables.CycleTime.Name.ToString() == DataRow[2].ToString())
                        {

                            index = i;
                        }
                    }
                    else
                    {

                        //  if (ListVariables.LostTime.Name.ToString() == DataRow[2].ToString())
                        //  {

                        //     index = i;
                        //  }

                    }
                    i++;
                }
                //string Name,string sShow,TypeGr TypeGr,ListVariables ListVariables, Brush brFont,Color BackColor,int sizeFont,int defaut,Font font,bool isChar,bool isVal,bool isConst)
                TypeGr typeGr = (TypeGr)Enum.Parse(typeof(TypeGr), DataRow[1].ToString());
                G.ListToolGr.Add(new ToolGr(DataRow[0].ToString(), DataRow[3].ToString(), typeGr, G.ListVariables[index], new SolidBrush(fontDlg.Color), backcolor, Convert.ToDouble(DataRow[12].ToString()), fontDlg.Font, Boolean.Parse(DataRow[8].ToString()), Boolean.Parse(DataRow[9].ToString()), Boolean.Parse(DataRow[10].ToString())));
            }
            List<ToolChart> ToolChart = new List<GRAPHIC.ToolChart>();
            List<string> ListNameChart = new List<string>();
            string nameChart = ""; DateTime dtBegin = new DateTime(); int Reset = 0, Update = 0; Point pOffset = new Point();
            int indexRow = 0;
            foreach (DataRow DataRow in dtChart.Rows)
            {
                if (DataRow[0].ToString() != nameChart && nameChart != "")
                {
                    G.ListGraphic.Add(new ListGraphic(nameChart, ToolChart, G.ListData, dtBegin, Reset, Update, int.Parse(DataRow[5].ToString()), pOffset, int.Parse(DataRow[8].ToString()), bool.Parse(DataRow[9].ToString())));
                    ToolChart = new List<GRAPHIC.ToolChart>();
                }

                //  ToolChart.Clear();
                int i = 0;
                int index = 0;
                foreach (ToolGr ToolGr in G.ListToolGr)
                {
                    if (DataRow[1].ToString() == ToolGr.Name)
                    {
                        string[] ChartPoint = DataRow[6].ToString().Split(',');
                        ToolChart.Add(new ToolChart(ToolGr, new Point(int.Parse(ChartPoint[0]), int.Parse(ChartPoint[1]))));
                    }
                    i++;
                }
                G.ListData = new List<List<ListData>>();
                try
                {
                    dtBegin = DateTime.Parse(DataRow[2].ToString());
                }
                catch
                {
                    dtBegin = DateTime.Now;
                }
                
                dtBegin.AddYears(DateTime.Now.Year - dtBegin.Year);
                dtBegin.AddMonths(DateTime.Now.Month - dtBegin.Month);
                dtBegin.AddDays(DateTime.Now.Day - dtBegin.Day);
                Reset = int.Parse(DataRow[3].ToString());
                Update = int.Parse(DataRow[4].ToString());
                G.ListToolChart = ToolChart;
                UpdateGraphic(Reset, Update);


                string[] pOffsetSplit = DataRow[7].ToString().Split(',');
                pOffset = new Point(int.Parse(pOffsetSplit[0]), int.Parse(pOffsetSplit[1]));

                nameChart = DataRow[0].ToString();
                indexRow++;
                if (indexRow == dtChart.Rows.Count) 
                {
                    G.ListGraphic.Add(new ListGraphic(nameChart, ToolChart, G.ListData, dtBegin, Reset, Update, int.Parse(DataRow[5].ToString()), pOffset, int.Parse(DataRow[8].ToString()), bool.Parse(DataRow[9].ToString())));
                }
            }
            ///load Avatar
            //CREATE TABLE PIC ( NAME nvachar(50))
          
        }
             void UpdateGraphic(int MinReset, int MinUpdate)
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
                        G.ListData[G.ixData].Add(new ListData(ListToolChart, pDrawing, timer, cycle, lost,timelost));
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
        }
    }


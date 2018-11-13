using DATABUILDERAXLibEx;
using Microsoft.VisualBasic.Devices;
using Microsoft.VisualBasic.FileIO;
using SFS_FV.Data;
using SFS_FV.GRAPHIC;
using SFS_FV.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trestan;

namespace SFS_FV
{
    public partial class Graphic : Form
    {
        private BackgroundWorker myWorker = new BackgroundWorker();
        public Graphic()
        {
            InitializeComponent();
            TCResize resizeNote = new TCResize(this.pNote);
            TCResize resizePropeties = new TCResize(this.pPropeties);
            TCResize resizeShow = new TCResize(this.pShow);
            myWorker.DoWork += myWorker_DoWork;
            myWorker.RunWorkerCompleted += myWorker_RunWorkerCompleted;
            myWorker.ProgressChanged += myWorker_ProgressChanged;
            myWorker.WorkerReportsProgress = true;
            myWorker.WorkerSupportsCancellation = true;
        }

        void myWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Show the progress to the user based on the input we got from the background worker
           // lblStatus.Text = string.Format("Counting number: {0}...", e.ProgressPercentage);
        }

        void myWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null)//Check if the worker has been cancelled or if an error occured
            {
                string result = (string)e.Result;//Get the result from the background thread
              //  txtResult.Text = result;//Display the result to the user
               // lblStatus.Text = "Done";
            }
            else if (e.Cancelled)
            {
               // lblStatus.Text = "User Cancelled";
            }
            else
            {
               // lblStatus.Text = "An error has occured";
            }
            btnStart.Enabled = true;//Reneable the start button
        }

        void myWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker sendingWorker = (BackgroundWorker)sender;//Capture the BackgroundWorker that fired the event
            object[] arrObjects = (object[])e.Argument;//Collect the array of objects the we recived from the main thread

            int maxValue = (int)arrObjects[0];//Get the numeric value from inside the objects array, don't forget to cast
            StringBuilder sb = new StringBuilder();//Declare a new string builder to store the result.
        //    Online Online = new Online();
            for (int i = 1; i <= maxValue; i++)//Start a for loop
            {
                if (!sendingWorker.CancellationPending)//At each iteration of the loop, check if there is a cancellation request pending 
                {
                   // sb.Append(string.Format("Counting number: {0}{1}", PerformHeavyOperation(i), Environment.NewLine));//Append the result to the string builder
                   
                    sendingWorker.ReportProgress(i);//Report our progress to the main thread
                }
                else
                {
                    e.Cancel = true;//If a cancellation request is pending,assgine this flag a value of true
                    break;// If a cancellation request is pending, break to exit the loop
                }
            }

            e.Result = sb.ToString();// Send our result to the main thread!
        }
    

        private int PerformHeavyOperation(int i)
        {
            System.Threading.Thread.Sleep(100);
            return i * 1000;
        }
        List<int> ListValRec = new List<int>();
       
        int OffsetLine ;
       
        int numDrawing;
       bool blCycle;
        ToolChart ToolChart2;
        Point sizeDraw;
     
        private void picGraphic_Paint(object sender, PaintEventArgs e)
        {
            OffsetLine = picGraphic.Height;
           
               
                sizeDraw = new Point(picGraphic.Width, picGraphic.Height);
                Pen pen1 = new Pen(Color.Black, 3);
                Point pXaxis = new Point(40, sizeDraw.Y - 40);
                Point pXaxis2 = new Point(sizeDraw.X, sizeDraw.Y - 40);
                e.Graphics.DrawLine(pen1, pXaxis, pXaxis2);
                Point pYaxis = new Point(40, sizeDraw.Y - 40);
                Point pYaxis2 = new Point(40, 0);

                e.Graphics.DrawLine(pen1, pYaxis, pYaxis2);
                 numDrawing = Convert.ToInt32(ListGraphicTemp.TimeReset*60/ ListGraphicTemp.TimeUpdate);
                Point OffSetG = new Point(0, 0); bool blDrawBegin = false; int indexDr = 0;
                Point OffSetG2 = new Point(0, 0);
                int hour = ListGraphicTemp.TimeBegin.Hour;
                int min = ListGraphicTemp.TimeBegin.Minute;

                double zoomY = (double)(sizeDraw.Y - 40) / ListGraphicTemp.Max;
                List<List<Point>> pointL; pointL = new List<List<Point>>();
                List<List<Point>> pointCur = new List<List<Point>>();
                Rectangle rec11 = new Rectangle(sizeDraw.X - 200, 0, 200, 150);
             
                int offSetNote = 0;
                
                if (ListGraphicTemp.GIRD == true&&ListGraphicTemp!=null)
                {
                   

                        for (int i = 40; i < sizeDraw.X; i += sizeDraw.Y *ListGraphicTemp.MIN / ListGraphicTemp.Max)
                        {
                            e.Graphics.DrawLine(new Pen(Color.LightGray, 1), new Point(i, 0), new Point(i, sizeDraw.Y - 40));
                        }
                        for (int i = 0; i < sizeDraw.Y - 40; i += sizeDraw.Y * ListGraphicTemp.MIN / ListGraphicTemp.Max)
                        {
                            e.Graphics.DrawLine(new Pen(Color.LightGray, 1), new Point(40, i), new Point(sizeDraw.X, i));
                        }
                   
                }
        //    new SolidBrush(Color.FromArgb(50, 255, 255, 255))
                e.Graphics.DrawString("S", new Font("Arial", 144, FontStyle.Bold), new SolidBrush(Color.FromArgb(20, 0, 255, 255)), this.Width/4, this.Height/3);
                e.Graphics.DrawString("F", new Font("Arial", 144, FontStyle.Bold), new SolidBrush(Color.FromArgb(20, 50, 50, 50)), 2 * this.Width / 5 + 40, this.Height / 3);
                e.Graphics.DrawString("S", new Font("Arial", 144, FontStyle.Bold), new SolidBrush(Color.FromArgb(20, 0, 255, 255)), 3*this.Width / 5, this.Height / 3);
                e.Graphics.DrawString(ListGraphicTemp.Name, new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Blue), new Point(picGraphic.Width / 2 - (ListGraphicTemp.Name.Count() * picGraphic.Width / 200), picGraphic.Height / 16));

               
                for (int i = 0; i <= numDrawing; i++)
                {
                    int pTime = 0;
                    
                    foreach (ToolChart ListToolChart in ListGraphicTemp.ToolChart)
                    {
                        pTime += ListToolChart.pDrawing.X;
                    }
                    pTime = pTime / ListGraphicTemp.ToolChart.Count();

                    if (min >= 60)
                    {
                        hour++;
                        min = min - 60;
                    }
                    string sHour, sMin;
                    if (min < 10) sMin = "0" + min; else sMin = min + "";
                    if (hour < 10) sHour = "0" + hour; else sHour = hour + "";

                    Rectangle rec1 = new Rectangle(OffSetG2.X + ListGraphicTemp.ToolChart[0].pDrawing.X, sizeDraw.Y - 20, ListGraphicTemp.ToolChart[ListGraphicTemp.ToolChart.Count() - 1].pDrawing.X - ListGraphicTemp.ToolChart[0].pDrawing.X + ListGraphicTemp.ToolChart[ListGraphicTemp.ToolChart.Count() - 1].ToolGr.sizeFont, 20);
                    e.Graphics.DrawString(sHour + ":" + sMin, new Font("Arial", 12), Brushes.Black, new Point(pTime + OffSetG2.X, sizeDraw.Y - 20));
                    min += ListGraphicTemp.TimeUpdate;
                    OffSetG2.X += ListGraphicTemp.Offset.X;
                    OffSetG2.Y = ListGraphicTemp.Offset.Y;
                }

              
                    ListGraphic ListGraphic = ListGraphicTemp;

                    for (int k = 0; k < ListGraphic.ListData.Count; k++)
                    {
                        List<ListData> ListData = ListGraphic.ListData[k];
                        OffSetG = new Point(0, 0);
                        for (int m = 0; m < ListData.Count(); m++)
                        {
                            ListData Data = ListData[m];
                            ToolChart ToolChart = Data.ToolChart;
                            int ValueDrawing = Data.val;
                        if (ToolChart.ToolGr.TypeGr == TypeGr.Cycle)
                        {
                            if (blCycle == false) { ToolChart2 = ToolChart; blCycle = true; }
                            int W = sizeDraw.X - 40;
                            int H = sizeDraw.Y - 40;
                            int HH = Convert.ToInt32((ValueDrawing - G.zoom) * zoomY);
                            int P = Convert.ToInt32(((sizeDraw.Y - HH - ToolChart2.pDrawing.Y) / ToolChart2.ToolGr.maxTime) * ListGraphicTemp.Max);

                            Region rgn = new Region(new Rectangle(40, 0, W, H));
                            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                            Data.pDwaring.Clear();
                           
                        
                                if (Data.cycle.Count() > 0)
                                {
                                double valMax=0, valMin= 0, valTB = 0;
                                double svalMax=0, svalMin=0, svalTB=0;
                                    for (int n = 0; n < Data.cycle.Count(); n++)
                                    {
                                        double temp = (double)(Data.cycle[n] / ToolChart2.ToolGr.maxTime) * (sizeDraw.Y - 40);
                                        int Y = sizeDraw.Y - 40 - (int)temp;
                                        int X = (int)((Data.timer[n] / (ListGraphicTemp.TimeUpdate * numDrawing)) * (ListGraphicTemp.Offset.X * numDrawing))+40;
                                        if (n == 0) Data.pDwaring.Add(new Point(40, Y));
                                        Data.pDwaring.Add(new Point(X, Y));
                                        valTB += Y;
                                    svalTB += Data.cycle[n];
                                    if (n==0)
                                    {
                                        svalMax = Data.cycle[n];
                                        valMax = Y;

                                    }

                                    if (Y < valMax) { svalMax = Data.cycle[n]; valMax = Y; }
                                    if (Y > valMin)
                                    { svalMin = Data.cycle[n]; valMin = Y; }

                                }
                                svalTB= svalTB/ Data.cycle.Count();
                                valTB = valTB / Data.cycle.Count();
                                    Data.pDwaring.Add(new Point(Data.pDwaring[Data.pDwaring.Count() - 1].X, sizeDraw.Y - 40));
                                    Data.pDwaring.Add(new Point(sizeDraw.X, sizeDraw.Y - 40));
                                    Data.pDwaring.Add(new Point(sizeDraw.X, 0));
                                    Data.pDwaring.Add(new Point(40, 0));
                                    Data.pDwaring.Add(new Point(40, Data.pDwaring[0].Y));
                                    path.AddLines(Data.pDwaring.ToArray());
                                    rgn.Exclude(path);
                                    e.Graphics.FillRegion(ToolChart2.ToolGr.BackColor, rgn);
                                e.Graphics.DrawLine(new Pen(Color.Blue, ToolChart.ToolGr.sizeFont), new Point(40,Convert.ToInt32( valTB)), new Point(sizeDraw.X, Convert.ToInt32(valTB)));
                                e.Graphics.DrawLine(new Pen(Color.Red, ToolChart.ToolGr.sizeFont), new Point(40, Convert.ToInt32(valMax)), new Point(sizeDraw.X, Convert.ToInt32(valMax)));
                                e.Graphics.DrawLine(new Pen(Color.Green, ToolChart.ToolGr.sizeFont), new Point(40, Convert.ToInt32(valMin)), new Point(sizeDraw.X, Convert.ToInt32(valMin)));
                                e.Graphics.DrawString(Math.Round(svalTB, 2) + "s", ToolChart.ToolGr.font,new SolidBrush (Color.Blue), new Point(5, Convert.ToInt32(valTB)));
                                e.Graphics.DrawString(Math.Round(svalMax, 2) + "s", ToolChart.ToolGr.font, new SolidBrush(Color.Red), new Point(5, Convert.ToInt32(valMax)-20));
                                e.Graphics.DrawString(Math.Round(svalMin, 2) + "s", ToolChart.ToolGr.font, new SolidBrush(Color.Green), new Point(5, Convert.ToInt32(valMin)+20));
                                for (int ii = 0; ii < Data.cycle.Count(); ii++)
                                    {
                                        double temp = (double)(Data.cycle[ii] / ToolChart2.ToolGr.maxTime) * (sizeDraw.Y - 40);

                                        int Y = sizeDraw.Y - 40 - (int)temp;
                                        int X = (int)((Data.timer[ii] / (ListGraphicTemp.TimeUpdate * numDrawing)) * (ListGraphicTemp.Offset.X * numDrawing))+40;

                                        Point point1 = new Point(X, Y);
                                        Point pString = new Point(point1.X, point1.Y - 20);
                                        //Rectangle recCircle = new Rectangle(point1.X - 10, point1.Y - 5, 10, 10);
                                 //   e.Graphics.FillEllipse(ToolChart.ToolGr.brFont, recCircle);
                                    if (ToolChart.ToolGr.isVal == true)
                                        e.Graphics.DrawString(Math.Round( Data.cycle[ii],2) + "s", ToolChart.ToolGr.font, ToolChart.ToolGr.brFont, pString);
                                      
                                    }
                                }
                            if (Data.lost.Count() > 0)
                            {
                                for (int n = 0; n < Data.lost.Count(); n++)
                                {
                                    double temp = (double)(Data.cycle[Data.cycle.Count-1] / ToolChart2.ToolGr.maxTime) * (sizeDraw.Y - 40);
                                    int H2 = sizeDraw.Y - 140;
                                    int W2 = (int)((Data.lost[n] / (ListGraphicTemp.TimeUpdate * numDrawing)) * (ListGraphicTemp.Offset.X * numDrawing)) ;

                                    int X = (int)((Data.timeLost[n] / (ListGraphicTemp.TimeUpdate * numDrawing)) * (ListGraphicTemp.Offset.X * numDrawing)) + 40;
                                    //  pLost.Add(new Point( X, Y));
                                    Rectangle rec = new Rectangle(X - W2, H2, W2, 100 );
                                    e.Graphics.FillRectangle(new SolidBrush(Color.Red), rec);
                                    Point pString = new Point(X - W2, H2);
                                    Point pString2 = new Point(X - W2, H2+20);
                                   // e.Graphics.DrawString(Data.TimeBegin, ToolChart.ToolGr.font, new SolidBrush(Color.Black), pString);
                                    e.Graphics.DrawString(Data.lost[n] + "m", ToolChart.ToolGr.font, new SolidBrush(Color.White), pString2);
                                }
                            }
                        }
                            if (ToolChart.ToolGr.TypeGr == TypeGr.Line)
                            {
                                if (ToolChart.ToolGr.isConst == false)
                                {
                                    if (blDrawBegin == false)
                                        pointL.Add(new List<Point>());
                                    Pen pen = new Pen(ToolChart.ToolGr.BackColor, ToolChart.ToolGr.sizeFont);
                                    Brush br = ToolChart.ToolGr.brFont;
                                    int H = Convert.ToInt32((ValueDrawing - G.zoom) * zoomY);
                                    int P = sizeDraw.Y - Convert.ToInt32((H - G.zoom) * zoomY) - ToolChart.pDrawing.Y;
                                    OffsetLine = sizeDraw.Y - Convert.ToInt32((Convert.ToInt32((ValueDrawing - G.zoom) * zoomY) - G.zoom) * zoomY) - ToolChart.pDrawing.Y;;
                                    OffSetG.X = ListGraphic.Offset.X;
                                   // Data.values.Clear();
                                    for (int i = 0; i < Data.values.Count(); i++)
                                    {
                                        Data.values[i]=new Point(OffSetG.X * i + ToolChart.pDrawing.X, Data.values[i].Y);
                                    }
                                    OffSetG.X = 0;
                                    e.Graphics.DrawLines(pen, Data.values.ToArray());
                                    if (ToolChart.ToolGr.isVal)
                                    {

                                        for (int ii = 0; ii < Data.values.Count; ii++)
                                        {
                                            Point point1 = Data.values[ii];
                                            Point pString = new Point(point1.X, point1.Y - 20);
                                            Rectangle recCircle = new Rectangle(point1.X - 3, point1.Y - 3, 6, 6);
                                            e.Graphics.DrawString(ValueDrawing + "", ToolChart.ToolGr.font, br, pString);
                                            e.Graphics.FillEllipse(ToolChart.ToolGr.brFont, recCircle);
                                        }
                                    }
                                    if (ToolChart.ToolGr.isChar)
                                    {
                                        Point pLabel = new Point(sizeDraw.X - 50, P);
                                        e.Graphics.DrawString(ToolChart.ToolGr.sShow + "", ToolChart.ToolGr.font, br, pLabel);
                                    }
                                }
                                else
                                {
                                    if (blDrawBegin == false)
                                        pointL.Add(new List<Point>());


                                    Pen pen = new Pen(ToolChart.ToolGr.BackColor, ToolChart.ToolGr.sizeFont);
                                    Brush br = ToolChart.ToolGr.brFont;
                                   
                                    OffSetG.X = ListGraphic.Offset.X;
                                List<Point> ListTarget = new List<Point>();
                                    for (int i = 0; i <= numDrawing; i++)
                                    {
                                    int H = Convert.ToInt32((Data.values[i].Y - G.zoom) * zoomY);
                                    int P = sizeDraw.Y - H - ToolChart.pDrawing.Y;
                                    ListTarget.Add(new Point( OffSetG.X * i + ToolChart.pDrawing.X, P));
                                       // Data.values[i] = new Point);
                                    }
                                    OffSetG.X = 0;
                                    e.Graphics.DrawLines(pen, ListTarget.ToArray());
                                    if (ToolChart.ToolGr.isVal)
                                    {

                                        for (int ii = 0; ii < ListTarget.Count; ii++)
                                        {
                                            Point point1 = ListTarget[ii];
                                            Point pString = new Point(point1.X, point1.Y - 20);
                                            Rectangle recCircle = new Rectangle(point1.X - 3, point1.Y - 3, 6, 6);
                                            e.Graphics.DrawString(Data.values[ii].Y + "", ToolChart.ToolGr.font, br, pString);
                                            e.Graphics.FillEllipse(ToolChart.ToolGr.brFont, recCircle);
                                        }
                                    }
                                    if (ToolChart.ToolGr.isChar)
                                    {
                                       // Point pLabel = new Point(sizeDraw.X - 50, sizeDraw.Y/2);
                                       // e.Graphics.DrawString(ToolChart.ToolGr.sShow + "", ToolChart.ToolGr.font, br, pLabel);
                                    }
                                }
                                indexDr++;
                            }
                            if (ToolChart.ToolGr.TypeGr == TypeGr.Yield)
                            {
                                  
                                    Pen pen = new Pen(ToolChart.ToolGr.BackColor, ToolChart.ToolGr.sizeFont);
                                    Brush br = ToolChart.ToolGr.brFont;
                                    int H = Convert.ToInt32((ToolChart.ToolGr.defaut - G.zoom) * zoomY);
                                    int P = sizeDraw.Y - Convert.ToInt32((H - G.zoom) * zoomY) - ToolChart.pDrawing.Y;
                                    OffsetLine = sizeDraw.Y - Convert.ToInt32((Convert.ToInt32((ToolChart.ToolGr.defaut - G.zoom) * zoomY) - G.zoom) * zoomY) - ToolChart.pDrawing.Y; ;
                                    OffSetG.X = ListGraphic.Offset.X;
                                List<Point> pYield = new List<Point>();
                                    for (int i = 0; i < Data.valueYield.Count(); i++)
                                    {
                                    pYield.Add( new Point(OffSetG.X * i + ToolChart.pDrawing.X, sizeDraw.Y-Convert.ToInt32((double)(Data.valueYield[i]/100.0)* (sizeDraw.Y - 40-ListGraphic.Max/10))));
                                    }
                                    OffSetG.X = 0;
                                    e.Graphics.DrawLines(pen, pYield.ToArray());
                                    if (ToolChart.ToolGr.isVal)
                                    {

                                        for (int ii = 0; ii < pYield.Count; ii++)
                                        {
                                            Point point1 = pYield[ii];
                                            Point pString = new Point(point1.X, point1.Y - 20);
                                            Rectangle recCircle = new Rectangle(point1.X - 5, point1.Y , 5, 5);
                                        e.Graphics.FillEllipse(ToolChart.ToolGr.brFont, recCircle);
                                        e.Graphics.DrawString(Math.Round(Data.valueYield[ii], 2) + "%", ToolChart.ToolGr.font, br, pString);
                                           
                                        }
                                    }
                                    if (ToolChart.ToolGr.isChar)
                                    {
                                        Point pLabel = new Point(sizeDraw.X - 50, P);
                                        e.Graphics.DrawString(ToolChart.ToolGr.sShow + "", ToolChart.ToolGr.font, br, pLabel);
                                    }
                                
                            }
                                if (ToolChart.ToolGr.TypeGr == TypeGr.Rectanger)
                            {
                                //new Rectangle(ToolChart.pDrawing.X,G.zoom+ sizeDraw.Y - ToolChart.ToolGr.defaut- ToolChart.pDrawing.Y, ToolChart.ToolGr.sizeFont, ToolChart.ToolGr.defaut-G.zoom);
                                int H = Convert.ToInt32(zoomY * (ValueDrawing - G.zoom));
                                int P = sizeDraw.Y - H - ToolChart.pDrawing.Y;
                                Rectangle rec = new Rectangle(ToolChart.pDrawing.X + OffSetG.X, P, ToolChart.ToolGr.sizeFont, H);
                                //new Rectangle(10 + ToolChart.pDrawing.X + OffSetG.X, 20 - ToolChart.pDrawing.Y, ToolChart.ToolGr.sizeFont, sizeDraw.Y - 20);
                                Point point;

                                Brush br = ToolChart.ToolGr.brFont;
                                P = P - 20;
                                point = new Point(ToolChart.pDrawing.X + OffSetG.X, P);

                                // P = sizeDraw.Y - H - ToolChart.pDrawing.Y;
                                if (ToolChart.ToolGr.isVal)
                                {

                                    e.Graphics.DrawString(ValueDrawing + "", ToolChart.ToolGr.font, br, point);

                                }
                                if (ToolChart.ToolGr.isChar)
                                {
                                    // P = P + 20;
                                    Point pLabel = new Point(ToolChart.pDrawing.X + OffSetG.X, sizeDraw.Y - ToolChart.pDrawing.Y);

                                    //new Point(10 + ToolChart.ToolGr.sizeFont / 4 + ToolChart.pDrawing.X + OffSetG.X, sizeDraw.Y - 20 - ToolChart.pDrawing.Y);
                                    e.Graphics.DrawString(ToolChart.ToolGr.sShow + "", ToolChart.ToolGr.font, br, pLabel);
                                }
                                e.Graphics.FillRectangle(ToolChart.ToolGr.BackColor, rec);
                            }

                            indexDr = 0;
                            blDrawBegin = true;
                            OffSetG.X += ListGraphicTemp.Offset.X;
                            OffSetG.Y = ListGraphicTemp.Offset.Y;
                        }

                    }
                
            
        }
        DateTime dtBegin,dtNow;
   
        TimeSpan dtSpan2;
        int index=0;bool blStart;
        bool blStop;
        int indexMax = 0;
        bool blClearData=false;
        string sBegin = "";
        string sNow = "";
        DateTime tmBegin;
        
        private void timer1_Tick(object sender, EventArgs e)
        {

            foreach (ListGraphic ListGraphic in G.ListGraphic)
            {


                if (dtNow >= tmBegin && blStart == false)
                {
                    blClearData = false;

                  
                   

                 
                  btnNext.Enabled = true;
                   dtBegin = ListGraphic.TimeBegin;
                   dtBegin = dtBegin.AddMinutes((index + 1) * ListGraphic.TimeUpdate);
                    blStart = true;
                }
                numDrawing = Convert.ToInt32(ListGraphicTemp.TimeReset / ListGraphicTemp.TimeUpdate);
                dtNow = DateTime.Now;

                sBegin = dtBegin.ToString("hh:mm");
                sNow = dtNow.ToString("hh:mm");
                if (dtNow >= tmBegin)
                {
                   
                    for (int k = 0; k < ListGraphic.ListData.Count; k++)
                    {
                        List<ListData> ListData = ListGraphic.ListData[k];
                        if (ListData[0].ToolChart.ToolGr.TypeGr == TypeGr.Rectanger)
                        {
                            if (index != 0)
                                ListData[index].val = (Convert.ToInt32(ListData[index].ToolChart.ToolGr.ListVariables.Val) - ListData[index - 1].valTemp);
                            else
                                ListData[index].val = Convert.ToInt32(ListData[index].ToolChart.ToolGr.ListVariables.Val);
                            if (sBegin == sNow && blStart == true)
                            {
                                ListData[index].valTemp = int.Parse(ListData[index].ToolChart.ToolGr.ListVariables.Val);
                                blStop = true;
                                G.sourceSQL = G.ChartSQL;
                                string datenows = DateTime.Now.ToString("yyyy-MM-dd");
                                List<string> list = new List<string>();
                                int iShift = G.Shift + 1;
                                if (!SQLITE.CHECK("*", "DATA", "DATE='" + datenows + "' AND SHIFT ='" + iShift + "'  AND CHART ='" + ListGraphic.Name + "' AND TOOL ='" + ListData[0].ToolChart.ToolGr.Name + "'"))
                                {
                                    list.Add(datenows);
                                    list.Add(iShift + "");
                                    list.Add(ListGraphic.Name + "");
                                    list.Add(ListData[0].ToolChart.ToolGr.Name);
                                    string sYield = "";
                                    for (int i = 0; i < ListData.Count; i++)
                                    {
                                        sYield += ListData[i].val + ",";
                                    }
                                    sYield += Environment.NewLine;
                                    for (int i = 0; i < ListData.Count; i++)
                                    {
                                        sYield += ListData[i].valTemp + ",";
                                    }
                                    list.Add(sYield);

                                    SQLITE.Insert("DATA", list);
                                }
                                else
                                {
                                    string sYield = "";
                                    for (int i = 0; i < ListData.Count; i++)
                                    {
                                        sYield += ListData[i].val + ",";
                                    }
                                    sYield += Environment.NewLine;
                                    for (int i = 0; i < ListData.Count; i++)
                                    {
                                        sYield += ListData[i].valTemp + ",";
                                    }

                                    Dictionary<string, string> dic = new Dictionary<string, string>();
                                    dic.Add("VALUE", sYield + "");
                                    SQLITE.Update("DATA", dic, "DATE='" + datenows + "' AND SHIFT ='" + iShift + "'  AND CHART ='" + ListGraphic.Name + "' AND TOOL ='" + ListData[0].ToolChart.ToolGr.Name + "'", G.ChartSQL);
                                }
                            }
                        }
                        else if (ListData[0].ToolChart.ToolGr.TypeGr == TypeGr.Line)
                        {

                            if (ListData[0].ToolChart.ToolGr.isConst == false)
                                ListData[0].values[index] = new Point(0, OffsetLine - Convert.ToInt32(ListData[0].ToolChart.ToolGr.ListVariables.Val));
                           

                            if (sBegin == sNow && blStart == true)
                            {

                                blStop = true;
                            }
                        }
                        else if (ListData[0].ToolChart.ToolGr.TypeGr == TypeGr.Cycle)
                        {
                            if (ListData[0].ToolChart.ToolGr.ListVariables.CycleTime.isCycle == isCycle.close)
                            {
                                dtSpan2 = ListData[0].ToolChart.ToolGr.ListVariables.CycleTime.dtEnd - ListGraphic.TimeBegin;
                                if (Convert.ToDouble(ListData[0].ToolChart.ToolGr.ListVariables.CycleTime.cycleTime) >= ListData[0].ToolChart.ToolGr.maxTime / 2)
                                {
                                    if( ListData[0].cycle.Count != 0)
                                    ListData[0].cycle.Add(ListData[0].cycle[ListData[0].cycle.Count - 1]);
                                    else 
                                     ListData[0].cycle.Add(ListData[0].ToolChart.ToolGr.maxTime / 2);
                                    TimeSpan sp = ListData[0].ToolChart.ToolGr.ListVariables.CycleTime.dtEnd - ListData[0].ToolChart.ToolGr.ListVariables.CycleTime.dtBegin;
                                    double dbLost = sp.Hours * 60 + sp.Minutes + sp.Seconds / 60;
                                    ListData[0].lost.Add(dbLost);
                                    G.cycleTimeSum.Add(ListData[0].cycle[ListData[0].cycle.Count - 1]);
                                    G.lostTimeSumH += sp.Hours;
                                    G.lostTimeSumM += sp.Minutes;
                                    G.lostTimeSumS += sp.Seconds;
                                    if (G.lostTimeSumS>=60)
                                    {
                                        G.lostTimeSumS =G.lostTimeSumS- 60;
                                        G.lostTimeSumM++;
                                    }
                                    if (G.lostTimeSumM >= 60)
                                    {
                                        G.lostTimeSumM =G.lostTimeSumM - 60;
                                        G.lostTimeSumH++;
                                    }
                                    ListData[0].timeLost.Add(dtSpan2.Hours * 60 + dtSpan2.Minutes);
                                }
                            else
                                 ListData[0].cycle.Add(Convert.ToDouble(ListData[0].ToolChart.ToolGr.ListVariables.CycleTime.cycleTime));
                              
                                ListData[0].timer.Add(dtSpan2.Hours * 60 + dtSpan2.Minutes);
                                ListData[0].ToolChart.ToolGr.ListVariables.CycleTime.isCycle = isCycle.open;
                                if (sBegin == sNow && blStart == true)
                                {

                                    blStop = true;
                                    G.sourceSQL = G.ChartSQL;
                                    string datenows = DateTime.Now.ToString("yyyy-MM-dd");
                                    List<string> list = new List<string>();
                                    int iShift = G.Shift + 1;
                                    if (!SQLITE.CHECK("*", "DATA", "DATE='" + datenows + "' AND SHIFT ='" + iShift + "'  AND CHART ='" + ListGraphic.Name + "' AND TOOL ='" + ListData[0].ToolChart.ToolGr.Name + "'"))
                                    {
                                        list.Add(datenows);
                                        list.Add(iShift + "");
                                        list.Add(ListGraphic.Name + "");
                                        list.Add(ListData[0].ToolChart.ToolGr.Name);
                                        string sCycle = "";
                                        for (int i = 0; i < ListData[0].timer.Count; i++)
                                        {
                                            sCycle += ListData[0].timer[i] + ",";
                                        }
                                        sCycle += Environment.NewLine;
                                        for (int i = 0; i < ListData[0].cycle.Count; i++)
                                        {
                                            sCycle += ListData[0].cycle[i] + ",";
                                        }
                                        sCycle += Environment.NewLine;
                                        for (int i = 0; i < ListData[0].lost.Count; i++)
                                        {
                                            sCycle += ListData[0].lost[i] + ",";
                                        }
                                      
                                        list.Add(sCycle);

                                        SQLITE.Insert("DATA", list);
                                    }
                                    else
                                    {
                                        string sCycle = "";
                                        for (int i = 0; i < ListData[0].timer.Count; i++)
                                        {
                                            sCycle += ListData[0].timer[i] + ",";
                                        }
                                        sCycle += Environment.NewLine;
                                        for (int i = 0; i < ListData[0].cycle.Count; i++)
                                        {
                                            sCycle += ListData[0].cycle[i] + ",";
                                        }
                                        sCycle += Environment.NewLine;
                                        for (int i = 0; i < ListData[0].lost.Count; i++)
                                        {
                                            sCycle += ListData[0].lost[i] + ",";
                                        }
                                        sCycle += Environment.NewLine;
                                        Dictionary<string, string> dic = new Dictionary<string, string>();
                                        dic.Add("VALUE", sCycle + "");
                                        SQLITE.Update("DATA", dic, "DATE='" + datenows + "' AND SHIFT ='" + iShift + "'  AND CHART ='" + ListGraphic.Name + "' AND TOOL ='" + ListData[0].ToolChart.ToolGr.Name + "'", G.ChartSQL);
                                    }
                                
                            }
                            }


                        }
                        else if (ListData[0].ToolChart.ToolGr.TypeGr == TypeGr.Yield)
                        {

                            int valOk = 0;
                            for (int i = 0; i < ListData[0].ToolChart.ToolGr.ListVariables.Yield.ListOK.Count; i++)
                            {                                                               
                                    valOk += (int.Parse(ListData[0].ToolChart.ToolGr.ListVariables.Yield.ListOK[i].Val));
                            }
                            if (index != 0)
                                valOk -= ListData[0].tempOK[index - 1];
                                int valNG = 0;
                            for (int i = 0; i < ListData[0].ToolChart.ToolGr.ListVariables.Yield.ListNG.Count; i++)
                            {
                                
                                    valNG += (int.Parse(ListData[0].ToolChart.ToolGr.ListVariables.Yield.ListNG[i].Val));
                            }
                            if (index != 0)
                                valNG -= ListData[0].tempNG[index - 1];
                            if (valOk != 0)
                            {
                                double valYield = (double)(valOk / (valOk + valNG + 0.0) * 100.0);
                                ListData[0].valueYield[index] = valYield;

                                if (sBegin == sNow && blStart == true)
                                {
                                    ListData[0].tempOK[index] = 0;
                                    for (int i = 0; i < ListData[0].ToolChart.ToolGr.ListVariables.Yield.ListOK.Count; i++)
                                    {
                                        ListData[0].tempOK[index] += Convert.ToInt32(ListData[0].ToolChart.ToolGr.ListVariables.Yield.ListOK[i].Val);
                                    }
                                    ListData[0].tempNG[index] = 0;
                                    for (int i = 0; i < ListData[0].ToolChart.ToolGr.ListVariables.Yield.ListNG.Count; i++)
                                    {
                                        ListData[0].tempNG[index] += Convert.ToInt32(ListData[0].ToolChart.ToolGr.ListVariables.Yield.ListNG[i].Val);
                                    }
                                    blStop = true;
                                    G.sourceSQL = G.ChartSQL;
                                    string datenows = DateTime.Now.ToString("yyyy-MM-dd");
                                    List<string> list = new List<string>();
                                    int iShift = G.Shift + 1;
                                    if (!SQLITE.CHECK("*", "DATA", "DATE='" + datenows + "' AND SHIFT ='" + iShift + "'  AND CHART ='" + ListGraphic.Name + "' AND TOOL ='" + ListData[0].ToolChart.ToolGr.Name + "'"))
                                    {
                                        list.Add(datenows);
                                        list.Add(iShift + "");
                                        list.Add(ListGraphic.Name + "");
                                        list.Add(ListData[0].ToolChart.ToolGr.Name);
                                        string sYield = "";
                                        for(int i=0;i< ListData[0].valueYield.Count;i++)
                                        {
                                            sYield += ListData[0].valueYield[i]+",";
                                        }
                                        sYield += Environment.NewLine;
                                        for (int i = 0; i < ListData[0].tempOK.Count; i++)
                                        {
                                            sYield += ListData[0].tempOK[i] + ",";
                                        }
                                        sYield += Environment.NewLine;
                                        for (int i = 0; i < ListData[0].tempNG.Count; i++)
                                        {
                                            sYield += ListData[0].tempNG[i] + ",";
                                        }
                                        sYield += Environment.NewLine;
                                        list.Add(sYield);

                                        SQLITE.Insert("DATA", list);
                                    }
                                    else
                                    {
                                        string sYield = "";
                                        for (int i = 0; i < ListData[0].valueYield.Count; i++)
                                        {
                                            sYield += ListData[0].valueYield[i] + ",";
                                        }
                                        sYield += Environment.NewLine;
                                        for (int i = 0; i < ListData[0].tempOK.Count; i++)
                                        {
                                            sYield += ListData[0].tempOK[i] + ",";
                                        }
                                        sYield += Environment.NewLine;
                                        for (int i = 0; i < ListData[0].tempNG.Count; i++)
                                        {
                                            sYield += ListData[0].tempNG[i] + ",";
                                        }
                                        sYield += Environment.NewLine;
                                        Dictionary<string, string> dic = new Dictionary<string, string>();
                                        dic.Add("VALUE", sYield + "");
                                        SQLITE.Update("DATA", dic,  "DATE='" + datenows + "' AND SHIFT ='" + iShift + "'  AND CHART ='" + ListGraphic.Name + "' AND TOOL ='" + ListData[0].ToolChart.ToolGr.Name + "'",G.ChartSQL);
                                    }
                                }
                            }
                        }
                        if (blStop == true && k == ListGraphic.ListData.Count - 1)
                        {
                            blStart = false;
                            if (index < indexMax)
                            {
                                //  cmd.CommandText = " CREATE TABLE DATEHOUR (DATE nvachar(50),SHIFT nvachar(50),HOUR nvachar(50),VARIABLE nvachar(50), VALUE nvachar(50));"; //gancau lech cmd
                                /// cmd.ExecuteNonQuery();//thuc thi 
                                DATAHOUR DATAHOUR = new Data.DATAHOUR(sBegin);
                                index++;
                                cbTargetHour.SelectedIndex = index;
                            }
                            blStop = false;

                        }

                    }
                    picGraphic.Invalidate();
                }
                else
                {
                    if (blClearData == false)
                    {
                       
                    blClearData = true;
                }

                    }



            }
           
        }
       
        private void LoadForm()
        {
            LoadModelLine();
            LoadDataLine();
            LoadLine();
            LoadVariable();
           // InsertListTime();
        }
       // private BackgroundWorker myWorker = new BackgroundWorker();
        int numProcess = 0;
      
        private void loadss()
        {

           // int numericValue = (int)numericUpDownMax.Value;//Capture the user input
            object[] arrObjects = new object[] { 1 };//Declare the array of objects
          LoadSQLITE LoadSQLITE = new LoadSQLITE();
          /// load Avartar
          ListAvatar = new List<Image>();
          foreach (string path in G.sPicAvatar)
          {
              ListAvatar.Add(Image.FromFile(path));
          }

          if (ListAvatar.Count != 0)
          {
              tmAvatar.Enabled = true;
          }
       
            
       
        }
        private void Graphic_Load(object sender, EventArgs e)
        {
            picWait.SizeMode = PictureBoxSizeMode.StretchImage;
            picLoading.SizeMode = PictureBoxSizeMode.StretchImage;
           
            //timer1.Enabled = true;
            //cbMode.SelectedIndex = 0;
            int numericValue = 1;//Capture the user input

            object[] arrObjects = new object[] { numericValue };//Declare the array of objects
            System.Drawing.Image picCloud = new Bitmap("pic\\cloud.gif");
           // System.Drawing.Image myimageLoginErr = new Bitmap("error.gif");            
            numProcess = 1;
            // myWorker.RunWorkerAsync(arrObjects);//Call the background worker
            picWait.Image = picCloud;
            System.Drawing.Image picLoadings = new Bitmap("pic\\loading.gif");
            // System.Drawing.Image myimageLoginErr = new Bitmap("error.gif");            
            numProcess = 1;
            // myWorker.RunWorkerAsync(arrObjects);//Call the background worker

            picLoading.Image = picLoadings;
       
          
            loadss();

            
            System.Drawing.Image picLoadWifi = new Bitmap("pic\\online.gif");
            picWait.Image = picLoadWifi;
            G.sWatting = "ĐANG THIẾT LẬP ĐƯỜNG TRUYỀN VỚI THIẾT BỊ TRÊN  LINE !" + Environment.NewLine + Environment.NewLine + "VUI LÒNG ĐỢI  ^_^";
            lbWait.Text = G.sWatting;
            tmLoad.Enabled = true;
         
        }

        private void Graphic_Shown(object sender, EventArgs e)
        {
           // LoadForm();
        }

        private void picGraphic_Click(object sender, EventArgs e)
        {

        }

        private void Graphic_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            //btnStop.Enabled = false;
            btnStart.Enabled = true;
        }

        private void txtNGhour_MouseMove(object sender, MouseEventArgs e)
        {
          
        }

        private void picAvatar_MouseMove(object sender, MouseEventArgs e)
        {
          btnSubAvatar.Visible = true;
          btnPlusAvatar.Visible = true;
          btnGoAvatar.Visible = true;
          btnStartAvatar.Visible = true;
                
        }

        private void picAvatar_MouseLeave(object sender, EventArgs e)
        {
          //  btnSubAvatar.Visible = false;
           // btnPlusAvatar.Visible = false;
        }

        private void picGraphic_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void picGraphic_MouseHover(object sender, EventArgs e)
        {
             btnSubAvatar.Visible = false;
            btnPlusAvatar.Visible = false;
            btnGoAvatar.Visible = false;
            btnStartAvatar.Visible = false;
        }

        private void picAvatar_Paint(object sender, PaintEventArgs e)
        {
            if (imgAvartar!=null)
            {
                Rectangle rec = new Rectangle(0, 0, picAvatar.Width,  picAvatar.Height );

                e.Graphics.DrawImage(imgAvartar, rec);
            }
            
            
        }
        List<Image> ListAvatar = new List<Image>();
        private void btnPlusAvatar_Click(object sender, EventArgs e)
        {
            string PathFile;
            OpenFileDialog thisDialog = new OpenFileDialog();
            thisDialog.Filter = "Image (*.png*)|*.png*|Image (*.jpg*)|*.jpg*";
            thisDialog.FilterIndex = 2;
            thisDialog.RestoreDirectory = true;
            thisDialog.Multiselect = true;
            thisDialog.Title = "Chọn Avatar";

            if (thisDialog.ShowDialog() == DialogResult.OK)
            {

                PathFile = thisDialog.FileName;

                try
                {
                    Computer comp = new Computer();

            
            
                    string fileName = Path.GetFileName(PathFile);
                    comp.FileSystem.CopyFile(PathFile, "AVAR\\" + fileName, UIOption.AllDialogs, UICancelOption.DoNothing);
                    ListAvatar.Add( Image.FromFile(PathFile));
                    G.sourceSQL=G.DATASQL;
                    if(!SQLITE.CHECK("*","PIC","NAME='"+"AVAR\\" + fileName+"'"))
                    {
                        List<string> list=new List<string>();
                        list.Add( "AVAR\\" + fileName);
                        SQLITE.Insert("PIC", list);
                    }
                    imgAvartar = Image.FromFile(PathFile);
                    picAvatar.Invalidate();
                    ixAvatar = ListAvatar.Count() - 1;
                }
                catch (Exception)
                {

                }
            }
        }
        Image imgAvartar;
        int ixAvatar = 0;
        bool blStartAvatar;
        private void tmAvatar_Tick(object sender, EventArgs e)
        {
          
               
                imgAvartar = ListAvatar[ixAvatar];
            ixAvatar++;
            blStartAvatar = true;
            picAvatar.Invalidate();
            if (ixAvatar >= ListAvatar.Count) ixAvatar = 0;


        }
        
        private void btnStartAvatar_Click(object sender, EventArgs e)
        {
            if(blStartAvatar==false)
            {
                tmAvatar.Enabled = true;
                btnSubAvatar.Enabled = false;
                btnGoAvatar.Enabled = false;
                btnStartAvatar.BackgroundImage = Properties.Resources.Stop;
            }
            else
            {
                tmAvatar.Enabled = false;
                btnSubAvatar.Enabled = true;
                btnGoAvatar.Enabled = true;
                btnStartAvatar.BackgroundImage = Properties.Resources.Starts;
            }
            blStartAvatar = !blStartAvatar;
           
        }

        private void btnSubAvatar_Click(object sender, EventArgs e)
        {

            ixAvatar--;
            if (ixAvatar < 0) ixAvatar = ListAvatar.Count() - 1;
            G.sourceSQL=G.DATASQL;
            SQLITE.Delete("PIC", "NAME='" + G.sPicAvatar[ixAvatar] + "'");
            ListAvatar[ixAvatar].Dispose(); // this removes all resources
            System.IO.File.Delete(G.sPicAvatar[ixAvatar]);
            G.sPicAvatar.RemoveAt(ixAvatar);
           
            ListAvatar.RemoveAt(ixAvatar);
            

            ixAvatar = ListAvatar.Count() - 1;
            imgAvartar = ListAvatar[ixAvatar];
            picAvatar.Invalidate();
        }

        private void btnGoAvatar_Click(object sender, EventArgs e)
        {
            ixAvatar++;
            if (ixAvatar >= ListAvatar.Count) ixAvatar = 0;
            imgAvartar = ListAvatar[ixAvatar];
            picAvatar.Invalidate();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void tracShift_Scroll(object sender, EventArgs e)
        {
           // Enum a= (Shift)int.Parse(tracShift.Value + "");
            //txtShift.Text = a.ToString();
        }
        Clock Clock = new Clock();
        private void btnClock_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {

        }

        private void cbMode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbMode_Click(object sender, EventArgs e)
        {
         
            
                tmNextPage.Enabled = false;
           
        }
        ListGraphic ListGraphicTemp;
        int indexNext = 0;
        bool blLoadTimeChart = false;
        private void tmNextPage_Tick(object sender, EventArgs e)
        {
            
                ListGraphicTemp = G.ListGraphic[indexNext];
               // btnNext.Enabled = false;
                indexNext++;
                if (indexNext >= G.ListGraphic.Count) indexNext = 0;
                if (blLoadTimeChart == true)
                {
                    for (int i = 0; i < ListGraphicTemp.ListData.Count; i++)
                    {
                        List<ListData> ListData = ListGraphicTemp.ListData[i];
                       
                        if (ListData.Count == 1)
                        {
                            int hourBegin = ListGraphicTemp.TimeBegin.Hour;
                            int minBegin = ListGraphicTemp.TimeBegin.Minute;
                            string shour = "", smin = "";
                          //  cbTargetHour.Items.Clear();
                            G.ListDataTemp = new List<GRAPHIC.ListData>();

                            
                        }
                        blLoadTimeChart = false;
                    }
                }
                picGraphic.Invalidate();
                picNote.Invalidate();
              
                btnNext.Enabled = true;
            
        }

        private void numDelay_ValueChanged(object sender, EventArgs e)
        {
            tmNextPage.Interval =Convert.ToInt32( numDelay.Value * 1000);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
           
        }

        private void picGraphic_PaddingChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = int.Parse(G.ListVariables[0].Val) + 1;
            G.ListVariables[0].Val =a+ "";
        }
        bool blStartShow = false;
        private void InsertListTime()
        {
            G.sourceSQL = G.DATASQL;
           // ListDataTarget.values = new List<Point>();
            if (!SQLITE.CHECK("*", "LISTTIME", " SHIFT ='" + numShift.Value + "'"))
            {
                for (int i = 0; i < ListDataTarget.values.Count; i++)
                {
                    List<string> ListTime = new List<string>();

                  
                    ListTime.Add(numShift.Value + "");
                    ListTime.Add(cbTargetHour.Items[i].ToString());
                    ListTime.Add(ListDataTarget.values[i].Y.ToString());
                    SQLITE.Insert("LISTTIME", ListTime);
                }
            }
            else if(SQLITE.CHECK("*", "LISTTIME", " SHIFT ='" + numShift.Value + "'"))
            {
                List<string> ListTime = SQLITE.SQL_List(0, SQLITE.SQL_Table("TIME", "LISTTIME", "SHIFT ='" + numShift.Value + "'"));

                for (int i = 0; i < ListDataTarget.values.Count; i++)
                {
                    try
                    {
                        if (SQLITE.CHECK("*", "LISTTIME", " SHIFT ='" + numShift.Value + "' AND TIME ='" + ListTime[i] + "'"))
                        {
                            Dictionary<string, string> dic = new Dictionary<string, string>();
                            dic.Add("TIME", cbTargetHour.Items[i].ToString());
                            // dic.Add("TARGET", ListDataTarget.values[i].Y.ToString());
                            SQLITE.Update("LISTTIME", dic, "SHIFT ='" + numShift.Value + "' AND TIME ='" + ListTime[i] + "'", G.DATASQL);
                        }
                    }catch(Exception)
                    { 
                        List<string> ListTime1 = new List<string>();
                        ListTime1.Add(numShift.Value + "");
                        ListTime1.Add(cbTargetHour.Items[i].ToString());
                        ListTime1.Add(ListDataTarget.values[i].Y.ToString());
                        SQLITE.Insert("LISTTIME", ListTime1);
                    }
                    }
            }
            List<string> Listpoint=SQLITE.SQL_List(0, SQLITE.SQL_Table("TARGET", "LISTTIME", "SHIFT ='" + numShift.Value + "'"));
            for (int j = 0; j < Listpoint.Count; j++)
            {
                try
                {
                    ListDataTarget.values[j] = new Point(ListDataTarget.values[j].X, int.Parse(Listpoint[j]));
                }
                catch(Exception)
                {
                   // ListDataTarget.values.Add ( new Point(ListDataTarget.values[ListDataTarget.values.Count-1].X, int.Parse(Listpoint[j])));
                }
            }
            try
            {
                numTargetHour.Value = Convert.ToInt32(ListDataTarget.values[cbTargetHour.SelectedIndex].Y);
            }
            catch(Exception)
            {
              /*  numTargetHour.Value = numTargetHour.Maximum;*/
            }
           
            }
        private void UpdateListTime(int i)
        {
            G.sourceSQL = G.DATASQL;
                         
                    Dictionary<string, string> dic = new Dictionary<string, string>();                  
                    dic.Add("TARGET", ListDataTarget.values[i].Y.ToString());
                    SQLITE.Update("LISTTIME", dic, "SHIFT ='" + numShift.Value + "' AND TIME ='" + cbTargetHour.Items[i].ToString() + "'",G.DATASQL);                
            
        }
        private void UpdateGraphic(int MinReset, int MinUpdate)
        {
            G.ixData = 0;

            foreach (ToolChart ListToolChart in G.ListToolChart)
            {
                G.ListData.Add(new List<ListData>());
                int numDrawing = Convert.ToInt32(MinReset / MinUpdate);


                if (ListToolChart.ToolGr.TypeGr == TypeGr.Rectanger)
                {
                    int index = 0;
                    while (index <= numDrawing)
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
                        for (int i = 0; i <= numDrawing; i++)
                        {
                            values.Add(new Point(0, ListToolChart.ToolGr.defaut));
                        }
                        G.ListData[G.ixData].Add(new ListData(ListToolChart, values));
                    }
                    else
                    {
                        for (int i = 0; i <= numDrawing; i++)
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
                    for (int i = 0; i <= numDrawing; i++)
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
        private void LoadTarget()
        {
           List< List<ListData> >ListData=ListGraphicTemp.ListData;
         
        }
        private void TangCa()
        {
            try
            {
                OT OTs = (OT)Enum.Parse(typeof(OT), txtOT.Text);
                G.OTshift = (int)OTs;
            }
            catch (Exception)
            {

            }
            foreach (ListGraphic ListGraphic in G.ListGraphic)
            {
                ListGraphicTemp = ListGraphic;
                DateTime myDate;

                myDate = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd") + " " + G.listHShift[G.Shift] + ":52,531", "yyyy-MM-dd HH:mm:ss,fff",
                                  System.Globalization.CultureInfo.InvariantCulture);
                ListGraphicTemp.TimeBegin = myDate;
                int hourReset = ((G.OTshift) * 30 + 30) / 60;
                if (hourReset != 0)
                {
                    ListGraphicTemp.TimeReset = Convert.ToInt32(G.listDShift[G.Shift]) + hourReset;
                    G.ListData = new List<List<ListData>>();
                    G.ListToolChart = ListGraphicTemp.ToolChart;
                    UpdateGraphic(Convert.ToInt32(ListGraphicTemp.TimeReset * 60), ListGraphicTemp.TimeUpdate);
                    ListGraphicTemp.ListData = G.ListData;
                }
                else
                {
                    ListGraphicTemp.TimeReset = ListGraphicTemp.TimeReset / 60;
                }
            }
        }
        private void StartDraw()
        {
            tmLoad.Enabled = false;
            
                // btnStop.Enabled = true;
                tmChart.Interval = Convert.ToInt32(numUpdate.Value) * 1000;
                // btnStart.Enabled = false;
                index = 0;
                if (G.ListGraphic.Count != 0)
                {
                    LoadF = true;
                    LoadDataLine();

                    LoadLine();
                    ////
                    TangCa();
                    ListGraphicTemp = G.ListGraphic[0];
                    DateTime tmBegin = ListGraphicTemp.TimeBegin;
                    numDrawing = Convert.ToInt32(ListGraphicTemp.TimeReset * 60 / ListGraphicTemp.TimeUpdate);
                    indexMax = numDrawing;
                    for (int i = 0; i <= numDrawing; i++)
                    {

                        if (tmBegin.AddMinutes(i * ListGraphicTemp.TimeUpdate) < DateTime.Now)
                        {
                            index++;
                        }
                    }
                    Enum eModel;





                    LoadDataLine();

                    InsertListTime();
                    ListGraphicTemp = G.ListGraphic[0];
                    tmNextPage.Interval = Convert.ToInt32(numDelay.Value * 1000);
                    tmNextPage.Enabled = true;
                    tmChart.Enabled = true;
                    blLoadTimeChart = true;
                    tracOffChartX.Value = ListGraphicTemp.Offset.X;
                    dtNow = DateTime.Now;
                    if (index != 0) index--;
                    cbTargetHour.SelectedIndex = index;
                    tmBegin = ListGraphicTemp.TimeBegin;
                    tmBegin = tmBegin.AddMinutes(index * ListGraphicTemp.TimeUpdate);
                    timer1.Enabled = true;
                    tmNextPage.Enabled = true;
                  //   Online Online = new Online();

                    if (G.isConnect == isConnect.Disconnected)
                    {
                  //      this.Close();
                    }
                    else
                    {
                        pLoad.Visible = false;
                    }
                    pLoad.Visible = false;
                }
                
             
           
            
        }
        private void btnStarts_Click(object sender, EventArgs e)
        {
            if (blStartShow == false)
            {

                timer1.Enabled = true;
                tmChart.Enabled = true;
                tmNextPage.Enabled = true;
                btnStart.BackgroundImage = Properties.Resources.Stop;
            }
        else
        {
         timer1.Enabled = false;
         tmChart.Enabled = false;
    // blStart = false;
       tmNextPage.Enabled = false;
       btnStart.BackgroundImage = Properties.Resources.Starts;
        }
            blStartShow = !blStartShow;
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
                ListGraphicTemp = G.ListGraphic[indexNext];
                //btnNext.Enabled = false;
                indexNext++;
                if (indexNext >= G.ListGraphic.Count) indexNext = 0;
                picGraphic.Invalidate();
           
        }
        int indexShow = 0;
        private void tmLoadbtn_Tick(object sender, EventArgs e)
        {
        }
        bool blMenu;
        private void btnMenus_Click(object sender, EventArgs e)
        {
            if (blMenu == false)
            {
                pSetting.Visible = true;
                LoadForm();
            }
            else
            {

                pSetting.Visible = false;
            }
            blMenu = !blMenu;
            
        }

        private void tmHideBtn_Tick(object sender, EventArgs e)
        {
         
        }
        bool blMinimum;
        private void btnMinimum_Click(object sender, EventArgs e)
        {

           
                this.WindowState = FormWindowState.Minimized;
           
        }
        bool blSetting = false;
        
        private void LoadDataLine()
        {
            try
            {
                ListOKGr = new List<ListVariables>();
                ListNGGr = new List<ListVariables>();
                listOK.Items.Clear();
                listNG.Items.Clear();
                G.sourceSQL = G.DATASQL;
                DataTable dt = new DataTable();
                dt = SQLITE.SQL_Table("*", "LINE", "");
                txtELine.Text = SQLITE.SQL_List(1, dt)[0];
                cbEModel.SelectedIndex = cbEModel.FindStringExact(SQLITE.SQL_List(2, dt)[0]);
                numEMan.Value = int.Parse(SQLITE.SQL_List(3, dt)[0]);
                numEOP.Value = int.Parse(SQLITE.SQL_List(4, dt)[0]);
                numEOT.Value = int.Parse(SQLITE.SQL_List(5, dt)[0]);
                numEDate.Value = int.Parse(SQLITE.SQL_List(6, dt)[0]);
                numEhour.Value = int.Parse(SQLITE.SQL_List(7, dt)[0]);
                numUpdate.Value= int.Parse(SQLITE.SQL_List(10, dt)[0]);
                String[] splitOK = SQLITE.SQL_List(8, dt)[0].Split(',');
                String[] splitNG = SQLITE.SQL_List(9, dt)[0].Split(',');
                numMan.Maximum = numEMan.Value;
                numOP.Maximum = numEOP.Value;
                tracOT.Maximum =Convert.ToInt32( numEOT.Value)*2;
              //  G.OTshift= Convert.ToInt32(numEOT.Value);
                numTargetDate.Maximum = numEDate.Value;
                numTargetHour.Maximum = numEhour.Value;
                
                foreach (string s in splitOK)
                {
                    foreach(ListVariables ListVariables in G.ListVariables )
                    {
                        if(s== ListVariables.Name)
                        {
                            ListOKGr.Add(ListVariables);
                            listOK.Items.Add(ListVariables.Name);
                        }
                    }
                }
                foreach (string s in splitNG)
                {
                    foreach (ListVariables ListVariables in G.ListVariables)
                    {
                        if (s == ListVariables.Name)
                        {
                            ListNGGr.Add(ListVariables);
                            listNG.Items.Add(ListVariables.Name);
                        }
                    }
                }
                labMan.Text = "/" + numEMan.Value;
                labOP.Text = "/" + numEOP.Value;
                txtLine.Text = SQLITE.SQL_List(1, dt)[0];
                numTargetDate.Maximum = numEDate.Value;
                numTargetHour.Maximum = numEhour.Value;
            }
            catch(Exception)
            {

            }
            cbTarget.Items.Clear();
           
            foreach (ListGraphic ListGraphic in G.ListGraphic)
            {
               List< ToolChart> ToolChart = ListGraphic.ToolChart;
                foreach (ToolChart ToolChart1 in ToolChart)
                {
                    if (ToolChart1.ToolGr.TypeGr == TypeGr.Line)
                    {
                        if (ToolChart1.ToolGr.isConst == true)
                        {
                            cbTarget.Items.Add(ListGraphic.Name+","+ ToolChart1.ToolGr.Name);
                            
                        }
                    }
                }
            }
            if(cbTarget.Items.Count!=0)
            {
               
                cbTarget.SelectedIndex = 0;
                
            }
            DataTable dt2 = new DataTable();
            dt2 = SQLITE.SQL_Table("*", "TIME", "");
            string hShift1 = SQLITE.SQL_List(1, dt2)[0];
            string hShift2 = SQLITE.SQL_List(1, dt2)[1];
            string hShift3= SQLITE.SQL_List(1, dt2)[2];
            string dShift1 = SQLITE.SQL_List(2, dt2)[0];
            string dShift2 = SQLITE.SQL_List(2, dt2)[1];
            string dShift3 = SQLITE.SQL_List(2, dt2)[2];
            numShift1H.Value = Convert.ToInt32(hShift1.Split(':')[0]);
            numShift1P.Value = Convert.ToInt32(hShift1.Split(':')[1]);
            numShift2H.Value = Convert.ToInt32(hShift2.Split(':')[0]);
            numShift2P.Value = Convert.ToInt32(hShift2.Split(':')[1]);
            numShift3H.Value = Convert.ToInt32(hShift3.Split(':')[0]);
            numShift3P.Value = Convert.ToInt32(hShift3.Split(':')[1]);
            numShift1D.Value= Convert.ToInt32(dShift1);
            numShift2D.Value = Convert.ToInt32(dShift2);
            numShift3D.Value = Convert.ToInt32(dShift3);
            G.listHShift = new List<string>();
            G.listDShift = new List<string>();
            if (numShift1H.Value < 10) hShift1 = "0" + hShift1;
            if (numShift2H.Value < 10) hShift2 = "0" + hShift2;
            if (numShift3H.Value < 10) hShift3 = "0" + hShift3;

            G.listHShift.Add(hShift1);
            G.listHShift.Add(hShift2);
            G.listHShift.Add(hShift3);
            G.listDShift.Add(dShift1);
            G.listDShift.Add(dShift2);
            G.listDShift.Add(dShift3);
        }
        //Dictionary<int,int> indexTarget = new List<int, int>();
        private void LoadModelLine()
        {
            G.sourceSQL = G.DATASQL;
            DataTable dt = new DataTable();
           
            cbEModel.DataSource=SQLITE.SQL_List(0, SQLITE.SQL_Table("*", "MOD", ""));
        }
        List<int> indexOK = new List<int>();
        List<int> indexNG = new List<int>();
        
        ListData ListDataTarget;
        
        private void LoadVariable()
        {
            indexOK = new List<int>();
            indexNG = new List<int>();
            int index = 0;
            foreach (ListVariables ListVariables in G.ListVariables)
            {
                if (ListVariables.Name != null)
                {
                   
                    cbEOk.Items.Add(ListVariables.Name);
                    cbENg.Items.Add(ListVariables.Name);
                    indexOK.Add(index);
                    indexNG.Add(index);
                }
                index++;
            }
           

        }
        private void btnSetting_Click_1(object sender, EventArgs e)
        {
            if (blSetting == false)
            {
                LoadForm();
                pSetting.Visible = true;
                //btnSetting.BackColor = Color.Cornsilk;
            }
            else
            {
                pSetting.Visible = false;
               // btnSetting.BackColor = Color.White;
            }
            blSetting = !blSetting;
            
        }
        bool blClock;
        private void btnClock_Click_1(object sender, EventArgs e)
        {
            if (blClock == false)
            {
                Clock.Show();
                btnClock.BackColor = Color.LightBlue;
            }
            else
            {
                btnClock.BackColor = Color.White;
                Clock.Close();
               
            }
            blClock = !blClock;
           
        }
        bool blShowMove;
        private void btnShow_Click(object sender, EventArgs e)
        {
            if (blShowMove == false)
            {

                pShow.Size = szShow;
                btnShow.Visible = false;
                btnMiniShow.Visible = true;
                btnPinShow.Visible = true;
                pShow.Location = new Point(pShow.Location.X + 40, pShow.Location.Y);
               
            }
        }
        bool blPropeties;
        private void UpdateLine()
        {
            G.sourceSQL = G.DATASQL;
            if (SQLITE.CHECK("*", "DATADATE", "DATE='" + DateTime.Now.ToString("yyyy-MM-dd") + "'"))
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();

              //  dic.Add("",DateTime.Now.ToString("yyyy-MM-dd"));
                dic.Add("LINE", txtLine.Text);
                dic.Add("MOD", cbModel.Text);
                dic.Add("Shift", numShift.Value+"");
                dic.Add("Man", numMan.Value+labMan.Text+"");
                dic.Add("OP", numOP.Value + labOP.Text + "");
                dic.Add("OT", txtOT.Text + "");
                dic.Add("TargetDate", numTargetDate.Value+ "");
                SQLITE.Update("DATADATE", dic, "DATE='" + DateTime.Now.ToString("yyyy-MM-dd") + "'",G.DATASQL);
                MessageBox.Show("Đã Update dữ liệu Line thành công");
            }

        }
        private void LoadLine()
        {
            
                G.sourceSQL = G.DATASQL;
                if (SQLITE.CHECK("*", "DATADATE", "DATE='" + DateTime.Now.ToString("yyyy-MM-dd") + "'"))
                {
                    DataTable dt1 = new DataTable();
                    dt1 = SQLITE.SQL_Table("*", "DATADATE", "DATE='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
                    DataRow dtRow = dt1.Rows[0];
                    txtLine.Text = dtRow[1].ToString();
                    cbModel.Text = dtRow[2].ToString();

                    try
                    {
                        numShift.Value = int.Parse(dtRow[3].ToString());
                        numMan.Value = int.Parse(dtRow[4].ToString().Split('/')[0]);
                        numOP.Value = int.Parse(dtRow[5].ToString().Split('/')[0]);
                    }
                    catch(Exception)
                    {
                       /*numShift.Value = numShift.Maximum;
                        numMan.Value = numMan.Maximum;
                        numOP.Value = numOP.Maximum;*/
                    }
                    txtOT.Text = dtRow[6].ToString();
                    labMan.Text = "/" + dtRow[4].ToString().Split('/')[1];
                    labOP.Text = "/" + dtRow[5].ToString().Split('/')[1];
                   
                    try
                    {
                        OT OTs = (OT)Enum.Parse(typeof(OT), txtOT.Text);
                        G.OTshift = (int)OTs;
                    }
                    catch(Exception)
                    {

                    }
                    try
                    {
                        numTargetDate.Value = int.Parse(dtRow[7].ToString());
                    }
                    catch
                    {
                     /*  numTargetDate.Value = numTargetDate.Maximum;*/
                    }
                   
                    lbOk.Text = dtRow[8].ToString();
                    lbNG.Text = dtRow[9].ToString();
                    lbYield.Text = dtRow[10].ToString();
                    
                }
                else
                {
                    if (SQLITE.CHECK("*", "DATADATE", "DATE='" + DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + "'"))
                    {
                        DataTable dt1 = new DataTable();
                        dt1 = SQLITE.SQL_Table("*", "DATADATE", "DATE='" + DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + "'");
                        DataRow dtRow = dt1.Rows[0];
                        txtLine.Text = dtRow[1].ToString();
                        cbModel.Text = dtRow[2].ToString();

                        numShift.Value = int.Parse(dtRow[3].ToString());
                        numMan.Value = int.Parse(dtRow[4].ToString().Split('/')[0]);
                        numOP.Value = int.Parse(dtRow[5].ToString().Split('/')[0]);
                        txtOT.Text = dtRow[6].ToString();
                        labMan.Text = "/" + dtRow[4].ToString().Split('/')[1];
                        labOP.Text = "/" + dtRow[5].ToString().Split('/')[1];
                        try
                        {
                            OT OTs = (OT)Enum.Parse(typeof(OT), txtOT.Text);
                            G.OTshift = (int)OTs;
                        }
                        catch (Exception)
                        {

                        }
                        numTargetDate.Value = int.Parse(dtRow[7].ToString());
                        lbOk.Text = "0";
                        lbNG.Text = "0";
                        lbYield.Text = "0";
                        List<string> List = new List<string>();
                        List.Add(DateTime.Now.ToString("yyyy-MM-dd"));
                        List.Add(dtRow[1].ToString());
                        List.Add(dtRow[2].ToString());
                        List.Add(dtRow[3].ToString());
                        List.Add(dtRow[4].ToString());
                        List.Add(dtRow[5].ToString());
                        List.Add(dtRow[6].ToString());
                        List.Add(dtRow[7].ToString());
                        List.Add(dtRow[8].ToString());
                        List.Add(dtRow[9].ToString());
                        List.Add(dtRow[10].ToString());
                        SQLITE.Insert("DATADATE", List);

                    }
                    else
                    {

                        numShift.Value = 1;
                        numMan.Value = 0;
                        numOP.Value = 0;
                        txtOT.Text = "NONE";
                        numTargetDate.Value = 0;
                        List<string> List = new List<string>();
                        List.Add(DateTime.Now.ToString("yyyy-MM-dd"));
                        List.Add(txtLine.Text);
                        List.Add(cbModel.Text);
                        List.Add(numShift.Value + "");
                        List.Add(numMan.Value + labMan.Text + "");
                        List.Add(numOP.Value + labOP.Text + "");
                        List.Add(txtOT.Text + "");
                        List.Add(numTargetDate.Value + "");
                        List.Add("0");
                        List.Add("0");
                        List.Add("0");

                        SQLITE.Insert("DATADATE", List);
                    }
                }
               
          
           

        }
        bool blPropetiesMove;
        private void btnPropeties_Click(object sender, EventArgs e)
        {
            if (blPropetiesMove == false)
            {
                pPropeties.Size = szPropeties;
                btnPropeties.Visible = false;
                btnMenus.Visible = true;
            }
            
        }
        bool isFirst;
        bool toBlock;
        Point prevLeftClick;
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (blPinShow == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    blShowMove = true;
                    if (isFirst == true)
                    {
                        prevLeftClick = new Point(e.X, e.Y);
                        isFirst = false;
                    }
                    else
                    {
                        if (toBlock == false)
                            pShow.Location = new Point(pShow.Location.X + e.X - prevLeftClick.X, pShow.Location.Y + e.Y - prevLeftClick.Y);

                        prevLeftClick = new Point(e.X, e.Y);
                        toBlock = !toBlock;
                    }
                }
                else
                    isFirst = true;
            }
        }
        bool isFirst1;
        bool toBlock1;
        Point prevLeftClick1;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Y > 90 && e.Y < 150)
            {
                btnUpdateLine.Visible = true;
                btnMenus.Visible = true;
            }
            else
            {
                btnUpdateLine.Visible = false;
                btnMenus.Visible = false;
            }
         
            if (blPinPro == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (isFirst1 == true)
                    {
                        prevLeftClick1 = new Point(e.X, e.Y);
                        isFirst1 = false;
                    }
                    else
                    {

                        if (toBlock1 == false)
                            pPropeties.Location = new Point(pPropeties.Location.X + e.X - prevLeftClick1.X, pPropeties.Location.Y + e.Y - prevLeftClick1.Y);

                        prevLeftClick1 = new Point(e.X, e.Y);
                        toBlock1 = !toBlock1;
                    }
                }
                else
                    isFirst1 = true;
            }
        
        }
        bool isFirst2;
        bool toBlock2;
        Point prevLeftClick2;
        private void btnMenus_MouseMove(object sender, MouseEventArgs e)
        {
         
        }
        SQLITE SQLITE = new SQLITE();
        private void btnEApply_Click(object sender, EventArgs e)
        {
            G.sourceSQL = G.DATASQL;         
                List<string> List = new List<string>();
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("LINE", txtELine.Text);
                dic.Add("MOD", cbEModel.Text);
                dic.Add("maxMan", numEMan.Value + "");
                dic.Add("maxOP", numEOP.Value + "");
                dic.Add("maxOT", numEOT.Value + "");
                dic.Add("maxTargetDate", numEDate.Value + "");
                dic.Add("maxTargetHour", numEhour.Value + "");
           
            string sOk="";
            foreach(ListVariables ListVariables in ListOKGr)
            {
                sOk += ListVariables.Name + ",";
            }
            sOk = sOk.Substring(0, sOk.Length - 1);
            string sNG = "";
            foreach (ListVariables ListVariables in ListNGGr)
            {
                sNG += ListVariables.Name + ",";
            }
            sNG = sNG.Substring(0, sNG.Length - 1);
            dic.Add("varOK", sOk);
            dic.Add("varNG", sNG);
            dic.Add("timeUpdate", numUpdate.Value+"");
            SQLITE.Update("LINE", dic,"ID='ID'",G.DATASQL);

            numTargetHour.Maximum = numEhour.Value;
            numTargetDate.Maximum = numEDate.Value;
            dic = new Dictionary<string, string>();
            dic.Add("TIME", numShift1H.Value+":"+ numShift1P.Value);
            dic.Add("DELAY", numShift1D.Value+"");       
            SQLITE.Update("TIME", dic, "SHIFT='1'", G.DATASQL);
            dic = new Dictionary<string, string>();
            dic.Add("TIME", numShift2H.Value + ":" + numShift2P.Value);
            dic.Add("DELAY", numShift2D.Value + "");
            SQLITE.Update("TIME", dic, "SHIFT='2'", G.DATASQL);
            dic = new Dictionary<string, string>();
            dic.Add("TIME", numShift3H.Value + ":" + numShift3P.Value);
            dic.Add("DELAY", numShift3D.Value + "");
            SQLITE.Update("TIME", dic, "SHIFT='3'", G.DATASQL);
            ///
            if (SQLITE.CHECK("*", "DATADATE", "DATE='" + DateTime.Now.ToString("yyyy-MM-dd") + "'"))
            {
                Dictionary<string, string> dic1 = new Dictionary<string, string>();

                //  dic.Add("",DateTime.Now.ToString("yyyy-MM-dd"));
                dic1.Add("LINE", txtELine.Text);
                dic1.Add("MOD", cbEModel.Text);
                dic1.Add("Man", numMan.Value + "/" + numEMan.Value + "");
                dic1.Add("OP", numOP.Value + "/" + numEOP.Value + "");
                SQLITE.Update("DATADATE", dic1, "DATE='" + DateTime.Now.ToString("yyyy-MM-dd") + "'", G.DATASQL);
             ///   MessageBox.Show("Đã Update dữ liệu Line thành công");
            }
            LoadLine();
            MessageBox.Show("Đã sửa thông tin Line");
        }

        private void btnPlusModel_Click(object sender, EventArgs e)
        {
            G.sourceSQL = G.DATASQL;
            if (!SQLITE.CHECK("*", "MOD", ""))
            {
                List<string> List = new List<string>();
                List.Add(cbEModel.Text);
                SQLITE.Insert("MOD", List);
                MessageBox.Show("Đã thêm Model mới");
            }
            else
            {
                MessageBox.Show("Model  đã tồn tại");
            }
        }

        private void btnSubModel_Click(object sender, EventArgs e)
        {
            if (cbEModel.Text != "")
            {
                G.sourceSQL = G.DATASQL;
                SQLITE.Delete("MOD", "MOD='" + cbEModel.Text + "'");
                MessageBox.Show("Bạn đã xóa Model :" + cbEModel.Text);
                LoadModelLine();
            }
            else
            {
                MessageBox.Show("Vui lofgn chọn Model để xóa!" );
            }
        }

        private void btnUpdateLine_Click(object sender, EventArgs e)
        {
            UpdateLine();
        }
        List<ListVariables> ListOKGr = new List<ListVariables>();
        List<ListVariables> ListNGGr = new List<ListVariables>();
        private void cbEOk_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListOKGr.Add(G.ListVariables[indexOK[cbEOk.SelectedIndex]]);
            listOK.Items.Add(ListOKGr[ListOKGr.Count - 1].Name);
        }

        private void cbENg_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListNGGr.Add(G.ListVariables[indexNG[cbENg.SelectedIndex]]);
            listNG.Items.Add(ListNGGr[ListNGGr.Count - 1].Name);
        }

        private void listOK_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ListOKGr.Remove(ListOKGr[listOK.SelectedIndex]);
                listOK.Items.Remove(listOK.Items[listOK.SelectedIndex]);
            }
            catch(Exception)
            {

            }
           
        }

        private void listNG_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ListNGGr.Remove(ListNGGr[listNG.SelectedIndex]);
                listNG.Items.Remove(listNG.Items[listNG.SelectedIndex]);
            }
            catch(Exception)
            {

            }

        }
        int valOK = 0;
        int valNG = 0;
        double valYield = 0;
        double cycleMin = 10;
        double cycleMax = 0;
        double cycleMedium = 0;
        private void tmChart_Tick(object sender, EventArgs e)
        {
            valOK = 0; valNG = 0;
            foreach (ListVariables ListVariables in ListOKGr)
            {
                valOK+=int.Parse( ListVariables.Val);
            }
            foreach (ListVariables ListVariables in ListNGGr)
            {
                valNG += int.Parse(ListVariables.Val);
            }
            
            valYield =Math.Round( ((double)((valOK*1.0) / (valOK + valNG))) * 100.0,2);
            lbOk.Text = valOK+"";
            lbNG.Text = valNG + "";
            lbYield.Text = valYield + "%";
            int numVariable = 0;
            cycleMedium = 0;
            cycleMin = 10;
            cycleMax = 0;
            foreach (double cycleTimeSum in G.cycleTimeSum)
            {

                if (cycleTimeSum < cycleMin)
                    cycleMin = cycleTimeSum;
                if (cycleTimeSum > cycleMax)
                    cycleMax = cycleTimeSum;
                 numVariable++;
                 cycleMedium += cycleTimeSum;
                   
               
            }
            if (numVariable!=0)
            cycleMedium = (double)(cycleMedium / numVariable);
            lbCycleMax.Text = cycleMax+"";
            lbCycleMedium.Text = cycleMedium + "";
            lbCycleMin.Text = cycleMin + "";
            lbLostTimeH.Text = G.lostTimeSumH + "";
            lbLostTimeM.Text = G.lostTimeSumM + "";
            lbLostTimeS.Text = G.lostTimeSumS + "";
        }

        private void cbTargetHour_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LoadF == true)
                if (cbTargetHour.SelectedIndex != cbTargetHour.Items.Count - 1)
                    try
                    {

                        numTargetHour.Value = Convert.ToInt32(ListDataTarget.values[cbTargetHour.SelectedIndex].Y);

                    }
                    catch(Exception)
                    {
                      /*  numTargetHour.Value = numTargetHour.Maximum;
                        for (int i = 0; i < ListDataTarget.values.Count; i++)
                        {
                            ListDataTarget.values[i] = new Point(ListDataTarget.values[i].X, Convert.ToInt32(numTargetHour.Value));
                        }*/
                        picGraphic.Invalidate();
                    }
        }
           
        ListGraphic ListgraphicTarget;
        bool LoadF = false;
        private void cbTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LoadF == true)
            {
                foreach (ListGraphic ListGraphic in G.ListGraphic)
                {
                    List<List<ListData>> ListData = ListGraphic.ListData;
                    foreach (List<ListData> ListData1 in ListData)
                    {
                        foreach (ListData ListData2 in ListData1)
                        {
                            if (cbTarget.Items[cbTarget.SelectedIndex].ToString().Split(',')[0] == ListGraphic.Name)
                            {
                                if (cbTarget.Items[cbTarget.SelectedIndex].ToString().Split(',')[1] == ListData2.ToolChart.ToolGr.Name)
                                {
                                    ListgraphicTarget = ListGraphic;
                                    ListDataTarget = ListData2;
                                }
                            }

                        }
                    }
                }
                int hourBegin = ListgraphicTarget.TimeBegin.Hour, minBegin = ListgraphicTarget.TimeBegin.Minute;
                string shour = "", smin = ""; cbTargetHour.Items.Clear();
                for (int j = 0; j < ListDataTarget.values.Count(); j++)
                {


                    if (hourBegin < 10) shour = "0" + hourBegin;
                    else shour = hourBegin + "";
                    if (minBegin < 10) smin = "0" + minBegin;
                    else smin = minBegin + "";
                    cbTargetHour.Items.Add(shour + ":" + smin);

                    minBegin += ListgraphicTarget.TimeUpdate;
                    if (minBegin >= 60)
                    {
                        minBegin = minBegin - 60;
                        hourBegin++;
                    }
                    if (hourBegin >= 24)
                    {
                        hourBegin = hourBegin - 24;
                    }




                }
                cbTargetHour.Items.Add("Target All");
                if (cbTargetHour.Items.Count != 0)
                {
                    cbTargetHour.SelectedIndex = 0;
                }
            }
        }

        private void numTargetHour_ValueChanged(object sender, EventArgs e)
        {
            if (cbTargetHour.SelectedIndex == cbTargetHour.Items.Count - 1)
            {
                for(int i=0;i< ListDataTarget.values.Count;i++ )
                {
                    ListDataTarget.values[i] = new Point(ListDataTarget.values[i].X, Convert.ToInt32(numTargetHour.Value));
                }
            }
            else
                ListDataTarget.values[cbTargetHour.SelectedIndex] =new Point(ListDataTarget.values[cbTargetHour.SelectedIndex].X, Convert.ToInt32( numTargetHour.Value));
            picGraphic.Invalidate();
        }

        private void btnUpdateTarget_Click(object sender, EventArgs e)
        {
            if (cbTargetHour.SelectedIndex != -1)
            {
                if (cbTargetHour.SelectedIndex == cbTargetHour.Items.Count - 1)
                {
                    for (int i = 0; i < ListDataTarget.values.Count; i++)
                    {
                        UpdateListTime(i);
                    }
                }
                else
                {

                    UpdateListTime(cbTargetHour.SelectedIndex);
                }
            }
            picTick.Visible = true;
            tmTick.Enabled = true;
           
        }

        private void label27_Click(object sender, EventArgs e)
        {
        }

        private void tmTick_Tick(object sender, EventArgs e)
        {
            picTick.Visible = false;
        }
        bool isFirst4;
        bool toBlock4;
        Point prevLeftClick4;
        private void pSetting_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void picNote_Paint(object sender, PaintEventArgs e)
        {
            int offSetNote =0;

            if (ListGraphicTemp != null)
            {
                foreach (ToolChart ListToolChart in ListGraphicTemp.ToolChart)
                {
                   
                    if (ListToolChart.ToolGr.TypeGr == TypeGr.Rectanger)
                    {
                        Rectangle rec1 = new Rectangle(5, offSetNote + 5, 20, 20);
                        e.Graphics.FillRectangle(ListToolChart.ToolGr.BackColor, rec1);
                        e.Graphics.DrawString(ListToolChart.ToolGr.sShow, ListToolChart.ToolGr.font, Brushes.Black, new Point(25, offSetNote+ 5));

                    }
                    if (ListToolChart.ToolGr.TypeGr == TypeGr.Line || ListToolChart.ToolGr.TypeGr == TypeGr.Yield)
                    {
                        Rectangle rec1 = new Rectangle(5, offSetNote + 40, 20, 20);
                        e.Graphics.DrawLine(new Pen(ListToolChart.ToolGr.BackColor, ListToolChart.ToolGr.sizeFont), 5, offSetNote +20, 25, offSetNote + 20);
                        e.Graphics.DrawString(ListToolChart.ToolGr.sShow, ListToolChart.ToolGr.font, Brushes.Black, new Point(25, offSetNote + 5));

                    }
                    if (ListToolChart.ToolGr.TypeGr == TypeGr.Cycle)
                    {

                        Region rgn = new Region(new Rectangle(5, offSetNote + 5, 20, 20));
                        System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                        List<Point> point2 = new List<Point>();
                        point2.Add(new Point(5, offSetNote + 40));
                        point2.Add(new Point(5 + 10, offSetNote + 35));
                        point2.Add(new Point(5 + 20, offSetNote + 40));
                        point2.Add(new Point(5 + 20, offSetNote + 30));
                        point2.Add(new Point(5, offSetNote + 30));
                        point2.Add(new Point(5, offSetNote + 40));

                        path.AddCurve(point2.ToArray());
                        // path.AddLine(60, 60, 100, 100);
                        rgn.Exclude(path);
                        // Graphics g = this.CreateGraphics();
                        //   string redHex = colorDlg.Color.R;
                        // colorDlg.FR
                        e.Graphics.FillRegion(ListToolChart.ToolGr.BackColor, rgn);

                        e.Graphics.DrawString(ListToolChart.ToolGr.sShow, ListToolChart.ToolGr.font, Brushes.Black, new Point(25, offSetNote + 5));

                    }
                    offSetNote += 30;
                }
            }
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
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
                        pSetting.Location = new Point(pSetting.Location.X + e.X - prevLeftClick4.X, pSetting.Location.Y + e.Y - prevLeftClick4.Y);

                    prevLeftClick4 = new Point(e.X, e.Y);
                    toBlock4 = !toBlock4;
                }
            }
            else
                isFirst4 = true;
        }
        bool isFirst5;
        bool toBlock5;
        Point prevLeftClick5;
        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {
            if (blPinNote == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (isFirst5 == true)
                    {
                        prevLeftClick5 = new Point(e.X, e.Y);
                        isFirst5 = false;
                    }
                    else
                    {
                        if (toBlock5 == false)
                            pNote.Location = new Point(pNote.Location.X + e.X - prevLeftClick5.X, pNote.Location.Y + e.Y - prevLeftClick5.Y);

                        prevLeftClick5 = new Point(e.X, e.Y);
                        toBlock5 = !toBlock5;
                    }
                }
                else
                    isFirst5 = true;
            }
        }

        private void picNote_MouseMove(object sender, MouseEventArgs e)
        {
            if (blPinNote == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (isFirst5 == true)
                    {
                        prevLeftClick5 = new Point(e.X, e.Y);
                        isFirst5 = false;
                    }
                    else
                    {
                        if (toBlock5 == false)
                            pNote.Location = new Point(pNote.Location.X + e.X - prevLeftClick5.X, pNote.Location.Y + e.Y - prevLeftClick5.Y);

                        prevLeftClick5 = new Point(e.X, e.Y);
                        toBlock5 = !toBlock5;
                    }
                }
                else
                    isFirst5 = true;
            }
        }
        bool blPinNote = false;
        private void btnPinNote_Click(object sender, EventArgs e)
        {
            if(blPinNote==false)
            {
                pNote.BringToFront();
              btnPinNote.BackgroundImage=  Properties.Resources.pin;
            }          
            else
            {
                pNote.SendToBack();
                btnPinNote.BackgroundImage = Properties.Resources.unpin;
            }
            picGraphic.SendToBack();
            blPinNote = !blPinNote;
        }
        bool blPinPro = false;
        private void btnPinPropeties_Click(object sender, EventArgs e)
        {
            if (blPinPro == false)
            {

                pPropeties.BringToFront();
                btnPinPropeties.BackgroundImage = Properties.Resources.pin;
            }
            else
            {
                pPropeties.SendToBack();
                btnPinPropeties.BackgroundImage = Properties.Resources.unpin;
            }
            picGraphic.SendToBack();
            blPinPro = !blPinPro;
        }

        private void btnNote_MouseMove(object sender, MouseEventArgs e)
        {
            if (blPinNote == false)
            {
                
                if (e.Button == MouseButtons.Left)
                {
                    blNoteMove = true;
                    if (isFirst5 == true)
                    {
                        prevLeftClick5 = new Point(e.X, e.Y);
                        isFirst5 = false;
                    }
                    else
                    {
                        if (toBlock5 == false)
                            pNote.Location = new Point(pNote.Location.X + e.X - prevLeftClick5.X, pNote.Location.Y + e.Y - prevLeftClick5.Y);

                        prevLeftClick5 = new Point(e.X, e.Y);
                        toBlock5 = !toBlock5;
                    }
                }
                else
                    isFirst5 = true;
            }
        }
        bool blNoteMove;
        Size szNote;
        private void btnNote_MouseClick(object sender, MouseEventArgs e)
        {
            if (blNoteMove == false)
            {
                pNote.Size = szNote;
                btnNote.Visible = false;
                pNote.Location = new Point(pNote.Location.X + 40, pNote.Location.Y);
            }
           // else
              //  pNote.Size = btnNote.Size;
           // blNotes = !blNotes;
        }

        private void ntmMinNote_Click(object sender, EventArgs e)
        {
            szNote = pNote.Size;
            pNote.Size = new Size(btnNote.Width + 3, btnNote.Height + 3);

            btnNote.Visible = true;
            pNote.Location = new Point(pNote.Location.X - 40, pNote.Location.Y);
            
        }

        private void btnNote_MouseUp(object sender, MouseEventArgs e)
        {
            blNoteMove = false;
        }

        private void btnNote_Click(object sender, EventArgs e)
        {
            

           
        }
        Size szPropeties;
        private void btnMiniPropeties_Click(object sender, EventArgs e)
        {
            szPropeties = pPropeties.Size;
            pPropeties.Size = new Size(btnPropeties.Width + 3, btnPropeties.Height + 3);
            pSetting.Visible = false;
            btnMenus.Visible = false;
            btnPropeties.Visible = true;
        }

        private void btnPropeties_MouseUp(object sender, MouseEventArgs e)
        {
            blPropetiesMove = false;
        }

        private void btnPropeties_MouseMove(object sender, MouseEventArgs e)
        {
            if (blPinPro == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    blPropetiesMove = true;
                    if (isFirst1 == true)
                    {
                        prevLeftClick1 = new Point(e.X, e.Y);
                        isFirst1 = false;
                    }
                    else
                    {

                        if (toBlock1 == false)
                            pPropeties.Location = new Point(pPropeties.Location.X + e.X - prevLeftClick1.X, pPropeties.Location.Y + e.Y - prevLeftClick1.Y);

                        prevLeftClick1 = new Point(e.X, e.Y);
                        toBlock1 = !toBlock1;
                    }
                }
                else
                    isFirst1 = true;
            }

        }

        private void btnECancel_Click(object sender, EventArgs e)
        {
            pSetting.Visible = false;
            blMenu = false;
        }
        bool blPinShow;
        private void btnPinShow_Click(object sender, EventArgs e)
        {
            if (blPinShow == false)
            {

                pShow.BringToFront();
                btnPinShow.BackgroundImage = Properties.Resources.pin;
            }
            else
            {
                pShow.SendToBack();
                btnPinShow.BackgroundImage = Properties.Resources.unpin;
            }
            picGraphic.SendToBack();
            blPinShow = !blPinShow;
        }
        Size szShow;
        private void btnMiniShow_Click(object sender, EventArgs e)
        {
            
            szShow = pShow.Size;
            pShow.Size = new Size(btnShow.Width + 3, btnShow.Height + 3);
           
            btnShow.Visible = true;
            btnMiniShow.Visible = false;
            btnPinShow.Visible = false;
            pShow.Location = new Point(pShow.Location.X - 40, pShow.Location.Y);
        }

        private void btnShow_MouseUp(object sender, MouseEventArgs e)
        {
            blShowMove = false;
        }

        private void btnShow_MouseMove(object sender, MouseEventArgs e)
        {
            if (blPinShow == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    blShowMove = true;
                    if (isFirst == true)
                    {
                        prevLeftClick = new Point(e.X, e.Y);
                        isFirst = false;
                    }
                    else
                    {
                        if (toBlock == false)
                            pShow.Location = new Point(pShow.Location.X + e.X - prevLeftClick.X, pShow.Location.Y + e.Y - prevLeftClick.Y);

                        prevLeftClick = new Point(e.X, e.Y);
                        toBlock = !toBlock;
                    }
                }
                else
                    isFirst = true;
            }
        }
        Point OffSet = new Point();
        private void tracOffChartX_Scroll(object sender, EventArgs e)
        {
            OffSet.X = tracOffChartX.Value;
           
          
                ListGraphicTemp.Offset = OffSet;
            picGraphic.Invalidate();
            
        }

        private void btnUpdateShow_Click(object sender, EventArgs e)
        {
            //CPOINT
            Dictionary<String, String> dic = new Dictionary<string, string>();
            dic.Add("CPOINT", ListGraphicTemp.Offset.X + "," + ListGraphicTemp.Offset.Y);
            SQLITE.Update("CHART", dic, "NAME='" + ListGraphicTemp.Name + "'", G.ChartSQL);
            MessageBox.Show("Đã thay đổi khoảng cách thời gian !");
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            
                ListGraphicTemp = G.ListGraphic[indexNext];
                //btnNext.Enabled = false;
                indexNext--;
                if (indexNext <0 ) indexNext = G.ListGraphic.Count-1;
                picGraphic.Invalidate();
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            G.ListVariables[0].Val =( int.Parse(G.ListVariables[0].Val) + 1).ToString();
        }

        private void tracOT_Scroll(object sender, EventArgs e)
        {
            Enum a = (OT)int.Parse(tracOT.Value + "");

             txtOT.Text = a.ToString();
             TangCa();
        }

        SQLITE cSql =new SQLITE();
        ReadData ReadData;
        private void tmReadData_Tick(object sender, EventArgs e)
        {
            ReadData = new ReadData(); 
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            
          

        }

        private void Online()
        {
          
            G.blOnline = true;
        }
        private void tmLoad_Tick(object sender, EventArgs e)
        {
            StartDraw();
            btnStart.BackgroundImage = Properties.Resources.Stop;
            blStartShow = !blStartShow;
            if (G.isConnect == isConnect.Connected)
            {
                Refresh Refresh = new SQL.Refresh();
                tmReadData.Enabled = true;
            }
            Clock.Show();
            btnClock.BackColor = Color.LightBlue;
            blClock = !blClock;
            Clock.Location = new Point(300, 10);
        }
        Error Error;

        private void tmOnline_Tick(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Drawing.Image piconline = new Bitmap("pic\\online.gif");
            picWait.Image = piconline;
            G.blSQLITE = false;
          //  tmOnline.Enabled = true;
            var cancellationToken = new CancellationTokenSource(TimeSpan.FromSeconds(15)).Token;

           // while (!cancellationToken.IsCancellationRequested)
            //{
                Online();
           // }
         //   Thread t = new Thread(Online);
            G.sWatting = "Đang kết nối với mạng với PLC .......";
            lbWait.Text = G.sWatting;
           
        }

        private void btnClock_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void picGraphic_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.X>this.Width-50 && e.Y<50)
            {
                btnClock.Visible = true;
                btnMinimum.Visible = true;
            }
            else
            {
                btnClock.Visible = false;
                btnMinimum.Visible = false;
            }
               
        }

        private void label52_Click(object sender, EventArgs e)
        {

        }

        private void label68_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void cbModel_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
        private void UpdateShowMini()
        {
            txtLines.Text = txtLine.Text;
            cbModels.Text = cbModel.Text;
            tracOTs.Text = txtOT.Text;
            if (numMan.Value == numMan.Maximum && numOP.Value == numOP.Maximum)
            {
                ckNS.Checked = true;
            }
            else
            {
                ckNS.Checked = false;
            }
            numTargetDates.Maximum = numTargetDate.Maximum;
            numTargetDates.Value = numTargetDate.Value;
            lbOks.Text = lbOk.Text;
            lbNGs.Text = lbNG.Text;
            lbYields.Text = lbYield.Text;
            lbLostTimeHs.Text = lbLostTimeH.Text;
            lbLostTimeMs.Text = lbLostTimeM.Text;
            lbLostTimeSs.Text = lbLostTimeS.Text;
        }
        Size szPropeties2;
        private void btnminiShows_Click(object sender, EventArgs e)
        {
            pPropeties2.Visible = true;
            tmUpshowmini.Enabled = true;
            szPropeties2 = pPropeties2.Size;
            szPropeties = pPropeties.Size;
            pPropeties.Size = new Size(szPropeties2.Width + 3, szPropeties2.Height + 3);
            blShowInfor = true;
            tmShowMini.Enabled = true;
            tmAvatar.Enabled = false;
            btnStartMini.BackgroundImage = Properties.Resources.Stop;
        }

        private void tmUpshowmini_Tick(object sender, EventArgs e)
        {
            UpdateShowMini();
        }

        private void btnMaxshow_Click(object sender, EventArgs e)
        {
           
            pPropeties2.Visible = false;
            tmUpshowmini.Enabled = false;
           // szPropeties2 = pPropeties2.Size;
            pPropeties.Size = szPropeties;
            tmShowMini.Enabled = false;
            tmAvatar.Enabled = true;
        }

        private void pPropeties2_MouseMove(object sender, MouseEventArgs e)
        {
            if (blPinPro == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (isFirst1 == true)
                    {
                        prevLeftClick1 = new Point(e.X, e.Y);
                        isFirst1 = false;
                    }
                    else
                    {

                        if (toBlock1 == false)
                            pPropeties.Location = new Point(pPropeties.Location.X + e.X - prevLeftClick1.X, pPropeties.Location.Y + e.Y - prevLeftClick1.Y);

                        prevLeftClick1 = new Point(e.X, e.Y);
                        toBlock1 = !toBlock1;
                    }
                }
                else
                    isFirst1 = true;
            }
        }
        bool blShowInfor=true;
        private void tmShowMini_Tick(object sender, EventArgs e)
        {
            if (ixAvatar == 0)
            {
                tmShowMini.Interval = 1000;
            }
            if (ixAvatar < ListAvatar.Count && blShowInfor == false)
            {
                picAvatarmini.Visible = true;
                imgAvartar = ListAvatar[ixAvatar];
                ixAvatar++;
                blStartAvatar = true;
                picAvatarmini.Invalidate();
            }
            if (blShowInfor == true)
            {
                picAvatarmini.Visible = false;
               
                blShowInfor = false;
                ixAvatar = 0;
                tmShowMini.Interval = 4000;
            }
            if (ixAvatar >= ListAvatar.Count)
            {
                ixAvatar = 0;
                blShowInfor = true;
             
                
            }
        }

        private void picAvatarmini_Paint(object sender, PaintEventArgs e)
        {
            if (imgAvartar != null)
            {
                Rectangle rec = new Rectangle(0, 0, picAvatarmini.Width, picAvatarmini.Height);

                e.Graphics.DrawImage(imgAvartar, rec);
            }
        }
        bool blStartMini=false;
        private void btnStartMini_Click(object sender, EventArgs e)
        {
            if (blStartMini==false)
            {
                tmShowMini.Enabled = false;
                btnStartMini.BackgroundImage = Properties.Resources.Starts;
             }
            else
            {
                tmShowMini.Enabled = true;
                btnStartMini.BackgroundImage = Properties.Resources.Stop;
            }
            blStartMini = !blStartMini;
        }

        private void picAvatarmini_MouseMove(object sender, MouseEventArgs e)
        {
            if (blPinPro == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (isFirst1 == true)
                    {
                        prevLeftClick1 = new Point(e.X, e.Y);
                        isFirst1 = false;
                    }
                    else
                    {

                        if (toBlock1 == false)
                            pPropeties.Location = new Point(pPropeties.Location.X + e.X - prevLeftClick1.X, pPropeties.Location.Y + e.Y - prevLeftClick1.Y);

                        prevLeftClick1 = new Point(e.X, e.Y);
                        toBlock1 = !toBlock1;
                    }
                }
                else
                    isFirst1 = true;
            }
        }

        private void groupBox7_Move(object sender, EventArgs e)
        {
            
        }

        private void groupBox7_MouseHover(object sender, EventArgs e)
        {
           
                btnUpdateTarget.Visible = true;

        }

        private void lbWait_Click(object sender, EventArgs e)
        {

        }

        private void groupBox7_Leave(object sender, EventArgs e)
        {
            btnUpdateTarget.Visible = false;
        }
    }
}

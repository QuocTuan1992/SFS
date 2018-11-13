using SFS_FV.GRAPHIC;
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

namespace SFS_FV
{
    public partial class CreateGraphic : Form
    {
        public CreateGraphic()
        {
            InitializeComponent();
        }
        ColorDialog colorDlg = new ColorDialog();
        int valDefaut = 400;
        bool isConst = false;
        SQLITE SQLITE = new SQLITE();
        FontDialog fontDlg = new FontDialog();
        private void CreateGraphic_Load(object sender, EventArgs e)
        {
            //TOOL
           
            colorDlg.Color = Color.Red;
           
            fontDlg.Font = new Font("Arial", 8);
            fontDlg.Color = Color.Black;
           
          

            // Set up the delays for the ToolTip.
            tiptracOffChartX.AutoPopDelay = 5000;
            tiptracOffChartX.InitialDelay = 1000;
            tiptracOffChartX.ReshowDelay = 100;
            // Force the ToolTip text to be displayed whether or not the form is active.
            tiptracOffChartX.ShowAlways = true;
            tiptracOffChartY.AutoPopDelay = 5000;
            tiptracOffChartY.InitialDelay = 1000;
            tiptracOffChartY.ReshowDelay = 100;
            // Force the ToolTip text to be displayed whether or not the form is active.
            tiptracOffChartY.ShowAlways = true;
        }

        private void CreateGraphic_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;
        }
        Point pOffset = new Point(50, 40);
        private void cbTool_SelectedIndexChanged(object sender, EventArgs e)
        {
            tracOffChartX.Enabled = true;
            tracOffChartY.Enabled = true;
            if (G.ListToolChart.Count != 0&& G.ListToolTemp[indexTool2[cbTool.SelectedIndex]].TypeGr==TypeGr.Rectanger)
            {
                int szOffset = G.ListToolChart[G.ListToolChart.Count - 1].ToolGr.sizeFont;
                pOffset = new Point(pOffset.X + szOffset+ szOffset/10, pOffset.Y);
            }
                G.ListToolChart.Add(new ToolChart(G.ListToolTemp[indexTool2[cbTool.SelectedIndex]], pOffset));
            tracOffChartX.Value = G.ListToolChart[G.ListToolChart.Count-1].pDrawing.X;
            tracOffChartY.Value = G.ListToolChart[G.ListToolChart.Count - 1].pDrawing.Y;
           
            indexTool2.RemoveAt(cbTool.SelectedIndex);
            cbTool.Items.RemoveAt(cbTool.SelectedIndex);
            picReview2.Invalidate();
        }
        List<int> indexTool2 = new List<int>();
        private void cbTypeGr_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cbTool.Items.Clear();
            G.ListToolTemp.Clear();
            indexTool2 = new List<int>();
            int index = 0;
            foreach (ToolGr ListToolGr in G.ListToolGr)
            {
                if (ListToolGr.TypeGr.ToString() == cbTypeGr.Text)
                {
                    indexTool2.Add(index);
                    cbTool.Items.Add(ListToolGr.Name);
                }
                G.ListToolTemp.Add(ListToolGr);
                index++;
            }
           
            cbTool.SelectedIndex = -1;
        }

        private void picReview_Paint(object sender, PaintEventArgs e)
        {
            int with = picReview2.Width;
            int height = picReview2.Height;

           
            if (G.ListToolChart.Count != 0)
            {
                try
                {
                    if (ListGraphicTemp.GIRD == true)
                    {
                        if (ListGraphicTemp != null)
                        {

                            for (int i = 40; i < with; i += height * valMinRow / valMax)
                            {
                                e.Graphics.DrawLine(new Pen(Color.LightGray, 1), new Point(i, 0), new Point(i, height - 40));
                            }
                            for (int i = 0; i < height - 40; i += height * valMinRow / valMax)
                            {
                                e.Graphics.DrawLine(new Pen(Color.LightGray, 1), new Point(40, i), new Point(with, i));
                            }
                        }
                        else
                        {
                            for (int i = 40; i < with; i += height * valMinRow / valMax)
                            {
                                e.Graphics.DrawLine(new Pen(Color.LightGray, 1), new Point(i, 0), new Point(i, height - 40));
                            }
                            for (int i = 0; i < height - 40; i += height * valMinRow / valMax)
                            {
                                e.Graphics.DrawLine(new Pen(Color.LightGray, 1), new Point(40, i), new Point(with, i));
                            }
                        }
                    }
                }
                catch(Exception)
                {
                    for (int i = 40; i < with; i += height * valMinRow / valMax)
                    {
                        e.Graphics.DrawLine(new Pen(Color.LightGray, 1), new Point(i, 0), new Point(i, height - 40));
                    }
                    for (int i = 0; i < height - 40; i += height * valMinRow / valMax)
                    {
                        e.Graphics.DrawLine(new Pen(Color.LightGray, 1), new Point(40, i), new Point(with, i));
                    }
                }
                Pen pen1 = new Pen(Color.Black, 3);
                Point pXaxis = new Point(40, picReview2.Height - 40);
                Point pXaxis2 = new Point(picReview2.Width, picReview2.Height - 40);
                e.Graphics.DrawLine(pen1, pXaxis, pXaxis2);
                Point pYaxis = new Point(40, picReview2.Height - 40);
                Point pYaxis2 = new Point(40, 0);
                e.Graphics.DrawLine(pen1, pYaxis, pYaxis2);
                double zoomY = 1;
                try
                {
                    zoomY = (double)(picReview2.Height - 40) / ListGraphicTemp.Max;
                }
                catch (Exception)
                {
                    zoomY = (double)(picReview2.Height - 40) / 2000;
                }

                if (blChart == false)
                {

                    foreach (ToolChart ToolChart in G.ListToolChart)
                    {
                        if (ToolChart.ToolGr.TypeGr == TypeGr.Cycle)
                        {
                            int W = picReview2.Width - 40;
                            int H = picReview2.Height - 40;

                            Region rgn = new Region(new Rectangle(40, 0, W, H));
                            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                            List<Point> pointCur = new List<Point>();
                            pointCur.Add(new Point(40, H / 2));
                            pointCur.Add(new Point(40 + (W / 4), 3 * H / 4));
                            pointCur.Add(new Point(40 + (W / 2), H / 2));
                            pointCur.Add(new Point(40 + (3 * W / 4), 3 * H / 4));
                            pointCur.Add(new Point(40 + W, H / 2));
                            pointCur.Add(new Point(40 + W, 0));
                            pointCur.Add(new Point(40, 0));
                            pointCur.Add(new Point(40, H / 2));
                            path.AddCurve(pointCur.ToArray());
                            // path.AddLine(60, 60, 100, 100);
                            rgn.Exclude(path);
                            // Graphics g = this.CreateGraphics();
                            //   string redHex = colorDlg.Color.R;
                            // colorDlg.FR
                            //Brush br = new SolidBrush(Color.FromArgb(ToolChart.ToolGr.BackColor, colorDlg.Color.R, colorDlg.Color.G, colorDlg.Color.B));
                            e.Graphics.FillRegion( ToolChart.ToolGr.BackColor, rgn);
                        }
                        if (ToolChart.ToolGr.TypeGr == TypeGr.Line || ToolChart.ToolGr.TypeGr == TypeGr.Yield)
                        {

                            List<Point> point;
                            Pen pen = new Pen(ToolChart.ToolGr.BackColor, ToolChart.ToolGr.sizeFont);
                            Brush br = ToolChart.ToolGr.brFont;
                            point = new List<Point>();
                            int H = Convert.ToInt32((ToolChart.ToolGr.defaut - G.zoom) * zoomY);
                            int P = 0;
                            if (ToolChart.ToolGr.TypeGr == TypeGr.Yield)
                                P = picReview2.Height - Convert.ToInt32((double)(1.0) * (picReview2.Height - 40 - 2000 / 10));
                            else
                                P = picReview2.Height - H - ToolChart.pDrawing.Y;
                            point.Add(new Point(ToolChart.pDrawing.X, P));

                            point.Add(new Point(picReview2.Width + ToolChart.pDrawing.X - 50, P));
                            if (ToolChart.ToolGr.isVal)
                            {
                                foreach (Point point1 in point)
                                {
                                    e.Graphics.DrawString(ToolChart.ToolGr.defaut + "", ToolChart.ToolGr.font, br, point1);
                                }
                            }
                            if (ToolChart.ToolGr.isChar)
                            {
                                Point pLabel = new Point(ToolChart.pDrawing.X - 40, P);
                                e.Graphics.DrawString(ToolChart.ToolGr.sShow + "", ToolChart.ToolGr.font, br, pLabel);
                            }
                            e.Graphics.DrawLines(pen, point.ToArray());
                        }
                        if (ToolChart.ToolGr.TypeGr == TypeGr.Rectanger)
                        {
                            int H = Convert.ToInt32((ToolChart.ToolGr.defaut - G.zoom) * zoomY);
                            int P = picReview2.Height - H - ToolChart.pDrawing.Y;
                            Rectangle rec = new Rectangle(ToolChart.pDrawing.X, P, ToolChart.ToolGr.sizeFont, H);
                            Point point;

                            Brush br = ToolChart.ToolGr.brFont;

                            point = new Point(ToolChart.pDrawing.X, P-20);

                            if (ToolChart.ToolGr.isVal)
                            {

                                e.Graphics.DrawString(ToolChart.ToolGr.defaut + "", ToolChart.ToolGr.font, br, point);

                            }
                            if (ToolChart.ToolGr.isChar)
                            {
                                Point pLabel = new Point(ToolChart.pDrawing.X, picReview2.Height - ToolChart.pDrawing.Y);
                                e.Graphics.DrawString(ToolChart.ToolGr.sShow + "", ToolChart.ToolGr.font, br, pLabel);
                            }
                            e.Graphics.FillRectangle(ToolChart.ToolGr.BackColor, rec);
                        }
                    }
                }
                else
                {
                    int numDrawing = Convert.ToInt32(ListGraphicTemp.TimeReset / ListGraphicTemp.TimeUpdate);
                    Point OffSetG = new Point(0, 0); bool blDrawBegin = false; int indexDr = 0;
                    Point OffSetG2 = new Point(0, 0);
                    int hour = ListGraphicTemp.TimeBegin.Hour;
                    int min = ListGraphicTemp.TimeBegin.Minute;

                    List<List<Point>> pointL; pointL = new List<List<Point>>();
                    for (int i = 0; i < numDrawing; i++)
                    {
                        int pTime = 0;
                        foreach (ToolChart ListToolChart in G.ListToolChart)
                        {
                            pTime += ListToolChart.pDrawing.X;
                        }
                        pTime = pTime / G.ListToolChart.Count();

                        if (min >= 60)
                        {
                            hour++;
                            min = min - 60;
                        }
                        string sHour, sMin;
                        if (min < 10) sMin = "0" + min; else sMin = min + "";
                        if (hour < 10) sHour = "0" + hour; else sHour = hour + "";

                        Rectangle rec1 = new Rectangle(OffSetG2.X + G.ListToolChart[0].pDrawing.X, picReview2.Height - 20, G.ListToolChart[G.ListToolChart.Count() - 1].pDrawing.X - G.ListToolChart[0].pDrawing.X + G.ListToolChart[G.ListToolChart.Count() - 1].ToolGr.sizeFont, 20);
                        e.Graphics.DrawString(sHour + ":" + sMin, new Font("Arial", 12), Brushes.Black, new Point(pTime + OffSetG2.X, picReview2.Height - 20));
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
                            if (ToolChart.ToolGr.TypeGr == TypeGr.Cycle)
                            {
                                int W = picReview2.Width - 40;
                                int H = picReview2.Height - 40;
                                Region rgn = new Region(new Rectangle(40, 0, W, H));
                                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                                List<Point> pointCur = new List<Point>();
                                pointCur.Add(new Point(40, H / 2));
                                pointCur.Add(new Point(40 + (W / 4), 3 * H / 4));
                                pointCur.Add(new Point(40 + (W / 2), H / 2));
                                pointCur.Add(new Point(40 + (3 * W / 4), 3 * H / 4));
                                pointCur.Add(new Point(40 + W, H / 2));
                                pointCur.Add(new Point(40 + W, 0));
                                pointCur.Add(new Point(40, 0));
                                pointCur.Add(new Point(40, H / 2));
                                path.AddCurve(pointCur.ToArray());
                                rgn.Exclude(path);
                                e.Graphics.FillRegion(ToolChart.ToolGr.BackColor, rgn);

                            }
                            if (ToolChart.ToolGr.TypeGr == TypeGr.Line || ToolChart.ToolGr.TypeGr == TypeGr.Yield)
                            {

                                if (blDrawBegin == false)
                                    pointL.Add(new List<Point>());

                                Pen pen = new Pen(ToolChart.ToolGr.BackColor, ToolChart.ToolGr.sizeFont);
                                Brush br = ToolChart.ToolGr.brFont;
                                int H = Convert.ToInt32((ToolChart.ToolGr.defaut - G.zoom) * zoomY);
                                int P = picReview2.Height - H - ToolChart.pDrawing.Y;
                                OffSetG.X = ListGraphic.Offset.X;
                                Data.values.Clear();
                                for (int i = 0; i < numDrawing; i++)
                                {
                                    Data.values.Add(new Point(OffSetG.X * i + ToolChart.pDrawing.X, P));
                                }
                                OffSetG.X = 0;
                                e.Graphics.DrawLines(pen, Data.values.ToArray());
                                if (ToolChart.ToolGr.isVal)
                                {

                                    for (int ii = 0; ii < Data.values.Count; ii++)
                                    {
                                        Point point1 = Data.values[ii];
                                        Point pString = new Point(point1.X, point1.Y - 20);
                                        Rectangle recCircle = new Rectangle(point1.X - 10, point1.Y - 5, 10, 10);
                                        e.Graphics.DrawString(ToolChart.ToolGr.defaut + "", ToolChart.ToolGr.font, br, pString);
                                        e.Graphics.FillEllipse(ToolChart.ToolGr.brFont, recCircle);
                                    }
                                }
                                if (ToolChart.ToolGr.isChar)
                                {
                                    Point pLabel = new Point(picReview2.Width - 50, P);
                                    e.Graphics.DrawString(ToolChart.ToolGr.sShow + "", ToolChart.ToolGr.font, br, pLabel);
                                }


                            }
                            if (ToolChart.ToolGr.TypeGr == TypeGr.Rectanger)
                            {
                                //new Rectangle(ToolChart.pDrawing.X,G.zoom+ picReview.Height - ToolChart.ToolGr.defaut- ToolChart.pDrawing.Y, ToolChart.ToolGr.sizeFont, ToolChart.ToolGr.defaut-G.zoom);
                                int H = Convert.ToInt32(zoomY * (ToolChart.ToolGr.defaut - G.zoom));
                                int P = picReview2.Height - H - ToolChart.pDrawing.Y;
                                Rectangle rec = new Rectangle(ToolChart.pDrawing.X + OffSetG.X, P, ToolChart.ToolGr.sizeFont, H);
                                //new Rectangle(10 + ToolChart.pDrawing.X + OffSetG.X*m, 20 - ToolChart.pDrawing.Y, ToolChart.ToolGr.sizeFont, picReview.Height - 20);
                                Point point;

                                Brush br = ToolChart.ToolGr.brFont;
                                P = P - 20;
                                point = new Point(ToolChart.pDrawing.X + OffSetG.X, P);

                                // P = picReview.Height - H - ToolChart.pDrawing.Y;
                                if (ToolChart.ToolGr.isVal)
                                {

                                    e.Graphics.DrawString(ToolChart.ToolGr.defaut + "", ToolChart.ToolGr.font, br, point);

                                }
                                if (ToolChart.ToolGr.isChar)
                                {
                                    // P = P + 20;
                                    Point pLabel = new Point(ToolChart.pDrawing.X + OffSetG.X, picReview2.Height - ToolChart.pDrawing.Y);

                                    //new Point(10 + ToolChart.ToolGr.sizeFont / 4 + ToolChart.pDrawing.X + OffSetG.X*m, picReview.Height - 20 - ToolChart.pDrawing.Y);
                                    e.Graphics.DrawString(ToolChart.ToolGr.sShow + "", ToolChart.ToolGr.font, br, pLabel);
                                }
                                e.Graphics.FillRectangle(ToolChart.ToolGr.BackColor, rec);
                            }
                            OffSetG.X += ListGraphicTemp.Offset.X;
                            OffSetG.Y = ListGraphicTemp.Offset.Y;
                            indexDr = 0;

                        }


                    }

                }
            }
            else
            {
                e.Graphics.Clear(Color.White);
            }
            }
        
        

        private void numOffN_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numOffD_ValueChanged(object sender, EventArgs e)
        {

        }
        bool blChart = false;
        int Max = 2000;
        DateTime timeBegin;// = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(numStartH.Value), Convert.ToInt32(numStartM.Value), 0);
        DateTime timeStep; TimeSpan timeSpan;
        private void UpdateGraphic()
        {
         

            foreach (ToolChart ListToolChart in G.ListToolChart)
            {
                G.ListData.Add(new List<ListData>());
                int numDrawing = Convert.ToInt32(MinReset / MinUpdate);
               
                
                    if (ListToolChart.ToolGr.TypeGr ==TypeGr.Rectanger )
                {
                    int index = 0;
                    while (index < numDrawing)
                        {
                            G.ListData[G.ixData].Add(new ListData(ListToolChart, 0, 0));
                            index++;
                        }
                 }
                else if ( ListToolChart.ToolGr.TypeGr == TypeGr.Line)
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
                        G.ListData[G.ixData].Add(new ListData(ListToolChart, values));
                    }
                      
                }
                else if (ListToolChart.ToolGr.TypeGr == TypeGr.Cycle )
                {
                        List<double> timer = new List<double>();
                        List<double> cycle = new List<double>();
                        List<Point> pDrawing = new List<Point>();
                        List<double> lost = new List<double>();
                        List<double> timelost = new List<double>();
                    G.ListData[G.ixData].Add(new ListData(ListToolChart,pDrawing, timer,cycle,lost,timelost));
                    }
                else if (ListToolChart.ToolGr.TypeGr == TypeGr.Yield)
                {                    
                    List<double> value = new List<double>();
                    List<int> tempOK = new List<int>();
                    List<int> tempNG = new List<int>();
                    List<Point> pDrawing = new List<Point>();
                    for(int i=0;i< numDrawing;i++)
                    {
                        tempOK.Add(0);
                        tempNG.Add(0);
                        value.Add(100);
                        pDrawing.Add(new Point(0,0));
                    }
                    G.ListData[G.ixData].Add(new ListData(ListToolChart, value, tempOK,tempNG, pDrawing));
                }
                G.ixData++;


            }
           
        }
        #region EditTool
        //SQLITE SQLITE = new SQLITE();
        ListGraphic ListGraphicTemp  ;
        private void btnAddTool_Click(object sender, EventArgs e)
        {
            G.sourceSQL = G.ChartSQL;
            MinReset = Convert.ToInt32(numHourReset.Value * 60 + numMinReset.Value);
            MinUpdate = Convert.ToInt32(numMinUpdateData.Value);
            DateTime timeBegin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(numStartH.Value), Convert.ToInt32(numStartM.Value), 0);
            G.ListData = new List<List<ListData>>();
            G.ixData = 0;
            UpdateGraphic();
            OffSet.X = tracOffChartX.Value;
            OffSet.Y = tracOffChartY.Value;
            tracOffChartX.Enabled = true;
            tracOffChartY.Enabled = true;
            ListGraphicTemp= new ListGraphic(txtEditName.Text, G.ListToolChart,G.ListData, timeBegin, MinReset, MinUpdate,Max,OffSet,valMinRow, ckGird.Checked);
            // CHART(NAME nvachar(50), ToolChart nvachar(50), TimeBegin nvachar(50), TimeReset nvachar(50), TimeUpdate nvachar(50), Max nvachar(50), TPOINT nvachar(50), CPOINT nvachar(50)); "; //gancau lech cmd
            
            picReview2.Invalidate();
            blChart = true;
            tmUpdateTime.Enabled = false;
        }
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
       ToolTip tiptracOffChartX = new ToolTip();
        ToolTip tiptracOffChartY = new ToolTip();
       
        Point OffSet = new Point(0,0);
        private void tracOffChartX_Scroll(object sender, EventArgs e)
        {
            OffSet.X = tracOffChartX.Value;
            OffSet.Y = tracOffChartY.Value;
            if (blChart == false)
            {
                pOffset.X = Convert.ToInt32(tracOffChartX.Value);
                G.ListToolChart[G.ListToolChart.Count() - 1].pDrawing = pOffset;

                //lbToolX.Text = tracOffChartX.Value + "";
                tiptracOffChartX.SetToolTip(tracOffChartX, tracOffChartX.Value.ToString());
                picReview2.Invalidate();
            }
            else
            {
                OffSet.X = tracOffChartX.Value;
                lbChartX.Text = tracOffChartX.Value + "";
                tiptracOffChartX.SetToolTip(tracOffChartX, tracOffChartX.Value.ToString());
                if (blChart == true)
                {
                    ListGraphicTemp.Offset = OffSet;
                      picReview2.Invalidate();
                }
            }
        }

        private void tracOffChartY_Scroll(object sender, EventArgs e)
        {
            OffSet.X = tracOffChartX.Value;
            OffSet.Y = tracOffChartY.Value;
            if (blChart==false)
            {

                pOffset.Y = Convert.ToInt32(tracOffChartY.Value);
                G.ListToolChart[G.ListToolChart.Count() - 1].pDrawing = pOffset;
                //lbToolY.Text = tracOffChartY.Value + "";
                tiptracOffChartY.SetToolTip(tracOffChartY, tracOffChartY.Value.ToString());
                picReview2.Invalidate();
            }
            else
            {
                OffSet.Y = tracOffChartY.Value;
                lbChartY.Text = tracOffChartY.Value + "";
                tiptracOffChartY.SetToolTip(tracOffChartY, tracOffChartY.Value.ToString());
                G.zoom = tracOffChartY.Value;
                if (blChart == true)
                {
                    ListGraphicTemp.Offset = OffSet;
                   
                    picReview2.Invalidate();
                }
            }
          
        }

        private void tracOffToolX_Scroll(object sender, EventArgs e)
        {
            
        }

        private void tracOffToolY_Scroll(object sender, EventArgs e)
        {
        
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
           
        }
        int MinUpdate = 1;
        private void numMinUpdateData_ValueChanged(object sender, EventArgs e)
        {
            MinUpdate =Convert.ToInt32( numMinUpdateData.Value);
            if (blChart == true)
            {
                ListGraphicTemp.TimeUpdate = MinUpdate;
                G.ListData = new List<List<ListData>>();
                G.ixData = 0;
                UpdateGraphic();
                ListGraphicTemp.ListData =G.ListData;
                picReview2.Invalidate();
            }
        }
        double MinReset = 1;
        private void numMinReset_ValueChanged(object sender, EventArgs e)
        {
            MinReset = Convert.ToInt32(numHourReset.Value * 60 + numMinReset.Value);
            if (blChart == true)
            {
                ListGraphicTemp.TimeReset = MinReset;
                G.ListData = new List<List<ListData>>();
                G.ixData = 0;
                UpdateGraphic();
                ListGraphicTemp.ListData = G.ListData;
                picReview2.Invalidate();
            }
        }

        private void numHourReset_ValueChanged(object sender, EventArgs e)
        {
            MinReset = Convert.ToInt32(numHourReset.Value*60 + numMinReset.Value);
            if (blChart == true)
            {
                ListGraphicTemp.TimeReset = MinReset;
                G.ListData = new List<List<ListData>>();
                G.ixData = 0;
                UpdateGraphic();
                ListGraphicTemp.ListData = G.ListData;
                picReview2.Invalidate();
            }
        }

        private void CreateGraphic_Shown(object sender, EventArgs e)
        {
            cbTypeGr.DataSource = Enum.GetValues(typeof(TypeGr));
            cbTool.Items.Clear();
            indexTool2 = new List<int>();
            int index = 0;
            foreach (ToolGr ListToolGr in G.ListToolGr)
            {
                indexTool2.Add(index);
                cbTool.Items.Add(ListToolGr.Name);
                index++;
            }
            
         cbTool.SelectedIndex = -1;

            cbChart.Items.Clear();
            foreach (ListGraphic ListGraphic in G.ListGraphic)
            {
                cbChart.Items.Add(ListGraphic.Name);
            }
            cbChart.Items.Add("* New Chart");
            if (cbChart.Items.Count!=0)
            cbChart.SelectedIndex = 0;
           

            // Set up the delays for the ToolTip.
            tiptracOffChartX.AutoPopDelay = 5000;
            tiptracOffChartX.InitialDelay = 1000;
            tiptracOffChartX.ReshowDelay = 100;
            // Force the ToolTip text to be displayed whether or not the form is active.
            tiptracOffChartX.ShowAlways = true;
            tiptracOffChartY.AutoPopDelay = 5000;
            tiptracOffChartY.InitialDelay = 1000;
            tiptracOffChartY.ReshowDelay = 100;
            // Force the ToolTip text to be displayed whether or not the form is active.
            tiptracOffChartY.ShowAlways = true;
            picReview2.Invalidate();
            
        }

        private void txtMax_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Max = Convert.ToInt32(txtMax.Text);
                if (blChart == true && Max != 0)
                {
                    //G.ListGraphic[G.ListGraphic.Count() - 1].Max = Max;
                    picReview2.Invalidate();
                }
            }
            catch(Exception)
            {

            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for( int i=0;i<G.ListToolChart.Count();i++)
            {
                G.ListToolChart[i].ToolGr.defaut = Convert.ToInt32(G.ListToolChart[i].ToolGr.ListVariables.Val);
               
                        
            }
            picReview2.Invalidate();
        }

        private void numStartH_ValueChanged(object sender, EventArgs e)
        {
           if (blChart == true)
            {
                DateTime timeBegin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(numStartH.Value), Convert.ToInt32(numStartM.Value), 0);

                ListGraphicTemp.TimeBegin = timeBegin;
               
                ListGraphicTemp.ListData = G.ListData;
                picReview2.Invalidate();
            }
        }

        private void numStartM_ValueChanged(object sender, EventArgs e)
        {
            if (blChart == true)
            {
                DateTime timeBegin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(numStartH.Value), Convert.ToInt32(numStartM.Value), 0);

                ListGraphicTemp.TimeBegin = timeBegin;
                
                ListGraphicTemp.ListData = G.ListData;
                picReview2.Invalidate();
            }
        }
#endregion
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void tmUpdateTime_Tick(object sender, EventArgs e)
        {
            numStartH.Value = DateTime.Now.Hour;

            numStartM.Value = DateTime.Now.Minute+1;
            if(numStartM.Value>=60)
            {
                numStartM.Value = 0;
                numStartH.Value++;
            }
        }
      //  public CreateTool CreateTool = new CreateTool();
        bool blTool = false;
        private void btnTool_Click(object sender, EventArgs e)
        {
             
            if(blPlusTool==false)
            {
               

                cbTypeTool.DataSource = Enum.GetValues(typeof(TypeGr));
                cbTool.Items.Clear();
                foreach (ToolGr ListToolGr in G.ListToolGr)
                {
                    cbTool.Items.Add(ListToolGr.Name);
                }
                cbTool.SelectedIndex = -1;
                pTool.Visible = true;
                btnTool.BackColor = Color.Cornsilk;
               
                cbName.Items.Clear();
                foreach (ToolGr ToolGr in G.ListToolGr)
                {
                    cbName.Items.Add(ToolGr.Name);
                }
                if (cbName.Items.Count > 0)
                {
                    cbName.SelectedIndex = 0;
                }
                if (G.ListVariables.Count() > 0)
                {
                    btnSave.Enabled = true;
                }
            }
            else
            {
                btnTool.BackColor = Color.White;
                pTool.Visible = false;
            }
            blPlusTool = !blPlusTool;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            tmPressSave.Enabled = true;
          
                if (cbChart.SelectedIndex == -1 || cbChart.SelectedIndex == cbChart.Items.Count - 1)
                {
                DialogResult dialogResult = MessageBox.Show("Bạn muốn thêm Chart tên : " + Environment.NewLine + txtEditName.Text, "Thêm Tool", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    G.sourceSQL = G.ChartSQL;
                    if (!SQLITE.CHECK("*", "CHART", "NAME='" + txtEditName.Text.Trim() + "'"))
                    {
                        if (txtEditName.Text.Trim() != "")
                        {
                            G.ListGraphic.Add(ListGraphicTemp);
                            G.sourceSQL = G.ChartSQL;
                            List<ToolChart> ToolChart = ListGraphicTemp.ToolChart;
                            DateTime timeBegin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(numStartH.Value), Convert.ToInt32(numStartM.Value), 0);

                            for (int j = 0; j < ToolChart.Count(); j++)
                            {
                                List<string> List = new List<string>();
                                List.Add(txtEditName.Text);
                                List.Add(ToolChart[j].ToolGr.Name);
                                List.Add(timeBegin + "");
                                List.Add(MinReset + "");
                                List.Add(MinUpdate + "");
                                List.Add(Max + "");
                                List.Add(ToolChart[j].pDrawing.X + "," + ToolChart[j].pDrawing.Y);
                                List.Add(tracOffChartX.Value + "," + tracOffChartY.Value);
                                List.Add(ListGraphicTemp.MIN + "");
                                List.Add(ListGraphicTemp.GIRD + "");
                                SQLITE.Insert("CHART", List);
                            }

                            G.sourceSQL = G.ToolSQL;
                            MessageBox.Show("Đã thêm Chart");
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập tên Chart");
                        }
                    }
                    else

                    {
                        MessageBox.Show("FAIL! Vui lòng chọn Tên khác");
                    }
                }
                }
                else
                {
                DialogResult dialogResult = MessageBox.Show("Bạn muốn Update Chart tên : " + Environment.NewLine + txtEditName.Text, "Update Tool", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    // G.ListGraphic[cbChart.SelectedIndex] = ListGraphicTemp;
                    G.sourceSQL = G.ChartSQL;
                    
                    List<ToolChart> ToolChart =ListGraphicTemp. ToolChart;
                    for (int j = 0; j < ToolChart.Count(); j++)
                    {
                        if (SQLITE.CHECK("*", "CHART", "NAME='"+ ListGraphicTemp.Name + "' AND ToolChart='"+ ToolChart[j].ToolGr.Name + "'"))
                        {
                            Dictionary<string, string> dic = new Dictionary<string, string>();
                            dic.Add("NAME", ListGraphicTemp.Name);
                            dic.Add("ToolChart", ToolChart[j].ToolGr.Name);
                            dic.Add("TimeBegin", ListGraphicTemp.TimeBegin + "");
                            dic.Add("TimeReset", ListGraphicTemp.TimeReset + "");
                            dic.Add("TimeUpdate", ListGraphicTemp.TimeUpdate + "");
                            dic.Add("Max", ListGraphicTemp.Max + "");
                            dic.Add("TPOINT", ToolChart[j].pDrawing.X + "," + ToolChart[j].pDrawing.Y);
                            dic.Add("CPOINT", ListGraphicTemp.Offset.X + "," + ListGraphicTemp.Offset.Y);
                            dic.Add("MIN", ListGraphicTemp.MIN + "");
                            dic.Add("GIRD", ListGraphicTemp.GIRD + "");
                            SQLITE.Update("CHART", dic, "NAME='" + ListGraphicTemp.Name + "' AND ToolChart ='" + ToolChart[j].ToolGr.Name + "'", G.ChartSQL);
                        }
                        else
                        {
                            List<string> list = new List<string>();
                            list.Add( ListGraphicTemp.Name);
                            list.Add( ToolChart[j].ToolGr.Name);
                            list.Add( ListGraphicTemp.TimeBegin + "");
                            list.Add( ListGraphicTemp.TimeReset + "");
                            list.Add( ListGraphicTemp.TimeUpdate + "");
                            list.Add( ListGraphicTemp.Max + "");
                            list.Add( ToolChart[j].pDrawing.X + "," + ToolChart[j].pDrawing.Y);
                            list.Add( ListGraphicTemp.Offset.X + "," + ListGraphicTemp.Offset.Y);
                            list.Add(ListGraphicTemp.MIN + "");
                            list.Add( ListGraphicTemp.GIRD + "");
                            SQLITE.Insert("CHART", list);

                        }
                    }
                    MessageBox.Show("Đã thay đổi thông số Chart");
                    G.sourceSQL = G.ToolSQL;

                }
                
            }
            btnSave.BackColor = Color.White;
        }
        ToolChart ToolChartTemp;
        private void cbChart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbChart.Text == "* New Chart")
            {
                 // G.ListToolChart.Clear();
                
                G.ListToolChart = new List<ToolChart>();
                G.ListToolChart.Clear();
                G.ListData = new List<List<ListData>>();
                G.ListData.Clear();
                //ListGraphicTemp.ListData.Clear();
                //ListGraphicTemp.ToolChart.Clear();
                // ListGraphicTemp = null;
                blChart = false;
                G.ixData = 0;
                picReview2.Invalidate();
            }
            else
            {
                if (cbChart.SelectedIndex != cbChart.Items.Count-1)
                {
                    blChart = true;
                    txtEditName.Text = cbChart.Text;
                    ListGraphicTemp = G.ListGraphic[cbChart.SelectedIndex];
                    G.ListToolChart = ListGraphicTemp.ToolChart;
                    G.ListData = ListGraphicTemp.ListData;
                    valMax = ListGraphicTemp.Max;
                    valMinRow = ListGraphicTemp.MIN;
                    numMinRow.Value = valMinRow;
                    txtMax.Value = valMax;
                    numStartH.Value = ListGraphicTemp.TimeBegin.Hour;
                    numStartM.Value = ListGraphicTemp.TimeBegin.Minute;
                    int houtUpdate =Convert.ToInt32( ListGraphicTemp.TimeReset / 60.0);
                    int minUpdate = Convert.ToInt32(ListGraphicTemp.TimeReset % 60.0);
                    numMinReset.Value = minUpdate;
                    numHourReset.Value = houtUpdate;
                    numMinUpdateData.Value = ListGraphicTemp.TimeUpdate;
                    lbChartX.Text = ListGraphicTemp.Offset.X+"";
                    lbChartY.Text = ListGraphicTemp.Offset.Y + "";
                    // numHourReset.Value = ListGraphicTemp.TimeReset;
                    ckGird.Checked = ListGraphicTemp.GIRD;
                  
                    blChart = true;
                    tracOffChartX.Value = ListGraphicTemp.Offset.X;
                    tracOffChartY.Value = ListGraphicTemp.Offset.Y;
                    if (G.ListToolChart.Count != 0 && G.ListToolChart[G.ListToolChart.Count - 1].ToolGr.TypeGr == TypeGr.Rectanger)
                    {
                        int szOffset = G.ListToolChart[G.ListToolChart.Count - 1].ToolGr.sizeFont;
                        pOffset = new Point(pOffset.X + szOffset + szOffset / 10, pOffset.Y);
                    }
                    picReview2.Invalidate();
                }
            }
          
        }
        List<int> indexRedo = new List<int>();
        List<Point> pRedo = new List<Point>();
        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (G.ListToolChart.Count != 0)
            {
                btnRedo.Enabled = true;
                btnRedo.BackColor = Color.LemonChiffon;
                if (G.ListToolChart.Count != 0 && G.ListToolChart[G.ListToolChart.Count - 1].ToolGr.TypeGr == TypeGr.Rectanger)
                {
                    int szOffset = G.ListToolChart[G.ListToolChart.Count - 1].ToolGr.sizeFont;
                    pOffset = new Point(pOffset.X - szOffset - szOffset / 10, pOffset.Y);
                }
                List<string> ListTool = new List<string>();
                foreach(ToolGr ToolGr in G.ListToolTemp)
                {
                    ListTool.Add(ToolGr.Name);
                   
                }
                int index = ListTool.FindIndex(x => x.StartsWith(G.ListToolChart[G.ListToolChart.Count - 1].ToolGr.Name));
              //  G.ListToolChart[]
                cbTool.Items.Add(G.ListToolChart[G.ListToolChart.Count - 1].ToolGr.Name);
                
                indexTool2.Add(index);
                indexRedo.Add(index);
                pRedo.Add(G.ListToolChart[G.ListToolChart.Count - 1].pDrawing);
                G.ListToolChart.RemoveAt(G.ListToolChart.Count - 1);
               
                picReview2.Invalidate();
            }
            else
            {
                btnReturn.BackColor=Color.LightGray;
                btnReturn.Enabled = false;
                btnClear.BackColor = Color.LightGray;
                btnClear.Enabled = false;
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            tmPressDelete.Enabled = true;
            DialogResult dialogResult = MessageBox.Show("Bạn muốn xóa Chart tên : " + Environment.NewLine + cbChart.Text, "Xóa Tool", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                G.sourceSQL = G.ChartSQL;
                SQLITE.Delete("CHART", "NAME='" + cbChart.Text + "'");
                MessageBox.Show("Đã xóa Chart thành công !");
            }
            btnXoa.BackColor = Color.White;
        }

        private void ckClock_CheckedChanged(object sender, EventArgs e)
        {
            if (ckClock.Checked) tmUpdateTime.Enabled = true;
            else tmUpdateTime.Enabled = false;
        }
        bool blPlusTool = false;
        private void btnPlusTool_Click(object sender, EventArgs e)
        {
            if (blPlusTool == false)
            {
                pPlusTool.Visible = true;
                btnPlusTool.BackColor = Color.Cornsilk;
            }
            else
            {
                pPlusTool.Visible = false;
                btnPlusTool.BackColor = Color.White;
            }
            blPlusTool = !blPlusTool;
        }

        private void pPlusTool_MouseLeave(object sender, EventArgs e)
        {
           
        }
        bool blPlusChart = false;
        private void btnSetting_Click(object sender, EventArgs e)
        {

            if (blPlusChart == false)
            {
                pSetting.Visible = true;
                btnSetting.BackColor = Color.Cornsilk;
            }
            else
            {
                pSetting.Visible = false;
                btnSetting.BackColor = Color.White;
            }
            blPlusChart = !blPlusChart;
        }

        private void picReview_Click(object sender, EventArgs e)
        {

        }
        bool blMenu = false;
        private void btnMenu_Click(object sender, EventArgs e)
        {

            if (blMenu == false)
            {
                tmLoadbtn.Enabled = true;
                btnMenu.BackColor = Color.Cornsilk;
            }
            else
            {
                tmHideBtn.Enabled = true;
                btnMenu.BackColor = Color.White;
                pPlusTool.Visible = false;
                blPlusTool = false;
                pControl.Visible = false;
                blControl = false;
                pSetting.Visible = false;
                blPlusChart= false;
                pTool.Visible = false;
                blTool = false;
                btnPlusTool.BackColor = Color.White;
                btnControl.BackColor = Color.White;
                btnXoa.BackColor = Color.White;

            }
            blMenu = !blMenu;
        }
        int index = 0;
        private void tmLoadbtn_Tick(object sender, EventArgs e)
        {
            switch (index)
            {
                
                case 0 :
                    btnControl.Visible = true;
                    break;
                case 1:
                    btnPlusTool.Visible = true;
                  
                    break;
                case 2:
                    btnSetting.Visible = true;
                    break;
                case 3:
                    btnSave.Visible = true;
                    break;
                case 4:
                    btnXoa.Visible = true;
                    break;
                case 5:
                    btnEditTool.Visible = true;
                    break;
                case 6:
                    btnTool.Visible = true;
                    break;
            }
            index++;
            if(index>6)
            {
                tmLoadbtn.Enabled = false;
                index = 0;
            }
        }

        private void tmHideBtn_Tick(object sender, EventArgs e)
        {
            switch (index)
            {
                case 6:
                    btnControl.Visible = false;
                    break;
                case 5:
                    btnPlusTool.Visible = false;
                    break;                             
                case 4:
                    btnSetting.Visible = false;
                    break;
                case 3:
                    btnSave.Visible = false;
                    break;
                case 2:
                    btnXoa.Visible = false;
                    break;
                case 1:
                    btnEditTool.Visible = false;
                    break;
                case 0:
                    btnTool.Visible = false;
                    break;
                
            }
            index++;
            if (index > 6)
            {

                tmHideBtn.Enabled = false;
                index = 0;
            }
        }

        private void tmPressSave_Tick(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.Cornsilk;
            tmPressSave.Enabled = false;
        }

        private void tmPressDelete_Tick(object sender, EventArgs e)
        {
            btnXoa.BackColor = Color.Cornsilk;
            tmPressDelete.Enabled = false;
        }

        private void BackgroundButton_Click(object sender, EventArgs e)
        {
            colorDlg = new ColorDialog();
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                txtShow.BackColor = colorDlg.Color;

            }
            picReview.Invalidate();
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;

            fontDlg.MaxSize = 55;
            fontDlg.MinSize = 4;
            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {


                txtShow.ForeColor = fontDlg.Color;
                txtShow.Font = fontDlg.Font;
            }
            picReview.Invalidate();
        }

        private void trackDefaut_Scroll(object sender, EventArgs e)
        {
            valDefaut = Convert.ToInt32(trackDefaut.Value);
            //   G.ListToolGr[G.ListToolGr.Count - 1].defaut = valDefaut;
            picReview.Invalidate();
        }
        private void trackSize_Scroll(object sender, EventArgs e)
        {
            sizeLine = trackSize.Value;
            //panel1.Height = trackSize.Value;
            picReview.Invalidate();
        }
        private void ckConst_CheckedChanged(object sender, EventArgs e)
        {
            isConst = ckConst.Checked;
            //   G.ListToolGr[G.ListToolGr.Count - 1].isConst = isConst;
            picReview.Invalidate();
        }
        private void ckVal_CheckedChanged(object sender, EventArgs e)
        {
            if (ckVal.Checked) blckVal = true;
            else blckVal = false;
            picReview.Invalidate();
        }
        private void ckLabel_CheckedChanged(object sender, EventArgs e)
        {
            if (ckLabel.Checked) blckLabel = true;
            else blckLabel = false;
            picReview.Invalidate();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enum.TryParse<TypeGr>(cbTypeTool.SelectedValue.ToString(), out TypeGr);
            cbNameVar.Items.Clear();
            indexTool.Clear();
            int i = 0;
            blNewTool = true;
            if (TypeGr == TypeGr.Cycle)
            {

                foreach (ListVariables ListVariables in G.ListVariables)
                {
                    try
                    {
                        cbNameVar.Items.Add(ListVariables.CycleTime.Name);
                        indexTool.Add(i);



                    }
                    catch (Exception)
                    {
                    }
                    i++;
                }

            }
            else if (TypeGr == TypeGr.LostTime)
            {

                foreach (ListVariables ListVariables in G.ListVariables)
                {
                    try
                    {
                        cbNameVar.Items.Add(ListVariables.LostTime.Name);
                        indexTool.Add(i);

                    }
                    catch (Exception)
                    {

                    }

                    i++;

                }

            }
            else if (TypeGr == TypeGr.Yield)
            {

                foreach (ListVariables ListVariables in G.ListVariables)
                {
                    try
                    {
                        cbNameVar.Items.Add(ListVariables.Yield.Name);
                        indexTool.Add(i);

                    }
                    catch (Exception)
                    {

                    }
                    i++;
                }

            }
            else
            {

                foreach (ListVariables ListVariables in G.ListVariables)
                {
                    try
                    {
                        cbNameVar.Items.Add(ListVariables.Name);
                        indexTool.Add(i);

                    }
                    catch (Exception)
                    {

                    }


                    i++;
                }

            }
            if (cbName.Items.Count > 0)
                cbNameVar.SelectedIndex = -1;
            picReview.Invalidate();
        }
        private void cbNameVar_SelectedIndexChanged(object sender, EventArgs e)
        {
            picReview.Invalidate();
        }
        private void cbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbName.SelectedIndex != -1)
            {



                TypeGr = G.ListToolGr[cbName.SelectedIndex].TypeGr;
                isConst = G.ListToolGr[cbName.SelectedIndex].isConst;

                blckVal = G.ListToolGr[cbName.SelectedIndex].isVal;
                blckLabel = G.ListToolGr[cbName.SelectedIndex].isChar;
                ckConst.Checked = isConst;
                ckLabel.Checked = blckLabel;
                ckVal.Checked = blckVal;
                fontDlg.Font = G.ListToolGr[cbName.SelectedIndex].font;
                Brush brush = G.ListToolGr[cbName.SelectedIndex].brFont;
                fontDlg.Color = (brush as SolidBrush).Color;
                Brush brushBack = G.ListToolGr[cbName.SelectedIndex].BackColor;
                colorDlg.Color = (brushBack as SolidBrush).Color;

                txtShow.Text = G.ListToolGr[cbName.SelectedIndex].sShow;
                sizeLine = G.ListToolGr[cbName.SelectedIndex].sizeFont;
                try
                {
                    trackSize.Value = sizeLine;
                }
                catch (Exception)
                {
                    trackSize.Value = 1;
                }
                valDefaut = G.ListToolGr[cbName.SelectedIndex].defaut;
                if (G.ListToolGr[cbName.SelectedIndex].TypeGr != TypeGr.Cycle)
                    trackDefaut.Value = valDefaut;
                else
                    trackDefaut.Value = 200;
                cbTypeTool.SelectedIndex = cbTypeTool.FindStringExact(TypeGr.ToString());
                ListVariables ListVariables = G.ListToolGr[cbName.SelectedIndex].ListVariables;
                if (ListVariables.Name != null)
                    cbNameVar.SelectedIndex = cbNameVar.FindStringExact(ListVariables.Name);
                if (ListVariables.CycleTime != null)
                    cbNameVar.SelectedIndex = cbNameVar.FindStringExact(ListVariables.CycleTime.Name);
                if (ListVariables.LostTime != null)
                    cbNameVar.SelectedIndex = cbNameVar.FindStringExact(ListVariables.LostTime.Name);
                if (ListVariables.Yield != null)
                    cbNameVar.SelectedIndex = cbNameVar.FindStringExact(ListVariables.Yield.Name);
            }
        }
        private void picReview_Paint_1(object sender, PaintEventArgs e)
        {
            sizeTool = new Point(picReview.Width, picReview.Height);
            if (TypeGr == TypeGr.Cycle)
            {
                int W = picReview.Width;
                int H = picReview.Height;
                Region rgn = new Region(new Rectangle(0, 0, W, H));
                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                List<Point> pointCur = new List<Point>();
                pointCur.Add(new Point(0, H / 2));
                pointCur.Add(new Point(W / 4, 3 * H / 4));
                pointCur.Add(new Point(W / 2, H / 2));
                pointCur.Add(new Point(3 * W / 4, 3 * H / 4));
                pointCur.Add(new Point(W, H / 2));
                pointCur.Add(new Point(W, 0));
                pointCur.Add(new Point(0, 0));
                pointCur.Add(new Point(0, H / 2));
                path.AddCurve(pointCur.ToArray());
                // path.AddLine(60, 60, 100, 100);
                rgn.Exclude(path);
                // Graphics g = this.CreateGraphics();
                //   string redHex = colorDlg.Color.R;
                // colorDlg.FR
                e.Graphics.FillRegion(new SolidBrush(Color.FromArgb(tracTranspa.Value, colorDlg.Color.R, colorDlg.Color.G, colorDlg.Color.B)), rgn);
            }
            if (TypeGr == TypeGr.Line || TypeGr == TypeGr.Yield)
            {
                List<Point> point;
                Pen pen = new Pen(colorDlg.Color, sizeLine);
                Brush br = new SolidBrush(fontDlg.Color);
                point = new List<Point>();

                // point.Add(new Point(5, valDefaut));
                if (isConst == false)
                {
                    point.Add(new Point(5 + 20, 100));
                    point.Add(new Point(15 + 20, 50));
                    point.Add(new Point(35 + 20, 75));
                    point.Add(new Point(55 + 20, 30));
                    point.Add(new Point(75 + 20, 65));
                    point.Add(new Point(100 + 20, 40));
                    point.Add(new Point(110 + 20, 100));
                }
                else
                {
                    int value = picReview.Height - Convert.ToInt32((double)(valDefaut / 1500.0) * picReview.Height);

                    point.Add(new Point(5 + 20, value));
                    point.Add(new Point(180 + 20, value));
                }
                if (ckVal.Checked)
                {
                    foreach (Point point1 in point)
                    {
                        e.Graphics.DrawString(valDefaut + "", fontDlg.Font, br, point1);
                    }
                }
                if (ckLabel.Checked)
                {
                    Point pLabel = new Point(120, 90);
                    e.Graphics.DrawString(txtShow.Text + "", fontDlg.Font, br, pLabel);
                }
                e.Graphics.DrawLines(pen, point.ToArray());
            }
            if (TypeGr == TypeGr.Rectanger)
            {
                double value = ((double)valDefaut / 1500.0) * sizeTool.Y;
                Rectangle rec = new Rectangle(picReview.Width / 3, sizeTool.Y - Convert.ToInt32(value), sizeLine, Convert.ToInt32(value) - 20);
                Point point;

                Brush br = new SolidBrush(fontDlg.Color);

                point = new Point(picReview.Width / 3, picReview.Height / 16);
                e.Graphics.FillRectangle(new SolidBrush(colorDlg.Color), rec);
                if (ckVal.Checked)
                {

                    e.Graphics.DrawString(valDefaut + "", fontDlg.Font, br, point);

                }
                if (ckLabel.Checked)
                {
                    Point pLabel = new Point(picReview.Width / 3, sizeTool.Y - 20);
                    e.Graphics.DrawString(txtShow.Text + "", fontDlg.Font, br, pLabel);
                }

            }
            else if (TypeGr == TypeGr.Circle)
            {

                Rectangle rec = new Rectangle(0, 0, trackRec.Value, trackRec.Value);
                e.Graphics.FillPie(new SolidBrush(colorDlg.Color), rec, 270, trackStartAngle.Value);
                int nextStep = 270 + trackStartAngle.Value;
                if (nextStep >= 360) nextStep = nextStep - 360;
                e.Graphics.FillPie(new SolidBrush(Color.Green), rec, nextStep, 360 - trackStartAngle.Value);
            }
            if (TypeGr == TypeGr.LostTime)
            {
                double value = ((double)valDefaut / 1500.0) * sizeTool.Y;
                Rectangle rec = new Rectangle(0, 0, picReview.Width / 2, picReview.Height);
                Point point;

                Brush br = new SolidBrush(fontDlg.Color);

                point = new Point(picReview.Width / 3, picReview.Height / 16);
                e.Graphics.FillRectangle(new SolidBrush(colorDlg.Color), rec);
              

            }
        }   
        private void cbName_TextChanged(object sender, EventArgs e)
        {
            if (cbName.SelectedIndex != -1)
            {
                btnDelectTool.Enabled = true;
            }
            else
            {
                btnDelectTool.Enabled = false;
            }
        }
        private void btnDelectTool_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn muốn xóa Tool : " + Environment.NewLine + cbName.Text, "Xóa Tool", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                G.sourceSQL = G.ToolSQL;
                if (cbTypeTool.Text != "Cycle" && cbTypeTool.Text != "LostTime")
                    SQLITE.Delete("Quantity", "NAME='" + cbName.Text + "'");
                else
                    SQLITE.Delete("Time", "NAME='" + cbName.Text + "'");
            }
        }            
        private void btnSave2_Click(object sender, EventArgs e)
        {
            if (cbName.SelectedIndex == -1)
            {
                try
                {
                    if (TypeGr == TypeGr.Rectanger || TypeGr == TypeGr.Line)
                    {
                        ListToolTemp = new ToolGr(cbName.Text, txtShow.Text, TypeGr, G.ListVariables[indexTool[cbNameVar.SelectedIndex]], new SolidBrush(fontDlg.Color), new SolidBrush(colorDlg.Color), sizeLine, valDefaut, fontDlg.Font, blckLabel, blckVal, isConst);
                        G.ListToolGr.Add(ListToolTemp);

                    }
                    else if (TypeGr == TypeGr.Cycle || TypeGr == TypeGr.LostTime)
                    {
                        ListToolTemp = new ToolGr(cbName.Text, txtShow.Text, TypeGr, G.ListVariables[indexTool[cbNameVar.SelectedIndex]], new SolidBrush(fontDlg.Color), new SolidBrush(Color.FromArgb(tracTranspa.Value, colorDlg.Color.R, colorDlg.Color.G, colorDlg.Color.B)), double.Parse(txtMaxtime.Value + ""), fontDlg.Font, blckLabel, blckVal, isConst);
                        G.ListToolGr.Add(ListToolTemp);

                        G.sourceSQL = G.ToolSQL;
                        List<string> List = new List<string>();
                        List.Add(cbName.Text);
                        List.Add(TypeGr.ToString());
                        SQLITE.Insert("TOOL", List);
                        var cvt = new FontConverter();
                        string font = cvt.ConvertToString(fontDlg.Font);
                        List = new List<string>();
                        List.Add(cbName.Text);
                        List.Add(TypeGr.ToString());
                        if (G.ListVariables[indexTool[cbNameVar.SelectedIndex]].LostTime != null)
                            List.Add(G.ListVariables[indexTool[cbNameVar.SelectedIndex]].LostTime.Name);
                        if (G.ListVariables[indexTool[cbNameVar.SelectedIndex]].CycleTime != null)
                            List.Add(G.ListVariables[indexTool[cbNameVar.SelectedIndex]].CycleTime.Name);
                        List.Add(txtShow.Text);
                        List.Add(1 + "");
                        List.Add(colorDlg.Color.ToString());
                        List.Add(font);
                        List.Add(fontDlg.Color.ToString());
                        // List.Add(100+"");
                        //blckLabel, blckVal, isConst
                        List.Add(blckLabel + "");
                        List.Add(blckVal + "");
                        List.Add(isConst + "");
                        List.Add(valDefaut + "");
                        List.Add(txtMaxtime.Value + "");
                        SQLITE.Insert("Time", List);
                        //LoadData("CycleTime");
                        G.sourceSQL = G.VariableSQL;
                    }
                    else if (TypeGr == TypeGr.Yield)
                    {
                        ListToolTemp = new ToolGr(cbName.Text, txtShow.Text, TypeGr, G.ListVariables[indexTool[cbNameVar.SelectedIndex]], new SolidBrush(fontDlg.Color), new SolidBrush(colorDlg.Color), sizeLine, valDefaut, fontDlg.Font, blckLabel, blckVal, isConst);
                        G.ListToolGr.Add(ListToolTemp);

                    }

                    if (TypeGr == TypeGr.Rectanger || TypeGr == TypeGr.Line || TypeGr == TypeGr.Yield)
                    {
                        G.sourceSQL = G.ToolSQL;
                        List<string> List = new List<string>();
                        List.Add(cbName.Text);
                        List.Add(TypeGr.ToString());
                        SQLITE.Insert("TOOL", List);
                        var cvt = new FontConverter();
                        string font = cvt.ConvertToString(fontDlg.Font);
                        List = new List<string>();
                        List.Add(cbName.Text);
                        List.Add(TypeGr.ToString());
                        if (G.ListVariables[indexTool[cbNameVar.SelectedIndex]].Name != null)
                            List.Add(G.ListVariables[indexTool[cbNameVar.SelectedIndex]].Name);
                        else if (G.ListVariables[indexTool[cbNameVar.SelectedIndex]].Yield != null)
                            List.Add(G.ListVariables[indexTool[cbNameVar.SelectedIndex]].Yield.Name);

                        List.Add(txtShow.Text);
                        List.Add(sizeLine + "");

                        List.Add(colorDlg.Color.ToString());
                        List.Add(font);
                        List.Add(fontDlg.Color.ToString());
                        // List.Add(100+"");
                        //blckLabel, blckVal, isConst
                        List.Add(blckLabel + "");
                        List.Add(blckVal + "");
                        List.Add(isConst + "");
                        List.Add(valDefaut + "");
                        SQLITE.Insert("Quantity", List);
                        //LoadData("CycleTime");
                        G.sourceSQL = G.VariableSQL;
                    }
                    cbName.Items.Clear();
                    foreach (ToolGr ToolGr in G.ListToolGr)
                    {

                        cbName.Items.Add(ToolGr.Name);

                    }
                    cbName.SelectedIndex = -1;
                    MessageBox.Show("Đã thêm Tool thành công!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Đã thêm Tool thật bại!");
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Bạn muốn Update Tool : " + Environment.NewLine + cbName.Text, "Update Tool", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        if (TypeGr == TypeGr.Rectanger || TypeGr == TypeGr.Line)
                        {

                            ListToolTemp = new ToolGr(cbName.Text, txtShow.Text, TypeGr, G.ListVariables[indexTool[cbNameVar.SelectedIndex]], new SolidBrush(fontDlg.Color), new SolidBrush(colorDlg.Color), sizeLine, valDefaut, fontDlg.Font, blckLabel, blckVal, isConst);
                            G.ListToolGr[cbName.SelectedIndex] = ListToolTemp;

                        }
                        else if (TypeGr == TypeGr.Cycle || TypeGr == TypeGr.LostTime)
                        {
                            ListToolTemp = new ToolGr(cbName.Text, txtShow.Text, TypeGr, G.ListVariables[indexTool[cbNameVar.SelectedIndex]], new SolidBrush(fontDlg.Color), new SolidBrush(colorDlg.Color), double.Parse(txtMaxtime.Value + ""), fontDlg.Font, blckLabel, blckVal, isConst);
                            G.ListToolGr[cbName.SelectedIndex] = ListToolTemp;

                            G.sourceSQL = G.ToolSQL;

                            Dictionary<string, string> dic = new Dictionary<string, string>();
                            dic.Add("NAME", cbName.Text);
                            dic.Add("TYPE", TypeGr.ToString());
                            SQLITE.Update("TOOL", dic, "NAME='" + cbName.Text + "'", G.ToolSQL);
                            var cvt = new FontConverter();
                            string font = cvt.ConvertToString(fontDlg.Font);
                            dic.Clear();
                            dic = new Dictionary<string, string>();
                            dic.Add("NAME", cbName.Text);
                            dic.Add("TYPE", TypeGr.ToString());
                            if (G.ListVariables[indexTool[cbNameVar.SelectedIndex]].CycleTime != null)
                                dic.Add("Variables", G.ListVariables[indexTool[cbNameVar.SelectedIndex]].CycleTime.Name);
                            if (G.ListVariables[indexTool[cbNameVar.SelectedIndex]].LostTime != null)
                                dic.Add("Variables", G.ListVariables[indexTool[cbNameVar.SelectedIndex]].LostTime.Name);
                            dic.Add("TEXT", txtShow.Text);
                            dic.Add("SIZE", sizeLine + "");
                            dic.Add("COLOR", colorDlg.Color.ToString());
                            dic.Add("FONT", font);
                            dic.Add("TCOLOR", fontDlg.Color.ToString());
                            dic.Add("isVAL", blckLabel + "");
                            dic.Add("isLAB", blckVal + "");
                            dic.Add("isCONST", isConst + "");
                            dic.Add("DEFAUT", valDefaut + "");
                            dic.Add("MAXTIME", txtMaxtime.Value + "");
                            SQLITE.Update("Time", dic, "NAME='" + cbName.Text + "'", G.ToolSQL);
                            G.sourceSQL = G.VariableSQL;
                        }
                        else if (TypeGr == TypeGr.Yield)
                        {
                            ListToolTemp = new ToolGr(cbName.Text, txtShow.Text, TypeGr, G.ListVariables[indexTool[cbNameVar.SelectedIndex]], new SolidBrush(fontDlg.Color), new SolidBrush(colorDlg.Color), sizeLine, valDefaut, fontDlg.Font, blckLabel, blckVal, isConst);
                            G.ListToolGr[cbName.SelectedIndex] = ListToolTemp;

                        }

                        if (TypeGr == TypeGr.Rectanger || TypeGr == TypeGr.Line || TypeGr == TypeGr.Yield)
                        {
                            G.sourceSQL = G.ToolSQL;



                            Dictionary<string, string> dic = new Dictionary<string, string>();
                            dic.Add("NAME", cbName.Text);
                            dic.Add("TYPE", TypeGr.ToString());
                            SQLITE.Update("TOOL", dic, "NAME='" + cbName.Text + "'", G.ToolSQL);
                            var cvt = new FontConverter();
                            string font = cvt.ConvertToString(fontDlg.Font);
                            dic = new Dictionary<string, string>();
                            dic.Clear();
                            dic.Add("NAME", cbName.Text);
                            dic.Add("TYPE", TypeGr.ToString());
                            if (G.ListVariables[indexTool[cbNameVar.SelectedIndex]].Name != null)
                                dic.Add("Variables", G.ListVariables[indexTool[cbNameVar.SelectedIndex]].Name);
                            else if (G.ListVariables[indexTool[cbNameVar.SelectedIndex]].Yield.Name != null)
                                dic.Add("Variables", G.ListVariables[indexTool[cbNameVar.SelectedIndex]].Yield.Name);
                            dic.Add("TEXT", txtShow.Text);
                            dic.Add("SIZE", sizeLine + "");
                            dic.Add("COLOR", colorDlg.Color.ToString());
                            dic.Add("FONT", font);
                            dic.Add("TCOLOR", fontDlg.Color.ToString());
                            dic.Add("isVAL", blckLabel + "");
                            dic.Add("isLAB", blckVal + "");
                            dic.Add("isCONST", isConst + "");
                            dic.Add("DEFAUT", valDefaut + "");

                            SQLITE.Update("Quantity", dic, "NAME='" + cbName.Text + "'", G.ToolSQL);
                            G.sourceSQL = G.VariableSQL;
                        }

                        MessageBox.Show("Đã sửa Tool thành công!");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Sửa Tool thất bại!");
                    }
                }
            }
        }
        private void txtShow_TextChanged(object sender, EventArgs e)
        {
            picReview.Invalidate();
        }
        ToolGr ListToolTemp;
        bool blckLabel = false, blckVal = true;
        int sizeLine = 1;
        Point sizeTool;
        TypeGr TypeGr;
        List<int> indexTool = new List<int>();
        bool blEditTool;
        private void btnEditTool_Click(object sender, EventArgs e)
        {
            
            if (blEditTool == false)
            {
                G.ListToolChart = new List<ToolChart>();
                G.ListToolChart = G.ListGraphic[cbChart.SelectedIndex].ToolChart;
                blChart = false;
                picReview2.Invalidate();
                
                btnEditTool.BackColor = Color.Cornsilk;
                btnPlusTool.Enabled = true;
                btnPlusTool.BackColor = Color.White;
                btnXoa.Enabled = false;
                btnXoa.BackColor = Color.LightGray;
                
                
            }
            else
            {
                blChart = true;
                picReview2.Invalidate();
                btnPlusTool.Enabled = false;
                btnPlusTool.BackColor = Color.LightGray;
                btnEditTool.BackColor = Color.White;
                pPlusTool.Visible = false;
                blPlusTool = false;
                btnXoa.Enabled = true;
                btnXoa.BackColor = Color.White;
            }
            blEditTool = !blEditTool;

        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            if (indexRedo.Count != 0)
            {
                btnClear.Enabled = true;
                btnClear.BackColor = Color.LavenderBlush;
                btnReturn.BackColor = Color.LightBlue;
                btnReturn.Enabled = true;

                tracOffChartX.Enabled = true;
                tracOffChartY.Enabled = true;
                
                G.ListToolChart.Add(new ToolChart(G.ListToolTemp[indexRedo[indexRedo.Count - 1]], pRedo[pRedo.Count-1]));
                tracOffChartX.Value = G.ListToolChart[G.ListToolChart.Count - 1].pDrawing.X;
                tracOffChartY.Value = G.ListToolChart[G.ListToolChart.Count - 1].pDrawing.Y;
             
                if (G.ListToolChart.Count != 0 && G.ListToolChart[G.ListToolChart.Count-1].ToolGr.TypeGr == TypeGr.Rectanger)
                {
                    int szOffset = G.ListToolChart[G.ListToolChart.Count - 1].ToolGr.sizeFont;
                    pOffset = new Point(pOffset.X + szOffset + szOffset / 10, pOffset.Y);
                }
                indexRedo.RemoveAt(indexRedo.Count - 1);
                pRedo.RemoveAt(pRedo.Count - 1);
                picReview2.Invalidate();
            }
            else
            {
                btnRedo.BackColor = Color.LightGray;
                btnRedo.Enabled = false;
            }
        }
        bool blClear = false;
        private void btnClear_Click(object sender, EventArgs e)
        {

        }
        bool blControl;
        private void btnControl_Click(object sender, EventArgs e)
        {
            
            if (blControl == false)
            {
                pControl.Visible = true;
                btnControl.BackColor = Color.Cornsilk;
            }
            else
            {
                pControl.Visible = false;
                btnControl.BackColor = Color.White;
            }
            blControl = !blControl;
        }
        int valMinRow = 10;
        private void numMinRow_ValueChanged(object sender, EventArgs e)
        {
            valMinRow =Convert.ToInt32( numMinRow.Value);
            try
            {
                ListGraphicTemp.MIN = valMinRow;
            }
            catch(Exception)
            {

            }
            picReview2.Invalidate();
        }
        int valMax = 2000;
        private void txtMax_ValueChanged(object sender, EventArgs e)
        {
            valMax =Convert.ToInt32( txtMax.Value);
           
            try
            {
                ListGraphicTemp.Max = valMax;
            }
            catch (Exception)
            {

            }
            picReview2.Invalidate();
        }

        private void ckGird_CheckedChanged(object sender, EventArgs e)
        {
            ListGraphicTemp.GIRD = ckGird.Checked;
            picReview2.Invalidate();
        }

        private void tracTranspa_Scroll(object sender, EventArgs e)
        {
            picReview.Invalidate();
        }

        bool blNewTool = false;
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFS_FV.GRAPHIC
{
    public class ListData
    {
        public string Name;
        public ToolChart ToolChart;
        public int Step
            ; public double TimeReset; public bool Enable;
        public Point Offset;
        public DateTime  TimeBegin;
        public int valTemp=0,val=0;
        public double valTemp2 = 0, val2 = 0;
        public List<double> timer = new List<double>();
        public List<double> cycle = new List<double>();
        public List<Point> pDwaring = new List<Point>();
        public ListData( ToolChart ToolChart,int val,int valTemp)
        {
            
            this.ToolChart = ToolChart;
            this.valTemp = valTemp;
            this.val = val;
        }
        public List<double> lost=new List<double>();
        public List<double> timeLost = new List<double>();
        public ListData(ToolChart ToolChart, List<Point>pDwaring, List<double> timer, List<double> cycle, List<double> lost, List<double> timeLost)
        {

            this.ToolChart = ToolChart;          
            this.timer = timer;
            this.cycle = cycle;
            this.pDwaring = pDwaring;
            this.lost = lost;
            this.timeLost = timeLost;
          
        }
        public List<Point> values=new List<Point>();
        public ListData(ToolChart ToolChart,  List<Point> values)
        {
          this.ToolChart = ToolChart;
          this.values = values;                               
        }
       public List<double> valueYield = new List<double>();
        public List<Point> pYield = new List<Point>();
        public List<int> tempOK = new List<int>();
        public List<int> tempNG = new List<int>();
        public ListData(ToolChart ToolChart, List<double> valueYield, List<int> tempOK, List<int> tempNG, List<Point> pYield)
        {
            this.ToolChart = ToolChart;
            this.pYield = pYield;
            this.valueYield = valueYield;
            this.tempOK = tempOK;
            this.tempNG = tempNG;
           
        }
    }
}

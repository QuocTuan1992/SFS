using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFS_FV.GRAPHIC
{
   public class ListGraphic
    {
        public string Name;
        public List<ToolChart> ToolChart=new List<GRAPHIC.ToolChart>();
        public int TimeUpdate; public double TimeReset; public bool Enable;
        public Point Offset;
        public int Step, Max;
        public DateTime TimeBegin;
        public int MIN;
        public bool GIRD;
        public List<List<ListData>> ListData = new List<List<ListData>>();
        public ListGraphic(string Name,List<ToolChart> ToolChart,List<List<ListData>> ListData, DateTime TimeBegin, double TimeReset, int TimeUpdate,int Max,Point Offset,int MIN,bool GIRD)
        {
            this.Name = Name;
            this.ListData = ListData;
            this.TimeBegin = TimeBegin;
            this.TimeReset = TimeReset;
            this.TimeUpdate = TimeUpdate;
            this.Max = Max;
            this.ToolChart = ToolChart;
            this.Offset = Offset;
            this.MIN = MIN;
            this.GIRD = GIRD;


        }
    }
}

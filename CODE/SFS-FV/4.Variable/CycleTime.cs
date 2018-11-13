using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFS_FV
{
  public   class CycleTime
    {


        public ListVariables ListVariables;
        public DateTime dtBegin; public DateTime dtEnd;
        public isCycle isCycle;
        public string Name, cycleTime;
        public int numScan, tempValue;
        public bool blStartCycle;
     ////   public List<double> timer = new List<double>();
      //  public List<double> Value = new List<double>();
        public CycleTime(string Name, ListVariables ListVariables, string cycleTime,int tempValue, int numScan, DateTime dtBegin, DateTime dtEnd, isCycle isCycle,bool blStartCycle)
        {
            this.Name = Name;
            this.cycleTime = cycleTime;
            this.numScan = numScan;
            this.dtBegin = dtBegin;
            this.dtEnd = dtEnd;
            this.isCycle = isCycle;
            this.tempValue = tempValue;
            this.ListVariables = ListVariables;
            this.blStartCycle = blStartCycle;
          //  this.pDrawing = pDrawing;

        }
    }
}

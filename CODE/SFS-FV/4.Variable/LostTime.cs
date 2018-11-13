using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFS_FV.Local
{
    public class LostTime
    {
        public ListVariables ListVariables;
        public DateTime dtBegin; public DateTime dtEnd;
        public isLost isLost;
        public string Name, LostTimes;
        public int timeMax, tempValue;
        public bool blStart;       
        public LostTime(string Name, ListVariables ListVariables, string LostTimes, int tempValue, int timeMax, DateTime dtBegin, DateTime dtEnd, isLost isLost, bool blStart)
        {
            this.Name = Name;
            this.LostTimes = LostTimes;
            this.timeMax = timeMax;
            this.dtBegin = dtBegin;
            this.dtEnd = dtEnd;
            this.isLost = isLost;
            this.tempValue = tempValue;
            this.ListVariables = ListVariables;
            this.blStart = blStart;          
        }
    }
}

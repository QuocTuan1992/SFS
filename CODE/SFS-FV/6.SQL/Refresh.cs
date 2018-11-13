using DATABUILDERAXLibEx;
using SFS_FV.GRAPHIC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFS_FV.SQL
{
   public class Refresh
    {
        SQLITE SQLITE = new SQLITE();
        public Refresh()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("VALUE", 0 + "");
            SQLITE.Update("BIT", dic, "", G.sourceSQL);
            Enum eModel;
          
            foreach (ListVariables ListVariables in G.ListVariables)
            {
                if (ListVariables.Name != null)
                {
                    string Model = ListVariables.Device.plcKey.PLC.ToString().Split('_')[1] + "_" + ListVariables.Area;
                    eModel = (DBPlcDevice)Enum.Parse(typeof(DBPlcDevice), Model);
                    ListVariables.Device.plcKey.WriteDevice((DBPlcDevice)eModel, ListVariables.bit, 0);
                }
                if (ListVariables.CycleTime != null)
                {

                    ListVariables.CycleTime.tempValue = 0;
                    ListVariables.CycleTime.isCycle = isCycle.open;
                    ListVariables.CycleTime.blStartCycle = false;
                    Dictionary<string, string> dic1 = new Dictionary<string, string>();
                    dic1.Add("CycleTime", "0");
                    dic1.Add("TempValue", "0");


                    SQLITE.Update("CycleTime", dic1, "NAME='" + ListVariables.CycleTime.Name + "'", G.VariableSQL);
                }



            }

        }
    }
}

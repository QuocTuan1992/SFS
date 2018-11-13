using SFS_FV.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFS_FV.Data
{
    class DATAHOUR
    {
        SQLITE SQLITE = new SQLITE();
        public DATAHOUR(string timeBegin)
        {
            G.sourceSQL = G.VariableSQL;
            string datenows = DateTime.Now.ToString("yyyy-MM-dd");
            foreach (ListVariables ListVariables in G.ListVariables)
            {
                List<string> list = new List<string>();
                string nameVariable = "";
                int iShift = G.Shift + 1;
                if (ListVariables.Name != null) nameVariable = ListVariables.Name;
                else if (ListVariables.CycleTime != null) nameVariable = ListVariables.CycleTime.Name;
                else if (ListVariables.Yield != null) nameVariable = ListVariables.Yield.Name;
                else if (ListVariables.LostTime != null) nameVariable = ListVariables.LostTime.Name;

                if (!SQLITE.CHECK("*", "DATEHOUR", "DATE='" + datenows + "' AND SHIFT ='" + iShift + "' AND HOUR ='" + timeBegin + "'  AND VARIABLE ='" + nameVariable + "'"))
                {
                    list.Add(datenows);
                    list.Add(iShift + "");
                    list.Add(timeBegin);
                    list.Add(nameVariable + "");
                    list.Add(ListVariables.Val + "");

                    SQLITE.Insert("DATEHOUR", list);
                }
                else
                {
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    dic.Add("VALUE", ListVariables.Val + "");
                    SQLITE.Update("DATEHOUR", dic, "DATE='" + datenows + "' AND SHIFT ='" + iShift + "' AND HOUR ='" + timeBegin + "'  AND VARIABLE ='" + nameVariable + "'", G.VariableSQL);
                }
            }
        }
    }
}

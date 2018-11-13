using DATABUILDERAXLibEx;
using SFS_FV.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFS_FV.Data
{
    class ReadData
    {
        SQLITE SQLITE=new SQLITE();
        LoadData LoadData;
        public ReadData()
        {
            Enum eModel;            
            G.sourceSQL = G.VariableSQL;
            int index = 0;
            foreach (ListVariables ListVariables in G.ListVariables)
            {
                if (ListVariables.Device != null)
                {
                    if (ListVariables.Device.isConnect == isConnect.Connected)
                    {
                        int valBit = 0;
                        Dictionary<string, string> dic = new Dictionary<string, string>();
                        dic = new Dictionary<string, string>();
                        dic.Clear();
                        string Model = ListVariables.Device.plcKey.PLC.ToString().Split('_')[1] + "_" + ListVariables.Area;
                        eModel = (DBPlcDevice)Enum.Parse(typeof(DBPlcDevice), Model);
                        valBit = ListVariables.Device.plcKey.ReadDevice((DBPlcDevice)eModel, ListVariables.bit);
                        if (int.Parse(G.ListVariables[index].Val) != valBit)
                        {
                            G.ListVariables[index].Val = valBit + "";
                            dic = new Dictionary<string, string>();
                            dic.Add("VALUE", G.ListVariables[index].Val + "");
                            SQLITE.Update("Global", dic, "NAME='" + G.ListVariables[index].Name + "'", G.VariableSQL);
                            LoadData = new LoadData("Global");
                        }
                    }

                }
                else
                {
                    if (ListVariables.typeVariable == typeVariable2.CycleTime)
                    {
                        string Model = ListVariables.CycleTime.ListVariables.Device.plcKey.PLC.ToString().Split('_')[1] + "_" + ListVariables.CycleTime.ListVariables.Area;
                        eModel = (DBPlcDevice)Enum.Parse(typeof(DBPlcDevice), Model);

                        if (ListVariables.CycleTime.isCycle == isCycle.open)
                        {
                            // ListVariables.CycleTime.ListVariables.Val = G.ListVariables[index].CycleTime.ListVariables.Device.plcKey.ReadDevice((DBPlcDevice)eModel, ListVariables.CycleTime.ListVariables.bit) + "";
                            if (ListVariables.CycleTime.tempValue != int.Parse(ListVariables.CycleTime.ListVariables.Val) && ListVariables.CycleTime.tempValue != 0 && ListVariables.CycleTime.blStartCycle == false)
                            {
                                ListVariables.CycleTime.dtBegin = DateTime.Now; ListVariables.CycleTime.blStartCycle = true;
                                G.sourceSQL = G.VariableSQL;
                                Dictionary<string, string> dic = new Dictionary<string, string>();
                                dic.Add("TempValue", ListVariables.CycleTime.tempValue + "");
                                SQLITE.Update("CycleTime", dic, "NAME='" + G.ListVariables[index].CycleTime.Name + "'", G.VariableSQL);
                                LoadData = new LoadData("CycleTime");
                            }
                            if (ListVariables.CycleTime.blStartCycle == false)
                                ListVariables.CycleTime.tempValue = int.Parse(ListVariables.CycleTime.ListVariables.Val);
                            if (ListVariables.CycleTime.blStartCycle == true && int.Parse(ListVariables.CycleTime.ListVariables.Val) - ListVariables.CycleTime.tempValue >= Convert.ToInt32(ListVariables.CycleTime.numScan) - 1)
                            {

                                ListVariables.CycleTime.dtEnd = DateTime.Now;
                                G.spRead = ListVariables.CycleTime.dtEnd - ListVariables.CycleTime.dtBegin;
                                double second = (double)(G.spRead.Minutes * 60 + G.spRead.Seconds) / Convert.ToInt32(ListVariables.CycleTime.numScan);
                                ListVariables.CycleTime.cycleTime = second + "";
                                //  ListVariables.CycleTime.pDrawing.Add(new Point(-1, second));
                                ListVariables.CycleTime.blStartCycle = false;
                                ListVariables.CycleTime.tempValue = int.Parse(ListVariables.CycleTime.ListVariables.Val);
                                ListVariables.CycleTime.isCycle = isCycle.close;
                                Dictionary<string, string> dic = new Dictionary<string, string>();
                                dic.Add("CycleTime", ListVariables.CycleTime.cycleTime + "");
                                dic.Add("isCycle", isCycle.close.ToString() + "");
                                SQLITE.Update("CycleTime", dic, "NAME='" + G.ListVariables[index].CycleTime.Name + "'", G.VariableSQL);
                                LoadData = new LoadData("CycleTime");

                            }
                            G.sourceSQL = G.defautSQL;
                        }
                    }
                    if (ListVariables.typeVariable == typeVariable2.LostTime)
                    {
                        string Model = ListVariables.LostTime.ListVariables.Device.plcKey.PLC.ToString().Split('_')[1] + "_" + ListVariables.LostTime.ListVariables.Area;
                        eModel = (DBPlcDevice)Enum.Parse(typeof(DBPlcDevice), Model);

                        if (ListVariables.LostTime.isLost == isLost.open)
                        {
                            // ListVariables.LostTime.ListVariables.Val = G.ListVariables[index].LostTime.ListVariables.Device.plcKey.ReadDevice((DBPlcDevice)eModel, ListVariables.LostTime.ListVariables.bit) + "";
                            if (ListVariables.LostTime.tempValue != int.Parse(ListVariables.LostTime.ListVariables.Val) && ListVariables.LostTime.tempValue != 0 && ListVariables.LostTime.blStart == false)
                            {
                                ListVariables.LostTime.dtBegin = DateTime.Now; ListVariables.LostTime.blStart = true;
                                G.sourceSQL = G.VariableSQL;
                                Dictionary<string, string> dic = new Dictionary<string, string>();
                                dic.Clear();
                                dic = new Dictionary<string, string>();
                                dic.Add("TempValue", ListVariables.LostTime.tempValue + "");
                                SQLITE.Update("LostTime", dic, "NAME='" + G.ListVariables[index].LostTime.Name + "'", G.VariableSQL);
                                LoadData = new LoadData("LostTime");
                            }
                            if (ListVariables.LostTime.blStart == false)
                                ListVariables.LostTime.tempValue = int.Parse(ListVariables.LostTime.ListVariables.Val);
                            if (ListVariables.LostTime.blStart == true && int.Parse(ListVariables.LostTime.ListVariables.Val) - ListVariables.LostTime.tempValue >= Convert.ToInt32(ListVariables.LostTime.tempValue) - 1)
                            {

                                ListVariables.LostTime.dtEnd = DateTime.Now;
                                G.spRead = ListVariables.LostTime.dtEnd - ListVariables.LostTime.dtBegin;
                                double second = (double)(G.spRead.Minutes * 60 + G.spRead.Seconds) / Convert.ToInt32(ListVariables.LostTime.tempValue);
                                ListVariables.LostTime.LostTimes = second + "";
                                //  ListVariables.LostTime.pDrawing.Add(new Point(-1, second));
                                ListVariables.LostTime.blStart = false;
                                ListVariables.LostTime.tempValue = int.Parse(ListVariables.LostTime.ListVariables.Val);
                                ListVariables.LostTime.isLost = isLost.close;
                                Dictionary<string, string> dic = new Dictionary<string, string>();
                                dic.Clear();
                                dic.Add("LostTime", ListVariables.LostTime.LostTimes + "");
                                dic.Add("isCycle", isCycle.close.ToString() + "");
                                SQLITE.Update("LostTime", dic, "NAME='" + G.ListVariables[index].LostTime.Name + "'", G.VariableSQL);
                                LoadData = new LoadData("LostTime");

                            }
                            G.sourceSQL = G.defautSQL;
                        }
                    }
                }
                index++;
            }
          
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxDATABUILDERAXLibEx;
using DATABUILDERAXLibEx;
namespace SFS_FV.KEYENCE
{
    class KEYENCEs
    {
        public static AxDBCommManager plcKey = new AxDBCommManager();
     
     public   void Connects()
        {
            try
            {
                plcKey.Connect();
                plcKey.SetMode(true);
                G.isConnect = isConnect.Connected;
            }
            catch
            {
                G.isConnect = isConnect.Disconnected;
            }
        }
        public static AxDBCommManager Create(DBPlcId Model, Via Via, string Para)
        {
            try
            {
                plcKey = new AxDBCommManager();
                plcKey.CreateControl();
                plcKey.PLC = Model;
                plcKey.Peer = Via.ToString();
                if(Via!=Via.USB)
                plcKey.Peer = Para;
                plcKey.UseWaitCursor = true;
              
                plcKey.Connect();


                G.isConnect = isConnect.Connected;
            
            }
            catch(Exception)
            {
                G.isConnect = isConnect.Disconnected;
            }
            return plcKey;
        }
        public static AxDBCommManager Connnect(AxDBCommManager plcKey)
        {
            try
            {
                plcKey.Connect();
                plcKey.SetMode(true);
                return plcKey;
            }
            catch (Exception)
            {
                G.isConnect = isConnect.Disconnected;
            }
            return plcKey;
        }
    }
}

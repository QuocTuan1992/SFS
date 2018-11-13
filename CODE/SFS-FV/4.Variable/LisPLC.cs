using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxDATABUILDERAXLibEx;
using DATABUILDERAXLibEx;
using System.Drawing;
using SFS_FV.KEYENCE;

namespace SFS_FV
{
  public  class LisPLC
    {
        public AxDBCommManager plcKey = new AxDBCommManager();
        public string Para, name,Co,Mod;
        public Via Via;
        public isConnect isConnect;
        public Image imgModel;
        public Image imgVia;
        public Point pMap;
        public LisPLC(string name,string Co,string Mod, Via Via,string Para, AxDBCommManager plcKey, isConnect isConnect, Image imgModel, Image imgVia, Point pMap)
        {
            this.name = name;
            this.plcKey = plcKey;
            this.Para = Para;
            this.isConnect = isConnect;
            this.imgModel = imgModel;
            this.imgVia = imgVia;
            this.pMap = pMap;
            this.Mod = Mod;
            this.Co = Co;
            this.Via = Via;
        }
        public LisPLC(AxDBCommManager plcKey, isConnect isConnect, Image imgModel, Point pMap)
        {
            //this.name = name;
            this.plcKey = plcKey;

            this.isConnect = isConnect;
            this.imgModel = imgModel;
            this.pMap = pMap;
        }
    }
}

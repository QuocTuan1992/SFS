using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxDATABUILDERAXLibEx;
using DATABUILDERAXLibEx;
using System.Drawing;

namespace SFS_FV.KEYENCE
{
  public  class ListKey
    {
        public AxDBCommManager plcKey = new AxDBCommManager();
        public string Para,name;
        public Via Via;
        public isConnect isConnect;
        public Image imgModel;
        public Point pMap;
        public ListKey (string name, AxDBCommManager plcKey,  isConnect isConnect,Image imgModel,Point pMap)
        {
            this.name = name;
            this.plcKey = plcKey;
            
            this.isConnect = isConnect;
            this.imgModel = imgModel;
            this.pMap = pMap;
        }
    }
}

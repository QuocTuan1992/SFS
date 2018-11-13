using DATABUILDERAXLibEx;
using SFS_FV.KEYENCE;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFS_FV.Data
{
    class Online
    {
        Error Error;
        public Online()
        {
            int index = 0; bool blConnect = false;
            foreach (LisPLC LisPLC in G.LisPLC)
            {
                // AxDBCommManager plcTemp = new AxDBCommManager();

                DBPlcId eModel = (DBPlcId)Enum.Parse(typeof(MOD), LisPLC.Mod.Replace("-", ""));

                Via eVia = LisPLC.Via;
               // KEYENCEs.Create(eModel, eVia, LisPLC.Para);

                G.LisPLC[index].plcKey = KEYENCEs.Create(eModel, eVia, LisPLC.Para);
                // G.LisPLC[index].plcKey = KEYENCE.KEYENCEs.Connnect(LisPLC.plcKey);
                G.LisPLC[index].isConnect = G.isConnect;
                if (G.isConnect == isConnect.Disconnected) 
                {
                    int num=index+1;
                    G.sError = "ERROR 0X02  : " + "LỖI ĐƯỜNG TRUYỀN KẾT NỐI VỚI LINE !" + Environment.NewLine + "VUI LÒNG KIỂM TRA LẠI KẾT NỐI VỚI THIẾT BỊ :" + LisPLC.name +"("+ LisPLC.Para+")";
                    G.imgError = new Bitmap("pic\\errorWifi.gif");
                    Error = new Error();
                    Error.ShowDialog();          //  this.Hide();
                   
                    break;
                    blConnect = true;

                }
                index++;
            }
          
        }
    }
}

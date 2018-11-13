using SFS_FV.GRAPHIC;
using SFS_FV.KEYENCE;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SFS_FV
{
    public enum PLC
    {
        KEYENCE,
        MISUBISHI,
        OMRON
    }
    public enum MOD
    {
        KV3000=515,
        KV5000 = 515,
        KV7000 = 525
    }
    public enum AreaKey
    {
        R=0,
        MR = 1,
        DM = 2,
        EM = 3,
        FM=4,
        W=5
    }
    public enum isConnect
    {
        Connected,
        Disconnected,

    }
    public enum isBit
    {
        _using,
        _unusing

    }
    public enum isCycle
    {
        open,
        close

    }
    public enum isLost
    {
        open,
        close

    }
    public enum isYield
    {
        open,
        close

    }
    public enum typeBit
    {
        ints,
        strings

    }
    public enum typeVariable
    {
     
        DEVICE,
        Global,
        CycleTime,
        Yield,
        LostTime,
        TYPE,
        CO,
        MOD,
        AREA

    }
    public enum typeVariable2
    {

     
        Global,
        CycleTime,
        Yield,
        LostTime,
        Plus
       

    }
    public enum Via
    {
        USB=0,
        SERIALPORT=1,
        ENTHERNET=2
    }
    public enum TypeGr
    {
        Cycle,
        LostTime,
        Yield,
        Circle,
        Rectanger ,
        Line 
    }
    public enum Shift
    {
        Ca_1,
        Ca_2,
        Ca_3
    }
    public enum OT
    {
        Nữa_tiếng,
        Một_tiếng,
        Một_tiếng_rưỡi,
        Hai_tiếng,
        Hai_tiếng_rưỡi,
        Ba_tiếng,
        Ba_tiếng_rưỡi,
        Bốn_tiếng,
        Bốn_tiếng_rưỡi,
        Năm_tiếng,
        Năm_tiếng_rưỡi,
        Sáu_tiếng,
    }
    public struct G
    {
        public static string sourceSQL = "Data source =SQL\\Data.sqlite;Version=3;New=False;Compress=True;SetPassword=12345678";
        public static string defautSQL = "Data source =SQL\\Data.sqlite;Version=3;New=False;Compress=True;SetPassword=12345678";
        public static string DATASQL = "Data source =SQL\\DATA.sfs;Version=3;New=False;Compress=True;SetPassword=12345678";
        public static string curTab = "TYPE";
        public static string curColumn = "";
        public static string curMode = "";
        public static string MODEL = "";
        public static string AREA = "";
        public static string CO = "";
        public static string BIT = "";
        public static int numBIT = 1;
        public static string TYPE = "PLC";
        public static double w_Start, w_Stop, st_Word, st_Bit;
        public static List<LisPLC> LisPLC = new List<LisPLC>();
        public static List<ListVariables> ListVariables = new List<ListVariables>();
        public static List<ListGraphic> ListGraphic = new List<GRAPHIC.ListGraphic>();
        public static List<ToolGr> ListToolGr = new List<ToolGr>();
        public static List<ToolChart> ListToolChart = new List<ToolChart>();
        public static List<ToolGr> ListToolTemp = new List<ToolGr>();
        public static Point pPen = new Point(0, 0);
        public static isConnect isConnect = isConnect.Disconnected;
        
        public static string pathSQL="";
        public static List<string> ListIp = new List<string>();
        public static string AddIPLoacal = "";
        public static string portIP = "";
        public static Point pNewDevice=new Point(0,0);
        public static Point pForm1 = new Point(0, 0);
        public static Point sForm1 = new Point(0, 0);
        public static List<string> LisDevice = new List<string>();
        public static Point spicReview = new Point(150, 150);
        public static Point penChart,sizChart=new Point(40,100);
        public static Brush colChart=Brushes.Green;
        public static int zoomChart = 1;
        public static int zoom = 1;
        public static int ixData = 0;
        public static List<List<ListData>> ListData = new List<List<GRAPHIC.ListData>>();
        public static CreateGraphic CreateGraphic = new CreateGraphic();
        public static List<string> ListHour = new List<string>();
        public static List<ListData> ListDataTemp = new List<GRAPHIC.ListData>();
        public static string VariableSQL= "Data source =SQL\\Variables.sfs; Version=3;New=False;Compress=True;SetPassword=12345678";
        public static string ToolSQL = "Data source = SQL\\TOOL.sfs; Version=3;New=False;Compress=True;SetPassword=12345678";
        public static string ChartSQL = "Data source = SQL\\CHART.sfs; Version=3;New=False;Compress=True;SetPassword=12345678";
        public static Point localMain;
        public static int Shift = 0;
        public static int OTshift = 0;
        public static List<string> listHShift = new List<string>();
        public static List<string> listDShift = new List<string>();
        public static TimeSpan spRead;
        public static bool blSQLITE, blOnline;
        public static string sError;
        public static Image imgError;
        public static  int wScreen;
        public static  int hScreen;
        public static string sWatting;
        public static string editTile;
        ///
        public static List<string> sPicAvatar = new List<string>();
        public static List<string> sBegin = new List<string>();
        public static List<double> cycleTimeSum = new List<double>();
        public static double lostTimeSumH;
        public static double lostTimeSumM;
        public static double lostTimeSumS;
    }
    class Global
    {
    }
}

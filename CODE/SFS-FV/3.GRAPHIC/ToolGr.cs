using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFS_FV.GRAPHIC
{
  public  class ToolGr
    {
        public string Name; public TypeGr TypeGr; public ListVariables ListVariables; 
        public bool isChar, isVal,isConst;
        public string sShow;
        public Brush BackColor;
        public Brush brFont;
        public Font font;
        public int sizeFont,defaut;
        public double  maxTime;
        public ToolGr(string Name,string sShow,TypeGr TypeGr,ListVariables ListVariables, Brush brFont, Brush BackColor,int sizeFont,int defaut,Font font,bool isChar,bool isVal,bool isConst)
        {
            this.Name = Name;
            this.TypeGr = TypeGr;
            this.ListVariables = ListVariables;
            this.BackColor = BackColor;
            this.brFont = brFont;
            this.sShow = sShow;
            this.isChar = isChar;
            this.isVal = isVal;
            this.font = font;
            this.sizeFont = sizeFont;
            this.isConst = isConst;
            this.defaut = defaut;
        }
        public ToolGr(string Name, string sShow, TypeGr TypeGr, ListVariables ListVariables, Brush brFont, Brush BackColor,  double maxTime, Font font,bool isChar, bool isVal, bool isConst)
        {
            this.Name = Name;
            this.TypeGr = TypeGr;
            this.ListVariables = ListVariables;
            this.BackColor = BackColor;
            this.brFont = brFont;
            this.sShow = sShow;
            this.isChar = isChar;
            this.isVal = isVal;
            this.font = font;
          
            this.isConst = isConst;
            this.maxTime = maxTime;
        }
    }
}

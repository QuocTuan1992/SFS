using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFS_FV.GRAPHIC
{
   public class ToolChart
    {
        public ToolGr ToolGr; public Point pDrawing;
        public ToolChart(ToolGr ToolGr,Point pDrawing)
        {
            this.ToolGr = ToolGr;
            this.pDrawing = pDrawing;
        }
    }
}

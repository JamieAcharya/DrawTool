using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawTool
{
    public abstract class Shape //Abstract Class
    {
        //Abstract method
        protected int x, y;
        protected int size = 10;
        protected Pen myPen = new Pen(Color.Black);
        public abstract void Display(Graphics drawArea);
    }
}

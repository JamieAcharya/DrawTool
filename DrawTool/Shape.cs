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
        protected float x, y, width, height;
        protected int size;
        protected Pen myPen = new Pen(Color.Black);
        public abstract void Display(Graphics drawArea);
        public Shape()
        {
        }

        public Shape(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public virtual void set(params float[] list)
        {

         
        }
        protected float P1,P2,P3;

    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawTool
{
    /*
    * Shape Abstract class
    * Sets up shape x,y coordinates and colour
    * All derrived classes will implement these methods
    */
    public abstract class Shape : ShapesInterface //Abstract Class using inheritance
    {
        //Abstract method
        protected float x, y;
        protected int size;
        protected float width, height;
        protected Pen myPen = new Pen(Color.Black); //creates pen object setting colour to black
        public abstract void Display(Graphics drawArea); //draws shape
        public Shape()
        {
        }

        public Shape(float x, float y)
        {
            this.x = x; //x coord
            this.y = y; //y coord
        }

        public abstract void set(params float[] list);

        protected float P1,P2,P3;

    }
}

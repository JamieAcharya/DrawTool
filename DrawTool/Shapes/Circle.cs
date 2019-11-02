using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawTool
{
   /*
   * Circle Shape class
   * Setups constructors need to draw circle (size)
   */
    public class Circle : Shape
    {
        public Circle(float initX, float initY, int initSize)
            : base(initX, initY)
        {
            x = initX;
            y = initY;
            size = initSize;
        }
        public override void Display(Graphics drawArea)
        {
            drawArea.DrawEllipse(myPen, x, y, size, size);
        }

        public override void set(params float[] list)
        {
            this.x = list[1];
            this.y = list[2];
        }
    }
}

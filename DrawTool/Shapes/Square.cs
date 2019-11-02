using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawTool
{
   /*
   *  Square Shape class
   * Setups constructor need to draw square (size)
   */
    public class Square : Shape
    {
        public Square(float initX, float initY, int initSize)
            : base(initX, initY)
        {
            x = initX;
            y = initY;
            size = initSize;

        }
        public override void Display(Graphics drawArea)
        {
            drawArea.DrawRectangle(myPen, x, y, size, size);
        }

        public override void set(params float[] list)
        {
            this.x = list[1];
            this.y = list[2];
        }
    }

}

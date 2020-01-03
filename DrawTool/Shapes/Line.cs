using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawTool
{

    /// <summary>
    /// Line (drawTo) Shape class
    /// Sets up constructors need to draw line(x and y coords)
    /// </summary>
    public class Line : Shape
    {
        public Line()
        {
        }

        public Line(float initX, float initY, int initSize)
            : base(initX, initY)
        {
            x = initX;
            y = initY;
            size = initSize;

        }
        public override void Display(Graphics drawArea)
        {
            drawArea.DrawLine(myPen, x, y, size, size);
        }

        public override void set(params float[] list)
        {
            this.x = list[1];
            this.y = list[2];
        }
    }
}

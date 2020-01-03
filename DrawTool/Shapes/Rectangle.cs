using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawTool
{
    /// <summary>
    /// Rectangle Shape class
    /// Sets up constructors need to draw line(Width and Height)
    /// </summary>
    public class Rectangle : Shape
    {
        public Rectangle()
        {
        }

        public Rectangle(float initX, float initY, float initHeight, float initWidth)
            : base(initX, initY)
        {
            height = initHeight;
            width = initWidth;
            x = initX;
            y = initY;
        }
        public override void Display(Graphics drawArea)
        {
            drawArea.DrawRectangle(myPen, x, y, width, height);
        }

        public override void set(params float[] list)
        {
            this.height = list[1];
            this.width = list[2];
        }
    }
}

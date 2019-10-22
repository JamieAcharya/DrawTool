using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawTool
{
    //Creating and defining Square
    public class Square : Shape
    {
        public Square(int initX, int initY, int initSize)
            : base()
        {
            x = initX;
            y = initY;
            size = initSize;

        }
        public override void Display(Graphics drawArea)
        {
            drawArea.DrawRectangle(myPen, x, y, size, size);
        }
    }

}

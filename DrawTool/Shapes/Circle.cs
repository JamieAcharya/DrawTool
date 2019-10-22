using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawTool
{
    //Creating and defining Circle
    public class Circle : Shape
    {
        public Circle(float initX, float initY, int initSize)
            : base()
        {
            x = initX;
            y = initY;
            size = initSize;
        }
        public override void Display(Graphics drawArea)
        {
            drawArea.DrawEllipse(myPen, x, y, size, size);
        }
    }
}

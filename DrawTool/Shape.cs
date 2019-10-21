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


    //Creating and defining Circle
    public class Circle : Shape
    {
        public Circle(int initX, int initY)
            : base()
        {
            x = initX;
            y = initY;
        }
        public override void Display(Graphics drawArea)
        {
            drawArea.DrawEllipse(myPen, x, y, size, size);
        }
    }

    //Creating and defining Square
    public class Square : Shape
    {
        public Square(int initX, int initY)
            : base()
        {
            x = initX;
            y = initY;
        }
        public override void Display(Graphics drawArea)
        {
            drawArea.DrawEllipse(myPen, x, y, size, size);
        }
    }


}

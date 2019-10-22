﻿using System;
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
}
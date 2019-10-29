using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawTool
{
    //Creating and defining Circle
    public class Triangle : Shape
    {
        PointF[] pnt;
        private Point[] trianglePoints;

        public Triangle()
        {
        }

        public Triangle(Point[] polygonPoints)
        {
            this.trianglePoints = polygonPoints;
        }

        public Triangle(float initP1, float initP2, float initP3)
            : base()
        {
            P1 = initP1;
            P2 = initP2;
            P3 = initP3;
         
        }
        public override void Display(Graphics drawArea)
        {
            drawArea.DrawPolygon(myPen, trianglePoints);
        }
    }
}

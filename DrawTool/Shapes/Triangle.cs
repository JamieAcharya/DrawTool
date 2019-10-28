using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawTool
{
    //Creating and define  Triangle
    public class Triangle : Shape
    {
        Point p1;
        Point p2;
        Point p3;
        Point[] allPoints;


        public Triangle() : base()
        {

        }

        // PointF[] allPoints;
        public Triangle(float initX, float initY, int p1x, int p1y, int p2x, int p2y, int p3x, int p3y)
            : base(initX, initY)
        {
            width = initX;
            height = initY;

            p1.X = p1x;
            p1.Y = p1y;

            p2.X = p2x;
            p2.Y = p2y;

            p3.X = p3x;
            p3.Y = p3y;

        }


        public override void set(params float[] list)
        {
            base.set(list[0], list[1], list[2]);

            p1.X = (int)list[3];
            p1.Y = (int)list[4];

            p2.X = (int)list[5];
            p2.Y = (int)list[6];

            p3.X = (int)list[7];
            p3.Y = (int)list[8];

            allPoints = new Point[] { p1, p2, p3 };
        }


        public override void Display(Graphics drawArea)
        {
            drawArea.DrawPolygon(myPen, allPoints);
        }
    }
}

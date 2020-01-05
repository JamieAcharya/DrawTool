using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawTool
{
    /// <summary>
    /// Triangle Shape class
    /// Sets up constructor need to draw a Triangle (3 Sides)
    /// </summary>
    public class Curve : Shape
    {
        private Point[] curvePoints; //Array to Store given triangle coords

        public Curve()
        {
        }

        public Curve(Point[] curvePoints)
        {
            this.curvePoints = curvePoints;
        }

        public Curve(float initP1, float initP2, float initP3)
            : base()
        {
            P1 = initP1;
            P2 = initP2;
            P3 = initP3;


        }
        public override void Display(Graphics drawArea)
        {
            drawArea.DrawCurve(myPen, curvePoints);
        }

        public override void set(params float[] list)
        {
            throw new NotImplementedException();
        }
    }
}

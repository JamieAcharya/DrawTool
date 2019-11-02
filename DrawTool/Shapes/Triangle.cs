using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawTool
{
   /*
   *  Triangle Shape class
   * Setups constructors need to draw triangle (3 Sides)
   */
    public class Triangle : Shape
    {
        private Point[] trianglePoints; //Array to Store given triangle coords

        public Triangle()
        {
        }

        public Triangle(Point[] trianglePoints)
        {
            this.trianglePoints = trianglePoints;
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

        public override void set(params float[] list)
        {
            throw new NotImplementedException();
        }
    }
}

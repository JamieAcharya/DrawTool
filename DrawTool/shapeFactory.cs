using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawTool
{
    class shapeFactory
    {
        public Shape DrawShape(string shapeName)
        {
            shapeName = shapeName.ToLower();
            switch (shapeName)
            {
                case "circle":
                    return new Circle();
                case "line":
                    return new Line();
                case "rectangle":
                    return new Rectangle();
                case "square":
                    return new Square();
                case "triangle":
                    return new Triangle();
                default:
                    return new Circle();
                    if (shapeName == null)
                    {
                        ArgumentException argEx = new ArgumentException();
                        MessageBox.Show(argEx.Message + shapeName + " does not exist");
                        throw argEx;
                    }
            }
        }
    }
}

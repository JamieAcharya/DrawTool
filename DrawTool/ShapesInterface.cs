using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawTool
{
   /*
   * Shape Interface class
   * Creates Display method which all derrived classes need
   */
    interface ShapesInterface
    {

            void set(params float[] list);

            void Display(Graphics drawArea);
    }
}

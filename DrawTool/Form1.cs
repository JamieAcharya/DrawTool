using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawTool
{
    public partial class Form1 : Form
    {
        private List<Shape> group = new List<Shape>();
        public Form1()
        {
            InitializeComponent();
        }

        private void DrawCircle_Click(object sender, EventArgs e)
        {
            int x = int.Parse(xCoord.Text), y = int.Parse(yCoord.Text);
            Circle circle = new Circle(x, y);
            group.Add(circle);
            displayAll();
        }
        private void DrawSquare_Click(object sender, EventArgs e)
        {
            int x = int.Parse(xCoord.Text), y = int.Parse(yCoord.Text);
            Square square = new Square(x, y);
            group.Add(square);
            displayAll();
        }
        private void displayAll()
        {
            Graphics paper = pictureBox1.CreateGraphics();
            foreach (Shape shape in group)
            {
                shape.Display(paper);
            }
        }

      
    }
}

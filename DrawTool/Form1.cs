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

        public class globalVariables
        {
            //pen position drawing coords
            public static float xCoords_Draw = 0;
            public static float yCoords_Draw = 0;

            //pen position coordinates
            public static float moveTo_x = 0;
            public static float moveTo_y = 0;

            //circle variables
            public static float circle_size { get; set; }


        }
        private List<Shape> group = new List<Shape>();
        public Form1()
        {
            InitializeComponent();
        }





        private void DrawCircle_Click(object sender, EventArgs e)
        {
            //int x = int.Parse(xCoord.Text), y = int.Parse(yCoord.Text); //getting coords straight from textbox
            float x = globalVariables.xCoords_Draw, y = globalVariables.yCoords_Draw;
            int size = int.Parse(Size.Text);
            Circle circle = new Circle(x, y, size);
            group.Add(circle);
            displayAll();
        }
        private void DrawSquare_Click(object sender, EventArgs e)
        {
            int x = int.Parse(xCoord.Text), y = int.Parse(yCoord.Text);
            int size = int.Parse(Size.Text);
            Square square = new Square(x, y, size);
            group.Add(square);
            displayAll();
        }
        private void DrawLine_Click(object sender, EventArgs e)
        {
            int x = int.Parse(xCoord.Text), y = int.Parse(yCoord.Text);
            int size = int.Parse(Size.Text);
            Line line = new Line(x, y, size);
            group.Add(line);
            displayAll();
        }


        //grab commands/text from command line
        private void run_Click(object sender, EventArgs e)
        {
            foreach (string line in commandLine.Lines)
            {
                //stores commands in array and splits them by space 
                string[] command = line.Split(' ');
                //if moveTo command is entered overwrite starting coordinates
                if (command[0].Equals("moveTo"))
                {
                    if (command.Length == 3) //check if the correct number of parameters have been given
                    {
                        if (ConvertMoveto(command[1], command[2]))  //convert from string to float
                        {
                            globalVariables.xCoords_Draw = globalVariables.moveTo_x;
                            globalVariables.yCoords_Draw = globalVariables.moveTo_y;

                            string txtXCOORD = globalVariables.xCoords_Draw.ToString();
                            string txtYCOORD = globalVariables.yCoords_Draw.ToString();
                            xCoord.Text = txtXCOORD;
                            yCoord.Text = txtYCOORD;

                            continue;
                        }
                    }
                    else
                    {
                        IndexOutOfRangeException argEx = new IndexOutOfRangeException();
                        MessageBox.Show(argEx.Message + " moveTo command error, please check number of variables and make sure they are postive integers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (command[0].Equals("circle"))
                {
                    if (command.Length == 2)
                    {
                        if (ConvertCircleParameters(command[1]))
                        {
                            float x = globalVariables.xCoords_Draw, y = globalVariables.yCoords_Draw;
                            string circle_size = globalVariables.circle_size.ToString();
                            int size = (int)globalVariables.circle_size;

                            Circle circle = new Circle(x, y, size);
                            group.Add(circle);
                            pictureBox1.Refresh();
                            displayAll();

                            continue;
                        }
                    }
                    else
                    {
                        IndexOutOfRangeException argEx = new IndexOutOfRangeException();
                        MessageBox.Show(argEx.Message + " circle command error, please check number of variables and make sure they are postive integers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }



            }
        }



        private void displayAll()
        {
            Graphics paper = pictureBox1.CreateGraphics();
            foreach (Shape shape in group)
            {
                shape.Display(paper);
            }
        }




        public bool ConvertMoveto(string x, string y)
        {
            bool converted = true;

            try
            {
                globalVariables.moveTo_x = (float)Convert.ToDouble(x);
                globalVariables.moveTo_y = (float)Convert.ToDouble(y);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message + " Please Enter Numbers for Coordinates.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                converted = false;
            }

            return converted;
        }

        public bool ConvertCircleParameters(string size)
        {
            bool converted = false;

            try
            {
                globalVariables.circle_size = (float)Convert.ToDouble(size);
                converted = true;
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message + "Ensure Circle Size is a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return converted;
        }

    }
}





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
            public static float size { get; set; }

            //pen position drawing coords
            public static float xCoords_Draw = 0;
            public static float yCoords_Draw = 0;

            //pen position coordinates
            public static float moveTo_x = 0;
            public static float moveTo_y = 0;

            //circle variables
            public static float circle_size { get; set; }

            //circle variables
            public static float square_size { get; set; }

            //rectangle size
            public static float rectangle_width { get; set; }
            public static float rectangle_height { get; set; }

            //triangle variables
            public static int triangle_width { get; set; }
            public static int triangle_height { get; set; }
            public static int width;
            public static int height;
            public static Point p1;
            public static Point p2;
            public static Point p3;
            //line variable
            public static float line_size { get; set; }
            public static float line_x1 = 0;
            public static float line_y1 = 0;

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

                else if (command[0].Equals("square"))
                {
                    if (command.Length == 2)
                    {
                        if (ConvertSquareParameters(command[1]))
                        {
                            float x = globalVariables.xCoords_Draw, y = globalVariables.yCoords_Draw;
                            string square_size = globalVariables.square_size.ToString();
                            int size = (int)globalVariables.square_size;

                            Square square = new Square(x, y, size);
                            group.Add(square);
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

                else if (command[0].Equals("rectangle"))
                {
                    if (command.Length == 3)
                    {
                        if (ConvertRectangleParameters(command[1], command[2]))
                        {
                            float x = globalVariables.xCoords_Draw, y = globalVariables.yCoords_Draw;
                            string rectangle_height = globalVariables.rectangle_height.ToString();
                            string rectangle_width = globalVariables.rectangle_width.ToString();
                            int height = (int)globalVariables.rectangle_height;
                            int width = (int)globalVariables.rectangle_width;

                            Rectangle rectangle = new Rectangle(x, y, height, width);
                            group.Add(rectangle);
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
                else if (command[0].Equals("triangle"))
                {
                    string width;
                    string height;


                    try
                    {
                        width = command[1];
                        height = command[2];
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        MessageBox.Show(ex.Message + " triangle command error, please check number of variables and make sure they are postive integers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

                    if (ConvertTriangleWidthHeight(width, height))
                    {
                        globalVariables.p1.X = (int)globalVariables.xCoords_Draw;
                        globalVariables.p1.Y = (int)globalVariables.yCoords_Draw;

                        globalVariables.p2.X = (int)globalVariables.xCoords_Draw + globalVariables.triangle_width;
                        globalVariables.p2.Y = (int)globalVariables.yCoords_Draw;

                        globalVariables.p3.X = (int)globalVariables.xCoords_Draw + globalVariables.triangle_width;
                        globalVariables.p3.Y = (int)globalVariables.yCoords_Draw - globalVariables.triangle_height;
                    }

                    Triangle triangle = new Triangle(globalVariables.xCoords_Draw, globalVariables.yCoords_Draw, globalVariables.p1.X, globalVariables.p1.Y, globalVariables.p2.X, globalVariables.p2.Y, globalVariables.p3.X, globalVariables.p3.Y);
                    group.Add(triangle);
                    pictureBox1.Refresh();
                    displayAll();

                    continue;
                }

                else if (command[0].Equals("clear"))
                {
                    globalVariables.xCoords_Draw = 0;
                    globalVariables.yCoords_Draw = 0;
                    group.Clear();
                    //pictureBox1.Image = null;
                    pictureBox1.Refresh();

                    continue;
                }
                else if (command[0].Equals("reset"))
                {
                    globalVariables.xCoords_Draw = 0;
                    globalVariables.yCoords_Draw = 0;
                    pictureBox1.Refresh();

                    continue;
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

        public bool ConvertSquareParameters(string size)
        {
            bool converted = false;

            try
            {
                globalVariables.square_size = (float)Convert.ToDouble(size);
                converted = true;
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message + "Ensure Square Size is a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return converted;
        }
        public bool ConvertRectangleParameters(string height, string width)
        {
            bool converted = false;

            try
            {
                globalVariables.rectangle_height = (float)Convert.ToDouble(height);
                globalVariables.rectangle_width = (float)Convert.ToDouble(width);

                converted = true;
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message + "Ensure rectangle height/width is a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return converted;
        }
        public bool ConvertTriangleWidthHeight(string width, string height)
        {
            bool converted = false;
            try
            {
                globalVariables.triangle_width = Convert.ToInt32(width);
                globalVariables.triangle_height = Convert.ToInt32(height);
                //globalVariables.width = Convert.ToInt32(width);
                //globalVariables.height = Convert.ToInt32(height);

                converted = true;
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message + " width/height not number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return converted;
        }
    }
}





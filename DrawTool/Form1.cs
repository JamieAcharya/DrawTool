using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawTool
{
   /*
   *  Main Program Form Class
   */
    public partial class Form1 : Form
    {
        /*
        *  Variables needed for all shapes
        */
        public class globalVariables
        {
            public static float size { get; set; }

            //pen position drawing coords
            public static float xCoords_Draw = 0;
            public static float yCoords_Draw = 0;

            //pen position coordinates
            public static float moveTo_x = 0;
            public static float moveTo_y = 0;

            //circle variable
            public static float circle_size { get; set; }

            //square variable
            public static float square_size { get; set; }

            //rectangle variables
            public static float rectangle_width { get; set; }
            public static float rectangle_height { get; set; }

            //triangle variables
            public static int p1 { get; set; }
            public static int p2 { get; set; }
            public static int p3 { get; set; }
           
            //line variable
            public static float line_size { get; set; }
            public static float line_x1 = 0;
            public static float line_y1 = 0;

        }
        /*
         * List array group to store all commands/shapes
         */
        private List<Shape> group = new List<Shape>();
        public Form1()
        {
            InitializeComponent();
        }




        /*
         * Temporary Buttons for testing the drawing of different shapes
         */
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
         private void drawTriangle_Click(object sender, EventArgs e)
        {
            Point[] trianglePoints = new Point[3];
            trianglePoints[0] = new Point(50, 150);
            trianglePoints[1] = new Point(20, 65);
            trianglePoints[2] = new Point(100, 10);
            Triangle triangle = new Triangle(trianglePoints);
            group.Add(triangle);
            displayAll();


        }
       
        /*
         * Button that executes code within program text area
         * Stores commands and creates main shapes to be executed
         */
        private void run_Click(object sender, EventArgs e)
        {
            foreach (string line in commandLine.Lines)
            {
                //stores commands in array and splits them by space 
                string[] command = line.Split(' ');
                //if moveTo command is entered overwrite starting coordinates
                if (command[0].ToLower().Equals("moveto"))
                {
                    if (command.Length == 3) //check if the correct number of parameters have been given
                    {
                        if (ConvertMoveto(command[1], command[2]))  //convert from string to float
                        {
                            globalVariables.xCoords_Draw = globalVariables.moveTo_x;
                            globalVariables.yCoords_Draw = globalVariables.moveTo_y;

                            string txtXCOORD = globalVariables.xCoords_Draw.ToString();
                            string txtYCOORD = globalVariables.yCoords_Draw.ToString();
                            xCoord.Text = txtXCOORD; //sets xCoordinate textbox with new value
                            yCoord.Text = txtYCOORD;

                            continue;
                        }
                    }
                    else
                    {
                        IndexOutOfRangeException argEx = new IndexOutOfRangeException();
                        MessageBox.Show(argEx.Message + " moveTo command error, please check number of parameters and make sure they are postive integers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (command[0].ToLower().Equals("drawto"))
                {
                    if (command.Length == 3)
                    {
                        int x = int.Parse(command[1]);
                        int y = int.Parse(command[2]);
                        int size = int.Parse(Size.Text);

                        group.Add(new Line(x, y, size));
                        displayAll();
                    }
                }
                else if (command[0].ToLower().Equals("circle"))
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
                        MessageBox.Show(argEx.Message + " circle command error, please check number of parameters and make sure they are postive integers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                else if (command[0].ToLower().Equals("square"))
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
                        MessageBox.Show(argEx.Message + " square command error, please check number of parameters and make sure they are postive integers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                else if (command[0].ToLower().Equals("rectangle"))
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
                        MessageBox.Show(argEx.Message + " rectangle command error, please check number of parameters and make sure they are postive integers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (command[0].ToLower().Equals("triangle"))
                {
                    string p1, p2, p3;

                    try
                    {
                        p1 = command[1];
                        p2 = command[2];
                        p3 = command[3];
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        MessageBox.Show(ex.Message + " triangle command error, please check number of variables and make sure they are postive integers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

                    globalVariables.p1 = Convert.ToInt32(p1);
                    globalVariables.p2 = Convert.ToInt32(p2);
                    globalVariables.p3 = Convert.ToInt32(p3);

                    Point[] trianglePoints = new Point[3];

                    trianglePoints[0] = new Point((int)globalVariables.xCoords_Draw, (int)globalVariables.yCoords_Draw);
                    trianglePoints[1] = new Point((int)globalVariables.xCoords_Draw + globalVariables.p2, (int)globalVariables.yCoords_Draw);
                    trianglePoints[2] = new Point((int)globalVariables.xCoords_Draw + globalVariables.p3, (int)globalVariables.yCoords_Draw - globalVariables.p3);

                    Triangle triangle = new Triangle(trianglePoints);
                    group.Add(triangle);
                    displayAll();
                    continue;


                }

                else if (command[0].ToLower().Equals("clear"))
                {
                    // globalVariables.xCoords_Draw = 0;
                    // globalVariables.yCoords_Draw = 0;
                    group.Clear();
                    //pictureBox1.Image = null;
                    pictureBox1.Refresh();

                    continue;
                }
                else if (command[0].ToLower().Equals("reset"))
                {

                    globalVariables.xCoords_Draw = 0;
                    globalVariables.yCoords_Draw = 0;
                    string txtXCOORD = globalVariables.xCoords_Draw.ToString();
                    string txtYCOORD = globalVariables.yCoords_Draw.ToString();
                    xCoord.Text = txtXCOORD;
                    yCoord.Text = txtYCOORD;
                    //pictureBox1.Refresh();

                    continue;
                }
                else if (command[0].ToLower().Equals("run"))
                {

                    continue;
                }
                else
                {
                    MessageBox.Show("Please Enter A vaild Command(s), see Help for command options", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }

            }
        }

        /*
         * Cycles through currently stored shapes and displays them when called
         */
        private void displayAll()
        {
            Graphics paper = pictureBox1.CreateGraphics();
            foreach (Shape shape in group)
            {
                shape.Display(paper);
            }
        }



        /*
         * Converts needed parameters for each shapes
         */
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

        /*
         * Menu item events
         * EXIT button event that exits application
         * SAVE button event that presents user with Save dialogue on where to save the text in the Program textbox and saves it to a file
         * LOAD button event that presents the User with a load dialogue on which a choosen file can be selected for text to be loaded into the program textbox area
         * SAVE IMAGE event that lets the user save the currently drawn shapes (needs fixing)
         * COMMAND Examples event that presents the user with a form of example commands and help
         * TRACKBAR event that increases the sizeTextbox on scroll
         */
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "DrawTool.dat";
            save.Filter = "Text File | *.dat";
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(save.OpenFile());
                writer.WriteLine(commandLine.Text);
                writer.Dispose();
                writer.Close();

            }
           // System.IO.File.WriteAllText(path, commandLine.Text);
            //System.IO.File.WriteAllText("C:\\Users\\User\\Desktop\\drawTool.dat", commandLine.Text);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //load file and insert into commandLine textbox
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string s = System.IO.File.ReadAllText(ofd.FileName);
                commandLine.Text = s;
            }
        }
        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "DrawToolImage.bmp";
            save.Filter = "Image File | *.bmp";
            if (save.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
                pictureBox1.DrawToBitmap(bmp, pictureBox1.ClientRectangle);
                bmp.Save(save.FileName);
               
           
            }
            
            
        }

        private void commandExamplesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommandHelp frmCommandHelp = new CommandHelp();
            frmCommandHelp.Show();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            Size.Text = trackBar1.Value.ToString();
        }

         /*
         * Instant Commands that are run when user hits enter on instantCommandLine textbox
         */

        private void runProgram()
        {
            foreach (string line in instantCommand.Lines)
            {
                //stores commands in array and splits them by space 
                string[] command = line.Split(' ');
                //if moveTo command is entered overwrite starting coordinates
                if (command[0].ToLower().Equals("moveto"))
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
                else if (command[0].ToLower().Equals("drawto"))
                {
                    if (command.Length == 3)
                    {
                        int x = int.Parse(command[1]);
                        int y = int.Parse(command[2]);
                        int size = int.Parse(Size.Text);

                        group.Add(new Line(x, y, size));
                        displayAll();

                        continue;
                    }
                    else
                    {
                        IndexOutOfRangeException argEx = new IndexOutOfRangeException();
                        MessageBox.Show(argEx.Message + " drawTo command error, please check number of variables and make sure they are postive integers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                else if (command[0].ToLower().Equals("circle"))
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

                else if (command[0].ToLower().Equals("square"))
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
                        MessageBox.Show(argEx.Message + " square command error, please check number of variables and make sure they are postive integers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                else if (command[0].ToLower().Equals("rectangle"))
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
                        MessageBox.Show(argEx.Message + " rectangle command error, please check number of variables and make sure they are postive integers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (command[0].ToLower().Equals("triangle"))
                {
                    string p1, p2, p3;

                    try
                    {
                        p1 = command[1];
                        p2 = command[2];
                        p3 = command[3];
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        MessageBox.Show(ex.Message + " triangle command error, please check number of variables and make sure they are postive integers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

                    globalVariables.p1 = Convert.ToInt32(p1);
                    globalVariables.p2 = Convert.ToInt32(p2);
                    globalVariables.p3 = Convert.ToInt32(p3);

                    Point[] trianglePoints = new Point[3];

                    trianglePoints[0] = new Point((int)globalVariables.xCoords_Draw, (int)globalVariables.yCoords_Draw);
                    trianglePoints[1] = new Point((int)globalVariables.xCoords_Draw + globalVariables.p2, (int)globalVariables.yCoords_Draw);
                    trianglePoints[2] = new Point((int)globalVariables.xCoords_Draw + globalVariables.p3, (int)globalVariables.yCoords_Draw - globalVariables.p3);

                    Triangle triangle = new Triangle(trianglePoints);
                    group.Add(triangle);
                    displayAll();
                    continue;


                }

                else if (command[0].ToLower().Equals("clear"))
                {
                    // globalVariables.xCoords_Draw = 0;
                    // globalVariables.yCoords_Draw = 0;
                    group.Clear();
                    //pictureBox1.Image = null;
                    pictureBox1.Refresh();

                    continue;
                }
                else if (command[0].ToLower().Equals("reset"))
                {

                    globalVariables.xCoords_Draw = 0;
                    globalVariables.yCoords_Draw = 0;
                    string txtXCOORD = globalVariables.xCoords_Draw.ToString();
                    string txtYCOORD = globalVariables.yCoords_Draw.ToString();
                    xCoord.Text = txtXCOORD;
                    yCoord.Text = txtYCOORD;
                    //pictureBox1.Refresh();

                    continue;
                }
                else
                {
                    MessageBox.Show("Please Enter A vaild Command, see Help for command options", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }

            }
        }
        /*
         * When the User hits enter the commands are entered and run
         */
        private void instantCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                runProgram();
                instantCommand.Text = "";
            }
        }
        /*
         * Checks program textbox to see if run command is typed/entered
         * If it is then program is run
         */
        private void commandLine_TextChanged(object sender, EventArgs e)
        {
        
                foreach (string line in commandLine.Lines)
                {
                    string[] command = line.Split(' ');
                    if (command[0].Equals("run"))
                    {
                        run.PerformClick();
                    }
                }
        
        }


        /*
         * Testing Parameters
         */
        public bool ValidateCircleSize(float circleSize)
        {
            bool converted = true;

            // If the circle radius entered by the user is less than 0 then an error message is shown and the circle radius variable is reset to 0;
            if (circleSize < 0)
            {
                MessageBox.Show("Circle has a negative size", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                globalVariables.circle_size = 0;
                converted = false;
            }

            return converted;
        }
    }
}





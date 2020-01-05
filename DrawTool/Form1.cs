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
    /// <summary>
    /// Main Form Program Class
    /// </summary>
    public partial class Form1 : Form
    {
        /*
        *  Variables needed for all shapes
        */
        /// <summary>
        /// Global Variables that are needed for shapes and commands
        /// </summary>
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
            public static float ifVariable_Value { get; set; }
            //square variable
            public static float square_size { get; set; }

            //rectangle variables
            public static float rectangle_width { get; set; }
            public static float rectangle_height { get; set; }

            //triangle variables
            public static int p1 { get; set; }
            public static int p2 { get; set; }
            public static int p3 { get; set; }
            public static int p4 { get; set; }


            public static int triangle_width;
            public static int triangle_height;

            public static Point point1;
            public static Point point2;
            public static Point point3;

            //line variable
            public static float line_size { get; set; }
            public static float line_x1 = 0;
            public static float line_y1 = 0;

            //programming variables

            //loop
            public static int loopIterations;

        }
        /*
         * List array group to store all commands/shapes
         */
        /// <summary>
        /// Array list that stores all Shapes and Commands
        /// </summary>
        private List<Shape> group = new List<Shape>();


        shapeFactory sf = new shapeFactory();
        Shape shape;
        /// <summary>
        /// Initializes Main Form Component for Displaying GUI
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }




        /*
         * Temporary Buttons for testing the drawing of different shapes
         */
        private void DrawCircle_Click(object sender, EventArgs e)
        {
            int x = int.Parse(xCoord.Text), y = int.Parse(yCoord.Text); //getting coords straight from textbox
            //float x = globalVariables.xCoords_Draw, y = globalVariables.yCoords_Draw;
            int size = int.Parse(Size.Text);
            Circle circle = new Circle(x, y, size);
            shape = sf.DrawShape("circle");
            shape.set(x, y, size);
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
        /// <summary>
        /// Button that executes code within program text area
        /// Stores commands and creates main shapes to be executed
        /// </summary>
        private void run_Click(object sender, EventArgs e)
        {
            bool methodFlag = false;
            bool loopFlag = false;
            foreach (string line in commandLine.Lines)
            {
                if (line.Contains("endloop") || line.Contains("circle radius") || line.Contains("endif") || line.Contains("call") || line.Contains("rectangle width") || line.Contains("rectangle height")
                    || line.Contains("square size"))
                {
                    continue;
                }
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
                            shape = sf.DrawShape("circle");
                            shape.set(x, y, size);
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

                else if (command[0].ToLower().Equals("curve"))
                {
                    string p1, p2, p3, p4;

                    try
                    {
                        p1 = command[1];
                        p2 = command[2];
                        p3 = command[3];
                        p4 = command[4];
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        MessageBox.Show(ex.Message + " curve command error, please check number of variables and make sure they are postive integers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    int degrees = Int32.Parse(p2);
                    double radians = degrees * Math.PI / 180.0;

                    globalVariables.xCoords_Draw = Convert.ToInt32((float)Math.Cos(radians) * Int32.Parse(p1) + globalVariables.xCoords_Draw);
                    globalVariables.yCoords_Draw = Convert.ToInt32((float)Math.Sin(-radians) * Int32.Parse(p1) + globalVariables.yCoords_Draw);

                    globalVariables.p1 = Convert.ToInt32(p1);
                    globalVariables.p2 = Convert.ToInt32(p2);
                    globalVariables.p3 = Convert.ToInt32(p3);
                    globalVariables.p4 = Convert.ToInt32(p4);

                    Point[] curvePoints = new Point[4];

                    curvePoints[0] = new Point((int)globalVariables.xCoords_Draw, (int)globalVariables.yCoords_Draw);
                    curvePoints[1] = new Point((int)globalVariables.xCoords_Draw + globalVariables.p2, (int)globalVariables.yCoords_Draw);
                    curvePoints[2] = new Point((int)globalVariables.xCoords_Draw + globalVariables.p3, (int)globalVariables.yCoords_Draw - globalVariables.p3);
                    curvePoints[3] = new Point((int)globalVariables.xCoords_Draw + globalVariables.p4, (int)globalVariables.yCoords_Draw - globalVariables.p4);

                    Curve curve = new Curve(curvePoints);
                    group.Add(curve);
                    displayAll();
                    continue;


                }

                else if (command[0].ToLower().Equals("mirror"))
                {
                    foreach (Shape shape in group)
                    {
                        Bitmap myBitmap;
                        Graphics g;
                        myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                        g = Graphics.FromImage(myBitmap);
                        pictureBox1.DrawToBitmap(myBitmap, pictureBox1.ClientRectangle);

                        myBitmap.RotateFlip(RotateFlipType.Rotate180FlipY);
                        //myBitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        shape.Display(g);
                        pictureBox1.Image = myBitmap;

                    }
                }
                else if (command[0].ToLower().Equals("rotate"))
                {
                    Bitmap myBitmap;
                    Graphics g;
                    myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    g = Graphics.FromImage(myBitmap);
                    pictureBox1.DrawToBitmap(myBitmap, pictureBox1.ClientRectangle);
                    foreach (Shape shape in group)
                    {
                        myBitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        //myBitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        shape.Display(g);
                        pictureBox1.Image = myBitmap;

                    }
                }

                /**
                 * Programming commands
                 */
                //if command
                else if (command[0].ToLower().Equals("if"))
                {
                    int ifVariableValue = 0;
                    if (command.Length > 3)
                    {
                        try
                        {
                            globalVariables.ifVariable_Value = Convert.ToInt32(command[3]);
                        }
                        catch (FormatException ex)
                        {
                            MessageBox.Show(ex.Message + "If variable needs to be number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }


                        float x = globalVariables.xCoords_Draw, y = globalVariables.yCoords_Draw;
                        string ifVariable_Value = globalVariables.ifVariable_Value.ToString();
                        int size = (int)globalVariables.ifVariable_Value;

                        Circle circle = new Circle(x, y, size);
                        group.Add(circle);
                        pictureBox1.Refresh();
                        displayAll();

                        continue;

                    }
                }


                else if (command[0].ToLower().Equals("method"))
                {
                    if (command.Length == 2)
                    {
                        try
                        {
                            //globalVariables.loopIterations = Convert.ToInt32(command[2]);

                            globalVariables.loopIterations = 1;
                        }
                        catch (FormatException ex)
                        {
                            MessageBox.Show(ex.Message + "Please ensure an unsigned integer has been used for loop command.");
                            break;
                        }

                        int loopStart = commandLine.Text.IndexOf("method ") + "method ".Length;
                        int loopEnd = commandLine.Text.LastIndexOf("call");


                        // loopStart can not be less than zero, endloop must be entered
                        if (loopStart <= 0)
                        {
                            throw new EndloopNotFoundException(loopEnd);
                            //throw new ArgumentOutOfRangeException();
                            MessageBox.Show("Include endloop", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        try
                        {
                            if (loopEnd <= 0)
                            {

                                throw new EndloopNotFoundException(loopEnd);
                                //throw new ArgumentOutOfRangeException();
                                //MessageBox.Show("Include endloop", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //return;
                            }
                        }
                        catch (EndloopNotFoundException)
                        {
                            break;
                        }
                        // start and end loop contents
                        string loopContents = commandLine.Text.Substring(loopStart, loopEnd - loopStart); // length cannot be < 0


                        // The loop command is split on each line
                        string[] loopCommands = loopContents.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                        int loopCounter = 0;

                        for (int i = 0; i < globalVariables.loopIterations; i++)
                        {
                            loopCounter++;

                            // foreach command in the loopCommand array
                            foreach (string commandLoop in loopCommands)
                            {
                                string[] loopCmd = commandLoop.Split(' ');

                                // If the loop command is for a circle
                                if (loopCmd[0].ToLower().Equals("circle"))
                                {
                                    if (command.Length == 2)
                                    {
                                        if (ConvertCircleParameters(command[1]))
                                        {
                                            float x = globalVariables.xCoords_Draw, y = globalVariables.yCoords_Draw;
                                            string circle_size = globalVariables.circle_size.ToString();
                                            int size = (int)globalVariables.circle_size;

                                            Circle circle = new Circle(x, y, size);
                                            shape = sf.DrawShape("circle");
                                            shape.set(x, y, size);
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
                                    if (loopCmd[0].ToLower().Equals("square"))
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
                                        if (loopCmd[0].ToLower().Equals("triangle"))
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

                                    }
                                }
                            }
                        }
                    }
                }


                //Loop commands
                else if (command[0].ToLower().Equals("loop"))
                {
                    if (command.Length == 2)
                    {
                        try
                        {
                            globalVariables.loopIterations = Convert.ToInt32(command[1]);
                        }
                        catch (FormatException ex)
                        {
                            MessageBox.Show(ex.Message + "Please ensure an unsigned integer has been used for loop command.");
                            break;
                        }

                        int loopStart = commandLine.Text.IndexOf("loop ") + "loop ".Length;
                        int loopEnd = commandLine.Text.LastIndexOf("endloop");


                        // loopStart can not be less than zero, endloop must be entered
                        if (loopStart <= 0)
                        {
                            throw new EndloopNotFoundException(loopEnd);
                            //throw new ArgumentOutOfRangeException();
                            MessageBox.Show("Include endloop", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        try
                        {
                            if (loopEnd <= 0)
                            {

                                throw new EndloopNotFoundException(loopEnd);
                                //throw new ArgumentOutOfRangeException();
                                //MessageBox.Show("Include endloop", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //return;
                            }
                        }
                        catch (EndloopNotFoundException)
                        {
                            break;
                        }
                        // start and end loop contents
                        string loopContents = commandLine.Text.Substring(loopStart, loopEnd - loopStart); // length cannot be < 0


                        // The loop command is split on each line
                        string[] loopCommands = loopContents.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                        int loopCounter = 0;

                        for (int i = 0; i < globalVariables.loopIterations; i++)
                        {
                            loopCounter++;

                            // foreach command in the loopCommand array
                            foreach (string commandLoop in loopCommands)
                            {
                                string[] loopCmd = commandLoop.Split(' ');

                                // If the loop command is for a circle
                                if (loopCmd[0].ToLower().Equals("circle"))
                                {
                                    int radius = 0;

                                    // check circle command has correct variables and parameters
                                    if (loopCmd.Length == 4)
                                    {
                                        // convert radius
                                        try
                                        {
                                            radius = Convert.ToInt32(loopCmd[3]);
                                        }
                                        catch (FormatException ex)
                                        {
                                            MessageBox.Show(ex.Message + " Circle Radius needs to be an Unsigned integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        ArgumentOutOfRangeException argEx = new ArgumentOutOfRangeException();
                                        MessageBox.Show(argEx.Message + "Circle command in loop command is incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    if (ValidateCircleSize(radius))
                                    {
                                        if (loopCmd[2].Equals("+"))
                                        {
                                            globalVariables.circle_size = globalVariables.circle_size += radius;

                                            Circle circle = new Circle(globalVariables.xCoords_Draw, globalVariables.yCoords_Draw, (int)globalVariables.circle_size);
                                            group.Add(circle);
                                            pictureBox1.Refresh();
                                            displayAll();

                                            continue;
                                        }

                                    }
                                }
                                if (loopCmd[0].ToLower().Equals("square"))
                                {
                                    int loop_square_size = 0;
                                    if (loopCmd.Length == 4)
                                    {
                                        try
                                        {
                                            loop_square_size = Convert.ToInt32(loopCmd[3]);
                                        }
                                        catch (FormatException ex)
                                        {
                                            MessageBox.Show(ex.Message + " Square size needs to be an Unsigned integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        ArgumentOutOfRangeException argEx = new ArgumentOutOfRangeException();
                                        MessageBox.Show(argEx.Message + "Square command in loop command is incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    if (loopCmd[2].Equals("+"))
                                    {
                                        globalVariables.square_size = globalVariables.square_size += loop_square_size;
                                        Square square = new Square(globalVariables.xCoords_Draw, globalVariables.yCoords_Draw, (int)globalVariables.square_size);
                                        group.Add(square);
                                        pictureBox1.Refresh();
                                        displayAll();

                                        continue;
                                    }

                                    //}
                                }
                                if (loopCmd[0].ToLower().Equals("rectangle"))
                                {
                                    // Local rectangle loop command variables
                                    int width = 0;
                                    int height = 0;

                                    // checks if loop command has correct variables
                                    if (loopCmd.Length >= 4)
                                    {
                                        // rectangle width to increase
                                        if (loopCmd[1].ToLower().Equals("width"))
                                        {
                                            // check width is an integer
                                            try
                                            {
                                                width = Convert.ToInt32(loopCmd[3]);
                                            }
                                            catch (FormatException ex)
                                            {
                                                MessageBox.Show(ex.Message + " Please ensure a number has been the width of the rectangle within the loop command.");
                                            }

                                            // increase rectangle variable
                                            if (loopCmd[2].Equals("+"))
                                            {
                                                // increase rectangle width by integer declared in loop
                                                globalVariables.rectangle_width = globalVariables.rectangle_width += width;
                                            }
                                        }
                                        // increase rectangle height
                                        if (loopCmd[1].ToLower().Equals("height"))
                                        {
                                            // check height is an integer
                                            try
                                            {
                                                height = Convert.ToInt32(loopCmd[3]);
                                            }
                                            catch (FormatException ex)
                                            {
                                                MessageBox.Show(ex.Message + " Please ensure a number has been the width and height of the rectangle within the loop command.");
                                            }

                                            // increase rectangle height
                                            if (loopCmd[2].Equals("+"))
                                            {
                                                globalVariables.rectangle_height = globalVariables.rectangle_height += height;
                                            }
                                        }
                                        // increase rectangle width and height
                                        if (loopCmd.Length > 4)
                                        {
                                            if (loopCmd[4].ToLower().Equals("height"))
                                            {
                                                try
                                                {
                                                    height = Convert.ToInt32(loopCmd[6]);
                                                }
                                                catch (FormatException ex)
                                                {
                                                    MessageBox.Show(ex.Message + " Please ensure a number has been the width and height of the rectangle within the loop command.");
                                                }

                                                // If the height is being increased
                                                if (loopCmd[5].Equals("+"))
                                                {
                                                    // increase height by number entered in loop
                                                    globalVariables.rectangle_height = globalVariables.rectangle_height += height;
                                                }

                                            }
                                            // checks if rectangle parameter is set to width
                                            if (loopCmd[4].ToLower().Equals("width"))
                                            {
                                                try
                                                {
                                                    width = Convert.ToInt32(loopCmd[6]);
                                                }
                                                catch (FormatException ex)
                                                {
                                                    MessageBox.Show(ex.Message + " Please ensure a number has been the width and height of the rectangle within the loop command.");
                                                }

                                                // increase width
                                                if (loopCmd[5].Equals("+"))
                                                {
                                                    globalVariables.rectangle_width = globalVariables.rectangle_width += width;
                                                }

                                            }
                                        }
                                        else
                                        {
                                            ArgumentOutOfRangeException argEx = new ArgumentOutOfRangeException();
                                            MessageBox.Show(argEx.Message + "The rectangle command within the loop has been entered incorrectly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                        //globalVariables.square_size = globalVariables.square_size += loop_square_size;
                                        Rectangle rectangle = new Rectangle(globalVariables.xCoords_Draw, globalVariables.yCoords_Draw, globalVariables.rectangle_height, globalVariables.rectangle_width);
                                        group.Add(rectangle); ;
                                        pictureBox1.Refresh();
                                        displayAll();


                                        continue;
                                    }
                                }
                                if (loopCmd[0].ToLower().Equals("triangle"))
                                {
                                }

                                /**
                                 * If command
                                 */
                                // If the loop command is for an if statement
                                if (loopCmd[0].ToLower().Equals("if"))
                                {
                                    int loopCountParam = 0;

                                    // If if command is a suitable length
                                    if (loopCmd.Length >= 7)
                                    {
                                        // Converting loop counter number delcared in if command
                                        try
                                        {
                                            loopCountParam = Convert.ToInt32(loopCmd[3]);
                                        }
                                        catch (FormatException ex)
                                        {
                                            MessageBox.Show(ex.Message + "Please ensure you have entered a number within the if command.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }

                                        // Validation checks for loop counter number
                                        if (loopCountParam > globalVariables.loopIterations || loopCountParam < 0)
                                        {
                                            MessageBox.Show("Please enter a counter number equal to or less than the loop number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }

                                        // If loop count number declared by user is equal to loopCounter
                                        if (Convert.ToInt32(loopCmd[3]) == loopCounter)
                                        {
                                            // If the if command is for a circle
                                            if (loopCmd[4].ToLower().Equals("circle"))
                                            {
                                                int radius = 0;

                                                // Convert circle radius to an int
                                                try
                                                {
                                                    radius = Convert.ToInt32(loopCmd[7]);
                                                }
                                                catch (FormatException ex)
                                                {
                                                    MessageBox.Show(ex.Message + "Please ensure you have entered a number for the circle radius.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    return;
                                                }

                                                if (ValidateCircleSize(radius))
                                                {
                                                    if (loopCmd[2].Equals("+"))
                                                    {
                                                        globalVariables.circle_size = globalVariables.circle_size += radius;

                                                        Circle circle = new Circle(globalVariables.xCoords_Draw, globalVariables.yCoords_Draw, (int)globalVariables.circle_size);
                                                        group.Add(circle);
                                                        pictureBox1.Refresh();
                                                        displayAll();

                                                        continue;
                                                    }
                                                }
                                            }
                                            // If the if command is equal to a rectangle
                                            if (loopCmd[4].ToLower().Equals("rectangle"))
                                            {
                                                int width = 0;
                                                int height = 0;

                                                // If the if command is of suitabe length
                                                if (loopCmd.Length >= 7)
                                                {
                                                    if (loopCmd[5].ToLower().Equals("width"))
                                                    {

                                                        try
                                                        {
                                                            width = Convert.ToInt32(loopCmd[7]);
                                                        }
                                                        catch (FormatException ex)
                                                        {
                                                            MessageBox.Show(ex.Message + " Please ensure a number has been the width and height of the rectangle within the loop command.");
                                                        }

                                                        if (loopCmd[2].Equals("+"))
                                                        {
                                                            // increase rectangle width by integer declared in loop
                                                            globalVariables.rectangle_width = globalVariables.rectangle_width += width;
                                                        }
                                                    }
                                                    // increase rectangle height
                                                    if (loopCmd[1].ToLower().Equals("height"))
                                                    {
                                                        // check height is an integer
                                                        try
                                                        {
                                                            height = Convert.ToInt32(loopCmd[3]);
                                                        }
                                                        catch (FormatException ex)
                                                        {
                                                            MessageBox.Show(ex.Message + " Please ensure a number has been the width and height of the rectangle within the loop command.");
                                                        }

                                                        // increase rectangle height
                                                        if (loopCmd[2].Equals("+"))
                                                        {
                                                            globalVariables.rectangle_height = globalVariables.rectangle_height += height;
                                                        }
                                                    }
                                                    // increase rectangle width and height
                                                    if (loopCmd.Length > 4)
                                                    {
                                                        if (loopCmd[4].ToLower().Equals("height"))
                                                        {
                                                            try
                                                            {
                                                                height = Convert.ToInt32(loopCmd[6]);
                                                            }
                                                            catch (FormatException ex)
                                                            {
                                                                MessageBox.Show(ex.Message + " Please ensure a number has been the width and height of the rectangle within the loop command.");
                                                            }

                                                            // If the height is being increased
                                                            if (loopCmd[5].Equals("+"))
                                                            {
                                                                // increase height by number entered in loop
                                                                globalVariables.rectangle_height = globalVariables.rectangle_height += height;
                                                            }

                                                        }
                                                        // checks if rectangle parameter is set to width
                                                        if (loopCmd[4].ToLower().Equals("width"))
                                                        {
                                                            try
                                                            {
                                                                width = Convert.ToInt32(loopCmd[6]);
                                                            }
                                                            catch (FormatException ex)
                                                            {
                                                                MessageBox.Show(ex.Message + " Please ensure a number has been the width and height of the rectangle within the loop command.");
                                                            }

                                                            // increase width
                                                            if (loopCmd[5].Equals("+"))
                                                            {
                                                                globalVariables.rectangle_width = globalVariables.rectangle_width += width;
                                                            }

                                                        }
                                                    }
                                                    else
                                                    {
                                                        ArgumentOutOfRangeException argEx = new ArgumentOutOfRangeException();
                                                        MessageBox.Show(argEx.Message + "The rectangle command within the loop has been entered incorrectly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        return;
                                                    }
                                                    //globalVariables.square_size = globalVariables.square_size += loop_square_size;
                                                    Rectangle rectangle = new Rectangle(globalVariables.xCoords_Draw, globalVariables.yCoords_Draw, globalVariables.rectangle_height, globalVariables.rectangle_width);
                                                    group.Add(rectangle); ;
                                                    pictureBox1.Refresh();
                                                    displayAll();


                                                    continue;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            ArgumentOutOfRangeException argEx = new ArgumentOutOfRangeException();
                                            MessageBox.Show(argEx.Message + "The if command entered is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }




                /**
                 * end of programming commands
                 */
                else if (command[0].ToLower().Equals("clear"))
                {
                    // globalVariables.xCoords_Draw = 0;
                    // globalVariables.yCoords_Draw = 0;
                    group.Clear();
                    pictureBox1.Image = null;
                    pictureBox1.BackColor = Color.DarkGray;
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
                else if (command[0].ToLower().Equals("rotate"))
                {
                    //  group.Add(circle);
                    pictureBox1.Refresh();
                    displayAll();

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

        /// <summary>
        /// Cycles through currently stored shapes and displays them when called
        /// </summary>
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

        /// <summary>
        /// Menu item events
        /// EXIT button event that exits application
        /// SAVE button event that presents user with Save dialogue on where to save the text in the Program textbox and saves it to a file
        /// LOAD button event that presents the User with a load dialogue on which a choosen file can be selected for text to be loaded into the program textbox area
        /// SAVE IMAGE event that lets the user save the currently drawn shapes(needs fixing)
        /// COMMAND Examples event that presents the user with a form of example commands and help
        /// TRACKBAR event that increases the sizeTextbox on scroll
        /// </summary>
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


        /// <summary>
        /// Save button that allows the user to save an image file of what is currently displayed within the main picturebox
        /// </summary>
        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            //save.FileName = "DrawToolImage.bmp";
            save.FileName = "DrawToolImageNEW" + DateTime.Now.ToString("yyMMddHmmss") + ".bmp";
            save.Filter = "Image File | *.bmp";

            if (save.ShowDialog() == DialogResult.OK)
            {
                Bitmap myBitmap;
                Graphics g;
                myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

                g = Graphics.FromImage(myBitmap);
                pictureBox1.DrawToBitmap(myBitmap, pictureBox1.ClientRectangle);
                foreach (Shape shape in group)
                {
                    shape.Display(g);
                }
                myBitmap.Save(save.FileName);

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
            if (e.KeyCode == Keys.Enter)
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

        public bool ValidateMoveTo(float x, float y)
        {
            bool converted = true;

            // x/y variables need to be postive or are reset to 0
            if (x < 0 || y < 0)
            {

                globalVariables.moveTo_x = 0;
                globalVariables.moveTo_y = 0;
                MessageBox.Show("MoveTo has to have postive Integers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                converted = false;
            }

            return converted;
        }

        /// <summary>
        /// Button that allows the user to select and image to be loaded in to the main picturebox
        /// </summary>
        private void drawImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string sPath = ofd.FileName;
                try
                {
                    Image img1 = Image.FromFile(@sPath);
                    Image choice = img1;

                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = choice;
                }
                catch(OutOfMemoryException)
                {
                    MessageBox.Show("File must be an image!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //throw new InvalidFileTypeException();
                }
            }

        }

        /// <summary>
        /// When the Main picturebox is clicked, a dialogue option appears allowing the user
        ///  to save what is currently drawn.
        /// </summary>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "DrawToolImageNEW" + DateTime.Now.ToString("yyMMddHmmss") + ".bmp";
            save.Filter = "Image File | *.bmp";

            if (save.ShowDialog() == DialogResult.OK)
            {
                Bitmap myBitmap;
                Graphics g;
                myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                g = Graphics.FromImage(myBitmap);
                pictureBox1.DrawToBitmap(myBitmap, pictureBox1.ClientRectangle);
                foreach (Shape shape in group)
                {
                    shape.Display(g);
                }
                myBitmap.Save(save.FileName);

            }
        }

        /// <summary>
        /// A Button that produces a color dialog interface that allows the user to change the current background of the main picturebox
        /// </summary>
        private void backgroundColor_Button_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            //dlg.ShowDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor = dlg.Color;


            }
        }

        private void rotate_Button_Click(object sender, EventArgs e)
        {
            Bitmap myBitmap;
            Graphics g;
            myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(myBitmap);
            pictureBox1.DrawToBitmap(myBitmap, pictureBox1.ClientRectangle);
            //g.TranslateTransform(0, pictureBox1.Height);

            foreach (Shape shape in group)
            {
                shape.Display(g);
                myBitmap.RotateFlip(RotateFlipType.Rotate180FlipY);
            }
            pictureBox1.Image = myBitmap;
        }
    }
}
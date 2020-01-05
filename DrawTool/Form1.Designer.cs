namespace DrawTool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.commandLine = new System.Windows.Forms.TextBox();
            this.run = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.DrawCircle = new System.Windows.Forms.Button();
            this.xLabel = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            this.xCoord = new System.Windows.Forms.TextBox();
            this.yCoord = new System.Windows.Forms.TextBox();
            this.DrawSquare = new System.Windows.Forms.Button();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.Size = new System.Windows.Forms.TextBox();
            this.DrawLine = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandExamplesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawTriangle = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.instantCommand = new System.Windows.Forms.TextBox();
            this.commandLabel = new System.Windows.Forms.Label();
            this.programLabel = new System.Windows.Forms.Label();
            this.drawImageButton = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.backgroundColor_Button = new System.Windows.Forms.Button();
            this.rotate_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // commandLine
            // 
            this.commandLine.Location = new System.Drawing.Point(63, 435);
            this.commandLine.Multiline = true;
            this.commandLine.Name = "commandLine";
            this.commandLine.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.commandLine.Size = new System.Drawing.Size(731, 90);
            this.commandLine.TabIndex = 1;
            this.commandLine.TextChanged += new System.EventHandler(this.commandLine_TextChanged);
            // 
            // run
            // 
            this.run.Location = new System.Drawing.Point(844, 435);
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(127, 90);
            this.run.TabIndex = 2;
            this.run.Text = "Run Command/Program";
            this.run.UseVisualStyleBackColor = true;
            this.run.Click += new System.EventHandler(this.run_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox1.Location = new System.Drawing.Point(63, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(731, 392);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // DrawCircle
            // 
            this.DrawCircle.Location = new System.Drawing.Point(844, 357);
            this.DrawCircle.Name = "DrawCircle";
            this.DrawCircle.Size = new System.Drawing.Size(127, 72);
            this.DrawCircle.TabIndex = 4;
            this.DrawCircle.Text = "Draw Circle";
            this.DrawCircle.UseVisualStyleBackColor = true;
            this.DrawCircle.Click += new System.EventHandler(this.DrawCircle_Click);
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(844, 12);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(45, 13);
            this.xLabel.TabIndex = 5;
            this.xLabel.Text = "XCoord:";
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(844, 46);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(45, 13);
            this.yLabel.TabIndex = 6;
            this.yLabel.Text = "YCoord:";
            // 
            // xCoord
            // 
            this.xCoord.Location = new System.Drawing.Point(895, 12);
            this.xCoord.Name = "xCoord";
            this.xCoord.Size = new System.Drawing.Size(100, 20);
            this.xCoord.TabIndex = 7;
            this.xCoord.Text = "0";
            // 
            // yCoord
            // 
            this.yCoord.Location = new System.Drawing.Point(895, 43);
            this.yCoord.Name = "yCoord";
            this.yCoord.Size = new System.Drawing.Size(100, 20);
            this.yCoord.TabIndex = 8;
            this.yCoord.Text = "0";
            // 
            // DrawSquare
            // 
            this.DrawSquare.Location = new System.Drawing.Point(844, 279);
            this.DrawSquare.Name = "DrawSquare";
            this.DrawSquare.Size = new System.Drawing.Size(127, 72);
            this.DrawSquare.TabIndex = 9;
            this.DrawSquare.Text = "Draw Square";
            this.DrawSquare.UseVisualStyleBackColor = true;
            this.DrawSquare.Click += new System.EventHandler(this.DrawSquare_Click);
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(847, 79);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(33, 13);
            this.sizeLabel.TabIndex = 10;
            this.sizeLabel.Text = "Size: ";
            // 
            // Size
            // 
            this.Size.Location = new System.Drawing.Point(895, 76);
            this.Size.Name = "Size";
            this.Size.Size = new System.Drawing.Size(100, 20);
            this.Size.TabIndex = 11;
            this.Size.Text = "0";
            // 
            // DrawLine
            // 
            this.DrawLine.Location = new System.Drawing.Point(844, 201);
            this.DrawLine.Name = "DrawLine";
            this.DrawLine.Size = new System.Drawing.Size(127, 72);
            this.DrawLine.TabIndex = 12;
            this.DrawLine.Text = "Draw Line";
            this.DrawLine.UseVisualStyleBackColor = true;
            this.DrawLine.Click += new System.EventHandler(this.DrawLine_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1225, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveImageToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.saveToolStripMenuItem.Text = "Save Program";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.saveImageToolStripMenuItem.Text = "Save Image";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.saveImageToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commandExamplesToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // commandExamplesToolStripMenuItem
            // 
            this.commandExamplesToolStripMenuItem.Name = "commandExamplesToolStripMenuItem";
            this.commandExamplesToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.commandExamplesToolStripMenuItem.Text = "Command Examples";
            this.commandExamplesToolStripMenuItem.Click += new System.EventHandler(this.commandExamplesToolStripMenuItem_Click);
            // 
            // drawTriangle
            // 
            this.drawTriangle.Location = new System.Drawing.Point(844, 144);
            this.drawTriangle.Name = "drawTriangle";
            this.drawTriangle.Size = new System.Drawing.Size(127, 51);
            this.drawTriangle.TabIndex = 14;
            this.drawTriangle.Text = "Draw Triangle";
            this.drawTriangle.UseVisualStyleBackColor = true;
            this.drawTriangle.Click += new System.EventHandler(this.drawTriangle_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(895, 102);
            this.trackBar1.Maximum = 1000;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(100, 45);
            this.trackBar1.TabIndex = 15;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // instantCommand
            // 
            this.instantCommand.Location = new System.Drawing.Point(63, 531);
            this.instantCommand.Name = "instantCommand";
            this.instantCommand.Size = new System.Drawing.Size(731, 20);
            this.instantCommand.TabIndex = 16;
            this.instantCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.instantCommand_KeyDown);
            // 
            // commandLabel
            // 
            this.commandLabel.AutoSize = true;
            this.commandLabel.Location = new System.Drawing.Point(0, 534);
            this.commandLabel.Name = "commandLabel";
            this.commandLabel.Size = new System.Drawing.Size(57, 13);
            this.commandLabel.TabIndex = 17;
            this.commandLabel.Text = "Command:";
            // 
            // programLabel
            // 
            this.programLabel.AutoSize = true;
            this.programLabel.Location = new System.Drawing.Point(0, 438);
            this.programLabel.Name = "programLabel";
            this.programLabel.Size = new System.Drawing.Size(49, 13);
            this.programLabel.TabIndex = 18;
            this.programLabel.Text = "Program:";
            // 
            // drawImageButton
            // 
            this.drawImageButton.Location = new System.Drawing.Point(1001, 144);
            this.drawImageButton.Name = "drawImageButton";
            this.drawImageButton.Size = new System.Drawing.Size(208, 129);
            this.drawImageButton.TabIndex = 19;
            this.drawImageButton.Text = "Load Image";
            this.drawImageButton.UseVisualStyleBackColor = true;
            this.drawImageButton.Click += new System.EventHandler(this.drawImageButton_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(1001, 279);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(208, 233);
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // backgroundColor_Button
            // 
            this.backgroundColor_Button.Location = new System.Drawing.Point(1001, 12);
            this.backgroundColor_Button.Name = "backgroundColor_Button";
            this.backgroundColor_Button.Size = new System.Drawing.Size(208, 22);
            this.backgroundColor_Button.TabIndex = 23;
            this.backgroundColor_Button.Text = "Change Background Color";
            this.backgroundColor_Button.UseVisualStyleBackColor = true;
            this.backgroundColor_Button.Click += new System.EventHandler(this.backgroundColor_Button_Click);
            // 
            // rotate_Button
            // 
            this.rotate_Button.Location = new System.Drawing.Point(1002, 46);
            this.rotate_Button.Name = "rotate_Button";
            this.rotate_Button.Size = new System.Drawing.Size(207, 23);
            this.rotate_Button.TabIndex = 24;
            this.rotate_Button.Text = "Mirror";
            this.rotate_Button.UseVisualStyleBackColor = true;
            this.rotate_Button.Click += new System.EventHandler(this.rotate_Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 559);
            this.Controls.Add(this.rotate_Button);
            this.Controls.Add(this.backgroundColor_Button);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.drawImageButton);
            this.Controls.Add(this.programLabel);
            this.Controls.Add(this.commandLabel);
            this.Controls.Add(this.instantCommand);
            this.Controls.Add(this.drawTriangle);
            this.Controls.Add(this.DrawLine);
            this.Controls.Add(this.Size);
            this.Controls.Add(this.sizeLabel);
            this.Controls.Add(this.DrawSquare);
            this.Controls.Add(this.yCoord);
            this.Controls.Add(this.xCoord);
            this.Controls.Add(this.yLabel);
            this.Controls.Add(this.xLabel);
            this.Controls.Add(this.DrawCircle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.run);
            this.Controls.Add(this.commandLine);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.trackBar1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "DrawTool";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox commandLine;
        private System.Windows.Forms.Button run;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button DrawCircle;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.TextBox xCoord;
        private System.Windows.Forms.TextBox yCoord;
        private System.Windows.Forms.Button DrawSquare;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.TextBox Size;
        private System.Windows.Forms.Button DrawLine;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandExamplesToolStripMenuItem;
        private System.Windows.Forms.Button drawTriangle;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TextBox instantCommand;
        private System.Windows.Forms.Label commandLabel;
        private System.Windows.Forms.Label programLabel;
        private System.Windows.Forms.Button drawImageButton;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button backgroundColor_Button;
        private System.Windows.Forms.Button rotate_Button;
    }
}


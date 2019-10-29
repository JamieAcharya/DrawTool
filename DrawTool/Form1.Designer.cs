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
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandExamplesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawTriangle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandLine
            // 
            this.commandLine.Location = new System.Drawing.Point(35, 435);
            this.commandLine.Multiline = true;
            this.commandLine.Name = "commandLine";
            this.commandLine.Size = new System.Drawing.Size(731, 90);
            this.commandLine.TabIndex = 1;
            // 
            // run
            // 
            this.run.Location = new System.Drawing.Point(847, 435);
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(124, 90);
            this.run.TabIndex = 2;
            this.run.Text = "Run Command/Program";
            this.run.UseVisualStyleBackColor = true;
            this.run.Click += new System.EventHandler(this.run_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox1.Location = new System.Drawing.Point(35, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(731, 392);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // DrawCircle
            // 
            this.DrawCircle.Location = new System.Drawing.Point(850, 322);
            this.DrawCircle.Name = "DrawCircle";
            this.DrawCircle.Size = new System.Drawing.Size(124, 72);
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
            // 
            // yCoord
            // 
            this.yCoord.Location = new System.Drawing.Point(895, 43);
            this.yCoord.Name = "yCoord";
            this.yCoord.Size = new System.Drawing.Size(100, 20);
            this.yCoord.TabIndex = 8;
            // 
            // DrawSquare
            // 
            this.DrawSquare.Location = new System.Drawing.Point(847, 244);
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
            // 
            // DrawLine
            // 
            this.DrawLine.Location = new System.Drawing.Point(847, 166);
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
            this.menuStrip1.Size = new System.Drawing.Size(1046, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
            // 
            // drawTriangle
            // 
            this.drawTriangle.Location = new System.Drawing.Point(850, 109);
            this.drawTriangle.Name = "drawTriangle";
            this.drawTriangle.Size = new System.Drawing.Size(121, 51);
            this.drawTriangle.TabIndex = 14;
            this.drawTriangle.Text = "Draw Triangle";
            this.drawTriangle.UseVisualStyleBackColor = true;
            this.drawTriangle.Click += new System.EventHandler(this.drawTriangle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 559);
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
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "DrawTool";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
    }
}


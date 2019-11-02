namespace DrawTool
{
    partial class CommandHelp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandHelp));
            this.commandHelpmenu = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // commandHelpmenu
            // 
            this.commandHelpmenu.Location = new System.Drawing.Point(13, 13);
            this.commandHelpmenu.Name = "commandHelpmenu";
            this.commandHelpmenu.ReadOnly = true;
            this.commandHelpmenu.Size = new System.Drawing.Size(775, 415);
            this.commandHelpmenu.TabIndex = 0;
            this.commandHelpmenu.Text = resources.GetString("commandHelpmenu.Text");
            // 
            // CommandHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.commandHelpmenu);
            this.Name = "CommandHelp";
            this.Text = "CommandHelp";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox commandHelpmenu;
    }
}
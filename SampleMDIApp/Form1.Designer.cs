namespace SampleMDIApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mdiControl1 = new winMdi.MdiControl();
            menuStrip1 = new MenuStrip();
            createWindowsToolStripMenuItem = new ToolStripMenuItem();
            setANewFontToolStripMenuItem = new ToolStripMenuItem();
            createAnotherWindowToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // mdiControl1
            // 
            mdiControl1.BackgroundImage = Properties.Resources.wallpaper;
            mdiControl1.Dock = DockStyle.Fill;
            mdiControl1.Location = new Point(0, 24);
            mdiControl1.Margin = new Padding(3, 2, 3, 2);
            mdiControl1.Name = "mdiControl1";
            mdiControl1.RemoveScreenFlickering = true;
            mdiControl1.Size = new Size(923, 547);
            mdiControl1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { createWindowsToolStripMenuItem, setANewFontToolStripMenuItem, createAnotherWindowToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(923, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // createWindowsToolStripMenuItem
            // 
            createWindowsToolStripMenuItem.Name = "createWindowsToolStripMenuItem";
            createWindowsToolStripMenuItem.Size = new Size(111, 20);
            createWindowsToolStripMenuItem.Text = "Create A Window";
            createWindowsToolStripMenuItem.Click += createWindowsToolStripMenuItem_Click;
            // 
            // setANewFontToolStripMenuItem
            // 
            setANewFontToolStripMenuItem.Name = "setANewFontToolStripMenuItem";
            setANewFontToolStripMenuItem.Size = new Size(94, 20);
            setANewFontToolStripMenuItem.Text = "Set a new font";
            setANewFontToolStripMenuItem.Click += setANewFontToolStripMenuItem_Click;
            // 
            // createAnotherWindowToolStripMenuItem
            // 
            createAnotherWindowToolStripMenuItem.Name = "createAnotherWindowToolStripMenuItem";
            createAnotherWindowToolStripMenuItem.Size = new Size(146, 20);
            createAnotherWindowToolStripMenuItem.Text = "Create Another Window";
            createAnotherWindowToolStripMenuItem.Click += createAnotherWindowToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(923, 571);
            Controls.Add(mdiControl1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Sample Project for WinMdi";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private winMdi.MdiControl mdiControl1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem createWindowsToolStripMenuItem;
        private ToolStripMenuItem setANewFontToolStripMenuItem;
        private ToolStripMenuItem createAnotherWindowToolStripMenuItem;
    }
}
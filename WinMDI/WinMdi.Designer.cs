
namespace winMdi
{
    partial class WinMdi
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region InitializeComponent

        private void InitializeComponent()
        {
            panelMain = new Panel();
            bMin = new PictureBox();
            bMax = new PictureBox();
            bClose = new PictureBox();
            labelTitle = new Label();
            panelFloor = new Panel();
            panelRightFloor = new Panel();
            panelLeft = new Panel();
            panelRight = new Panel();
            panelTop = new Panel();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bClose).BeginInit();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(83, 83, 83);
            panelMain.Controls.Add(bMin);
            panelMain.Controls.Add(bMax);
            panelMain.Controls.Add(bClose);
            panelMain.Controls.Add(labelTitle);
            panelMain.Dock = DockStyle.Top;
            panelMain.Location = new Point(1, 1);
            panelMain.Margin = new Padding(3, 2, 3, 2);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(523, 25);
            panelMain.TabIndex = 0;
            panelMain.MouseDown += panelMain_MouseDown;
            panelMain.MouseMove += panelMain_MouseMove;
            panelMain.MouseUp += panelMain_MouseUp;
            // 
            // bMin
            // 
            bMin.BackColor = Color.FromArgb(83, 83, 83);
            bMin.Dock = DockStyle.Right;
            bMin.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point);
            bMin.Image = Properties.Resources.min;
            bMin.Location = new Point(423, 0);
            bMin.Margin = new Padding(3, 2, 3, 2);
            bMin.Name = "bMin";
            bMin.Size = new Size(26, 25);
            bMin.TabIndex = 0;
            bMin.TabStop = false;
            bMin.Click += bMin_Click;
            bMin.MouseDown += bMin_MouseDown;
            bMin.MouseEnter += bMin_MouseEnter;
            bMin.MouseLeave += bMin_MouseLeave;
            // 
            // bMax
            // 
            bMax.BackColor = Color.FromArgb(83, 83, 83);
            bMax.Dock = DockStyle.Right;
            bMax.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point);
            bMax.Image = Properties.Resources.max;
            bMax.Location = new Point(449, 0);
            bMax.Margin = new Padding(3, 2, 3, 2);
            bMax.Name = "bMax";
            bMax.Size = new Size(26, 25);
            bMax.TabIndex = 0;
            bMax.TabStop = false;
            bMax.Click += bMax_Click;
            bMax.MouseDown += bMax_MouseDown;
            bMax.MouseEnter += bMax_MouseEnter;
            bMax.MouseLeave += bMax_MouseLeave;
            // 
            // bClose
            // 
            bClose.BackColor = Color.FromArgb(83, 83, 83);
            bClose.Dock = DockStyle.Right;
            bClose.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point);
            bClose.Image = Properties.Resources.close;
            bClose.Location = new Point(475, 0);
            bClose.Margin = new Padding(3, 2, 3, 2);
            bClose.Name = "bClose";
            bClose.Size = new Size(48, 25);
            bClose.TabIndex = 0;
            bClose.TabStop = false;
            bClose.Click += bClose_Click;
            bClose.MouseDown += bClose_MouseDown;
            bClose.MouseEnter += bClose_MouseEnter;
            bClose.MouseLeave += bClose_MouseLeave;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.BackColor = Color.Transparent;
            labelTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(0, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(65, 21);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "WinMdi";
            labelTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelFloor
            // 
            panelFloor.BackColor = Color.FromArgb(83, 83, 83);
            panelFloor.Dock = DockStyle.Bottom;
            panelFloor.Location = new Point(0, 299);
            panelFloor.Margin = new Padding(3, 2, 3, 2);
            panelFloor.Name = "panelFloor";
            panelFloor.Size = new Size(525, 1);
            panelFloor.TabIndex = 0;
            // 
            // panelRightFloor
            // 
            panelRightFloor.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panelRightFloor.BackColor = Color.FromArgb(83, 83, 83);
            panelRightFloor.Location = new Point(508, 283);
            panelRightFloor.Margin = new Padding(3, 2, 3, 2);
            panelRightFloor.Name = "panelRightFloor";
            panelRightFloor.Size = new Size(16, 16);
            panelRightFloor.TabIndex = 1;
            panelRightFloor.Paint += panelRightFloor_Paint;
            panelRightFloor.MouseDown += panelRightFloor_MouseDown;
            panelRightFloor.MouseEnter += panelRightFloor_MouseEnter;
            panelRightFloor.MouseLeave += panelRightFloor_MouseLeave;
            panelRightFloor.MouseMove += panelRightFloor_MouseMove;
            panelRightFloor.MouseUp += panelRightFloor_MouseUp;
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.FromArgb(83, 83, 83);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 1);
            panelLeft.Margin = new Padding(3, 2, 3, 2);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(1, 298);
            panelLeft.TabIndex = 0;
            // 
            // panelRight
            // 
            panelRight.BackColor = Color.FromArgb(83, 83, 83);
            panelRight.Dock = DockStyle.Right;
            panelRight.Location = new Point(524, 1);
            panelRight.Margin = new Padding(3, 2, 3, 2);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(1, 298);
            panelRight.TabIndex = 0;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(83, 83, 83);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(3, 2, 3, 2);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(525, 1);
            panelTop.TabIndex = 1;
            // 
            // WinMdi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelMain);
            Controls.Add(panelRightFloor);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Controls.Add(panelTop);
            Controls.Add(panelFloor);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(3, 2, 3, 2);
            Name = "WinMdi";
            Size = new Size(525, 300);
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)bMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)bClose).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.PictureBox bMin;
        private System.Windows.Forms.PictureBox bMax;
        private System.Windows.Forms.PictureBox bClose;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelFloor;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        public Panel panelRightFloor;
    }
}

using winMdi;

namespace SampleMDIApp
{
    public partial class Form1 : Form
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Form1()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            InitializeComponent();
        }

        private WinMdi winMdi;

        private void createWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (winMdi == null)
            {
                winMdi = mdiControl1.CreateWinMdiWithForm(new Content1());
                winMdi.SetTitle("Title: " + DateTime.Now.ToString());
                winMdi.SetTitleFont(new Font("Ink Free", 16, FontStyle.Bold));
                winMdi.Size = new Size(600, 400);
                winMdi.Location = new Point(50, 50);
            }

        }

        private void setANewFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (winMdi != null)
            {
                winMdi.SetTitleFont(new Font("Tahoma", 18, FontStyle.Italic));
            }
        }

        private void createAnotherWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mdiControl1.CreateWinMdiWithForm(new Content1());

        }
    }
}
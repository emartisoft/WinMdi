using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleMDIApp
{
    public partial class Content1 : Form
    {
        public Content1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "OK";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString("dd MMMM yyyy, dddd HH:mm:ss");
        }

        private void Content1_Load(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class colorForm : Form
    {
        public colorForm(MainForm f)
        {
            InitializeComponent();
            pf = f;
        }
        MainForm pf;
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pf.ActiveImage.light(trackBar1.Value/10.0f);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            pf.ActiveImage.lightColor(trackBar2.Value / 10.0f, Color.Red);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            pf.ActiveImage.lightColor(trackBar3.Value / 10.0f, Color.Green);
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            pf.ActiveImage.lightColor(trackBar4.Value / 10.0f, Color.Blue);
        }
    }
}

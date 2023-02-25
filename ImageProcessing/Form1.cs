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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PictureBox b = new PictureBox();
            b.Location = new Point(0, 0);
            b.Image = Image.FromFile(@"C:\Users\DELL\Pictures\22.png");
            b.SizeMode = PictureBoxSizeMode.AutoSize;
          //  this.scrolledPanel1.Controls.Add(b);
        }

        private void scrolledPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button b = new Button();
            b.Text = "hhhhh";
            b.Location = new Point(200, 200);
        //    this.scrolledPanel1.Controls.Add(b);
        }
    }
}

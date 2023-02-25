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
    public partial class ImageForm : Form
    {
        public ImageForm()
        {
            InitializeComponent();

            this.Controls.Remove(panelImageContainer);
            pictureView = new PictureView();
            pictureView.Dock = DockStyle.Fill;

            pictureView.BackColor = SystemColors.ControlDarkDark;
            this.Controls.Add(pictureView);
            this.Controls.Remove(panelFooter);
            this.Controls.Add(panelFooter);
            panelImageContainer.Controls.Remove(hScrollBar1);
            panelImageContainer.Controls.Remove(vScrollBar1);
            panelImage.Resize += panelImage_Resize;
        }
        PictureView pictureView;
        void panelImage_Resize(object sender, EventArgs e)
        {
            pictureBox1.Left = (panelImageContainer.Width - img.Width) / 2;
            pictureBox1.Top = (panelImageContainer.Height - img.Height) / 2;
           

            if (pictureBox1.Left < 0)
            {
                hScrollBar1.Maximum = -2 * pictureBox1.Left;
                hScrollBar1.Value = -pictureBox1.Left;
                panelImageContainer.Controls.Add(hScrollBar1);
            }
            else
            {
                panelImageContainer.Controls.Remove(hScrollBar1);
            }

            if (pictureBox1.Top < 0)
            {
                vScrollBar1.Maximum = -2 * pictureBox1.Top;
                vScrollBar1.Value = -pictureBox1.Top;
                panelImageContainer.Controls.Add(vScrollBar1);
            }
            else
            {
                panelImageContainer.Controls.Remove(vScrollBar1);
            }
        }
        Image img;

        public Image Img
        {
            get { return img; }
            set { img = value;
            pictureBox1.Image = img;
            panelImage_Resize(null, null);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.ShowDialog();
            pictureView.Image = Image.FromFile(of.FileName);
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            pictureBox1.Left =- hScrollBar1.Value;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            pictureBox1.Top = -vScrollBar1.Value;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                pictureView.Showrate = (PictureView.ShowRate)(new int[] {1,2,4 })[comboBox1.SelectedIndex];
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }
    }
}

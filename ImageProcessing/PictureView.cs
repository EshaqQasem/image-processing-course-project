using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ImageProcessing
{
   public class PictureView:Panel
    {
       public PictureView()
       {
           initiComp();
           this.Showrate = ShowRate._100;
           //this.Image = img;
          
       }

       private void initiComp()
       {
           pictureBoxContainer = new Panel();
           pictureBoxContainer.Dock = DockStyle.Fill;
           pictureBoxContainer.Resize += pictureBoxContainer_Resize;

           hScrollBar = new HScrollBar() { RightToLeft = System.Windows.Forms.RightToLeft.Yes };
           hScrollBar.Dock = DockStyle.Bottom;
           hScrollBar.Scroll += delegate { pictureBox.Left = -2*hScrollBar.Value; };

           vScrollBar = new VScrollBar();
           vScrollBar.Dock = DockStyle.Left;
           vScrollBar.Scroll += delegate { pictureBox.Top = -2*vScrollBar.Value; };

           pictureBox = new PictureBox();
           pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
           pictureBox.MouseMove += (s, e) => { this.mouseOnPixel(new Point(e.X *(int) this.Showrate, e.Y *(int) this.Showrate)); };

           this.Controls.Add(pictureBoxContainer);
          // this.Controls.Add(hScrollBar);
           //this.Controls.Add(vScrollBar);
           this.pictureBoxContainer.Controls.Add(pictureBox);


       }

       void pictureBoxContainer_Resize(object sender, EventArgs e)
       {
           if (this.Image != null)
           {
               pictureBox.Height = Image.Height / (int)Showrate;
               pictureBox.Width = Image.Width / (int)Showrate;

               pictureBox.Left = (pictureBoxContainer.Width - pictureBox.Width) / 2;
               pictureBox.Top = (pictureBoxContainer.Height - pictureBox.Height) / 2;


               if (pictureBox.Left < 0)
               {
                   hScrollBar.Maximum = - pictureBox.Left;
                   hScrollBar.Value = -pictureBox.Left/2;
                   this.Controls.Add(hScrollBar);
               }
               else
               {
                   this.Controls.Remove(hScrollBar);
               }

               if (pictureBox.Top < 0)
               {
                   vScrollBar.Maximum = - pictureBox.Top;
                   vScrollBar.Value = -pictureBox.Top/2;
                   this.Controls.Add(vScrollBar);
               }
               else
               {
                   this.Controls.Remove(vScrollBar);
               }
           }
       }

       public enum ShowRate { _100 = 1, _50 = 2, _25 = 4 ,Fit};
       ShowRate showrate;

       public ShowRate Showrate
       {
           get { return showrate; }
           set { showrate = value;

           pictureBoxContainer_Resize(null, null);
           }
       }
       Image image;

       public Image Image
       {
           get { return pictureBox.Image; }
           set {
               pictureBox.Image = value;
               pictureBoxContainer_Resize(null, null);
               this.pictureBox.Image=image = value; }
       }
      public delegate void Event(Point loc);
       public Event mouseOnPixel;
       Panel pictureBoxContainer;
       PictureBox pictureBox;
       HScrollBar hScrollBar;
       VScrollBar vScrollBar;
    }
}

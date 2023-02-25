using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace ImageProcessing
{
  public partial  class MainForm:Form
    {

        public MainForm()
        {
            Start();
        }

        void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (select)
            {
                endPoint = new Point(e.X, e.Y);
            }
        }

        

        void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                select = true;

                startPoint = new Point(e.X, e.Y);
            }
        }

       
        void sprate_Click(object sender, EventArgs e)
        {
            byte th = Convert.ToByte(threshold.Text);
            Bitmap tmp = new Bitmap(((ImageContainerForm)ActiveMdiChild).Image);
            grayImageMenuItem_Click(null, null);

           // grayToBinary(th);
            multiBitmap(tmp);
        }

        void onlyColor(Func<Color ,byte > fun)
        {
            //imageProcessing((img, row, col) =>
            //{
            //    byte nv = fun( img.GetPixel(col, row));
            //    img.SetPixel(col, row, Color.FromArgb(nv, nv, nv));
            //});
        }
        void simpleThresholding_Click(object sender, EventArgs e)
        {
            byte th = Convert.ToByte(threshold.Text);
            //Bitmap tmp = ((ImageContainerForm)ActiveMdiChild).Bitmap;

            //grayToBinary(th);
          //  multiBitmap(tmp);


        }
        void multiBitmap(Bitmap bm)
        {
            //imageProcessing((img, row, col) => { 
            //    byte b=(byte) (img.GetPixel(col,row).R/255);
            //    Color c=bm.GetPixel(col,row);
            //    img.SetPixel(col, row, Color.FromArgb(c.R * b, c.G * b, c.B * b));
            //});
        }
       
        void medianMenuItem_Click(object sender, EventArgs e)
        {
           this.ActiveImage.medianFilter(3);
        }

        void robertsMenuItem_Click(object sender, EventArgs e)
        {
            this.ActiveImage.rebortsTrans();
        }

        //void doMask(Bitmap img, float[,] mask, int mSize)
        //{
        //    int ms = (mSize - 1) / 2;
        //    for (int row = ms; row < img.Height-ms; row++)
        //    {
        //        for (int col = ms; col < img.Width-ms; col++)
        //        {
        //            byte newGrayLevel = 0;
        //            for (int i = 0; i < mSize; i++)
        //            {
        //                for (int j = 0; j < mSize; j++)
        //                {
        //                    newGrayLevel +=(byte)( img.GetPixel(col - (ms - j), row - (ms - i)).R * mask[i, j]);
        //                }
        //            }
        //            img.SetPixel(col,row,Color.FromArgb(newGrayLevel,newGrayLevel,newGrayLevel));
        //        }
                
        //    }

        //}
        byte maxGrayValue(Bitmap img)
        {
            byte max=img.GetPixel(0,0).R;
            //imageProcessing((im, r, c) => {
            //    byte tmp= im.GetPixel(c,r).R;
            //    if (tmp > max) max = tmp;
            //});

            return max;
        }

        byte minGrayValue(Bitmap img)
        {
            byte min= img.GetPixel(0, 0).R;
            //imageProcessing((im, r, c) =>
            //{
            //    byte tmp = im.GetPixel(c, r).R;
            //    if (tmp < min) min = tmp;
            //});

            return min;
        }
        void incrContrast_Click(object sender, EventArgs e)
        {
          /*  byte max, min;
            Bitmap img= ((ImageContainerForm)ActiveMdiChild).Bitmap;
            max = maxGrayValue(img);
            min = minGrayValue(img);

            imageProcessing((im, r, c) => { 
                byte newGrayLevel=(byte) (255*( (float)(im.GetPixel(c,r).R-min)/(float)(max-min)));
                im.SetPixel(c, r, Color.FromArgb(newGrayLevel, newGrayLevel, newGrayLevel));
            });
           * */

            Bitmap img =(Bitmap) ((ImageContainerForm)ActiveMdiChild).Image;
            //doMask(img, new float[,] { { 1 / 9f, 1 / 9f, 1 / 9f }, { 1 / 9f, 1 / 9f, 1 / 9f }, { 1 / 9f, 1 / 9f, 1 / 9f } }, 3);
            ((ImageContainerForm)ActiveMdiChild).Image = img; 
        }

        void redonly(Bitmap img,int r,int c)
        {
           Color color= img.GetPixel(c, r);
           img.SetPixel(c, r, Color.FromArgb(color.R, color.R, color.R));
        }
       
        void colorDistr_Click(object sender, EventArgs e)
        {
            this.ActiveImage.onColor(Color.FromArgb(50, 150, 200));
            //imageProcessing(redonly);
        //    Bitmap img = ((ImageContainerForm)ActiveMdiChild).Bitmap;
            
        //    for (int row = 0; row < img.Height; row++)
        //    {
        //        for (int col = 0; col < img.Width; col++)
        //        {
        //            Color color = img.GetPixel(col, row);
        //            img.SetPixel(col, row, Color.FromArgb(color.R, color.R, color.R));

        //        }
               
        //    }
        //    ((ImageContainerForm)ActiveMdiChild).Image.Bitmap = img;
        //
        }

        void meanMenuItem_Click(object sender, EventArgs e)
        {
           // this.ActiveImage.sharpFilter();
          this.ActiveImage.filter(new float[,] { { 1 / 9f, 1 / 9f, 1 / 9f }, { 1 / 9f, 1 / 9f, 1 / 9f }, { 1 / 9f, 1 / 9f, 1 / 9f } },3);
        }

        void nosieImageMenuItem_Click(object sender, EventArgs e)
        {
            this.ActiveImage.slatPepperNoise();
        }

        void lightImageMenuItem_Click(object sender, EventArgs e)
        {
            colorForm f = new colorForm(this);
            f.ShowDialog();
           // this.ActiveImage.light();
        }

        void clipYImageMenuItem_Click(object sender, EventArgs e)
        {
            this.ActiveImage.clipY();
        }

        void negitveColorMenuItem_Click(object sender, EventArgs e)
        {
            this.ActiveImage.negitve();
        }

       
        void grayImageMenuItem_Click(object sender, EventArgs e)
        {
            this.ActiveImage.rgbToGray(color => (byte)(0.299f * color.R + 0.587f * color.G + 0.114f * color.B));    
        }     
        
        void blackWhiteImageMenuItem_Click(object sender, EventArgs e)
        {
            this.ActiveImage.grayToBinary(122);           
        }

        void closeAllMenuItem_Click(object sender, EventArgs e)
        {
            //foreach (ImageContainerForm f in this.OpenedForms)
            //{
            //    f.Focus();
            //    f.Close();
            //}
          /*  while (this.ActiveMdiChild != null)
            {
                ((ImageContainerForm)this.ActiveMdiChild).Close();
            }
           * */
        }

        void closeMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveForm != null)
            {
               this.ActiveForm.Close();
              
            }
        }

        

        public ImageContainerForm ActiveForm
        {
            get
            {
                return this.OpenedForms.ActiveForm.Form;
            }
            set { this.OpenedForms.ActiveForm.Form = value; }
        
        }
        public ProcessedImage ActiveImage
        {
            get
            {
                return this.OpenedForms.ActiveForm.Form.ProcessedImage;
            }
            set { this.OpenedForms.ActiveForm.Form.ProcessedImage= value; }
        }
        void saveMenuItem_Click(object sender, EventArgs e)
        {
            ActiveForm.saveImage();           
        }

        void openMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Count() == 0)
            {
                this.newMenuItem_Click(null, null);
            }
            else
            {
                Image img = getImageFromSystem()[0];
                if (img != null)
                {
                    ((ImageContainerForm)this.ActiveMdiChild).Image =new Bitmap( img);
                }
            }
        }

        Image[] getImageFromSystem()
        {
            Image []img=null;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images File | *.png;*.jpg;*.tif";
            ofd.Multiselect = true;
           DialogResult res= ofd.ShowDialog();
           if (res == System.Windows.Forms.DialogResult.OK)
           {
               img = new Image[ofd.FileNames.Length];
               for (int i = 0; i < ofd.FileNames.Length; i++)
               {
                   FileStream file = new FileStream(ofd.FileNames[i], FileMode.Open, FileAccess.Read);
                   try
                   {
                       img[i] = new Bitmap(file);
                   }
                   catch (ArgumentException ex)
                   {
                   }
                   file.Close();
               }
           }
            return img;
        }

        void newMenuItem_Click(object sender, EventArgs e)
        {
            Image[] imgs = getImageFromSystem();
            if (imgs != null)
            {
                for (int i = 0; i < imgs.Length; i++)
                {
                    ImageContainerForm newImage = new ImageContainerForm(imgs[i]);

                    this.OpenedForms.AddForm(newImage);
                    //f.TopLevel = false;
                    //f.MdiParent = this;
                    //f.Show();
                    ToolStripMenuItem win = new ToolStripMenuItem();
                    win.Text = "Window " + this.MdiChildren.Count().ToString();
                    win.Tag = newImage;
                    newImage.WindowLabel = win;
                    win.Click += win_Click;

                    windowMenuItem.DropDownItems.Add(win);
                }
            }
        }

        void win_Click(object sender, EventArgs e)
        {
            ((Form)((ToolStripMenuItem)sender).Tag).Activate();
        }

        void filterTmi_Click(object sender, EventArgs e)
        {
            filterForm f = new filterForm();
            f.doMask = (mask,size) => {
                this.ActiveImage.filter(mask, size);
            };
            f.Show(this);
        }

        void undoMenuItem_Click(object sender, EventArgs e)
        {
            this.ActiveForm.undo();
        }

        void redoMenuItem_Click(object sender, EventArgs e)
        {
            this.ActiveForm.redo();
        }

        private void addTwoImage(object sender, EventArgs e)
        {
            Image img = getImageFromSystem()[0];
            this.ActiveImage.addImage(img);
        }

        Panel rightSide, LeftSide;
        MultiFormsTool OpenedForms;
        Label selecetLabel;
        Point startPoint, endPoint;
        bool select = false;

        
    }
}

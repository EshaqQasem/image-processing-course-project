using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ImageProcessing
{
   
   public class ImageContainerForm:Form
    {

       public Image Image
       {
           set
           {
               this.bitmapImage.Bitmap = (Bitmap)value;
               this.pictureView.Image = value;
               
           }
           get
           {
               return this.bitmapImage.Bitmap;
           }
       }
        public ImageContainerForm(Image img)
        {
            
            Initialize(img);
            bitmapImage=new BitmapImage(new Bitmap(img));
            this.Image = bitmapImage.Bitmap;
            this.ProcessedImage = new ProcessedImage(bitmapImage);
            
            ProcessedImage.PreProcessing = (im) =>
            {
                Bitmap bitmap = (Bitmap)bitmapImage.Bitmap.Clone();
                this.addImageToStack(bitmap);
                redoStack.Clear();
               
                this.Invoke(new inv((i) =>
                {
                    progressBar.Value = 0;
                    progressBar.Maximum = i.Height;
                    progressBar.Visible = true;
                }), new object[] { im });
            };
           
            processedImage.OnProcessing = (n) => {this.Invoke(new inv2(()=> progressBar.Value++));
            };
            this.processedImage.PostProcessing = () => {
                 this.Invoke(new inv2(() =>
                {
                this.Image = bitmapImage.Bitmap;
                progressBar.Visible = false;
                
                }));
            };
           // this.Image = img;
            this.Saved = false;
            this.Path = "";
        }


        Stack<Bitmap> undoStack = new Stack<Bitmap>();
        Stack<Bitmap> redoStack = new Stack<Bitmap>();
        private void addImageToStack(Bitmap image)
        {
            undoStack.Push(image);
        }

        public void undo()
        {
            if (undoStack.Count > 0)
            {
                Bitmap bitmap = undoStack.Pop();
                redoStack.Push(this.bitmapImage.Bitmap);
                this.Image = bitmap;
            }
        }

        public void redo()
        {
            if (redoStack.Count > 0)
            {
                Bitmap bitmap = redoStack.Pop();
                undoStack.Push(this.bitmapImage.Bitmap);
                this.Image = bitmap;
            }
        }

       delegate void  inv(IRGBImage img);
       delegate void inv2();
        BitmapImage bitmapImage;

        
        ProcessedImage processedImage;

        public ProcessedImage ProcessedImage
        {
            get { return processedImage; }
            set { processedImage = value; }
        }
        public void light()
        {

        }
        public void saveAsImage()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Images File | *.png;*.jpg;";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Path = sfd.FileName;
                this.pictureView.Image.Save(Path);
            }
        }
        public void saveImage()
        {
            if (path == "")
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Images File | *.png;*.jpg;";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Path = sfd.FileName;
                    this.pictureView.Image.Save(Path);
                }
            }
            else
            {
                this.pictureView.Image.Save(Path);
            }
        }

        public new  void Close()
        {
           DialogResult res= MessageBox.Show( "Do You Want To Save?","", MessageBoxButtons.YesNoCancel);
           if (res == System.Windows.Forms.DialogResult.No)
           {
               windowLabel.Dispose();
               base.Close();
           
           }
           else if (res == System.Windows.Forms.DialogResult.Yes)
           {
               this.saveImage();
               windowLabel.Dispose();
               base.Close();
              
           }
         
        }

        private ToolStripMenuItem windowLabel;

        public ToolStripMenuItem WindowLabel
        {
            get { return windowLabel; }
            set { windowLabel = value; }
        }
        private string path;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        private bool saved;

        public bool Saved
        {
            get { return saved; }
            set { saved = value; }
        }
       
       
        private void Initialize(Image img)
        {
         
            this.BackColor = SystemColors.ControlDarkDark;
            pictureView = new PictureView();
            pictureView.mouseOnPixel = (p) => { this.imageName.Text = p.X.ToString() + "," + p.Y.ToString(); };
            pictureView.Dock = DockStyle.Fill;
            this.Controls.Add(pictureView);

            panelFooter = new Panel();
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Height = 50;
            panelFooter.BackColor = SystemColors.ControlDark;
           // this.Controls.Add(panelFooter);
            
            contextMenu = new ContextMenuStrip();
            this.ContextMenuStrip = contextMenu;
            atuSize=new ToolStripMenuItem();
            atuSize.Text = "autoSize";
            atuSize.Tag = PictureBoxSizeMode.AutoSize;
            zoom = new ToolStripMenuItem();
            zoom.Text = "Zoom";
            zoom.Tag = PictureBoxSizeMode.Zoom;

            stritch = new ToolStripMenuItem();
            stritch.Text = "Stritch";
            stritch.Tag = PictureBoxSizeMode.StretchImage;
            center = new ToolStripMenuItem();
            center.Text = "Center";
            center.Tag = PictureBoxSizeMode.CenterImage;
            contextMenu.Items.AddRange(new ToolStripItem[]{
             atuSize,zoom,stritch,center});
            foreach (ToolStripItem t in contextMenu.Items)
            {
                t.Click+=context_Click;
            }

            statusStrip = new StatusStrip();
            statusStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            statusStrip.Dock = DockStyle.Bottom;
            statusStrip.BackColor = Color.FromArgb(88, 88, 88);
            statusStrip.AutoSize = false;
            statusStrip.Height = 33;
            statusStrip.ForeColor = Color.WhiteSmoke;
            statusStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Controls.Add(statusStrip);

            pixelCord = new ToolStripStatusLabel() {Text="jkbjh", AutoSize = false, Width = 70 };
            this.statusStrip.Items.Add(pixelCord);

            imageScaling = new ToolStripDropDownButton() {Text="100%", DisplayStyle = ToolStripItemDisplayStyle.Text };
            imageScaling.DisplayStyle = ToolStripItemDisplayStyle.Text;


            imageScaling.DropDownItems.AddRange(new ToolStripItem[]{new ToolStripMenuItem(){Text="100%",Tag=1},
                new ToolStripMenuItem(){Text="50%",Tag=2},new ToolStripMenuItem(){Text="25%",Tag=4}});
            foreach (ToolStripItem item in imageScaling.DropDownItems)
            {
                item.Click += (s, e) =>
                {
                    pictureView.Showrate = (PictureView.ShowRate)(int)((ToolStripMenuItem)s).Tag;
                };
            }
            this.statusStrip.Items.Add(imageScaling);

            imageName = new ToolStripStatusLabel() { AutoSize = true};
            this.statusStrip.Items.Add(imageName);
            progressBar = new ToolStripProgressBar();
            progressBar.Size = new System.Drawing.Size(150, 15);
            progressBar.Visible = false;
            statusStrip.Items.Add(progressBar);

           

           
        }

        

        private void context_Click(object sender, EventArgs e)
        {
            // this.Size;
            //imgBox.SizeMode =(PictureBoxSizeMode) ((ToolStripItem)sender).Tag;
            //this.imgBox.Size = this.Size;
        }
        ContextMenuStrip contextMenu;
        ToolStripMenuItem atuSize,zoom,stritch,center;
        StatusStrip statusStrip;
        ToolStripProgressBar progressBar;
        ToolStripStatusLabel pixelCord,imageName;
        ToolStripDropDownButton imageScaling;
        
        Panel panelFooter;
        PictureView pictureView;
    }
}

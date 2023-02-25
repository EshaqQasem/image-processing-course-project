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
    class copy1
    {

        //        public MainForm()
        //        {
        //            Start();
        //        }

        //        private void Start()
        //        {
        //            initilizeMainForm();

        //            mainMenu = new MenuStrip();
        //            initilizeMainMenus();
        //            this.Controls.Add(mainMenu);

        //            selecetLabel = new Label();
        //            this.MouseDown += MainForm_MouseDown;
        //            this.MouseMove += MainForm_MouseMove;
        //            // this.MainMenuStrip = mainMenu;
        //        }

        //        void MainForm_MouseMove(object sender, MouseEventArgs e)
        //        {
        //            if (select)
        //            {
        //                endPoint = new Point(e.X, e.Y);
        //            }
        //        }
        //        Label selecetLabel;
        //        Point startPoint, endPoint;
        //        bool select = false;
        //        void MainForm_MouseDown(object sender, MouseEventArgs e)
        //        {
        //            if (e.Button == System.Windows.Forms.MouseButtons.Left)
        //            {
        //                select = true;

        //                startPoint = new Point(e.X, e.Y);
        //            }
        //        }

        //        private void initilizeMainForm()
        //        {
        //            this.Text = "برنامج للتعديل على الصور";
        //            this.Size = new Size(1000, 600);
        //            this.StartPosition = FormStartPosition.CenterScreen;
        //            this.RightToLeft = RightToLeft.Yes;
        //            this.RightToLeftLayout = true;
        //            this.IsMdiContainer = true;
        //        }

        //        private void initilizeMainMenus()
        //        {
        //            fileMenuItem = new ToolStripMenuItem();
        //            fileMenuItem.Text = "ملف";
        //            newMenuItem = new ToolStripMenuItem();
        //            newMenuItem.Text = "جديد";
        //            newMenuItem.ShortcutKeys = Keys.Control | Keys.N;
        //            newMenuItem.Click += newMenuItem_Click;

        //            openMenuItem = new ToolStripMenuItem();
        //            openMenuItem.Text = "فتح صورة";
        //            openMenuItem.ShortcutKeys = Keys.Control | Keys.O;
        //            openMenuItem.Click += openMenuItem_Click;

        //            saveMenuItem = new ToolStripMenuItem();
        //            saveMenuItem.Text = "حفظ";
        //            saveMenuItem.ShortcutKeys = Keys.Control | Keys.S;
        //            saveMenuItem.Click += saveMenuItem_Click;
        //            saveAsMenuItem = new ToolStripMenuItem();
        //            saveAsMenuItem.Text = "حفظ باسم";

        //            closeMenuItem = new ToolStripMenuItem();
        //            closeMenuItem.Text = "اغلاق العمل الحالي";
        //            closeMenuItem.Click += closeMenuItem_Click;

        //            closeAllMenuItem = new ToolStripMenuItem();
        //            closeAllMenuItem.Text = "اغلاق كل الاعمال";
        //            closeAllMenuItem.Click += closeAllMenuItem_Click;
        //            exitMenuItem = new ToolStripMenuItem();
        //            exitMenuItem.Text = "الخروج من التبيق";
        //            fileMenuItem.DropDownItems.AddRange(new ToolStripItem[]{
        //            newMenuItem,openMenuItem,saveMenuItem,saveAsMenuItem
        //            ,closeMenuItem,closeAllMenuItem,exitMenuItem});

        //            editMenuItem = new ToolStripMenuItem();
        //            editMenuItem.Text = "تحرير";
        //            undoMenuItem = new ToolStripMenuItem();
        //            undoMenuItem.Text = "تراجع";
        //            undoMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
        //            redoMenuItem = new ToolStripMenuItem();
        //            redoMenuItem.Text = "اعادة";
        //            redoMenuItem.ShortcutKeys = Keys.Control | Keys.Y;
        //            copyMenuItem = new ToolStripMenuItem();
        //            copyMenuItem.Text = "نسخ";
        //            copyMenuItem.ShortcutKeys = Keys.Control | Keys.C;
        //            cutMenuItem = new ToolStripMenuItem();
        //            cutMenuItem.Text = "قص";
        //            cutMenuItem.ShortcutKeys = Keys.Control | Keys.X;
        //            pasteMenuItem = new ToolStripMenuItem();
        //            pasteMenuItem.Text = "لصق";
        //            pasteMenuItem.ShortcutKeys = Keys.Control | Keys.V;

        //            grayImageMenuItem = new ToolStripMenuItem();
        //            grayImageMenuItem.Text = "رمادي";
        //            grayImageMenuItem.ShortcutKeys = Keys.Control | Keys.G;
        //            grayImageMenuItem.Click += grayImageMenuItem_Click;

        //            blackWhiteImageMenuItem = new ToolStripMenuItem();
        //            blackWhiteImageMenuItem.Text = "ابيض واسود";
        //            blackWhiteImageMenuItem.Click += blackWhiteImageMenuItem_Click;

        //            negitveColorMenuItem = new ToolStripMenuItem();
        //            negitveColorMenuItem.Text = "عكس الألوان";
        //            negitveColorMenuItem.ShortcutKeys = Keys.Control | Keys.P;
        //            negitveColorMenuItem.Click += negitveColorMenuItem_Click;

        //            lightImageMenuItem = new ToolStripMenuItem();
        //            lightImageMenuItem.Text = "اضاءة";
        //            lightImageMenuItem.ShortcutKeys = Keys.Control | Keys.L;
        //            lightImageMenuItem.Click += lightImageMenuItem_Click;

        //            nosieImageMenuItem = new ToolStripMenuItem();
        //            nosieImageMenuItem.Text = "ازعاج";
        //            nosieImageMenuItem.Click += nosieImageMenuItem_Click;

        //            clipYImageMenuItem = new ToolStripMenuItem();
        //            clipYImageMenuItem.Text = "قلب الصورة عموديا";
        //            clipYImageMenuItem.Click += clipYImageMenuItem_Click;

        //            editMenuItem.DropDownItems.AddRange(new ToolStripItem[]{
        //            undoMenuItem,redoMenuItem,cutMenuItem,cutMenuItem,pasteMenuItem
        //            ,grayImageMenuItem,blackWhiteImageMenuItem,negitveColorMenuItem
        //            ,nosieImageMenuItem,lightImageMenuItem,clipYImageMenuItem});



        //            windowMenuItem = new ToolStripMenuItem();
        //            windowMenuItem.Text = "النوافذ";
        //            horizintailOrderMenuItem = new ToolStripMenuItem();
        //            horizintailOrderMenuItem.Text = "";
        //            verticalOrderMenuItem = new ToolStripMenuItem();
        //            verticalOrderMenuItem.Text = "";
        //            cascadeOrderMenuItem = new ToolStripMenuItem();
        //            cascadeOrderMenuItem.Text = "";
        //            windowMenuItem.DropDownItems.AddRange(new ToolStripItem[]{
        //            horizintailOrderMenuItem,verticalOrderMenuItem,cascadeOrderMenuItem});

        //            filtersMenuItem = new ToolStripMenuItem();
        //            filtersMenuItem.Text = "الفلاتر";
        //            meanMenuItem = new ToolStripMenuItem();
        //            meanMenuItem.Text = "Mean Filter";
        //            meanMenuItem.Click += meanMenuItem_Click;

        //            medianMenuItem = new ToolStripMenuItem();
        //            medianMenuItem.Text = "Median Filter";
        //            medianMenuItem.Click += medianMenuItem_Click;
        //            colorDistr = new ToolStripMenuItem();
        //            colorDistr.Text = "الاحمر فقط";
        //            colorDistr.Click += colorDistr_Click;

        //            incrContrast = new ToolStripMenuItem();
        //            incrContrast.Text = "زيادة التباين";
        //            incrContrast.Click += incrContrast_Click;
        //            filtersMenuItem.DropDownItems.AddRange(new ToolStripItem[] { meanMenuItem, medianMenuItem, colorDistr, incrContrast });



        //            mainMenu.Items.AddRange(new ToolStripItem[] { fileMenuItem, editMenuItem, windowMenuItem, filtersMenuItem });

        //            statusStrip = new StatusStrip();
        //            statusStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
        //            this.Controls.Add(statusStrip);
        //            progressBar = new ToolStripProgressBar();
        //            progressBar.Size = new System.Drawing.Size(150, 15);
        //            progressBar.Visible = false;
        //            statusStrip.Items.Add(progressBar);


        //            initToolStrip();
        //        }

        //        private void initToolStrip()
        //        {
        //            this.toolStrip = new ToolStrip();
        //            this.Controls.Add(toolStrip);

        //            this.simpleThresholding = new ToolStripButton();
        //            this.simpleThresholding.Text = "STH";
        //            this.simpleThresholding.Click += simpleThresholding_Click;

        //            ToolStripButton sprate = new ToolStripButton();
        //            sprate.Text = "SPrate";
        //            sprate.Click += sprate_Click;
        //            this.threshold = new ToolStripTextBox();

        //            this.onlyB = new ToolStripButton();
        //            this.onlyB.Text = "BLUE";

        //            this.onlyB.Click +=
        //            (s, e) =>
        //            {
        //                onlyColor((c) => c.B);

        //            };
        //            this.onlyG = new ToolStripButton();
        //            this.onlyG.Text = "GREEN";
        //            this.onlyG.Click += delegate { onlyColor(c => c.G); };

        //            this.onlyR = new ToolStripButton();
        //            this.onlyR.Text = "RED";
        //            this.onlyR.Click += delegate { onlyColor(c => c.R); };
        //            this.toolStrip.Items.AddRange(new ToolStripItem[] { simpleThresholding, threshold, sprate, onlyB, onlyG, onlyR });

        //        }

        //        void sprate_Click(object sender, EventArgs e)
        //        {
        //            byte th = Convert.ToByte(threshold.Text);
        //            Bitmap tmp = new Bitmap(((ImageContainerForm)ActiveMdiChild).Image);
        //            grayImageMenuItem_Click(null, null);

        //            grayToBinary(th);
        //            multiBitmap(tmp);
        //        }

        //        void onlyColor(Func<Color, byte> fun)
        //        {
        //            imageProcessing((img, row, col) =>
        //            {
        //                byte nv = fun(img.GetPixel(col, row));
        //                img.SetPixel(col, row, Color.FromArgb(nv, nv, nv));
        //            });
        //        }
        //        void simpleThresholding_Click(object sender, EventArgs e)
        //        {
        //            byte th = Convert.ToByte(threshold.Text);
        //            //Bitmap tmp = ((ImageContainerForm)ActiveMdiChild).Bitmap;

        //            grayToBinary(th);
        //            //  multiBitmap(tmp);


        //        }
        //        void multiBitmap(Bitmap bm)
        //        {
        //            imageProcessing((img, row, col) =>
        //            {
        //                byte b = (byte)(img.GetPixel(col, row).R / 255);
        //                Color c = bm.GetPixel(col, row);
        //                img.SetPixel(col, row, Color.FromArgb(c.R * b, c.G * b, c.B * b));
        //            });
        //        }
        //        byte median(List<byte> arr)
        //        {
        //            arr.Sort();
        //            return arr[arr.Count / 2];
        //        }

        //        void doMedianFilter(int maskSize)
        //        {
        //            imageProcessing2(1, (img, row, col) =>
        //            {
        //                List<byte> mask = new List<byte>();
        //                int ms = (maskSize - 1) / 2;
        //                for (int i = 0; i < maskSize * maskSize; i++)
        //                {
        //                    mask.Add(img.GetPixel(col - (ms - (i % maskSize)), row - (ms - (i / maskSize))).R);
        //                }
        //                byte newGrayLevel = median(mask);
        //                img.SetPixel(col, row, Color.FromArgb(newGrayLevel, newGrayLevel, newGrayLevel));
        //            });

        //        }
        //        void medianMenuItem_Click(object sender, EventArgs e)
        //        {
        //            doMedianFilter(3);
        //        }



        //        void doMask(Bitmap img, float[,] mask, int mSize)
        //        {
        //            int ms = (mSize - 1) / 2;
        //            for (int row = ms; row < img.Height - ms; row++)
        //            {
        //                for (int col = ms; col < img.Width - ms; col++)
        //                {
        //                    byte newGrayLevel = 0;
        //                    for (int i = 0; i < mSize; i++)
        //                    {
        //                        for (int j = 0; j < mSize; j++)
        //                        {
        //                            newGrayLevel += (byte)(img.GetPixel(col - (ms - j), row - (ms - i)).R * mask[i, j]);
        //                        }
        //                    }
        //                    img.SetPixel(col, row, Color.FromArgb(newGrayLevel, newGrayLevel, newGrayLevel));
        //                }

        //            }

        //        }
        //        byte maxGrayValue(Bitmap img)
        //        {
        //            byte max = img.GetPixel(0, 0).R;
        //            imageProcessing((im, r, c) =>
        //            {
        //                byte tmp = im.GetPixel(c, r).R;
        //                if (tmp > max) max = tmp;
        //            });

        //            return max;
        //        }
        //        byte minGrayValue(Bitmap img)
        //        {
        //            byte min = img.GetPixel(0, 0).R;
        //            imageProcessing((im, r, c) =>
        //            {
        //                byte tmp = im.GetPixel(c, r).R;
        //                if (tmp < min) min = tmp;
        //            });

        //            return min;
        //        }
        //        void incrContrast_Click(object sender, EventArgs e)
        //        {
        //            /*  byte max, min;
        //              Bitmap img= ((ImageContainerForm)ActiveMdiChild).Bitmap;
        //              max = maxGrayValue(img);
        //              min = minGrayValue(img);

        //              imageProcessing((im, r, c) => { 
        //                  byte newGrayLevel=(byte) (255*( (float)(im.GetPixel(c,r).R-min)/(float)(max-min)));
        //                  im.SetPixel(c, r, Color.FromArgb(newGrayLevel, newGrayLevel, newGrayLevel));
        //              });
        //             * */

        //            Bitmap img = ((ImageContainerForm)ActiveMdiChild).Bitmap;
        //            doMask(img, new float[,] { { 1 / 9f, 1 / 9f, 1 / 9f }, { 1 / 9f, 1 / 9f, 1 / 9f }, { 1 / 9f, 1 / 9f, 1 / 9f } }, 3);
        //            ((ImageContainerForm)ActiveMdiChild).Image = img;
        //        }

        //        void redonly(Bitmap img, int r, int c)
        //        {
        //            Color color = img.GetPixel(c, r);
        //            img.SetPixel(c, r, Color.FromArgb(color.R, color.R, color.R));
        //        }

        //        void colorDistr_Click(object sender, EventArgs e)
        //        {
        //            //imageProcessing(redonly);
        //            Bitmap img = ((ImageContainerForm)ActiveMdiChild).Bitmap;

        //            for (int row = 0; row < img.Height; row++)
        //            {
        //                for (int col = 0; col < img.Width; col++)
        //                {
        //                    Color color = img.GetPixel(col, row);
        //                    img.SetPixel(col, row, Color.FromArgb(color.R, color.R, color.R));

        //                }

        //            }
        //            ((ImageContainerForm)ActiveMdiChild).Image = img;
        //        }

        //        void meanMenuItem_Click(object sender, EventArgs e)
        //        {
        //            Bitmap img = (Bitmap)((ImageContainerForm)ActiveMdiChild).Image;
        //            progressBar.Value = 0;
        //            progressBar.Maximum = img.Height;
        //            progressBar.Visible = true;

        //            for (int row = 1; row < img.Height - 1; row++)
        //            {
        //                for (int col = 1; col < img.Width - 1; col++)
        //                {

        //                    Color[] points = new Color[] { 
        //                        img.GetPixel(col,row),
        //                        img.GetPixel(col - 1, row),img.GetPixel(col + 1, row), 
        //                        img.GetPixel(col, row - 1), img.GetPixel(col, row + 1),
        //                        img.GetPixel(col+1,row+1),img.GetPixel(col-1,row-1),
        //                        img.GetPixel(col+1,row-1),img.GetPixel(col-1,row+1)
        //                    };
        //                    int r = 0, g = 0, b = 0;
        //                    foreach (Color c in points)
        //                    {
        //                        r += c.R;
        //                        g += c.G;
        //                        b += c.B;
        //                    }

        //                    img.SetPixel(col, row, Color.FromArgb(r / points.Length, g / points.Length, b / points.Length));

        //                }
        //                progressBar.Value++;
        //            }
        //            progressBar.Visible = false;
        //            ((ImageContainerForm)ActiveMdiChild).Image = img;

        //        }

        //        void nosieImageMenuItem_Click(object sender, EventArgs e)
        //        {
        //            Bitmap img = (Bitmap)((ImageContainerForm)ActiveMdiChild).Image;
        //            Random random = new Random();
        //            for (int i = 0; i < 300; i++)
        //            {
        //                img.SetPixel(random.Next(0, img.Width - 1), random.Next(0, img.Height - 1), Color.White);

        //            }
        //            ((ImageContainerForm)ActiveMdiChild).Image = img;
        //        }

        //        void lightImageMenuItem_Click(object sender, EventArgs e)
        //        {
        //            imageProcessing((img, row, col) =>
        //            {
        //                Color oldColor = img.GetPixel(col, row);
        //                int r = oldColor.R + (int)((255 - oldColor.R) * 0.1f);
        //                int g = oldColor.G + (int)((255 - oldColor.G) * 0.1f);
        //                int b = oldColor.B + (int)((255 - oldColor.B) * 0.1f);
        //                img.SetPixel(col, row, Color.FromArgb(r, g, b));
        //            }
        //             );
        //        }

        //        void clipYImageMenuItem_Click(object sender, EventArgs e)
        //        {
        //            Bitmap img = (Bitmap)((ImageContainerForm)ActiveMdiChild).Image;
        //            progressBar.Value = 0;
        //            progressBar.Maximum = img.Height;
        //            progressBar.Visible = true;

        //            int n = img.Height;
        //            for (int row = 0; row < n / 2; row++)
        //            {
        //                for (int col = 0; col < img.Width; col++)
        //                {
        //                    Color temp = img.GetPixel(col, row);
        //                    img.SetPixel(col, row, img.GetPixel(col, n - 1 - row));
        //                    img.SetPixel(col, n - 1 - row, temp);
        //                }
        //                progressBar.Value++;
        //            }
        //            progressBar.Visible = false;
        //            ((ImageContainerForm)ActiveMdiChild).Image = img;
        //        }

        //        void negitveColorMenuItem_Click(object sender, EventArgs e)
        //        {
        //            imageProcessing((img, row, col) =>
        //            {
        //                Color oldColor = img.GetPixel(col, row);
        //                img.SetPixel(col, row, Color.FromArgb(255 - oldColor.R, 255 - oldColor.G, 255 - oldColor.B));

        //            });

        //        }


        //        void grayImageMenuItem_Click(object sender, EventArgs e)
        //        {
        //            imageProcessing((img, row, col) =>
        //            {
        //                Color oldColor = img.GetPixel(col, row);
        //                // int max = Math.Max(Math.Max(oldColor.R, oldColor.B), oldColor.G);
        //                //img.SetPixel(col, row, Color.FromArgb(max, max, max));
        //                int avg = (oldColor.R + oldColor.G + oldColor.B) / 3;
        //                img.SetPixel(col, row, Color.FromArgb(avg, avg, avg));
        //            });

        //        }

        //        void imageProcessing2(int shift, Action<Bitmap, int, int> action)
        //        {
        //            Bitmap img = (Bitmap)((ImageContainerForm)ActiveMdiChild).Image;
        //            progressBar.Value = 0;
        //            progressBar.Maximum = img.Height;
        //            progressBar.Visible = true;

        //            for (int row = shift; row < img.Height - shift; row++)
        //            {
        //                for (int col = shift; col < img.Width - shift; col++)
        //                {
        //                    action(img, row, col);

        //                }
        //                progressBar.Value++;
        //            }
        //            progressBar.Visible = false;
        //            ((ImageContainerForm)ActiveMdiChild).Image = img;
        //        }
        //        void imageProcessing(Action<Bitmap, int, int> action)
        //        {
        //            Bitmap img = (Bitmap)((ImageContainerForm)ActiveMdiChild).Image;
        //            progressBar.Value = 0;
        //            progressBar.Maximum = img.Height;
        //            progressBar.Visible = true;

        //            for (int row = 0; row < img.Height; row++)
        //            {
        //                for (int col = 0; col < img.Width; col++)
        //                {
        //                    action(img, row, col);

        //                }
        //                progressBar.Value++;
        //            }
        //            progressBar.Visible = false;
        //            ((ImageContainerForm)ActiveMdiChild).Image = img;
        //        }

        //        void grayToBinary(byte threshold)
        //        {
        //            imageProcessing((img, row, col) =>
        //            {
        //                Color oldColor = img.GetPixel(col, row);
        //                if (oldColor.R >= threshold)
        //                {
        //                    img.SetPixel(col, row, Color.White);
        //                }
        //                else
        //                {
        //                    img.SetPixel(col, row, Color.Black);
        //                }
        //            });
        //        }
        //        void blackWhiteImageMenuItem_Click(object sender, EventArgs e)
        //        {
        //            this.ActiveImage.grayToBinary(122);
        //            imageProcessing((img, row, col) =>
        //            {
        //                Color oldColor = img.GetPixel(col, row);
        //                if (oldColor.B > 122 || oldColor.R > 122 || oldColor.G > 122)
        //                {
        //                    img.SetPixel(col, row, Color.White);
        //                }
        //                else
        //                {
        //                    img.SetPixel(col, row, Color.Black);
        //                }
        //            });

        //        }

        //        void closeAllMenuItem_Click(object sender, EventArgs e)
        //        {
        //            foreach (ImageContainerForm f in this.MdiChildren)
        //            {
        //                f.Focus();
        //                f.Close();
        //            }
        //            /*  while (this.ActiveMdiChild != null)
        //              {
        //                  ((ImageContainerForm)this.ActiveMdiChild).Close();
        //              }
        //             * */
        //        }

        //        void closeMenuItem_Click(object sender, EventArgs e)
        //        {
        //            if (this.ActiveMdiChild != null)
        //            {
        //                ((ImageContainerForm)this.ActiveMdiChild).Close();

        //            }
        //        }


        //        public ProcessedImage ActiveImage
        //        {
        //            get { return ((ImageContainerForm)this.ActiveMdiChild).ProcessedImage; }
        //            set { ((ImageContainerForm)this.ActiveMdiChild).ProcessedImage = value; }
        //        }
        //        void saveMenuItem_Click(object sender, EventArgs e)
        //        {
        //            ((ImageContainerForm)this.ActiveMdiChild).saveImage();

        //        }

        //        void openMenuItem_Click(object sender, EventArgs e)
        //        {
        //            if (this.MdiChildren.Count() == 0)
        //            {
        //                this.newMenuItem_Click(null, null);
        //            }
        //            else
        //            {
        //                Image img = getImageFromSystem();
        //                if (img != null)
        //                {
        //                    ((ImageContainerForm)this.ActiveMdiChild).Image = img;
        //                }
        //            }
        //        }

        //        Image getImageFromSystem()
        //        {
        //            Image img = null;
        //            OpenFileDialog ofd = new OpenFileDialog();
        //            DialogResult res = ofd.ShowDialog();
        //            if (res == System.Windows.Forms.DialogResult.OK)
        //            {
        //                FileStream file = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
        //                img = new Bitmap(file);
        //                file.Close();
        //            }
        //            return img;
        //        }
        //        void newMenuItem_Click(object sender, EventArgs e)
        //        {
        //            Image img = getImageFromSystem();
        //            if (img != null)
        //            {
        //                ImageContainerForm f = new ImageContainerForm(img);
        //                f.TopLevel = false;
        //                f.MdiParent = this;
        //                f.Show();
        //                ToolStripMenuItem win = new ToolStripMenuItem();
        //                win.Text = "Window " + this.MdiChildren.Count().ToString();
        //                win.Tag = f;
        //                f.WindowLabel = win;
        //                win.Click += win_Click;

        //                windowMenuItem.DropDownItems.Add(win);
        //            }
        //        }

        //        void win_Click(object sender, EventArgs e)
        //        {
        //            ((Form)((ToolStripMenuItem)sender).Tag).Activate();
        //        }

        //        MenuStrip mainMenu;

        //        ToolStripMenuItem fileMenuItem;
        //        ToolStripMenuItem newMenuItem;
        //        ToolStripMenuItem openMenuItem;
        //        ToolStripMenuItem saveMenuItem;
        //        ToolStripMenuItem saveAsMenuItem;
        //        ToolStripMenuItem closeMenuItem;
        //        ToolStripMenuItem closeAllMenuItem;
        //        ToolStripMenuItem exitMenuItem;

        //        ToolStripMenuItem editMenuItem;
        //        ToolStripMenuItem undoMenuItem;
        //        ToolStripMenuItem redoMenuItem;
        //        ToolStripMenuItem cutMenuItem;
        //        ToolStripMenuItem copyMenuItem;
        //        ToolStripMenuItem pasteMenuItem;
        //        ToolStripMenuItem grayImageMenuItem;
        //        ToolStripMenuItem blackWhiteImageMenuItem;
        //        ToolStripMenuItem negitveColorMenuItem;
        //        ToolStripMenuItem nosieImageMenuItem;
        //        ToolStripMenuItem lightImageMenuItem;
        //        ToolStripMenuItem clipYImageMenuItem;

        //        ToolStripMenuItem windowMenuItem;
        //        ToolStripMenuItem verticalOrderMenuItem;
        //        ToolStripMenuItem horizintailOrderMenuItem;
        //        ToolStripMenuItem cascadeOrderMenuItem;

        //        ToolStripMenuItem filtersMenuItem;
        //        ToolStripMenuItem meanMenuItem;
        //        ToolStripMenuItem medianMenuItem;
        //        ToolStripMenuItem colorDistr;
        //        ToolStripMenuItem incrContrast;

        //        ToolStrip toolStrip;
        //        ToolStripButton simpleThresholding;
        //        ToolStripTextBox threshold;
        //        ToolStripButton onlyR, onlyG, onlyB;
        //        StatusStrip statusStrip;
        //        ToolStripProgressBar progressBar;
        //    }
        //}
    }
}
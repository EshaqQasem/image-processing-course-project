using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImageProcessing
{
    public enum ColorDepthType { BINARY, RGB, GRAY }
    public class ProcessedImage
    {

        public ProcessedImage(IRGBImage image)
        {
           // PreProcessing += prep;
            this.Image = image;
            processImage = new ProcessImage(this.imageProcessingWith);

        }

        

        IRGBImage image;
        ProcessImage processImage;
        public ColorDepthType ImageType { set; get; }
        public IRGBImage Image
        {
            get { return image; }
            set { image = value; }
        }

        public void rgbToGray(Func<Color, byte> equation)
        {
            imageProcessing3((oldColor) =>
            {
                byte grayLevel = equation(oldColor);
                return Color.FromArgb(grayLevel, grayLevel, grayLevel);
            });
            ImageType = ColorDepthType.GRAY;
            // System.Windows.Forms.MessageBox.Show(";;");
        }

        public void grayToBinary(byte threshold)
        {
            if (ImageType != ColorDepthType.GRAY)
            {
                this.rgbToGray(color =>
                   (byte)(((byte)(0.299f * color.R + 0.587f * color.G + 0.114f * color.B)) < threshold ? 0 : 255)
                     );
            }
            else
            {
                imageProcessing3((oldColor) =>
                {
                    byte binaryValue = (byte)((oldColor.R < threshold) ? 0 : 255);// t=20  
                    return Color.FromArgb(binaryValue, binaryValue, binaryValue);
                });
            }
            ImageType = ColorDepthType.BINARY;

        }
        public void negitve()
        {
            imageProcessing3((oldColor) =>
            {

                return Color.FromArgb(255 - oldColor.R, 255 - oldColor.G, 255 - oldColor.B);

            });

        }

        public void clipY()
        {

            PreProcessing(Image);
            int n = Image.Height;
            for (int row = 0; row < n / 2; row++)
            {
                for (int col = 0; col < Image.Width; col++)
                {
                    Color temp = Image[col, row];
                    Image[col, row] = Image[col, n - 1 - row];
                    Image[col, n - 1 - row] = temp;
                }
                OnProcessing(0);
            }
            PostProcessing();
        }

        public void light()
        {
            imageProcessing3((oldColor) =>
                {

                    int r = oldColor.R - (int)((oldColor.R) * 0.1f);
                    int g = oldColor.G + (int)((oldColor.G) * 0.5f);
                    int b = oldColor.B + (int)((oldColor.B) * 0.5f);
                    return Color.FromArgb(r, g, b);
                }
             );
        }

        public void lightColor(float rate, Color color)
        {

            if (color == Color.Red)
            {
                imageProcessing3((oldColor) =>
        {
            int r = oldColor.R + (int)((255 - oldColor.R) * rate);//100 10 90 9 81 8 20 
            return Color.FromArgb(r, oldColor.G, oldColor.B);
        });
            }
            else if (color == Color.Green)
            {
                imageProcessing3((oldColor) =>
       {
           int g = oldColor.G + (int)((255 - oldColor.G
               ) * rate);//100 10 90 9 81 8 20 
           return Color.FromArgb(oldColor.R, g, oldColor.B);
       });
            }

            else if (color == Color.Blue)
            {
                imageProcessing3((oldColor) =>
       {
           int b = oldColor.B + (int)((255 - oldColor.B) * rate);//100 10 90 9 81 8 20 
           return Color.FromArgb(oldColor.R, oldColor.G, b);
       });
            }

        }
        public void light(float rate)
        {
            imageProcessing3((oldColor) =>
            {

                int r = oldColor.R - (int)((oldColor.R) * rate);//100 10 90 9 81 8 20 
                int g = oldColor.G - (int)((oldColor.G) * rate);
                int b = oldColor.B - (int)((oldColor.B) * rate);
                return Color.FromArgb(r, g, b);
            }
             );
        }

        public void filter(float[,] mask, int mSize)
        {

            int ms = (mSize - 1) / 2;
            processImage((img, y, x) =>
            {
                float newGrayLevel = 0;
                for (int i = 0; i < mSize; i++)
                {
                    for (int j = 0; j < mSize; j++)
                    {
                        newGrayLevel += (float)(img[x - (ms - j), y - (ms - i)].R) * (mask[i, j]);
                    }
                }
                //if (newGrayLevel < 0) newGrayLevel *= -1;

                //newGrayLevel =(int) scaleValue(0,4*255,0,255,newGrayLevel);
                if (newGrayLevel > 255) newGrayLevel = 255;
                if (newGrayLevel < 0) newGrayLevel = 0;

                img[x, y] = Color.FromArgb((int)newGrayLevel,(int) newGrayLevel, (int)newGrayLevel);
            }, ms);


        }
        
        private double scaleValue(double min,double max,double nmin,double nmax,double value)
        {
            double rate = (max - min) / (nmax - nmin);
            double nvalue =nmin+ (value - min) / rate;
            return nvalue;
        }

        public void filter2(float[,] mask, int width,int height=0)
        {
            //if (height == 0)
            //    height = width;
            //int ms = (mSize - 1) / 2;
            //processImage((img, y, x) =>
            //{
            //    byte newGrayLevel = 0;
            //    for (int i = 0; i < height; i++)
            //    {
            //        for (int j = 0; j < wi; j++)
            //        {
            //            newGrayLevel += (byte)(img[x - (ms - j), y - (ms - i)].R * mask[i, j]);
            //        }
            //    }
            //    img[x, y] = Color.FromArgb(newGrayLevel, newGrayLevel, newGrayLevel);
            //}, ms);


        }
        public void sharpFilter()
        {
            int mSize = 3;
            //float[,] mask = new float[,] { { 1 / 9f, 1 / 9f, 1 / 9f }, { 1 / 9f, 1 / 9f, 1 / 9f }, { 1 / 9f, 1 / 9f, 1 / 9f } };
            float[,] mask = new float[,] { { 1 , 1 , 1  }, { 1 , 1 , 1 }, { 1 , 1 , 1 } };
            int ms = (mSize - 1) / 2;
            processImage((img, y, x) =>
            {
                int newGrayLevel = 9* img[x,y].R;
                int sum = 0;
                for (int i = 0; i < mSize; i++)
                {
                    for (int j = 0; j < mSize; j++)
                    {
                        sum += (byte)(img[x - (ms - j), y - (ms - i)].R * mask[i, j]);
                    }
                }
                newGrayLevel -= sum;
                if (newGrayLevel > 255) newGrayLevel = 255;
                if (newGrayLevel < 0) newGrayLevel = 0;
                img[x, y] = Color.FromArgb(newGrayLevel, newGrayLevel, newGrayLevel);
            }, ms);


        }


        public void filter2(int[,] mask, int mSize)
        {
            
            int filterSum = (int)MyLibrary.Math.Sum(mask, mSize,v=>Math.Abs(v));
            int ms = (mSize - 1) / 2;
            processImage((img, y, x) =>
            {
                int newGrayLevel = 0;
                for (int i = 0; i < mSize; i++)
                {
                    for (int j = 0; j < mSize; j++)
                    {
                        newGrayLevel += (byte)(img[x - (ms - j), y - (ms - i)].R * mask[i, j]);
                    }
                }
                newGrayLevel =Math.Abs( newGrayLevel) ;
                byte ngl = (byte) newGrayLevel;
                img[x, y] = Color.FromArgb(ngl, ngl, ngl);
            }, ms);


        }

        public void medianFilter(int maskSize)
        {
            processImage((img, row, col) =>
            {
                List<byte> mask = new List<byte>();
                int ms = (maskSize - 1) / 2;
                for (int i = 0; i < maskSize * maskSize; i++)
                {
                    mask.Add(img[col - (ms - (i % maskSize)), row - (ms - (i / maskSize))].R);
                }
                byte newGrayLevel = median(mask);
                img[col, row] = Color.FromArgb(newGrayLevel, newGrayLevel, newGrayLevel);
            }, 1);

        }

        byte median(List<byte> arr)
        {
            arr.Sort();
            return arr[arr.Count / 2];
        }

        public void slatPepperNoise()
        {
            PreProcessing(Image);
            Random random = new Random();
            for (int i = 0; i < Image.Width; i++)
            {
                Image[random.Next(0, Image.Width - 1), random.Next(0, Image.Height - 1)] = new Color[] { Color.Black, Color.White }[random.Next(0, 2)];

            }
            PostProcessing();
        }

        public void onColor(Color c)
        {
            imageProcessing3((oldColor) =>
            {

                return Color.FromArgb((byte)(oldColor.R / 255.0f * c.R), (byte)(oldColor.G / 255.0f * c.G), (byte)(oldColor.B / 255.0f * c.B));
            });
        }

        public void rebortsTrans()
        {
            imageProcessing3((oc) =>
            {
                byte b = (byte)Math.Log(oc.R + 1, Math.E);
                return Color.FromArgb(b, b, b);
            });
            //this.filter(new float[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } }, 3);
            //imageProcessingWith((img,y,x)=>{
            //    byte b =(byte)
            //        Math.Max(Math.Max(
            //        Math.Max(Math.Abs(img[x - 1, y - 1].R - img[x + 1, y + 1].R), Math.Abs(img[x - 1, y].R - img[x + 1, y].R)),
            //       Math.Abs(img[x, y - 1].R - img[x, y + 1].R)), Math.Abs(img[x - 1, y].R - img[x + 1, y].R));
            //        //(byte) Math.Sqrt(Math.Pow(img[x, y].R - img[x - 1, y - 1].R, 2) + Math.Pow(img[x, y - 1].R - img[x - 1, y].R,2));
            //    img[x, y] = Color.FromArgb(b, b, b);
            //},1);
        }

        public delegate void proc();
        public Action<IRGBImage> PreProcessing;
        public proc PostProcessing;
        private Action<int> onProcessing;

        public Action<int> OnProcessing
        {
            get { return onProcessing; }
            set
            {
                onProcessing = value;
                if (onProcessing != null)
                {
                    processImage = imageProcessingWith;
                }
            }
        }
        private void imageProcessing3(Func<Color, Color> getNewColor)
        {
            imageProcessing((img, y, x) =>
            {
                img[x, y] = getNewColor(img[x, y]);
            });
        }
        private void imageProcessing0(Action<IRGBImage, int, int> action, int shift)
        {
            for (int y = shift; y < this.Image.Height - shift; y++)
            {
                for (int x = shift; x < this.Image.Width - shift; x++)
                {
                    action(this.Image, y, x);
                }

            }
        }

        private void fun(int y2, int shift, Action<IRGBImage, int, int> action)
        {
            for (int y = y2; y < y2 + 10; y++)
            {
                for (int x = shift; x < this.Image.Width - shift; x++)
                {
                    action(this.Image, y, x);
                }
                onProcessing(y);
            }
        }

        private void imageProcessingWithTh(Action<IRGBImage, int, int> action, int shift)
        {

            PreProcessing(this.Image);
            System.Threading.Thread[] th = new System.Threading.Thread[10];
            int tmp = this.Image.Height - 2 * shift;
            for (int i = 0; i < tmp / 10; i++)
            {
                th[i] = new System.Threading.Thread(() => fun(i * 10, shift, action));
                th[i].Start();
            }
            /* for (int y = shift; y < this.Image.Height - shift; y++)
             {
                 for (int x = shift; x < this.Image.Width - shift; x++)
                 {
                     action(this.Image, y, x);
                 }
                 onProcessing(y);
             }
             * */
            PostProcessing();
        }
        private void imageProcessingWith(Action<IRGBImage, int, int> action, int shift)
        {
            PreProcessing(this.Image);
            //IRGBImage img=new BitmapImage(Image.
            //   System.Threading.Thread[] th = new System.Threading.Thread[10];
            for (int y = shift; y < this.Image.Height - shift; y++)
            {
                for (int x = shift; x < this.Image.Width - shift; x++)
                {
                    action(this.Image, y, x);
                }
                onProcessing(y);
            }
            PostProcessing();
        }
        private void imageProcessing(Action<IRGBImage, int, int> action)
        {
            //System.Threading.Thread th = new System.Threading.Thread(()=> processImage(action, 0));
            //th.Start();
            processImage(action, 0);
        }

        delegate void ProcessImage(Action<IRGBImage, int, int> action, int shift);

        public void addImage(Image img)
        {
            Bitmap bitmap =(Bitmap) img;
            imageProcessing((im, y, x) => {
                if(y <= bitmap.Height && x<= bitmap.Width)
                im[x, y] = addColor(im[x, y], bitmap.GetPixel(x, y));         
            
            });
        }
        public static Color addColor(Color color1, Color color2)
        {
            int r, g, b;
            r = color1.R + color2.R;
            r = r / 2;
            if (r > 255) r = 255;
            g = color1.G + color2.G;
            if (g > 255) g = 255;
            b = color1.B + color2.B;
            if (b > 255) b = 255;
            return Color.FromArgb(r, r, r);
        }
    }
}

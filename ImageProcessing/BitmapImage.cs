using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImageProcessing
{
   public class BitmapImage : IRGBImage
    {

       public BitmapImage(Bitmap bitmap)
       {
           this.Bitmap = bitmap;
       }
        public Bitmap Bitmap { set; get; }
        //public byte this[int x, int y, Colors c]
        //{
        //    get
        //    {
        //        Color color= this.Bitmap.GetPixel(x, y);
        //        return new byte[] { color.R, color.G, color.B }[(int)c];
        //    }
        //    set
        //    {
        //        Color color= this.Bitmap.GetPixel(x, y);

        //        this.Bitmap.SetPixel(x, y, color);
        //    }
        //}

        public Color this[int x, int y]
        {
            get
            {
                return this.Bitmap.GetPixel(x, y);
                 
            }
            set
            {
                this.Bitmap.SetPixel(x, y,value);
            }
        }
        //public byte this[int x, int y]
        //{
        //    get
        //    {
        //        return this.Bitmap.GetPixel(x, y).R;
        //    }
        //    set
        //    {
        //        this.Bitmap.SetPixel(x, y, Color.FromArgb(value, value, value));
        //    }
        //}
       
        public int Height
        {
            get { return this.Bitmap.Height; }
        }
        public int Width
        {
            get { return this.Bitmap.Width; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImageProcessing
{
    class ByteImage:IRGBImage
    {
        byte[, ,] image;
        public ByteImage(System.IO.FileStream ims)
        {
            image = new byte[20, 20, 3];
        }
        public int Height
        {
            get { return 0; }
        }
        public int Width
        {
            get { return 0; }
        }
        public System.Drawing.Color this[int x, int y]
        {
            get
            {
              return  Color.FromArgb(image[x, y, 0], image[x, y, 1], image[x, y, 2]);
            }
            set
            {
                image[x, y, 0]=value.R;
                image[x, y, 1]=value.G;
                image[x, y, 2] = value.B;
            }
        }
    }
}

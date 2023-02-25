using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing
{
    public interface IImage
    {
        byte grayLevel(int x, int y);
        int Height {  get; }
        int Width {  get; }
    }

    public enum Colors{Red,Green,Blue}
    public interface IRGBImage
    {
        int Height { get; }
        int Width { get; }
        System.Drawing.Color this[int x, int y] { set; get; }
    }
}

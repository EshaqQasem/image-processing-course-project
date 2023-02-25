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
    public partial class filterForm : Form
    {
        public filterForm()
        {
            InitializeComponent();
             rows = 3;
             cols = 3;
           
            nbmMask.Show(rows, cols);
        }
        int rows;
        int cols;
        public Action<float [,],int> doMask;
        private void btnDoFilter_Click(object sender, EventArgs e)
        {
            float[,] mask = new float[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    mask[i, j] = (float) (((MyLibrary.Windows.Forms.NumberBox)nbmMask[i, j]).Number);
                }
            }
            doMask(mask,rows);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
             rows = (int)nbRows.Number;
             cols = (int)nbCols.Number;
             nbmMask.InitilazeText = this.nbStartValue.Text;
            nbmMask.Show(rows, cols);
        }
    }
}

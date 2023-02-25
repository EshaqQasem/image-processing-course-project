using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace ImageProcessing
{
    class ScrolledPanel:Panel
    {
        public ScrolledPanel()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            
            mainContainer = new Panel();
            mainContainer.BackColor = Color.Red;
            mainContainer.Size = new System.Drawing.Size(0, 0);
            mainContainer.Location = new Point(0, 0);
            mainContainer.AutoSize = true;
            mainContainer.AutoSizeMode = AutoSizeMode.GrowOnly;
            mainContainer.Resize += mainContainer_Resize;
            this.Controls.Add(mainContainer);
            hScrollBar = new HScrollBar();
            hScrollBar.Visible = false;
            hScrollBar.Scroll+=hScrollBar_Scroll;
            this.Controls.Add(hScrollBar);

            vScrollBar = new VScrollBar();
            vScrollBar.Visible = false;
            vScrollBar.Scroll += vScrollBar_Scroll;

            this.Controls.Add(vScrollBar);
        // this
           
        this.ControlAdded+=ScrolledPanel_ControlAdded;
        }

        void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            this.mainContainer.Top = -this.vScrollBar.Value;
        }

        private void hScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            this.mainContainer.Left = -this.hScrollBar.Value;
        }

       

     /*   public new  ControlCollection Controls
        {
            
            get { return this.mainContainer.Controls; }
        }
      * */
        private void ScrolledPanel_ControlAdded(object sender, ControlEventArgs e)
        {
           // foreach(Control c in this.Controls)
           if(e.Control != this.mainContainer && e.Control!= vScrollBar && e.Control != hScrollBar)
            this.mainContainer.Controls.Add(e.Control);
            
        }

        void mainContainer_Resize(object sender, EventArgs e)
        {
            if (mainContainer.Width > this.Width- (vScrollBar.Visible?vScrollBar.Width:0))
            {
                hScrollBar.Visible = true;
                
                hScrollBar.Maximum = this.mainContainer.Width - this.Width;
                hScrollBar.BringToFront();
            }
            else
            {
                hScrollBar.Visible = false;
            }

            if (mainContainer.Height > this.Height- (hScrollBar.Visible ? hScrollBar.Height : 0))
            {
               
                vScrollBar.Visible = true;
                vScrollBar.Maximum = this.mainContainer.Height - this.Height + (hScrollBar.Visible ? hScrollBar.Height : 0);
                vScrollBar.BringToFront();
            }
            else
            {
                vScrollBar.Visible = false;
            }
        }
        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            mainContainer_Resize(null,null);
            vScrollBar.Location = new Point(this.Width - vScrollBar.Width, 0);
            hScrollBar.Location = new Point(0, this.Height - hScrollBar.Height);
            hScrollBar.Width = this.Width;
            vScrollBar.Height = this.Height;
           
        }
        Panel mainContainer;
        HScrollBar hScrollBar;
        VScrollBar vScrollBar;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class MultiFormsTool : UserControl
    {
        public MultiFormsTool()
        {
            InitializeComponent();
            forms = new List<MultiFormsItem>();
            
        }

        public void AddForm(ImageContainerForm form)
        {
           
            MultiFormsItem item = new MultiFormsItem(form);
            this.panelHeader.Controls.Add(item.Header);
            item.onHeaderClick = ShowItem;
            form.FormClosed += (s,e)=> { CloseItem(item); };
            item.onClose = delegate { form.Close(); };
            ShowItem(item);
            Forms.Add(item);

        }

        private void CloseItem(MultiFormsItem sender)
        {

            RemoveForm(sender);
            //sender.Form.Close();
            if (Forms.Count != 0)
            {
                ShowItem(Forms[0]);
            }
           

        }
        private void RemoveForm(MultiFormsItem sender)
        {
            this.Forms.Remove(sender);
            this.panelHeader.Controls.Remove(sender.Header);
            this.panelFormContainer.Controls.Remove(sender.Form);
        }
        MultiFormsItem activeForm;

        public MultiFormsItem ActiveForm
        {
            get { return activeForm; }
            set { activeForm = value; }
        }
        void ShowItem(MultiFormsItem item)
        {
            if (item != activeForm)
            {
                if (activeForm != null)
                {
                    activeForm.Header.LoseFoucs();
                }
                activeForm = item;
                item.Form.FormBorderStyle = FormBorderStyle.None;
                item.Form.Dock = DockStyle.Fill;
                item.Form.TopLevel = false;
                panelFormContainer.Controls.Add(item.Form);
                item.Form.BringToFront();
                item.Form.Show();
            }
        }
        private List<MultiFormsItem> forms;

        public List<MultiFormsItem> Forms
        {
            get { return forms; }
            set { forms = value; }
        }

    }

   public class MultiFormsHeader : Panel
    {
        public MultiFormsHeader(Image img)
        {
            initComp(img);
        }

        private void initComp(Image img)
        {
            this.Dock = DockStyle.Right;
           // this.Width = this.Height;
            this.BackColor = Color.FromArgb(70, 70, 70);
            this.Padding =new Padding(0,3,0,3);
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            
            pcbIconTitle = new PictureBox();
            pcbIconTitle.Dock = DockStyle.Right;
            pcbIconTitle.SizeMode = PictureBoxSizeMode.Zoom;
            pcbIconTitle.Width = 50;
            pcbIconTitle.Image = img;

            pcbIconTitle.Click += (s, e) => { this.OnClick(e); };
            this.Controls.Add(pcbIconTitle);

            btnClose = new Button();
            btnClose.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClose.Image = global::ImageProcessing.Properties.Resources.icons8_close_window2_16;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Dock = DockStyle.Left;
            btnClose.Width = 20;
            this.Controls.Add(this.btnClose);
            this.Click += (s, e) => { this.Controls.Add(this.btnClose); this.BackColor = SystemColors.ControlDarkDark; };
            
        }
       public void LoseFoucs()
        {
            this.Controls.Remove(btnClose);
            this.BackColor = Color.FromArgb(70, 70, 70);
        }
        PictureBox pcbIconTitle;
      public  Button btnClose;
    }

   public class MultiFormsItem
    {
       public MultiFormsItem(ImageContainerForm form)
       {
           this.Form = form;
           header = new MultiFormsHeader(form.Image);
           this.Header.Click += (s, e) => { onHeaderClick(this); };
           this.header.btnClose.Click += (s, e) => { onClose(this); };
       }
       public void Close()
       {
           onClose(this);
       }
        ImageContainerForm form;

        public ImageContainerForm Form
        {
            get { return form; }
            set { form = value; }
        }
        MultiFormsHeader header;

        public MultiFormsHeader Header
        {
            get { return header; }
            set { header = value; }
        }

        public delegate void Event(MultiFormsItem sender);
        public Event onHeaderClick;
        public Event onClose;
        
    }
}

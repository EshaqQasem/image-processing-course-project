using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ImageProcessing
{
   partial class MainForm
    {
       private void Start()
       {
           initilizeMainForm();

           initilizeMainMenus();
           this.Controls.Add(mainMenu);

           selecetLabel = new Label();
           this.MouseDown += MainForm_MouseDown;
           this.MouseMove += MainForm_MouseMove;
           // this.MainMenuStrip = mainMenu;
       }

       private void initilizeMainForm()
       {
           this.BackColor = SystemColors.ControlDarkDark;
           this.Text = "برنامج للتعديل على الصور";
           this.Size = new Size(1000, 600);
           this.StartPosition = FormStartPosition.CenterScreen;
           this.RightToLeft = RightToLeft.Yes;
           this.RightToLeftLayout = true;
           //this.IsMdiContainer = true;
           this.BackColor = SystemColors.ControlDarkDark;

           OpenedForms = new MultiFormsTool();
           OpenedForms.Dock = DockStyle.Fill;

           this.Controls.Add(OpenedForms);

           rightSide = new Panel();
           rightSide.Width = 150;
           rightSide.Dock = DockStyle.Left;
           rightSide.BackColor = Color.FromArgb(30, 30, 30);
           this.Controls.Add(rightSide);

           LeftSide = new Panel();
           LeftSide.Width = 150;
           LeftSide.Dock = DockStyle.Right;
           LeftSide.BackColor = Color.FromArgb(30, 30, 30);
           this.Controls.Add(LeftSide);


       }

       private void initilizeMainMenus()
       {
           mainMenu = new MenuStrip();

           mainMenu.BackColor = SystemColors.ControlDarkDark;
           mainMenu.ForeColor = Color.White;
           fileMenuItem = new ToolStripMenuItem();
           fileMenuItem.Text = "ملف";
           newMenuItem = new ToolStripMenuItem();
           newMenuItem.Text = "جديد";
           newMenuItem.ShortcutKeys = Keys.Control | Keys.N;
           newMenuItem.Click += newMenuItem_Click;

           openMenuItem = new ToolStripMenuItem();
           openMenuItem.Text = "فتح صورة";
           openMenuItem.ShortcutKeys = Keys.Control | Keys.O;
           openMenuItem.Click += openMenuItem_Click;

           saveMenuItem = new ToolStripMenuItem();
           saveMenuItem.Text = "حفظ";
           saveMenuItem.ShortcutKeys = Keys.Control | Keys.S;
           saveMenuItem.Click += saveMenuItem_Click;
           saveAsMenuItem = new ToolStripMenuItem();
           saveAsMenuItem.Text = "حفظ باسم";

           closeMenuItem = new ToolStripMenuItem();
           closeMenuItem.Text = "اغلاق العمل الحالي";
           closeMenuItem.Click += closeMenuItem_Click;

           closeAllMenuItem = new ToolStripMenuItem();
           closeAllMenuItem.Text = "اغلاق كل الاعمال";
           closeAllMenuItem.Click += closeAllMenuItem_Click;
           exitMenuItem = new ToolStripMenuItem();
           exitMenuItem.Text = "الخروج من التبيق";
           fileMenuItem.DropDownItems.AddRange(new ToolStripItem[]{
            newMenuItem,openMenuItem,saveMenuItem,saveAsMenuItem
            ,closeMenuItem,closeAllMenuItem,exitMenuItem});

           editMenuItem = new ToolStripMenuItem();
           editMenuItem.Text = "تحرير";
           undoMenuItem = new ToolStripMenuItem();
           undoMenuItem.Text = "تراجع";
           undoMenuItem.Click += undoMenuItem_Click;
           undoMenuItem.ShortcutKeys = Keys.Control | Keys.Z;

           redoMenuItem = new ToolStripMenuItem();
           redoMenuItem.Text = "اعادة";
           redoMenuItem.Click += redoMenuItem_Click;
           redoMenuItem.ShortcutKeys = Keys.Control | Keys.Y;
           copyMenuItem = new ToolStripMenuItem();
           copyMenuItem.Text = "نسخ";
           copyMenuItem.ShortcutKeys = Keys.Control | Keys.C;
           cutMenuItem = new ToolStripMenuItem();
           cutMenuItem.Text = "قص";
           cutMenuItem.ShortcutKeys = Keys.Control | Keys.X;
           pasteMenuItem = new ToolStripMenuItem();
           pasteMenuItem.Text = "لصق";
           pasteMenuItem.ShortcutKeys = Keys.Control | Keys.V;

           grayImageMenuItem = new ToolStripMenuItem();
           grayImageMenuItem.Text = "رمادي";
           grayImageMenuItem.ShortcutKeys = Keys.Control | Keys.G;
           grayImageMenuItem.Click += grayImageMenuItem_Click;

           blackWhiteImageMenuItem = new ToolStripMenuItem();
           blackWhiteImageMenuItem.Text = "ابيض واسود";
           blackWhiteImageMenuItem.Click += blackWhiteImageMenuItem_Click;

           negitveColorMenuItem = new ToolStripMenuItem();
           negitveColorMenuItem.Text = "عكس الألوان";
           negitveColorMenuItem.ShortcutKeys = Keys.Control | Keys.P;
           negitveColorMenuItem.Click += negitveColorMenuItem_Click;

           lightImageMenuItem = new ToolStripMenuItem();
           lightImageMenuItem.Text = "اضاءة";
           lightImageMenuItem.ShortcutKeys = Keys.Control | Keys.L;
           lightImageMenuItem.Click += lightImageMenuItem_Click;

           nosieImageMenuItem = new ToolStripMenuItem();
           nosieImageMenuItem.Text = "ازعاج";
           nosieImageMenuItem.Click += nosieImageMenuItem_Click;

           clipYImageMenuItem = new ToolStripMenuItem();
           clipYImageMenuItem.Text = "قلب الصورة عموديا";
           clipYImageMenuItem.Click += clipYImageMenuItem_Click;

           editMenuItem.DropDownItems.AddRange(new ToolStripItem[]{
            undoMenuItem,redoMenuItem,cutMenuItem,cutMenuItem,pasteMenuItem
            ,grayImageMenuItem,blackWhiteImageMenuItem,negitveColorMenuItem
            ,nosieImageMenuItem,lightImageMenuItem,clipYImageMenuItem});



           windowMenuItem = new ToolStripMenuItem();
           windowMenuItem.Text = "النوافذ";
           horizintailOrderMenuItem = new ToolStripMenuItem();
           horizintailOrderMenuItem.Text = "";
           verticalOrderMenuItem = new ToolStripMenuItem();
           verticalOrderMenuItem.Text = "";
           cascadeOrderMenuItem = new ToolStripMenuItem();
           cascadeOrderMenuItem.Text = "";
           windowMenuItem.DropDownItems.AddRange(new ToolStripItem[]{
            horizintailOrderMenuItem,verticalOrderMenuItem,cascadeOrderMenuItem});

           filtersMenuItem = new ToolStripMenuItem();
           filtersMenuItem.Text = "الفلاتر";
           meanMenuItem = new ToolStripMenuItem();
           meanMenuItem.Text = "Mean Filter";
           meanMenuItem.Click += meanMenuItem_Click;

           medianMenuItem = new ToolStripMenuItem();
           medianMenuItem.Text = "Median Filter";
           medianMenuItem.Click += medianMenuItem_Click;
           colorDistr = new ToolStripMenuItem();
           colorDistr.Text = "الاحمر فقط";
           colorDistr.Click += colorDistr_Click;

           incrContrast = new ToolStripMenuItem();
           incrContrast.Text = "زيادة التباين";
           incrContrast.Click += incrContrast_Click;

           addMenuItem("Roberts Filter", filtersMenuItem, robertsMenuItem_Click);
           filtersMenuItem.DropDownItems.AddRange(new ToolStripItem[] { meanMenuItem, medianMenuItem, colorDistr, incrContrast });


           ToolStripMenuItem filterTmi = new ToolStripMenuItem() { Text = "فلتر" };
           filterTmi.Click += filterTmi_Click;
           mainMenu.Items.AddRange(new ToolStripItem[] { fileMenuItem, editMenuItem, windowMenuItem, filtersMenuItem,filterTmi });

          


           initToolStrip();
           addMenuItem("جمع صورتين",editMenuItem,addTwoImage);
       }


       
      
      

      
       public void addMenuItem(string text,ToolStripMenuItem submenu,EventHandler onclick)
       {
           ToolStripMenuItem item = new ToolStripMenuItem() { Text = text };
           item.Click += onclick;
           submenu.DropDownItems.Add(item);
       }

       private void initToolStrip()
       {
           this.toolStrip = new ToolStrip();
           this.toolStrip.BackColor = SystemColors.ControlDark;
           toolStrip.ForeColor = Color.White;
           this.Controls.Add(toolStrip);

           this.simpleThresholding = new ToolStripButton();
           this.simpleThresholding.Text = "STH";
           this.simpleThresholding.Click += simpleThresholding_Click;

           ToolStripButton sprate = new ToolStripButton();
           sprate.Text = "SPrate";
           sprate.Click += sprate_Click;
           this.threshold = new ToolStripTextBox();

           this.onlyB = new ToolStripButton();
           this.onlyB.Text = "BLUE";

           this.onlyB.Click +=
           (s, e) =>
           {
               onlyColor((c) => c.B);

           };
           this.onlyG = new ToolStripButton();
           this.onlyG.Text = "GREEN";
           this.onlyG.Click += delegate { onlyColor(c => c.G); };

           this.onlyR = new ToolStripButton();
           this.onlyR.Text = "RED";
           this.onlyR.Click += delegate { onlyColor(c => c.R); };
           this.toolStrip.Items.AddRange(new ToolStripItem[] { simpleThresholding, threshold, sprate, onlyB, onlyG, onlyR });

       }
       MenuStrip mainMenu;

       ToolStripMenuItem fileMenuItem;
       ToolStripMenuItem newMenuItem;
       ToolStripMenuItem openMenuItem;
       ToolStripMenuItem saveMenuItem;
       ToolStripMenuItem saveAsMenuItem;
       ToolStripMenuItem closeMenuItem;
       ToolStripMenuItem closeAllMenuItem;
       ToolStripMenuItem exitMenuItem;

       ToolStripMenuItem editMenuItem;
       ToolStripMenuItem undoMenuItem;
       ToolStripMenuItem redoMenuItem;
       ToolStripMenuItem cutMenuItem;
       ToolStripMenuItem copyMenuItem;
       ToolStripMenuItem pasteMenuItem;
       ToolStripMenuItem grayImageMenuItem;
       ToolStripMenuItem blackWhiteImageMenuItem;
       ToolStripMenuItem negitveColorMenuItem;
       ToolStripMenuItem nosieImageMenuItem;
       ToolStripMenuItem lightImageMenuItem;
       ToolStripMenuItem clipYImageMenuItem;

       ToolStripMenuItem windowMenuItem;
       ToolStripMenuItem verticalOrderMenuItem;
       ToolStripMenuItem horizintailOrderMenuItem;
       ToolStripMenuItem cascadeOrderMenuItem;

       ToolStripMenuItem filtersMenuItem;
       ToolStripMenuItem meanMenuItem;
       ToolStripMenuItem medianMenuItem;
       ToolStripMenuItem colorDistr;
       ToolStripMenuItem incrContrast;

       ToolStrip toolStrip;
       ToolStripButton simpleThresholding;
       ToolStripTextBox threshold;
       ToolStripButton onlyR, onlyG, onlyB;
        // StatusStrip statusStrip;
        //ToolStripProgressBar progressBar;
    }
}

namespace ImageProcessing
{
    partial class filterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnClose = new MyLibrary.Windows.Forms.CloseButton();
            this.btnDoFilter = new System.Windows.Forms.Button();
            this.nbRows = new MyLibrary.Windows.Forms.NumberBox();
            this.nbCols = new MyLibrary.Windows.Forms.NumberBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nbmMask = new MyLibrary.Windows.Forms.NumberBoxMatrix();
            this.nbStartValue = new MyLibrary.Windows.Forms.NumberBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.nbStartValue);
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnDoFilter);
            this.panel2.Controls.Add(this.nbRows);
            this.panel2.Controls.Add(this.nbCols);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(242, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(144, 318);
            this.panel2.TabIndex = 1;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(37, 173);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(79, 23);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "انشاء جديد";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(41, 268);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "اغلاق";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnDoFilter
            // 
            this.btnDoFilter.Location = new System.Drawing.Point(41, 218);
            this.btnDoFilter.Name = "btnDoFilter";
            this.btnDoFilter.Size = new System.Drawing.Size(75, 23);
            this.btnDoFilter.TabIndex = 2;
            this.btnDoFilter.Text = "تنفيذ";
            this.btnDoFilter.UseVisualStyleBackColor = true;
            this.btnDoFilter.Click += new System.EventHandler(this.btnDoFilter_Click);
            // 
            // nbRows
            // 
            this.nbRows.Location = new System.Drawing.Point(80, 71);
            this.nbRows.Name = "nbRows";
            this.nbRows.Number = 3D;
            this.nbRows.Size = new System.Drawing.Size(36, 20);
            this.nbRows.TabIndex = 1;
            this.nbRows.Text = "3";
            // 
            // nbCols
            // 
            this.nbCols.Location = new System.Drawing.Point(24, 71);
            this.nbCols.Name = "nbCols";
            this.nbCols.Number = 3D;
            this.nbCols.Size = new System.Drawing.Size(36, 20);
            this.nbCols.TabIndex = 1;
            this.nbCols.Text = "3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "الصفوف";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "الاعمدة";
            // 
            // nbmMask
            // 
            this.nbmMask.AutoScroll = true;
            this.nbmMask.ControlSize = new System.Drawing.Size(50, 20);
            this.nbmMask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nbmMask.HerizontalMargin = 10;
            this.nbmMask.InitilazeText = "0";
            this.nbmMask.LeftMargin = 10;
            this.nbmMask.Location = new System.Drawing.Point(0, 0);
            this.nbmMask.Name = "nbmMask";
            this.nbmMask.Size = new System.Drawing.Size(242, 318);
            this.nbmMask.TabIndex = 2;
            this.nbmMask.TopMargin = 10;
            this.nbmMask.VerticalMargin = 10;
            // 
            // numberBox1
            // 
            this.nbStartValue.Location = new System.Drawing.Point(24, 134);
            this.nbStartValue.Name = "numberBox1";
            this.nbStartValue.Size = new System.Drawing.Size(36, 20);
            this.nbStartValue.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "قيمة ابتدائية";
            // 
            // filterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 318);
            this.Controls.Add(this.nbmMask);
            this.Controls.Add(this.panel2);
            this.Name = "filterForm";
            this.Text = "filterForm";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDoFilter;
        private MyLibrary.Windows.Forms.NumberBox nbRows;
        private MyLibrary.Windows.Forms.NumberBox nbCols;
        private MyLibrary.Windows.Forms.CloseButton btnClose;
        private MyLibrary.Windows.Forms.NumberBoxMatrix nbmMask;
        private System.Windows.Forms.Button btnNew;
        private MyLibrary.Windows.Forms.NumberBox nbStartValue;
        private System.Windows.Forms.Label label3;
       
    }
}
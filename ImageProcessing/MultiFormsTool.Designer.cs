namespace ImageProcessing
{
    partial class MultiFormsTool
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelFormContainer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(748, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // panelFormContainer
            // 
            this.panelFormContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormContainer.Location = new System.Drawing.Point(0, 60);
            this.panelFormContainer.Name = "panelFormContainer";
            this.panelFormContainer.Size = new System.Drawing.Size(748, 234);
            this.panelFormContainer.TabIndex = 1;
            // 
            // MultiFormsTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.panelFormContainer);
            this.Controls.Add(this.panelHeader);
            this.Name = "MultiFormsTool";
            this.Size = new System.Drawing.Size(748, 294);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelFormContainer;
    }
}

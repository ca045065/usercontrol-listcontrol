namespace AccountFormsCtrlLib
{
    partial class ListControlView
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
            this.vScrollBarAdv1 = new DevComponents.DotNetBar.VScrollBarAdv();
            this.SuspendLayout();
            // 
            // vScrollBarAdv1
            // 
            this.vScrollBarAdv1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBarAdv1.Location = new System.Drawing.Point(259, 0);
            this.vScrollBarAdv1.Name = "vScrollBarAdv1";
            this.vScrollBarAdv1.Size = new System.Drawing.Size(20, 381);
            this.vScrollBarAdv1.TabIndex = 0;
            this.vScrollBarAdv1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBarAdv1_Scroll);
            // 
            // ListControlView
            // 
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Controls.Add(this.vScrollBarAdv1);
            //this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Name = "ListControlView";
            this.Size = new System.Drawing.Size(279, 381);
            this.Resize += new System.EventHandler(this.ListControlView_Resize);
            this.ResumeLayout(false);

        }

        void ListControlView_Resize(object sender, System.EventArgs e)
        {
            this.vScrollBarAdv1.Size = new System.Drawing.Size(this.vScrollBarAdv1.Size.Width, this.Size.Height);

            this.vScrollBarAdv1.Location = new System.Drawing.Point(Size.Width - vScrollBarAdv1.Size.Width, vScrollBarAdv1.Location.Y);
        }

        #endregion

        private DevComponents.DotNetBar.VScrollBarAdv vScrollBarAdv1;

    }
}

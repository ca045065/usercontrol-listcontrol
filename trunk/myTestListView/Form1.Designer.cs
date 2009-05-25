namespace myTestListView
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.listControlView1 = new AccountFormsCtrlLib.ListControlView();
            this.btRemove = new DevComponents.DotNetBar.ButtonX();
            this.contextMenuBar1 = new DevComponents.DotNetBar.ContextMenuBar();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.listViewEx1 = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.listControlView1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contextMenuBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(252, 33);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.TabIndex = 1;
            this.buttonX1.Text = "Add";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // listControlView1
            // 
            this.listControlView1.AddFromFirst = false;
            this.listControlView1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.listControlView1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("listControlView1.BackgroundImage")));
            this.listControlView1.Controls.Add(this.contextMenuBar1);
            this.listControlView1.Location = new System.Drawing.Point(12, 2);
            this.listControlView1.Name = "listControlView1";
            this.listControlView1.SelectIndex = -1;
            this.listControlView1.Size = new System.Drawing.Size(218, 360);
            this.listControlView1.TabIndex = 0;
            // 
            // btRemove
            // 
            this.btRemove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btRemove.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btRemove.Location = new System.Drawing.Point(252, 82);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(75, 23);
            this.btRemove.TabIndex = 3;
            this.btRemove.Text = "Remove";
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // contextMenuBar1
            // 
            this.contextMenuBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1});
            this.contextMenuBar1.Location = new System.Drawing.Point(49, 78);
            this.contextMenuBar1.Name = "contextMenuBar1";
            this.contextMenuBar1.Size = new System.Drawing.Size(75, 25);
            this.contextMenuBar1.Stretch = true;
            this.contextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.contextMenuBar1.TabIndex = 1;
            this.contextMenuBar1.TabStop = false;
            this.contextMenuBar1.Text = "contextMenuBar1";
            // 
            // buttonItem1
            // 
            this.buttonItem1.AutoExpandOnClick = true;
            this.buttonItem1.ImagePaddingHorizontal = 8;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem2});
            this.buttonItem1.Text = " 列表";
            // 
            // buttonItem2
            // 
            this.buttonItem2.ImagePaddingHorizontal = 8;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Text = "buttonItem2";
            this.buttonItem2.Click += new System.EventHandler(this.buttonItem2_Click);
            // 
            // listViewEx1
            // 
            // 
            // 
            // 
            this.listViewEx1.Border.Class = "ListViewBorder";
            this.listViewEx1.Location = new System.Drawing.Point(278, 156);
            this.listViewEx1.Name = "listViewEx1";
            this.listViewEx1.Size = new System.Drawing.Size(152, 98);
            this.listViewEx1.TabIndex = 4;
            this.listViewEx1.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 374);
            this.Controls.Add(this.listViewEx1);
            this.Controls.Add(this.btRemove);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.listControlView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.listControlView1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contextMenuBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AccountFormsCtrlLib.ListControlView listControlView1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX btRemove;
        private DevComponents.DotNetBar.ContextMenuBar contextMenuBar1;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.Controls.ListViewEx listViewEx1;


    }
}


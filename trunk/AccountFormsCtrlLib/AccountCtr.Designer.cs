namespace AccountFormsCtrlLib
{
    partial class AccountCtr
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
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                }
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
            //this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.UidLab = new DevComponents.DotNetBar.LabelX();
            this.AccountLab = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.UserName = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.lbGrade = new DevComponents.DotNetBar.LabelX();
            //this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.panelEx1.Controls.Add(this.lbGrade);
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.pictureBox1);
            this.panelEx1.Controls.Add(this.UidLab);
            this.panelEx1.Controls.Add(this.AccountLab);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.UserName);
            this.panelEx1.Controls.Add(this.labelX3);
//             this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
//             this.panelEx1.Enabled = false;
//             this.panelEx1.Location = new System.Drawing.Point(0, 0);
//             this.panelEx1.Margin = new System.Windows.Forms.Padding(0);
//             this.panelEx1.Name = "panelEx1";
//             this.panelEx1.Size = new System.Drawing.Size(196, 80);
//             this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
//             this.panelEx1.Style.BackColor1.Color = System.Drawing.SystemColors.ActiveCaptionText;
//             this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
//             this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
//             this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
//             this.panelEx1.Style.BorderWidth = 0;
//             this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
//             this.panelEx1.Style.GradientAngle = 90;
//             this.panelEx1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 50);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // UidLab
            // 
            this.UidLab.Enabled = false;
            this.UidLab.Location = new System.Drawing.Point(97, 20);
            this.UidLab.Name = "UidLab";
            this.UidLab.Size = new System.Drawing.Size(90, 23);
            this.UidLab.TabIndex = 6;
            this.UidLab.Text = "labelX4";
            // 
            // AccountLab
            // 
            this.AccountLab.Enabled = false;
            this.AccountLab.Location = new System.Drawing.Point(43, 54);
            this.AccountLab.Name = "AccountLab";
            this.AccountLab.Size = new System.Drawing.Size(147, 23);
            this.AccountLab.TabIndex = 5;
            this.AccountLab.Text = "labelX3";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.labelX2.Enabled = false;
            this.labelX2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(68, 22);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(37, 23);
            this.labelX2.TabIndex = 4;
            this.labelX2.Text = "ID：";
            // 
            // labelX1
            // 
            this.labelX1.Enabled = false;
            this.labelX1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(4, 57);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(44, 23);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "账号：";
            // 
            // UserName
            // 
            this.UserName.Enabled = false;
            this.UserName.Location = new System.Drawing.Point(90, 4);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(48, 23);
            this.UserName.TabIndex = 1;
            this.UserName.Text = "姓名";
            this.UserName.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX3
            // 
            this.labelX3.Enabled = false;
            this.labelX3.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.Location = new System.Drawing.Point(60, 4);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(45, 23);
            this.labelX3.TabIndex = 7;
            this.labelX3.Text = "姓名：";
            // 
            // labelX4
            // 
            this.labelX4.Enabled = false;
            this.labelX4.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX4.Location = new System.Drawing.Point(57, 40);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(46, 23);
            this.labelX4.TabIndex = 9;
            this.labelX4.Text = "等级：";
            // 
            // lbGrade
            // 
            this.lbGrade.Enabled = false;
            this.lbGrade.Location = new System.Drawing.Point(96, 37);
            this.lbGrade.Name = "lbGrade";
            this.lbGrade.Size = new System.Drawing.Size(75, 23);
            this.lbGrade.TabIndex = 10;
            this.lbGrade.Text = "labelX5";
            // 
            // AccountCtr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.Controls.Add(this.panelEx1);
//             this.Controls.Add(this.lbGrade);
//             this.Controls.Add(this.labelX4);
//             this.Controls.Add(this.pictureBox1);
//             this.Controls.Add(this.UidLab);
//             this.Controls.Add(this.AccountLab);
//             this.Controls.Add(this.labelX2);
//             this.Controls.Add(this.labelX1);
//             this.Controls.Add(this.UserName);
//             this.Controls.Add(this.labelX3);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "AccountCtr";
            this.Size = new System.Drawing.Size(196, 80);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        //private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX UserName;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX UidLab;
        private DevComponents.DotNetBar.LabelX AccountLab;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX lbGrade;

    }
}

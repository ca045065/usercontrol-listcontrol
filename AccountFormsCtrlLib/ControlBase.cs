using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Design;


namespace AccountFormsCtrlLib
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class ControlBase : System.Windows.Forms.UserControl
    {
        bool m_bSelected = false;

        public ControlBase()
        {
            InitializeComponent();
        }

        public bool Selected
        {
            get
            {
                return m_bSelected;
            }
        }

        internal void ShowBorderForSelect()
        {
            //this.AllowDrop = false;
            this.panelEx1.Style.BorderWidth = 2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.Color = System.Drawing.Color.RoyalBlue;
            this.panelEx1.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.All;
            m_bSelected = true;
        }

        internal void ShowBorderForDragOver(DevComponents.DotNetBar.eBorderSide eSide)
        {
            this.panelEx1.Style.BorderWidth = 2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.Color = System.Drawing.Color.Red;
            this.panelEx1.Style.BorderSide = eSide;
        }

        internal void ShowBorderForDragLeave()
        {
            this.panelEx1.Style.BorderWidth = 2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.None;
        }

        internal void DeleteBorderForNoSelect()
        {
            //this.AllowDrop = true;
            this.panelEx1.Style.BorderWidth = 1;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.None;
            m_bSelected = false;
        }
    }
}

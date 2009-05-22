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
    public partial class AccountCtr : /*DevComponents.DotNetBar.Office2007Form*/ControlBase
    {
        string m_strMyLoginMail = string.Empty;
        string m_strMyName = string.Empty;
        string m_strMyUid = string.Empty;
        int m_iIndex = 0;
        public AccountCtr(string strLoginMail, string strName, string strUid, int iGrade)
        {
            InitializeComponent();
            m_strMyLoginMail = strLoginMail;
            m_strMyName = strName;
            m_strMyUid = strUid;

            AccountLab.Text = m_strMyLoginMail;
            UidLab.Text = m_strMyUid;
            UserName.Text = m_strMyName;
            lbGrade.Text = iGrade.ToString();
            pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\1234.jpg");
        }

        public int Index
        {
            get
            {
                return m_iIndex;
            }
            
            set
            {
                m_iIndex = value;
            }
        }

        public string LoginMail
        {
            get
            {
                return m_strMyLoginMail;
            }
        }

        public void DisposeImage()
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
        }
    }
}

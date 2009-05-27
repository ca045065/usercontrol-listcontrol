using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AccountFormsCtrlLib;


namespace myTestListView
{
    public partial class AccountCtr : ControlBase
    {
        string m_strMyLoginMail = string.Empty;
        string m_strMyName = string.Empty;
        string m_strMyUid = string.Empty;
        int m_myGrade = 0;
        public AccountCtr(string strLoginMail, string strName, string strUid, int iGrade)
        {
            InitializeComponent();
            m_strMyLoginMail = strLoginMail;
            m_strMyName = strName;
            m_strMyUid = strUid;
            m_myGrade = iGrade;

            AccountLab.Text = m_strMyLoginMail;
            UidLab.Text = m_strMyUid;
            UserName.Text = m_strMyName;
            lbGrade.Text = m_myGrade.ToString();
        }

        public string LoginMail
        {
            get
            {
                return m_strMyLoginMail;
            }
            set
            {
                m_strMyLoginMail = value;
            }
        }

        public string MyName
        {
            get
            {
                return m_strMyName;
            }
            set
            {
                m_strMyName = value;
            }
        }

        public string MyUid
        {
            get
            {
                return m_strMyUid;
            }
            set
            {
                m_strMyUid = value;
            }
        }

        public int MyGrade
        {
            get
            {
                return m_myGrade;
            }
            set
            {
                m_myGrade = value;
            }
        }

        public void DisposeImage()
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
            string strFilePath = Application.StartupPath + @"\pic\" + MyUid + ".jpg";
            File.Delete(strFilePath);
        }

        public void ShowImage()
        {
            string strFilePath = Application.StartupPath + @"\pic\" + MyUid + ".jpg";
            if (File.Exists(strFilePath))
            {
                pictureBox1.Image = Image.FromFile(strFilePath);
            }
        }
    }
}

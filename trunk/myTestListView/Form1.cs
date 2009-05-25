using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AccountFormsCtrlLib;

namespace myTestListView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            AccountCtr myAccount = new AccountCtr("sfasdfas", "haah", "12342134", listControlView1.Count);
            myAccount.Name = "accountCtr" + listControlView1.Count;
            myAccount.Size = new System.Drawing.Size(300, 80);
            listControlView1.Add(myAccount);
            listControlView1.Focus();
            contextMenuBar1.SetContextMenuEx(listControlView1, buttonItem1);
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            listControlView1.RemoveAt(listControlView1.SelectIndex);
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            contextMenuBar1.SetContextMenuEx(listControlView1, buttonItem1);
            //listControlView1.ContextMenu;
        }
    }
}

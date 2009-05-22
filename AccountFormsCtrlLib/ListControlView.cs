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
    public partial class ListControlView : UserControl
    {
        private int TotalControlHeight = 0;
        private int initilzeControlNum = 0;

        private int selectIndex = -1;
        private int lastSelectIndex = -1;
        public EventHandler SelectIndexChanged;

        private List<int> IndexVisibleList = new List<int>();

        private int LastWheelValue = -1;

        private int LastScrollValue = 0;

        private bool AutoScroll = true;

        private bool bAddFromFirstorEnd = false;

        public int ScrollBarHeight = 0;

        private int LastDragY = 0;

        ControlBase lastDragOver;

        private int DragIndex = 0;

        public bool AddFromFirst
        {
            get
            {
                return bAddFromFirstorEnd;
            }
            set
            {
                bAddFromFirstorEnd = value;
            }
        }

        public bool AddFromEnd
        {
            get
            {
                return !bAddFromFirstorEnd;
            }
            set
            {
                bAddFromFirstorEnd = !value;
            }
        }

        public ListControlView()
        {
            InitializeComponent();
            vScrollBarAdv1.Maximum = 10;
            vScrollBarAdv1.Minimum = 0;
            ScrollBarHeight = vScrollBarAdv1.Maximum - 9;
            vScrollBarAdv1.Value = ScrollBarHeight;
            initilzeControlNum = Controls.Count;
            vScrollBarAdv1.Enabled = false;
            LastScrollValue = 0;

            this.vScrollBarAdv1.Minimum = 0;
            this.vScrollBarAdv1.Maximum = 80;
            this.vScrollBarAdv1.LargeChange = 80;
            this.vScrollBarAdv1.SmallChange = 20;
            this.vScrollBarAdv1.Focus();
        }

        public int Count
        {
            get
            {
                return Controls.Count - initilzeControlNum;
            }
        }

        public int SelectIndex
        {
            get
            {
                return selectIndex;
            }

            set
            {
                lastSelectIndex = selectIndex;
                selectIndex = value;
                OnSelectIndexChanged();
            }
        }

        private int FactSelectIndex
        {
            get
            {
                return (initilzeControlNum + selectIndex);
            }
            set
            {
                lastSelectIndex = selectIndex;
                selectIndex = value - initilzeControlNum;
                OnSelectIndexChanged();
            }
        }

        private int FactLastSelectIndex
        {
            get
            {
                return (initilzeControlNum + lastSelectIndex);
            }
        }

        private void OnSelectIndexChanged() 
        {
            DoSelectAction();
            if(SelectIndexChanged != null)
            {
                SelectIndexChanged(this,null);
            }
        } 

        public void DoSelectAction()
        {
            if (lastSelectIndex >= 0)
            {
                ((ControlBase)Controls[FactLastSelectIndex]).DeleteBorderForNoSelect();
            }

            if (selectIndex >= 0)
            {
                ((ControlBase)Controls[FactSelectIndex]).ShowBorderForSelect();
            }
        }

        public void Add(ControlBase value)
        {
            value.AllowDrop = true;
            value.MouseDown += new MouseEventHandler(this.Controls_MouseDown);
            value.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.Controls_QueryContinueDrag);
            value.DragOver += new System.Windows.Forms.DragEventHandler(this.Controls_DragOver);
            value.DragLeave += new EventHandler(Controls_DragLeave);
            value.DragDrop += new DragEventHandler(Controls_DragDrop);
            Controls.Add(value);
            FactSelectIndex = Controls.Count - 1;

            TotalControlHeight += value.Size.Height;
            LastWheelValue = -1;
            //vScrollBarAdv1.Maximum = TotalControlHeight;

            if (AddFromFirst)
            {
                PlaceAddFromFirst(value);
            }
            else
            {
                PlaceAddFromEnd(value);
            }
        }

        void Controls_DragDrop(object sender, DragEventArgs e)
        {

        }

        void Controls_DragLeave(object sender, EventArgs e)
        {
            Console.Write("Controls_DragLeave\n");
            if((ControlBase)Controls[FactSelectIndex] != ((ControlBase)sender))
            {
                ((ControlBase)sender).ShowBorderForDragLeave();
            }
        }

        void Controls_DragOver(object sender, DragEventArgs e)
        {
            Console.Write("Controls_DragOver\n");
            ControlBase myCtrl = (ControlBase)sender;
            ControlBase myDragCtrl = (ControlBase)Controls[FactSelectIndex];



            if (myCtrl != myDragCtrl)
            {
                if (LastDragY < e.Y)
                {
                    ((ControlBase)sender).ShowBorderForDragOver(DevComponents.DotNetBar.eBorderSide.Bottom);
                }
                else if (LastDragY > e.Y)
                {
                    ((ControlBase)sender).ShowBorderForDragOver(DevComponents.DotNetBar.eBorderSide.Top);
                }
            }

            LastDragY = e.Y;
            lastDragOver = myCtrl;
        }

        void Controls_MouseDown(object sender, MouseEventArgs e)
        {
            Console.Write("Controls_MouseDown\n");
            foreach (int Index in IndexVisibleList)
            {
                if (Controls[Index] == (Control)sender)
                {
                    FactSelectIndex = Index;
                    break;
                }
            }
            lastDragOver = ((ControlBase)sender);
            ((ControlBase)sender).DoDragDrop("", DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void Controls_QueryContinueDrag(object sender, System.Windows.Forms.QueryContinueDragEventArgs e)
        {
            Console.Write("Controls_QueryContinueDrag\n");
            if (e.Action == DragAction.Continue)
            {
                Console.Write("Continue\n");
                if ((lastDragOver.Location.Y <= 0) & (vScrollBarAdv1.Value > 0))
                {
                    vScrollBarAdv1.Value -= 1;
                    DoScrollAction();
                }
                else if ((lastDragOver.Location.Y + lastDragOver.Size.Height >= vScrollBarAdv1.ClientSize.Height)
                    && (vScrollBarAdv1.Value < (vScrollBarAdv1.Maximum - vScrollBarAdv1.LargeChange + 1)))
                {
                    vScrollBarAdv1.Value += 1;
                    DoScrollAction();
                }
            }

            if (e.EscapePressed)
            {
                e.Action = DragAction.Cancel;
            }
        }

        public void InsertAt(int Index, ControlBase value)
        {
        }

        public void Remove(ControlBase value)
        {
            Controls.Remove(value);

            TotalControlHeight -= value.Size.Height;
            PlaceRemove(value);
        }

        public void RemoveAt(int Index)
        {

        }

        public bool ExChangeControl(int itemIndex1, int itemIndex2)
        {
            if ((itemIndex1 < 0) || (itemIndex1 >= Controls.Count))
            {
                return false;
            }

            if ((itemIndex2 < 0) || (itemIndex2 >= Controls.Count))
            {
                return false;
            }

            return true;
        }

        private void DisableControl(Control value)
        {
            value.Visible = false;
        }

        private void EnableControl(Control value)
        {
            value.Visible = true;
        }

        private void PlaceAddFromFirst(ControlBase value)
        {
            if (TotalControlHeight > Size.Height)
            {
                vScrollBarAdv1.Value = vScrollBarAdv1.Minimum;
                vScrollBarAdv1.Enabled = true;
            }
            IndexVisibleList.Clear();
            int currentHeigth = 0;

            for (int i = initilzeControlNum; i < Controls.Count; ++i)
            {
                if (currentHeigth < Size.Height)
                {
                    IndexVisibleList.Insert(0, i);
                    EnableControl(Controls[i]);
                    Controls[i].Location = new Point(1, currentHeigth);
                    currentHeigth += Controls[i].Size.Height;
                }
                else
                {
                    DisableControl(Controls[i]);
                }
            }
            Update();
        }

        private void PlaceAddFromEnd(ControlBase value)
        {
            IndexVisibleList.Clear();

            if (TotalControlHeight > Size.Height)
            {
                //vScrollBarAdv1.Value = ScrollBarHeight;
                vScrollBarAdv1.Enabled = true;
                int currentHeigth = 0;

                for (int i = Controls.Count - 1; i >= initilzeControlNum; --i)
                {
                    if (currentHeigth < Size.Height)
                    {
                        IndexVisibleList.Insert(0, i);
                        EnableControl(Controls[i]);
                        Controls[i].Location = new Point(1, Size.Height - currentHeigth - Controls[i].Size.Height);
                        currentHeigth += Controls[i].Size.Height;
                    }
                    else
                    {
                        DisableControl(Controls[i]);
                    }
                }
                this.vScrollBarAdv1.Maximum = (int)((double)(TotalControlHeight * vScrollBarAdv1.LargeChange) / (double)vScrollBarAdv1.ClientSize.Height);
                this.vScrollBarAdv1.Value = vScrollBarAdv1.Maximum - vScrollBarAdv1.LargeChange + 1;

            }
            else
            {
                vScrollBarAdv1.Enabled = false;
                int currentHeigth = 0;

                for (int i = initilzeControlNum; i < Controls.Count; ++i)
                {
                    if (currentHeigth < Size.Height)
                    {
                        IndexVisibleList.Add(i);
                        EnableControl(Controls[i]);
                        Controls[i].Location = new Point(1, currentHeigth);
                        currentHeigth += Controls[i].Size.Height;
                    }
                    else
                    {
                        DisableControl(Controls[i]);
                    }
                }
             }
            Update();
        }
 
        void vScrollBarAdv1_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            DoScrollAction();
            return;
        }

        void DoScrollAction()
        {
            this.Cursor = System.Windows.Forms.Cursors.NoMoveVert;
            int wheelValue = vScrollBarAdv1.Value;

            int k = (int)(((double)(TotalControlHeight - this.vScrollBarAdv1.ClientSize.Height) / (double)(this.vScrollBarAdv1.Maximum - this.vScrollBarAdv1.LargeChange + 1)) * wheelValue);

            int position = k;
            int currentHeight = 0;
            int lastControlHeight = 0;
            int startWh = -1;
            IndexVisibleList.Clear();
            for (int i = initilzeControlNum; i < Controls.Count; ++i )
            {
                Control myCtl = Controls[i];
                EnableControl(myCtl);
                currentHeight += myCtl.Size.Height;
                if ((currentHeight >= position) && ((currentHeight - myCtl.Size.Height) <= (position + this.vScrollBarAdv1.ClientSize.Height)))
                {
                    IndexVisibleList.Add(i);
                    //myCtl.Visible = true;
                    EnableControl(myCtl);
                    if (startWh == -1)
                    {
                        startWh = currentHeight - myCtl.Size.Height - position;
                        myCtl.Location = new Point(1, startWh);
                    }
                    else
                    {
                        myCtl.Location = new Point(1, startWh);

                    }
                    startWh += myCtl.Size.Height;
                }
                else
                {
                    DisableControl(myCtl);
                }
            }
            Update();
        }

        private void PlaceRemove(ControlBase value)
        {

        }

    }
}

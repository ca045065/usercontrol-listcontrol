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
        List<ControlBase> m_myControls;

        private int TotalControlHeight = 0;
        private int initilzeControlNum = 0;

        private int selectIndex = -1;
        private int lastSelectIndex = -1;
        public event System.EventHandler SelectedIndexChanged;
        public event System.EventHandler DragDrop;

        private List<int> IndexVisibleList = new List<int>();

        private int LastWheelValue = -1;

        private int LastScrollValue = 0;

        private bool AutoScroll = true;

        private bool bAddFromFirstorEnd = true;

        private int LastDragY = 0;

        ControlBase lastDragOver;

        private int DragIndex = 0;

        public List<ControlBase> ListControls
        {
            get
            {
                return m_myControls;
            }
        }

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

        public ListControlView()
        {
            InitializeComponent();
            m_myControls = new List<ControlBase>();
            initilzeControlNum = Controls.Count;
            vScrollBarAdv1.Enabled = false;
            LastScrollValue = 0;

            this.vScrollBarAdv1.Minimum = 0;
            this.vScrollBarAdv1.Maximum = 0;
            this.vScrollBarAdv1.LargeChange = 80;
            this.vScrollBarAdv1.SmallChange = 20;
            this.vScrollBarAdv1.Focus();
        }

        public int Count
        {
            get
            {
                return ListControls.Count;
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

        private int LastSelectIndex
        {
            get
            {
                return lastSelectIndex;
            }
        }

        private void OnSelectIndexChanged() 
        {
            DoSelectAction();
            if (SelectedIndexChanged != null)
            {
                if ((SelectIndex >= 0) && (SelectIndex < ListControls.Count))
                {
                    SelectedIndexChanged(ListControls[selectIndex], null);
                }
            }
        }

        private void OnDragDrop()
        {
            if (DragDrop != null)
            {
                DragDrop(ListControls[selectIndex], null);
            }
        }

        public void DoSelectAction()
        {
            if ((LastSelectIndex >= 0) && (LastSelectIndex < ListControls.Count))
            {
                ListControls[LastSelectIndex].DeleteBorderForNoSelect();
            }

            if ((SelectIndex >= 0) && (SelectIndex < ListControls.Count))
            {
                ListControls[SelectIndex].ShowBorderForSelect();
            }
        }

        public void Add(ControlBase value)
        {
            //value.Enabled = false;
            value.Size = new Size(this.Size.Width - this.vScrollBarAdv1.Width - 2, 80);
            value.AllowDrop = true;
            value.MouseDown += new MouseEventHandler(this.Controls_MouseDown);
            value.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.Controls_QueryContinueDrag);
            value.DragOver += new System.Windows.Forms.DragEventHandler(this.Controls_DragOver);
            value.DragLeave += new EventHandler(Controls_DragLeave);
            value.DragDrop += new DragEventHandler(Controls_DragDrop);
            Controls.Add(value);

            TotalControlHeight += value.Size.Height;
            LastWheelValue = -1;

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
            Console.Write("Controls_DragDrop\n");
            int iCnt = 0;
            ControlBase SelectControl = ListControls[SelectIndex];
            if (SelectIndex > DragIndex)
            {
                for (iCnt = SelectIndex - 1; iCnt >= DragIndex; --iCnt)
                {
                    ListControls[iCnt].Location = new Point(1, ListControls[iCnt].Location.Y + SelectControl.Size.Height);
                    ListControls[iCnt + 1] = ListControls[iCnt];
                }
                ListControls[DragIndex] = SelectControl;
                SelectIndex = DragIndex;
            }
            else if (SelectIndex < DragIndex)
            {
                for (iCnt = SelectIndex + 1; iCnt <= DragIndex; ++iCnt)
                {
                    ListControls[iCnt].Location = new Point(1, ListControls[iCnt].Location.Y - SelectControl.Size.Height);
                    ListControls[iCnt - 1] = ListControls[iCnt];
                }
                ListControls[DragIndex] = SelectControl;
                SelectIndex = DragIndex;
            }
            else {

            }
        }

        void Controls_DragLeave(object sender, EventArgs e)
        {
            Console.Write("Controls_DragLeave\n");
            if(ListControls[SelectIndex] != ((ControlBase)sender))
            {
                ((ControlBase)sender).ShowBorderForDragLeave();
            }
        }

        void Controls_DragOver(object sender, DragEventArgs e)
        {
            Console.Write("Controls_DragOver\n");
            ControlBase myCtrl = (ControlBase)sender;
            ControlBase myDragCtrl = ListControls[SelectIndex];

            DragIndex = ListControls.IndexOf(myCtrl);

            if (myCtrl != myDragCtrl)
            {
                if (LastDragY < e.Y)
                {
                    ((ControlBase)sender).ShowBorderForDragOver(DevComponents.DotNetBar.eBorderSide.Bottom);
                    ++DragIndex;
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
                if (ListControls[Index] == (ControlBase)sender)
                {
                    SelectIndex = Index;
                    break;
                }
            }
            DragIndex = SelectIndex;
            lastDragOver = ((ControlBase)sender);
            if (this.ContextMenu != null)
            {
                this.ContextMenu.Show(lastDragOver, e.Location);
            }
            if (e.Button == MouseButtons.Left)
            {
                ((ControlBase)sender).DoDragDrop("", DragDropEffects.Copy | DragDropEffects.None);
            }

            this.Cursor = System.Windows.Forms.Cursors.Default;
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
                    this.Cursor = System.Windows.Forms.Cursors.NoMoveVert;
                    DoScrollAction();
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                }
                else if ((lastDragOver.Location.Y + lastDragOver.Size.Height >= vScrollBarAdv1.ClientSize.Height)
                    && (vScrollBarAdv1.Value < (vScrollBarAdv1.Maximum - vScrollBarAdv1.LargeChange + 1)))
                {
                    vScrollBarAdv1.Value += 1;
                    this.Cursor = System.Windows.Forms.Cursors.NoMoveVert;
                    DoScrollAction();
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                }
            }
            else if (e.Action == DragAction.Drop)
            {
                int iCnt = 0;
                ControlBase SelectControl = ListControls[SelectIndex];
                Point DragPoint = ListControls[DragIndex].Location;
                if (SelectIndex > DragIndex)
                {
                    
                    for (iCnt = SelectIndex - 1; iCnt >= DragIndex; --iCnt)
                    {
                        if (ListControls[iCnt].Visible == true)
                        {
                            ListControls[iCnt].Location = new Point(1, ListControls[iCnt].Location.Y + SelectControl.Size.Height);

                        }
                        ListControls[iCnt + 1] = ListControls[iCnt];
                    }
                    SelectControl.Location = DragPoint;
                    EnableControl(SelectControl);
                    ListControls[DragIndex] = SelectControl;
                    SelectIndex = DragIndex;
                    OnDragDrop();
                }
                else if (SelectIndex < DragIndex)
                {
                    for (iCnt = SelectIndex + 1; iCnt <= DragIndex; ++iCnt)
                    {
                        if (ListControls[iCnt].Visible == true)
                        {
                            ListControls[iCnt].Location = new Point(1, ListControls[iCnt].Location.Y - SelectControl.Size.Height);
                        }
                        ListControls[iCnt - 1] = ListControls[iCnt];
                    }
                    SelectControl.Location = DragPoint;
                    EnableControl(SelectControl);
                    ListControls[DragIndex] = SelectControl;
                    SelectIndex = DragIndex;
                    OnDragDrop();
                }
                else
                {

                }
            }
            else 
            {

            }
            this.Cursor = System.Windows.Forms.Cursors.Default;
            Update();
            if (e.EscapePressed)
            {
                e.Action = DragAction.Cancel;
            }
        }

//         public void InsertAt(int Index, ControlBase value)
//         {
//         }

        public void Remove(ControlBase value)
        {
            int index = ListControls.IndexOf(value);
            RemoveAt(index);
        }

        public void RemoveAt(int Index)
        {
            if ((Index < 0) || (Index >= ListControls.Count))
            {
                return;
            }
            int lastTotalHeight = TotalControlHeight;
            TotalControlHeight -= ListControls[Index].Size.Height;
            if (TotalControlHeight < vScrollBarAdv1.ClientSize.Height)
            {
                this.vScrollBarAdv1.Maximum = 0;
                this.vScrollBarAdv1.Value = 0;
                vScrollBarAdv1.Enabled = false;
            }
            else
            {
                int lastMax = this.vScrollBarAdv1.Maximum;
                int lastValue = this.vScrollBarAdv1.Value;

                int lastheightdiff = lastTotalHeight - this.vScrollBarAdv1.ClientSize.Height;
                int heightdiff = TotalControlHeight - this.vScrollBarAdv1.ClientSize.Height;

                int lastvalueMax = lastMax - this.vScrollBarAdv1.LargeChange + 1;

                int currentMax = (int)((double)(TotalControlHeight * vScrollBarAdv1.LargeChange) / (double)vScrollBarAdv1.ClientSize.Height);

                int valueMax = currentMax - this.vScrollBarAdv1.LargeChange + 1;

                int currentvalue = (int)((double)(lastheightdiff * valueMax * lastValue) / (lastvalueMax * heightdiff));

                this.vScrollBarAdv1.Maximum = currentMax;

                if (this.vScrollBarAdv1.Value <= 0)
                {
                    this.vScrollBarAdv1.Value = 1;
                }
                else if (this.vScrollBarAdv1.Value > valueMax)
                {
                    this.vScrollBarAdv1.Value = valueMax;
                }
                else
                {
                    this.vScrollBarAdv1.Value = currentvalue;
                }


            }

            ListControls[Index].MouseDown -= new MouseEventHandler(this.Controls_MouseDown);
            ListControls[Index].QueryContinueDrag -= new System.Windows.Forms.QueryContinueDragEventHandler(this.Controls_QueryContinueDrag);
            ListControls[Index].DragOver -= new System.Windows.Forms.DragEventHandler(this.Controls_DragOver);
            ListControls[Index].DragLeave -= new EventHandler(Controls_DragLeave);
            ListControls[Index].DragDrop -= new DragEventHandler(Controls_DragDrop);

            Controls.Remove(ListControls[Index]);
            ListControls.RemoveAt(Index);

            DoScrollAction();

            if (SelectIndex >= ListControls.Count)
            {
                SelectIndex = ListControls.Count - 1;
            }
            else if (SelectIndex < 0)
            {
                SelectIndex = 0;
            }
            else
            {
                SelectIndex = SelectIndex;
            }
            Update();
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
            int currentHeigth = value.Size.Height;

            for (int i = 0; i < ListControls.Count; ++i)
            {
                if (currentHeigth < Size.Height)
                {
                    IndexVisibleList.Add(i + 1);
                    EnableControl(ListControls[i]);
                    ListControls[i].Location = new Point(1, currentHeigth);
                    currentHeigth += ListControls[i].Size.Height;
                }
                else
                {
                    DisableControl(ListControls[i]);
                }
            }

            value.Location = new Point(1, 0);
            EnableControl(value);
            ListControls.Insert(0, value);
            IndexVisibleList.Insert(0, 0);

            if (TotalControlHeight > Size.Height)
            {
                this.vScrollBarAdv1.Maximum = (int)((double)(TotalControlHeight * vScrollBarAdv1.LargeChange) / (double)vScrollBarAdv1.ClientSize.Height);
                this.vScrollBarAdv1.Value = 1;
            }
            selectIndex = SelectIndex + 1;
            SelectIndex = 0;
            vScrollBarAdv1.Update();
            Update();
        }

        private void PlaceAddFromEnd(ControlBase value)
        {
            IndexVisibleList.Clear();
            ListControls.Add(value);

            if (TotalControlHeight > Size.Height)
            {
                vScrollBarAdv1.Enabled = true;
                int currentHeigth = 0;

                for (int i = ListControls.Count - 1; i >= 0; --i)
                {
                    if (currentHeigth < Size.Height)
                    {
                        IndexVisibleList.Insert(0, i);
                        EnableControl(ListControls[i]);
                        ListControls[i].Location = new Point(1, Size.Height - currentHeigth - ListControls[i].Size.Height);
                        currentHeigth += ListControls[i].Size.Height;
                    }
                    else
                    {
                        DisableControl(ListControls[i]);
                    }
                }
                this.vScrollBarAdv1.Maximum = (int)((double)(TotalControlHeight * vScrollBarAdv1.LargeChange) / (double)vScrollBarAdv1.ClientSize.Height);
                this.vScrollBarAdv1.Value = vScrollBarAdv1.Maximum - vScrollBarAdv1.LargeChange + 1;
            }
            else
            {
                vScrollBarAdv1.Enabled = false;
                int currentHeigth = 0;

                for (int i = 0; i < ListControls.Count; ++i)
                {
                    if (currentHeigth < Size.Height)
                    {
                        IndexVisibleList.Add(i);
                        EnableControl(ListControls[i]);
                        ListControls[i].Location = new Point(1, currentHeigth);
                        currentHeigth += ListControls[i].Size.Height;
                    }
                    else
                    {
                        DisableControl(ListControls[i]);
                    }
                }
             }
            SelectIndex = ListControls.Count - 1;
            Update();
        }
 
        void vScrollBarAdv1_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            DoScrollAction();
            return;
        }

        void DoScrollAction()
        {
            //this.vScrollBarAdv1.Cursor = System.Windows.Forms.Cursors.NoMoveVert;
            int wheelValue = vScrollBarAdv1.Value;

            int k = 0;

            if (TotalControlHeight > this.vScrollBarAdv1.ClientSize.Height)
            {
                k = (int)(((double)(TotalControlHeight - this.vScrollBarAdv1.ClientSize.Height) / (double)(this.vScrollBarAdv1.Maximum - this.vScrollBarAdv1.LargeChange + 1)) * wheelValue);
            }

            int position = k;
            int currentHeight = 0;
            int lastControlHeight = 0;
            int startWh = -1;
            IndexVisibleList.Clear();
            for (int i = 0; i < ListControls.Count; ++i)
            {
                Control myCtl = ListControls[i];
                EnableControl(myCtl);
                currentHeight += myCtl.Size.Height;
                if ((currentHeight >= position) && ((currentHeight - myCtl.Size.Height) <= (position + this.vScrollBarAdv1.ClientSize.Height)))
                {
                    IndexVisibleList.Add(i);
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

//         private void PlaceRemove(ControlBase value)
//         {
//         }

        public void ScrollToIndex(int iIndex)
        {
            if ((iIndex < 0) || (iIndex >= ListControls.Count))
            {
                return;
            }

            if (TotalControlHeight <= vScrollBarAdv1.ClientSize.Height)
            {
                vScrollBarAdv1.Value = 0;
                DoScrollAction();
                return;
            }

            int CurrentIndexHeight = 0;

            for(int iCnt = 0; iCnt <iIndex; ++iCnt)
            {
                CurrentIndexHeight += ListControls[iCnt].Height;
            }

            if ((TotalControlHeight - CurrentIndexHeight) <= vScrollBarAdv1.ClientSize.Height)
            {
                vScrollBarAdv1.Value = vScrollBarAdv1.Maximum - vScrollBarAdv1.LargeChange + 1;
                DoScrollAction();
                return;
            }

            vScrollBarAdv1.Value = (int)(((double)(vScrollBarAdv1.Maximum - vScrollBarAdv1.LargeChange + 1) / (TotalControlHeight - vScrollBarAdv1.ClientSize.Height)) * CurrentIndexHeight);
            DoScrollAction();
        }

    }
}

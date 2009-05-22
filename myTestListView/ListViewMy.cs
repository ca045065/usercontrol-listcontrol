using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace myTestListView
{
    public partial class ListViewMy : Component
    {
        public ListViewMy()
        {
            InitializeComponent();
        }

        public ListViewMy(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}

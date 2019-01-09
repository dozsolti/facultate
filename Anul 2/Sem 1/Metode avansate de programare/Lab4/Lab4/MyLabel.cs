using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public class MyLabel: Label
    {
        public bool isfree;
        public MyLabel(): base() {
            isfree = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Display : UserControl
    {
        Adrese a;
        public Display(Adrese a)
        {
            this.a = a;
            InitializeComponent();
        }

        private void Display_Load(object sender, EventArgs e)
        {
            switch (a.tip)
            {
                case tipAdrese.adresaSimpla:
                    panel1.Visible = true;
                    panel2.Visible = false;
                    panel3.Visible = false;

                    break;
            }
        }
    }
}

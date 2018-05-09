using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        //1:2 vectori aleatorii, sa se calc produsul scalar si cel vectorial si norma.
        //2:Se dau 3 vectori sa se calculeze volumul paralelipiedului determ de ce 3 vectori.
        //3:Se dau 2 pcte sa se determ dreapta determ de cele 2 puncte.
        //4: se da 1 pct si o dreapta sa se determ distanta de la pct la dreapta.
        public Form1()
        {
            InitializeComponent();
        }

        public Bitmap bmp;
        public Graphics grp;

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);

        }
    }
}

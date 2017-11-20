using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fr01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random rand = new Random();
        Bitmap b;
        Graphics g;
        int resx, resy;

        private void Form1_Load(object sender, EventArgs e)
        {
            resx = pictureBox1.Width;
            resy = pictureBox1.Height;

            b = new Bitmap(resx, resy);
            g = Graphics.FromImage(b);

            for(int i=0;i<=400;i=i+10)
                patrat(resx / 2, resy / 2, i);

            pictureBox1.Image = b;
        }
        public void patrat(int x,int y,int r)
        {
            Pen pen = Pens.Red;
            
            int nr = rand.Next(100);
            if (nr % 3 == 0) {
                pen = Pens.Blue;
            }
            else if (nr % 3 == 1)
            {
                pen = Pens.Green;
            }
            else
            {
                pen = Pens.Red;
            }
            g.DrawLine(pen, x - r / 2, y + r / 2, x + r / 2, y + r / 2);
            g.DrawLine(pen, x + r / 2, y - r / 2, x + r / 2, y + r / 2);
            g.DrawLine(pen, x + r / 2, y - r / 2, x - r / 2, y - r / 2);
            g.DrawLine(pen, x - r / 2, y - r / 2, x - r / 2, y + r / 2);
        }
    }
}

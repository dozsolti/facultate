using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication30
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics grp;
        int w, h;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            w = pictureBox1.Width;
            h = pictureBox1.Height;
            bmp = new Bitmap(w,h);
            grp = Graphics.FromImage(bmp);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Draw(new PointF(0,h/2), new PointF(w,h/2));
        }

        private void Draw(PointF start, PointF end)
        {
            float d = (float)Math.Sqrt((start.X - end.X)* (start.X - end.X) + (start.Y - end.Y)* (start.Y - end.Y));
            if(d<5)
                return;

            grp.DrawLine(new Pen(Color.Black, 8), start, end);
            pictureBox1.Image = bmp;

            start.Y += 14;
            end.Y += 14;

            //partea stanga
            end.X -= 2 * d / 3;
            Draw(start, end);

            //partea dreapta
            end.X += 2 * d / 3; //endul trebuie resetat, fiindca s-a schimbat cand afisez partea stanga
            start.X += 2 * d / 3;
            Draw(start, end);
        }
    }
}

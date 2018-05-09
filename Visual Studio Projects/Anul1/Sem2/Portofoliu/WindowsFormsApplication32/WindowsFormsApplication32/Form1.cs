using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication32
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
            bmp = new Bitmap(w, h);
            grp = Graphics.FromImage(bmp);

            PointF C = new PointF(w / 4, 2 * h / 3);

            PointF A = PunctDinCooPolar(C, -60, w / 2);
            PointF B = PunctDinCooPolar(C, 0, w / 2);

            Draw(A, B, C);
        }
        private void Draw(PointF A, PointF B, PointF C)
        {
            if (Dist(A,B) < 15)
                return;
            grp.DrawPolygon(new Pen(Color.Black, 4), new PointF[] { A, B, C });
            pictureBox1.Image = bmp;

            PointF newA, newB, newC;

            newA = new PointF(A.X, A.Y);
            newB = PunctDinCooPolar(B,-120,Dist(B,A) /2);
            newC = PunctDinCooPolar(C,-60,Dist(C,A)/2);
            Draw(newA, newB, newC);

            newA = PunctDinCooPolar(B, -120, Dist(B, A) / 2);
            newB = B;
            newC = PunctDinCooPolar(C, 0, Dist(C, A) / 2);
            Draw(newA, newB, newC);

            newA = PunctDinCooPolar(C, -60, Dist(C, A) / 2);
            newB = PunctDinCooPolar(C, 0, Dist(C, A) / 2);
            newC = C;
            Draw(newA, newB, newC);

        }
        float Dist(PointF a, PointF b)
        {
            return (float)Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }
        PointF GetCenterPoint(PointF a, PointF b)
        {
            return new PointF((a.X - b.X) / 2, (a.Y - b.Y) / 2);
        }
        PointF PunctDinCooPolar(PointF start, float angel, float r)
        {
            PointF a = new PointF(start.X, start.Y);
            Double angle = angel * Math.PI / 180;
            a.X += (float)(r * Math.Cos(angle));
            a.Y += (float)(r * Math.Sin(angle));
            return a;
        }
    }

}

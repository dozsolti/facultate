using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication31
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

            PointF C = new PointF(w /4, 2*h / 3);

            PointF A = PunctDinCooPolar(C,-60,w/2);
            PointF B = PunctDinCooPolar(C,0,w/2);

            Draw(A,B,C);
        }
        private void Draw(PointF A, PointF B,PointF C,int k=1)
        {
            if (k>5)
                return;
        
            /*grp.DrawString("A", new Font("Arial", 16), Brushes.Black, A);
            grp.DrawString("B", new Font("Arial", 16), Brushes.Black, B);
            grp.DrawString("C", new Font("Arial", 16), Brushes.Black, C);*/
            grp.DrawPolygon(new Pen(Color.Black, 4), new PointF[] { A, B, C });
            pictureBox1.Image = bmp;

            //Left
            {
                float d = Dist(A, C) / 3;
                PointF newC = PunctDinCooPolar(C, -60 * k, d);
                PointF newB = PunctDinCooPolar(C, -60 * k, 2*d);
                PointF newA = PunctDinCooPolar(newC, -60 * (k + 1), d);
                float d2 = Dist(C,B) / 3;
                PointF newC2 = PunctDinCooPolar(C, 60*(k-1), d);
                PointF newB2 = PunctDinCooPolar(C, 60 * (k - 1), 2*d);
                PointF newA2 = PunctDinCooPolar(newC, 60 * (k), d);
                Draw(newA2, newB2, newC2, k + 1);
                Draw(newA, newB, newC, k + 1);
            }

            //Bottom
            {
                
            }

        }
        float Dist(PointF a,PointF b)
        {
            return (float)Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }
        PointF PunctDinCooPolar(PointF start,float angel, float r)
        {
            PointF a = new PointF(start.X,start.Y);
            Double angle = angel * Math.PI / 180;
            a.X += (float)(r * Math.Cos(angle));
            a.Y += (float)(r * Math.Sin(angle));
            return a;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geom
{
    public partial class Form1 : Form
    {
        PointF cg;
        PointF mA, mB, mC;
        Random rnd;
        PointF[] triunghi = new PointF[3];

        Bitmap bmp;
        Graphics grp;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rnd = new Random();
            triunghi = new PointF[3];
            for (int i = 0; i < 3; i++)
                triunghi[i] = getRNDPoint();

            grp.FillPolygon(new SolidBrush(Color.Red), triunghi);
            grp.DrawPolygon(Pens.Black, triunghi);
            
            mA = new PointF((triunghi[1].X + triunghi[2].X) / 2, (triunghi[1].Y + triunghi[2].Y) / 2);
            mB = new PointF((triunghi[0].X + triunghi[2].X) / 2, (triunghi[0].Y + triunghi[2].Y) / 2);
            mC = new PointF((triunghi[0].X + triunghi[1].X) / 2, (triunghi[0].Y + triunghi[1].Y) / 2);

            grp.DrawLine(Pens.Green, triunghi[0], mA);
            grp.DrawLine(Pens.Green, triunghi[1], mB);
            grp.DrawLine(Pens.Green, triunghi[2], mC);

            float cg_X = 0;
            float cg_Y = 0;

            for (int i = 0; i < 3; i++)
            {
                cg_X += triunghi[i].X;
                cg_Y += triunghi[i].Y;
            }
            cg_X /= 3;
            cg_Y /= 3;

            cg = new PointF(cg_X, cg_Y);
            grp.DrawEllipse(Pens.Black, cg.X-5, cg.Y-5, 11, 11);

    float s =
            2 * (triunghi[0].X * (triunghi[1].Y - triunghi[2].Y)

            + triunghi[1].X * (triunghi[2].Y - triunghi[0].Y) +

            triunghi[2].X * (triunghi[0].Y - triunghi[1].Y));

            PointF A = triunghi[0];
            PointF B = triunghi[1];
            PointF C = triunghi[2];
            float xs =
                ((A.X*A.X)+(A.Y*A.Y))*(B.Y-C.Y)
                +(B.X*B.X+ B.Y*B.Y)*(C.Y-A.Y)
                +(C.X*C.X+C.Y*C.Y)*(A.Y-B.Y);
    float ys =
                ((A.X * A.X) + (A.Y * A.Y)) * (C.X - B.X)
                + (B.X * B.X + B.Y * B.Y) * (A.X - C.X)
                + (C.X * C.X + C.Y * C.Y) * (B.X - A.X);
            PointF ccc = new PointF(xs / s, ys / s);
            float R = d(ccc, triunghi[0]);
            grp.DrawEllipse(Pens.Green, ccc.X -5, ccc.Y -5, 11, 11);
            grp.DrawLine(Pens.Purple,ccc, mA);
            grp.DrawLine(Pens.Purple, ccc, mB);
            grp.DrawLine(Pens.Purple, ccc, mC);
            grp.DrawEllipse(Pens.OrangeRed, ccc.X-R,ccc.Y-R,R*2,R*2 );

            float m = (-(B.Y - C.Y)) / (C.X - B.X);
            float deltaS = (C.X - B.X) - (B.Y - C.Y) * m;
            float deltaX = (A.X - m*A.Y)*(C.X-B.X) - (B.Y*C.Y-B.X*C.Y) * m;
            float deltaY = (B.Y * C.X - B.X * C.Y) - (A.X - m * A.Y) * (B.Y - C.Y);
            PointF M = new PointF(deltaX / deltaS, deltaY / deltaS);
            grp.DrawLine(Pens.Aqua, A, M);

            pictureBox1.Image = bmp;

        }
        public float d(PointF A,PointF B)
        {
            return (float)Math.Sqrt((A.X - B.X) * (A.X - B.X)+ (A.Y - B.Y) * (A.Y - B.Y));
        }
        public PointF getRNDPoint()
        {
            return new PointF(rnd.Next(pictureBox1.Width), rnd.Next(pictureBox1.Height));

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace ScaleSiTranslatieCerc
{
    public static class Engine
    {
        public static PictureBox display;
        public static Point center;
        public static Graphics grp;
        public static Bitmap bmp;
        public static Pen sketch = new Pen(Color.LightGray, 2);
        public static Color[] colors = new Color[] { Color.HotPink, Color.Red, Color.Yellow, Color.Orange, Color.Green, Color.Blue, Color.Gray, Color.Purple };
        public static List<PointF>[] parts = new List<PointF>[colors.Length];

        public static float r = 100, n = 45, k = 0;
        public static double theta = Math.PI / (4 * n);
        public static PointF[] points;

        public static float x, y, dE, dSE;
        public static double d;


        public static void Init(PictureBox p)
        {
            display = p;
            DrawSketch(new Point(p.Width / 2, p.Height / 2));
            points = new PointF[8];

        }
        public static void InitValues()
        {
            x = 0; y = r;
            dE = 3; dSE = 5 - 2 * y;
            d = 1 - r;
            for (int i = 0; i < parts.Length; i++)
                parts[i] = new List<PointF>();
        }

        public static void DrawSketch(Point newCenter)
        {
            center = newCenter;
            bmp = new Bitmap(display.Width, display.Height);
            grp = Graphics.FromImage(bmp);
            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            grp.DrawLine(sketch, 0, center.Y, display.Width, center.Y);
            grp.DrawLine(sketch, center.X, 0, center.X, display.Height);
            grp.DrawEllipse(sketch, center.X - r, center.Y - r, 2 * r, 2 * r);
            display.Image = bmp;
        }

        public static void Calc()
        {
            while (x <= y)
            {
                points[0] = new PointF(y, x);
                points[1] = new PointF(x, y);
                points[2] = new PointF(-y, x);
                points[3] = new PointF(-x, y);
                points[4] = new PointF(-y, -x);
                points[5] = new PointF(-x, -y);
                points[6] = new PointF(y, -x);
                points[7] = new PointF(x, -y);

                for (int i = 0; i < 8; i++)
                    parts[i].Add(points[i]);

                if (d < 0)
                {
                    d += dE;
                    dE += 2;
                    dSE += 2;
                }
                else
                {
                    d += dSE;
                    dE += 2;
                    dSE += 4;
                    y--;
                }
                x++;
            }

        }


        public static void Draw()
        {
            grp.Clear(Color.White);
            for (int i = 0; i < parts.Length; i++)
                foreach (PointF point in parts[i])
                    grp.DrawEllipse(new Pen(colors[i]), center.X + point.X, center.Y + point.Y, 1, 1);
            display.Image = bmp;
        }
    }

}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ScalareSiTranslatareElipsa
{
    public static class Engine
    {
        public static PictureBox display;
        public static Point center = new Point(800 / 2, 450 / 2);
        public static Graphics grp;
        public static Bitmap bmp;
        public static Pen sketch = new Pen(Color.LightGray, 2);
        public static Color[] colors = new Color[] { Color.Red, Color.Yellow, Color.Green, Color.Blue };
        public static List<PointF>[] parts = new List<PointF>[colors.Length];
        public static float r1 = 100, r2 = 80;
        public static PointF[] points;

        public static float x, y, d, dx, dy;


        public static void Init(PictureBox p)
        {
            display = p;
            bmp = new Bitmap(display.Width, display.Height);
            grp = Graphics.FromImage(bmp);
            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            display.Image = bmp;

        }
        public static void InitValues()
        {
            x = 0;
            y = r2;
            d = r2 * r2 - r1 * r1 * r2 + r1 * r1 / 4;
            dx = 2 * r2 * r2 * x;
            dy = 2 * r1 * r1 * y;

            points = new PointF[4];
            for (int i = 0; i < parts.Length; i++)
                parts[i] = new List<PointF>();
        }
        public static void Calc()
        {
            while (x <= r1 && y >= 0)
            {
                points[0] = new PointF(x, y);
                points[1] = new PointF(-x, y);
                points[2] = new PointF(-x, -y);
                points[3] = new PointF(+x, -y);

                for (int i = 0; i < 4; i++)
                {
                    parts[i].Add(points[i]);
                }

                x++;
                dx += 2 * r2 * r2;
                d += dx + r2 * r2;

                if (d > 0)
                {
                    y--;
                    dy -= 2 * r1 * r1;
                    d -= dy;
                    x--;
                    dx -= 2 * r2 * r2;
                    d -= dx + r2 * r2;
                }
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
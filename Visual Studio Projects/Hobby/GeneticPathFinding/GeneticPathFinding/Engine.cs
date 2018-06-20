using System;
using System.Drawing;
using System.Windows.Forms;

namespace GeneticPathFinding
{
    public static class Engine
    {
        public static Random rnd = new Random();

        public static Bitmap bmp;
        public static Graphics grp;
        public static PictureBox display;
        public static float size = 20;
        public static PointF food;

        public static void Init(PictureBox pictureBox1)
        {
            display = pictureBox1;
            bmp = new Bitmap(display.Width, display.Height);
            grp = Graphics.FromImage(bmp);
            Grid();
        }

        public static void Grid()
        {
            grp.Clear(Color.Wheat);
            grp.FillEllipse(new SolidBrush(Color.Red), food.X, food.Y, Engine.size, Engine.size);
            for (int i = 0; i < (display.Width / size); i++)
                for (int j = 0; j < (display.Width / size); j++)
                    grp.DrawRectangle(Pens.Black, i * size, j * size, size, size);
            display.Image = bmp;
        }

        
    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication38
{
    /*
     * 1 = spatiu
     * 2-9 = numar
     * 10 = bomba 
     * 
     * Cele cu minus inseamna ca nu s-au data click inca
     */
    public static class Engine
    {
        public static bool alive;
        public static Random rnd;
        public static int n = 10, nrBombe =10
            ,bombCode=10, emptyCode=1, clickedCount;
        public static float w = 30, h = 30;
        public static int[,] m;
        public static bool[,] b;
        public static PictureBox display;
        public static Bitmap bmp;
        public static Graphics grp;
        public static Color clrBg;

        public static void Init(PictureBox _display)
        {
            display = _display;
            bmp = new Bitmap(display.Width, display.Height);
            grp = Graphics.FromImage(bmp);
            clrBg = Color.WhiteSmoke;
            rnd = new Random();
        }


        public static void Start()
        {
            clickedCount = 0;
            Clear();
            int _nrBombe = nrBombe;
            while (_nrBombe > 0)
            {
                int pX = rnd.Next(n);
                int pY = rnd.Next(n);
                while (m[pY, pX] != 0)
                {
                    pX = rnd.Next(n);
                    pY = rnd.Next(n);
                }
                for (int i = Math.Max(0, pY - 1); i <= Math.Min(n - 1, pY + 1); i++)
                    for (int j = Math.Max(0, pX - 1); j <= Math.Min(n - 1, pX + 1); j++)
                        m[i, j]++;

                m[pY, pX] = bombCode-1;
                _nrBombe--;
            }
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    m[i, j]++;
                    m[i, j] *= -1;
                }
            Draw();
            alive = true;

        }
        public static void Step(int x, int y)
        {
            if (alive == false)
                return;
            int i = (int)(x / w);
            int j = (int)(y / h);
            if (m[i, j] >= 0)
                return;

            if (Math.Abs(m[i, j]) == Math.Abs(bombCode))
            {
                Draw();
                MessageBox.Show("Game Over");
                alive = false;
            }
            else if (Math.Abs(m[i, j]) == Math.Abs(emptyCode))
            {
                Expand(i, j);
            }
            else
            {
                m[i, j] *= -1;
                clickedCount++;
            }
            Draw();
            if (clickedCount == n * n - nrBombe)
                MessageBox.Show("Ai castigat");
        }

        private static void Expand(int i, int j)
        {
            if (i >= 0 && i < n && j >= 0 && j < n && b[i, j] == false && -m[i,j]<bombCode)
            {
                clickedCount++;
                m[i, j] *= -1;
                b[i, j] = true;
                Expand(i - 1, j);
                Expand(i, j + 1);
                Expand(i + 1, j);
                Expand(i, j - 1);
            }
        }

        public static void Draw()
        {
            
            grp.Clear(clrBg);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    grp.DrawRectangle(Pens.Black, i * w, j * h, w, h);
                    if (m[i, j] > 0)
                    {
                        if (Math.Abs(m[i, j]) == Math.Abs(bombCode))
                            grp.DrawString("X", new Font("Arial", 14), Brushes.Red, i * w, j * h);
                        else
                            grp.DrawString((m[i, j]-1).ToString(), new Font("Arial", 14), Brushes.Black, i * w, j * h);
                    }
                }
            display.Image = bmp;
        }

        public static void Clear()
        {
            m = new int[n, n];
            b = new bool[n, n];
            grp.Clear(clrBg);
            display.Image = bmp;
        }
    }
}

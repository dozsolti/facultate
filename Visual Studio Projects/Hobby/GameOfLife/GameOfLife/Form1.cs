using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        Bitmap sursa;
        int n;
        int[,] m;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            n = pictureBox1.Width/3;
            m = new int[n, n];
            int count = n * (n/2);
            Random r = new Random();
            while (count > 0)
            {
                int i = r.Next(n);
                int j = r.Next(n);
                while (m[i, j] != 0)
                {
                    i = r.Next(n);
                    j = r.Next(n);
                }
                m[i, j] = 1;
                count--;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Step();
            Draw();
        }
        private void Step()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int neighboards = getNeighboards(j, i);
                    if (neighboards < 2 || neighboards > 3)
                        m[i, j] = 0;
                    if (m[i, j] == 0 && neighboards == 3)
                        m[i, j] = 1;
                }
            }
        }
        private void Draw()
        {
            sursa = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int y = -1; y < 2; y++)
                    {
                        for (int x = -1; x < 2; x++)
                        {
                            int xi = i + x;
                            xi = Math.Max(xi, 0);
                            xi = Math.Min(xi, n - 1);

                            int yj = j + y;
                            yj = Math.Max(yj, 0);
                            yj = Math.Min(yj, n - 1);

                            if (m[xi, yj] == 1)
                                sursa.SetPixel(xi, yj, Color.Black);
                            else
                                sursa.SetPixel(xi, yj, Color.Red);
                        }
                    }

                    
                }
            }
            pictureBox1.Image = sursa;
        }
        private int getNeighboards(int i, int j)
        {
            int neigh = 0;
            for (int y = -1; y < 2; y++)
            {
                for (int x = -1; x < 2; x++)
                {
                    int xi = i + x;
                    xi = Math.Max(xi, 0);
                    xi = Math.Min(xi, n - 1);

                    int yj = j + y;
                    yj = Math.Max(yj, 0);
                    yj = Math.Min(yj, n - 1);

                    if (m[xi, yj] == 1)
                        neigh++;
                }
            }
            return neigh;
        }

    }
}

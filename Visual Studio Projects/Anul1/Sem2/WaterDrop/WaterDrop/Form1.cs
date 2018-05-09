using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaterDrop
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics grp;

        public float[,] current;
        public float[,] previous;
        public float damping = 0.99f;
        public int w,h;
        public Form1()
        {
            InitializeComponent();
            w = pictureBox1.Width;
            h = pictureBox1.Height;
            current = new float[w, h];
            previous = new float[w, h];

            bmp = new Bitmap(w, h);
            grp = Graphics.FromImage(bmp);
            Draw();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            current[w/2, h/2] = 255;
            timer1.Start();
            timer1.Interval = 1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Draw();
        }

        private void Draw()
        {

            for (int i=1; i<w-1;i++)
                for(int j=1; j < h - 1; j++)
                {
                    current[i, j] = (previous[i-1,j]+ previous[i + 1, j]+ previous[i, j+1]+ previous[i, j-1]) / 2 + current[i, j];
                    current[i, j] *= damping;
                }

            float[,] _temp = previous;
            previous = current;
            current = _temp;

            for (int i = 1; i < w - 1; i++)
                for (int j = 1; j < h - 1; j++)
                {
                    int color = ((int)current[i, j]);
                    if (color < 0)
                        color = 0;
                    if (color > 255)
                        color = 255;
                    grp.DrawEllipse(
                        new Pen(
                            Color.FromArgb(color, color, color)
                         )
                        , i - 1, j - 1, 1, 1);
                }

            pictureBox1.Image = bmp;

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semiar3
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics grp;
        Random rnd;
        float angle;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Step();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            rnd = new Random();
            angle = 0;
            Step();
        }
        private void Step()
        {
            grp.Clear(Color.White);
            angle += (float)Math.PI / 10;
            Color color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            int cx = pictureBox1.Width / 2;
            int cy = pictureBox1.Height / 2;

            PointF[] points = new PointF[4];
            for (int i = 0; i < 4; i++)
            {
                float x = cx + 100 * (float)Math.Cos(Math.PI / 2 * i + angle);
                float y = cy + 100 * (float)Math.Sin(Math.PI / 2 * i + angle);
                points[i] = new PointF(x, y);
            }
            grp.FillPolygon(new SolidBrush(color), points);
            grp.DrawPolygon(new Pen(color, 2), points);
            pictureBox1.Image = bmp;
        }
    }
}

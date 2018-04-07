using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlyRotire
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            fg(5, 200, new PointF(300, 220), 0.4f);
            pictureBox1.Image = bmp;
        }
        Bitmap bmp;
        Graphics grp;


        public void fg(int n,float l,PointF center, float phi)
        {
            float us = ((float)Math.PI * 2) / (float)n;
            PointF [] points = new PointF[n];
            for(int i=0;i<n;i++)
            {
                float x = center.X + l * (float)Math.Cos(us * i + phi);
                float y = center.Y + l * (float)Math.Cos(us * i + phi);
                points[i] = new PointF(x, y);
            }
            grp.DrawPolygon(new Pen(Color.Black, 2), points);


        }
    }
}

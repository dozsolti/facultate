using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeminarNr4
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics grp;
        static Random r = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            
        }

        public void fg(int n,float l,PointF center,float phi)
        {
            float us = ((float)Math.PI * 2) / (float)n;
            PointF[] points = new PointF[n];
            for(int i = 0; i < n; i++)
            {
                float x = (center.X + l * (float)Math.Cos(us * i + phi));
                float y = (center.Y + l * (float)Math.Sin(us * i + phi));
                points[i] = new PointF(x,y);
                
            }
            
            grp.DrawPolygon(new Pen(Color.FromArgb(r.Next(256), r.Next(256), r.Next(256)), 2), points);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            grp.Clear(Color.Transparent);
            int y = r.Next(pictureBox1.Height);
            for(int i=0;i<8;i++)
                fg(3, r.Next(2,6)*20, new PointF(r.Next(70,100)*(i+1),y), 0.04f*i*3);

            pictureBox1.Image = bmp;
        }
    }
}

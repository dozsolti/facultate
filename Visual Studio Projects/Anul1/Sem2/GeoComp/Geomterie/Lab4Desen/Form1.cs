using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4Desen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap bmp;
        Graphics grp;
        Pen creion;

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            Random rnd = new Random();
            float w = pictureBox1.Width;
            float h = pictureBox1.Height;
            
            for(int i=0;i<8; i++)
            {
                float x1 = rnd.Next(0, (int)w);
                float x3 = rnd.Next(0, (int)w);
                float x2 = rnd.Next(0, (int)w);
                float y1 = rnd.Next(0, (int)h);
                float y3 = rnd.Next(0, (int)h);
                float y2 = rnd.Next(0, (int)h);
                Color c = new Color();
                c = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                creion = new Pen(c, 2);
                grp.DrawLine(creion, x1, y1, x2, y2);
                grp.DrawLine(creion, x1, y1, x3, y3);
                grp.DrawLine(creion, x3, y3, x2, y2);
            }
            pictureBox1.Image = bmp;

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeseneLab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        float ax;
        float ay;
        float bx;
        float by;
        float cx;
        float cy;
        Bitmap bmp;
        Graphics grp;

        public void curat()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
        }

        public void desen2()
        {
            
            Pen creion = new Pen(Color.Black, 2);
            grp.DrawLine(creion,ax,ay,bx,by);
            grp.DrawLine(creion, ax, ay, cx, cy);
            grp.DrawLine(creion, cx, cy, bx, by);
            int ax2 = (int)ax / 2;
            int ay2 = (int)ay / 2;
            int bx2 = (int)bx / 2;
            int by2 = (int)by / 2;
            int cx2 = (int)cx / 2;
            int cy2 = (int)cy / 2;
            grp.DrawLine(creion, cx, cy, bx2+ax2, by2+ay2);
            grp.DrawLine(creion, bx, by, cx2+ax2, cy2+ay2);
            grp.DrawLine(creion, ax,ay, bx2+cx2, by2+cy2);
            pictureBox1.Image = bmp;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            label7.Text = "Width:" + pictureBox1.Width;
            label8.Text = "Height" + pictureBox1.Height;
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            curat();
            ax = Convert.ToInt32(richTextBox1.Text);
            ay = Convert.ToInt32(richTextBox2.Text);
            bx = Convert.ToInt32(richTextBox3.Text);
            by = Convert.ToInt32(richTextBox4.Text);
            cx = Convert.ToInt32(richTextBox5.Text);
            cy = Convert.ToInt32(richTextBox6.Text);
            desen2();

        }

        public void desen3()
        {
            Pen creion = new Pen(Color.Black, 2);
            grp.DrawLine(creion, ax, ay, bx, by);
            grp.DrawLine(creion, ax, ay, cx, cy);
            grp.DrawLine(creion, cx, cy, bx, by);
             double c = Math.Sqrt(Math.Pow(ax - bx, 2) + Math.Pow(ay - by, 2));
             double a = Math.Sqrt(Math.Pow(bx - cx, 2) + Math.Pow(by - cy, 2));
             double b = Math.Sqrt(Math.Pow(cx - ax, 2) + Math.Pow(cy - ay, 2));
             grp.DrawEllipse(creion, (float)(a*ax + b*bx + c*cx) / (float)(a + b + c), (float)(a*ay + b*by + c*cy) / (float)(a + b + c),2 ,2 );
            grp.DrawLine(creion, (float)(a * ax + b * bx + c * cx) / (float)(a + b + c), (float)(a * ay + b * by + c * cy) / (float)(a + b + c),ax,ay);
            grp.DrawLine(creion, (float)(a * ax + b * bx + c * cx) / (float)(a + b + c), (float)(a * ay + b * by + c * cy) / (float)(a + b + c), bx, by);
            grp.DrawLine(creion, (float)(a * ax + b * bx + c * cx) / (float)(a + b + c), (float)(a * ay + b * by + c * cy) / (float)(a + b + c), cx, cy);
            float x=(float)( a * ax + b * bx + c * cx) / (float)(a + b + c);
            float y = (float)(a * ay + b * by + c * cy) / (float)(a + b + c);
            float a1 = (y - ay);
            float b1 = (ax - x);
            float c1 = (-ax * y) + (ay * x);
            float a2 = by - cy;
            float b2 = (cx - bx);
            float c2 = (-cx * by) + cy * bx;
            float x1 = ((c2 * b1) - (c1 * b2)) / ((a1 * b2) - (a2 * b1));
            float y1 = (-c1 - (a1 * x1)) / b1;
            grp.DrawLine(creion, x1, y1, x, y);
            a1 = (y - by);
            b1 = (bx - x);
            c1 = (-bx * y) + (by * x);
            a2 = ay - cy;
            b2 = (cx - ax);
            c2 = (-cx * ay) + cy * ax;
            x1 = ((c2 * b1) - (c1 * b2)) / ((a1 * b2) - (a2 * b1));
            y1 = (-c1 - (a1 * x1)) / b1;
            grp.DrawLine(creion, x1, y1, x, y);
            double t = Math.Sqrt(Math.Pow(x - x1, 2) + Math.Pow(y - y1, 2));
            grp.DrawEllipse(creion, x - (float)t , y -(float)t ,(float) t*2, (float)t*2);
            a1 = (y - cy);
            b1 = (cx - x);
            c1 = (-cx * y) + (cy * x);
            a2 = ay - by;
            b2 = (bx - ax);
            c2 = (-bx * ay) + by * ax;
            x1 = ((c2 * b1) - (c1 * b2)) / ((a1 * b2) - (a2 * b1));
            y1 = (-c1 - (a1 * x1)) / b1;
            grp.DrawLine(creion, x1, y1, x, y);

            pictureBox1.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            curat();
            ax = Convert.ToInt32(richTextBox1.Text);
            ay = Convert.ToInt32(richTextBox2.Text);
            bx = Convert.ToInt32(richTextBox3.Text);
            by = Convert.ToInt32(richTextBox4.Text);
            cx = Convert.ToInt32(richTextBox5.Text);
            cy = Convert.ToInt32(richTextBox6.Text);
            desen3();

        }

        public void desen4()
        {
            Pen creion = new Pen(Color.Black, 2);
            grp.DrawLine(creion, ax, ay, bx, by);
            grp.DrawLine(creion, ax, ay, cx, cy);
            grp.DrawLine(creion, cx, cy, bx, by);
            float x = ((ay * ay + ax * ax) * (by - cy) + (by * by + bx * bx) * (cy - ay) + (cy * cy + cx * cx) * (ay - by)) / (2 * (ax * (by - cy) + bx * (cy - ay) + cx * (ay - by)));
            float y = ((ay * ay + ax * ax) * (cx - bx) + (by * by + bx * bx) * (ax - cx) + (cy * cy + cx * cx) * (bx - ax)) / (2 * (ax * (by - cy) + bx * (cy - ay) + cx * (ay - by)));
            grp.DrawEllipse(creion, x, y, 2, 2);

            float a1 = (y - ay);
            float b1 = (ax-x);
            float c1 = (-ax * y) + (ay * x);
            float a2 = by - cy;
            float b2 = (cx - bx);
            float c2 = (-cx * by) + cy * bx;
            float x1 = ((c2 * b1) - (c1 * b2)) / ((a1 * b2) -( a2 * b1));
            float y1 = (-c1 - (a1 * x1)) / b1;
            grp.DrawLine(creion, x1, y1, x, y);
            grp.DrawLine(creion, ax, ay, x, y);
            grp.DrawLine(creion, x, y, bx, by);
            grp.DrawLine(creion, x, y, cx, cy);
            a1 = (y - by);
            b1 = (bx - x);
            c1 = (-bx * y) + (by * x);
            a2 = ay - cy;
            b2 = (cx - ax);
            c2 = (-cx * ay) + cy * ax;
            x1 = ((c2 * b1) - (c1 * b2)) / ((a1 * b2) - (a2 * b1));
            y1 = (-c1 - (a1 * x1)) / b1;
            grp.DrawLine(creion, x1, y1, x, y);
            a1 = (y - cy);
            b1 = (cx - x);
            c1 = (-cx * y) + (cy * x);
            a2 = ay - by;
            b2 = (bx - ax);
            c2 = (-bx * ay) + by * ax;
            x1 = ((c2 * b1) - (c1 * b2)) / ((a1 * b2) - (a2 * b1));
            y1 = (-c1 - (a1 * x1)) / b1;
            grp.DrawLine(creion, x1, y1, x, y);





            pictureBox1.Image = bmp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            curat();
            ax = Convert.ToInt32(richTextBox1.Text);
            ay = Convert.ToInt32(richTextBox2.Text);
            bx = Convert.ToInt32(richTextBox3.Text);
            by = Convert.ToInt32(richTextBox4.Text);
            cx = Convert.ToInt32(richTextBox5.Text);
            cy = Convert.ToInt32(richTextBox6.Text);
            desen4();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            curat();
            ax = Convert.ToInt32(richTextBox1.Text);
            ay = Convert.ToInt32(richTextBox2.Text);
            bx = Convert.ToInt32(richTextBox3.Text);
            by = Convert.ToInt32(richTextBox4.Text);
            cx = Convert.ToInt32(richTextBox5.Text);
            cy = Convert.ToInt32(richTextBox6.Text);
            desen5();
        }

        private void desen5()
        {
            pictureBox1.Image = null;
            Pen creion = new Pen(Color.Black, 2);
            grp.DrawLine(creion, ax, ay, bx, by);
            grp.DrawLine(creion, ax, ay, cx, cy);
            grp.DrawLine(creion, cx, cy, bx, by);
            float ax2 = ax / 2;
            float ay2 = ay / 2;
            float bx2 = bx / 2;
            float by2 = by / 2;
            float cx2 = cx / 2;
            float cy2 = cy / 2;

            float a1 = (bx - ax) / (by - ay);
            float b1 = 1;
            float c1 = -((ay+by)/2)+((bx-ax)/(by-ay))*(-((ax+bx)/2));
            float a2 = (cx-bx)/(cy-by);
            float b2 = 1;
            float c2 = -((by+cy)/2)+((cx-bx)/(cy-by))*(-((bx+cx)/2));
            float x = ((c2 * b1) - (c1 * b2)) / ((a1 * b2) - (a2 * b1));
            float y = (-c1 - (a1 * x)) / b1;
            grp.DrawEllipse(creion, x, y, 2, 2);
            grp.DrawLine(creion, (ax2 + bx2) , (ay2 + by2) ,x,y);
            grp.DrawLine(creion, (ax2 + cx2), (ay2 + cy2), x, y);
            grp.DrawLine(creion, (cx2 + bx2), (cy2 + by2), x, y);
            double t = Math.Sqrt(Math.Pow(ax - x, 2) + Math.Pow(ay - y, 2));
            grp.DrawEllipse(creion,x-(float)(t),y-(float)(t),(float)t*2,(float)t*2);


            pictureBox1.Image = bmp;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Photoshop
{
    public partial class Form1 : Form
    {
        Bitmap sursa, destinatie, snowsFlakes;
        int k;
        Random rnd;
        Point[] snows;
        public Form1()
        {
            InitializeComponent();
            sursa = new Bitmap(@"..\..\Resource\simbol.png");
            destinatie = new Bitmap(sursa.Width, sursa.Height);
            snowsFlakes = new Bitmap(sursa.Width, sursa.Height);

            pictureBox1.Image = sursa;

            rnd = new Random();
            snows = new Point[20];
            for (int i = 0; i < 20; i++)
                snows[i] = new Point(rnd.Next(sursa.Width),0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < sursa.Width; i++) {
                for (int j = 0; j < sursa.Height; j++) {
                    Color currentColor = sursa.GetPixel(i, j);
                    destinatie.SetPixel(i, j, BlackNWhite(currentColor));
                    }
            }
            pictureBox2.Image = destinatie;
            
        }
        private Color BlackNWhite(Color c)
        {
            float t = (c.R + c.G + c.B)/3;
            if (t < 128)
                return Color.FromArgb(0, 0, 0);
            else
                return Color.FromArgb(255,255,255);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < sursa.Width; i++)
            {
                for (int j = 0; j < sursa.Height; j++)
                {
                    Color currentColor = sursa.GetPixel(i, j);
                    destinatie.SetPixel(i, j, GreyScale(currentColor));
                }
            }
            pictureBox2.Image = destinatie;
        }
        private Color GreyScale(Color c)
        {
            int t = (c.R + c.G + c.B) / 3;
            return Color.FromArgb(t, t, t);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < sursa.Width; i++)
            {
                for (int j = 0; j < sursa.Height; j++)
                {
                    Color currentColor = sursa.GetPixel(i, j);
                    destinatie.SetPixel(i, j, Comp(currentColor));
                }
            }
            pictureBox2.Image = destinatie;
        }
        private Color Comp(Color c)
        {
            return Color.FromArgb(c.A, 255 - c.R, 255 - c.G, 255 - c.B);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < sursa.Width; i++)
            {
                for (int j = 0; j < sursa.Height; j++)
                {
                    Color currentColor = sursa.GetPixel(i, j);
                    destinatie.SetPixel(i, j, RedScale(currentColor));
                }
            }
            pictureBox2.Image = destinatie;
        }
        private Color RedScale(Color c)
        {
            return Color.FromArgb(c.A, c.R, 0, 0);
        }
        
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            k = trackBar1.Value;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < sursa.Width; i++)
            {
                for (int j = 0; j < sursa.Height; j++)
                {
                    Color currentColor = sursa.GetPixel(i, j);
                    destinatie.SetPixel(i, j, Luminozitate(currentColor, k));
                }
            }
            pictureBox2.Image = destinatie;
        }
        private Color Luminozitate(Color c,int v)
        {
            int r = Math.Max(Math.Min(255, c.R +v),0);
            int g = Math.Max(Math.Min(255, c.G + v),0);
            int b = Math.Max(Math.Min(255, c.B + v),0);

            return Color.FromArgb(c.A,r,g,b);
        }

        private void ContrastAll(int v)
        {
            for (int i = 0; i < sursa.Width; i++)
            {
                for (int j = 0; j < sursa.Height; j++)
                {
                    Color currentColor = sursa.GetPixel(i, j);
                    destinatie.SetPixel(i, j, Contrast(currentColor, k));
                }
            }
            pictureBox2.Image = destinatie;
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            ContrastAll(k);
        }
        private Color Contrast(Color c, int v)
        {
            int t = (c.R + c.G + c.B) / 3;
            if (t < 128)
                return Color.FromArgb(c.A, Math.Max(0, t - v), Math.Max(0, t - v), Math.Max(0, t - v));
            else
                return Color.FromArgb(c.A, Math.Min(255, t + v), Math.Min(255, t + v), Math.Min(255, t + v));
        }
        
        int Value = 0;
        private void button7_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Value += 5;
            ContrastAll(Value);
        }
       

        private void button8_Click(object sender, EventArgs e)
        {
            BlurAll();
        }
        private void BlurAll()
        {
            for (int i = 1; i < sursa.Width-1; i++)
            {
                for (int j = 1; j < sursa.Height-1; j++)
                {
                    Color currentColor = sursa.GetPixel(i, j);
                    destinatie.SetPixel(i, j, Blur(currentColor,i,j));
                }
            }
            pictureBox2.Image = destinatie;
        }
        private Color Blur(Color c, int i, int j)
        {
            int tR = 0, tG = 0, tB = 0;
            for (int k = -1; k <= 1; k++)
                for (int l = -1; l <= 1; l++)
                {
                    Color tmp = sursa.GetPixel(i + k, j + l);
                    tR += tmp.R;
                    tG += tmp.G;
                    tB += tmp.B;

                }
            tR /= 9;
            tG /= 9;
            tB /= 9;
            return Color.FromArgb(c.A, tR % 256, tG % 256, tB % 256);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Fulgi();
        }        
        public void Fulgi()
        {
            for (int i = 0; i < sursa.Width; i++)
            {
                for (int j = 0; j < sursa.Height; j++)
                {
                    Color currentColor = sursa.GetPixel(i, j);
                    destinatie.SetPixel(i, j, currentColor);
                }
            }

            for (int i = 0; i < 50; i++) {
                int x = rnd.Next(sursa.Width);
                int y = rnd.Next(sursa.Height);
                int s = rnd.Next(100,500);


                for (int j = 0; j < s; j++)
                {
                    int rp = rnd.Next(200);
                    int gp = rnd.Next(200);
                    int bp = rnd.Next(200);
                    float r =(float) rnd.NextDouble()*10;
                    float alpha = (float)(rnd.NextDouble()*(Math.PI*2));
                    float lx = (float)(x + r * Math.Cos(alpha));
                    float ly = (float)(y + r * Math.Sin(alpha));
                    if (lx >= 0 && ly >= 0 && lx < sursa.Width && ly < sursa.Height)
                    {
                        Color t = sursa.GetPixel((int)lx, (int)ly);
                        int pr = t.R + rp;
                        if (pr > 255)
                            pr = 255;

                        int pg = t.G + gp;
                        if (pg > 255)
                            pg = 255;

                        int pb = t.G + bp;
                        if (pb > 255)
                            pb = 255;
                        destinatie.SetPixel((int)lx, (int)ly, Color.FromArgb(pr, pg, pb));
                    }
                }
            }
            pictureBox2.Image = destinatie;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Outline(11);
        }
        public void Outline(int stroke)
        {
            for (int i = 0; i < sursa.Width; i++)
            {
                for (int j = 0; j < sursa.Height; j++)
                {
                    Color currentColor = sursa.GetPixel(i, j);
                    destinatie.SetPixel(i, j, currentColor);
                }
            }
            for (int i = stroke / 2; i < sursa.Width- stroke / 2; i++)
            {
                for (int j = stroke / 2; j < sursa.Height- stroke / 2; j++)
                {
                    Color currentColor = sursa.GetPixel(i, j);
                    if (currentColor.A < 10)
                    {
                        if (areVecin(i, j))
                        {
                            for (int k = (int)-stroke/2; k <= (int)stroke / 2; k++)
                                for (int l = (int)-stroke / 2; l <= (int)stroke / 2; l++)
                                    destinatie.SetPixel(i+k, j+l, Color.Black);
                        }
                    }
                    
                }
            }
            pictureBox2.Image = destinatie;
        }

        private bool areVecin(int i, int j)
        {
            for (int k = -1; k <= 1; k++)
                for (int l = -1; l <= 1; l++)
                    if (sursa.GetPixel(i + k, j + l).A > 128)
                        return true;
            return false;
        }

        private Color NewFilter(Color c,int i,int j)
        {
            int tR=0,tG=0,tB=0 ;
            for (int k = -1; k <= 1; k++)
                for (int l = -1; l <= 1; l++)
                {
                    Color tmp = sursa.GetPixel(i + k, j + l);
                    tR += tmp.R;
                    tG += tmp.G;
                    tB += tmp.B;

                }
            return Color.FromArgb(c.A, tR%256, tG%256, tB%256);
        }
    }
}


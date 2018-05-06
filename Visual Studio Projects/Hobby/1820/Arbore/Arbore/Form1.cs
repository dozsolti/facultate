using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arbore
{
    public partial class Form1 : Form
    {
        public static Form1 me;
        public Bitmap bmp;
        public Graphics grp;
        public Random rnd;

        public struct Nod
        {
            public int x, y,p;
            public ulong nr;
            public Point parentCoord;

            public Nod(int _x, int _y, ulong _nr, int _p, Point _parentCoord)
            {
                this.x = _x;
                this.y = _y;
                this.nr = _nr;
                this.p = _p;
                this.parentCoord = _parentCoord;
            }
            public void extend(int o,Nod ch)
            {
                if (o >= 50)
                    return;

                int _offsetX = 5;

                int offsetX = _offsetX;
                int offsetY = 15;

                //left
                if (ch.x > me.bmp.Width / 2)
                    offsetX = 0;
                else
                    offsetX = _offsetX;
                Nod cl = new Nod(ch.x - offsetX, ch.y + offsetY, ch.nr * 2, ch.p + 1, new Point(ch.x, ch.y));
                //me.draw(cl);

                ch.extend(o+1,cl);

                //right
                if (ch.x < me.bmp.Width / 2)
                    offsetX = 0;
                else
                    offsetX = _offsetX;
                Nod cr = new Nod(ch.x + offsetX, ch.y + offsetY, (ch.nr-1)/3, ch.p + 1, new Point(ch.x, ch.y));
                //me.draw(cr);
                if(ch.nr%3!=0)
                    ch.extend(o + 1, cr);

            }

            public Nod[] extend()
            {
                List<Nod> childs = new List<Nod>();
                int _offsetX = (20-(int)(p*1.5))*8;

                int offsetX = _offsetX;
                int offsetY = 8 * p;

                //left
                if (x > me.bmp.Width / 2)
                    offsetX = 0;
                else
                    offsetX = _offsetX;
                childs.Add(new Nod(x - offsetX, y + offsetY, nr * 2, p + 1, new Point(x, y) ));


                /*right
                if (x < bmp.Width / 2)
                    offsetX = 0;
                else
                    offsetX = _offsetX;
                if (nr%3!=0)
                    childs.Add(new Nod(x + offsetX, y + offsetY, (nr - 1) / 3, p + 1, new Point(x,y) ));
                */

                return childs.ToArray();
            }
        }        

        Nod radacina;
        List<Nod> frunze;
        List<Nod> frunzeNoi;

        int size = 2;

        bool wasStarted = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            me = this;
            Init();
        }

        private void Init()
        {
            rnd = new Random();
            frunze = new List<Nod>();
            frunzeNoi = new List<Nod>();
        }

        private void Start()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);

            radacina = new Nod( bmp.Width / 2, 0, 16, 5, new Point(bmp.Width / 2, 0) ) ;
            draw(radacina);

            frunze.Add(radacina);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!wasStarted)
            {
                Start();
                wasStarted = true;
            }
            //for(int i=0;i<1;i++)
            //    Step();

            draw(radacina);
            radacina.extend(0, radacina);
        }

        private void Step()
        {
            frunzeNoi.Clear();
            foreach (var item in frunze)
            {
                frunzeNoi.AddRange(item.extend());
            }
            if (frunzeNoi.Count > 0)
            {
                frunze.Clear();
                frunze.AddRange(frunzeNoi);
            }

            /*foreach (var item in frunze)
            {
               draw(item);
            }*/
        }

        public void draw(Nod nod)
        {
            grp.FillEllipse(Brushes.Black, nod.x, nod.y, size, size);
            grp.DrawEllipse(Pens.Black, nod.x, nod.y, size, size);
            grp.DrawLine(Pens.Black, nod.parentCoord.X + size/2 , nod.parentCoord.Y + size / 2, nod.x+size, nod.y+size/2);
            pictureBox1.Image = bmp;
        }
        private void CW(object str)
        {
            textBox1.Text += str.ToString() + ",";
        }
    }
}

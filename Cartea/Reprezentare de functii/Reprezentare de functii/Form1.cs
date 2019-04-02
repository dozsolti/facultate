using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reprezentare_de_functii
{
    public partial class Form1 : Form
    {
        Graphics grp;
        Bitmap bmp;
        PictureBox canvas;
        Font font = new Font("Arial", 14);

        float padding = 20;
        int dimensiuneGrid = 10;
        float xI ;

        public Form1()
        {
            InitializeComponent();
        }

        public void InitializeazaPanza()
        {
            
            canvas = pictureBox1;
            bmp = new Bitmap(canvas.Width, canvas.Height);
            grp = Graphics.FromImage(bmp);
            grp.Clear(Color.White);
        }
        private void InitializeazaGraficul()
        {
            grp.Clear(Color.White);
            // Linia horizontala (-)
            grp.DrawLine(Pens.Black, 0, canvas.Height/2, canvas.Width,canvas.Height/2);
            // Linia verticala (|)
            grp.DrawLine(Pens.Black, canvas.Width / 2, 0, canvas.Width / 2, canvas.Height);

            for (float i = 0; i <= dimensiuneGrid * 2; i ++)
            {
                if (i == dimensiuneGrid)
                    continue;


                float x = Remap(i,0,dimensiuneGrid*2, padding, canvas.Width- padding);
                grp.DrawLine(Pens.Black, x, canvas.Height / 2-5, x, canvas.Height / 2 + 5);
                grp.DrawString((i - dimensiuneGrid).ToString(), font, Brushes.Black, x, canvas.Height / 2 + 10);

               
                float y = Remap(i, 0, dimensiuneGrid * 2,  canvas.Height - padding, padding);
                grp.DrawLine(Pens.Black, canvas.Width/2-5, y, canvas.Width/2+ 5,y);
                grp.DrawString((i - dimensiuneGrid).ToString(), font, Brushes.Black, canvas.Width / 2 + 10,y);
            }

            canvas.Image = bmp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeazaPanza();
            InitializeazaGraficul();
            xI = -dimensiuneGrid;
            timer1.Start();
            //NOTA: Pentru a scoate animatia scoate variabila xI si timer1 si decomenteaza functiile de mai jos
            /*DeseneazaFunctie(Eq1);
            DeseneazaFunctie(Eq2);
            DeseneazaFunctie(Eq3);
            DeseneazaFunctie(Eq4);*/
        }

        float Eq1(float x)
        {
            return (float)(2 * (float)Math.Sqrt((-(float)Math.Abs((float)Math.Abs(x) - 1)) * (float)Math.Abs(3 - (float)Math.Abs(x)) / (((float)Math.Abs(x) - 1) * (3 - (float)Math.Abs(x)))) * (1 + (float)Math.Abs((float)Math.Abs(x) - 3) / ((float)Math.Abs(x) - 3)) * (float)Math.Sqrt(1 - (x / 7) * (x / 7)) + (5 + 0.97 * ((float)Math.Abs(x - 0.5) + (float)Math.Abs(x + 0.5)) - 3 * ((float)Math.Abs(x - 0.75) + (float)Math.Abs(x + 0.75))) * (1 + (float)Math.Abs(1 - (float)Math.Abs(x)) / (1 - (float)Math.Abs(x))));
        }
        float Eq2(float x)
        {
            return (float)((2.71052 + 1.5 - 0.5 * (float)Math.Abs(x) - 1.35526 * (float)Math.Sqrt(4 - ((float)Math.Abs(x) - 1) * ((float)Math.Abs(x) - 1))) * (float)Math.Sqrt((float)Math.Abs((float)Math.Abs(x) - 1) / ((float)Math.Abs(x) - 1)) + 0.9);
        }
        float Eq3(float x)
        {
            return (float)((-3) * (float)Math.Sqrt(1 - (x / 7) * (x / 7)) * (float)Math.Sqrt((float)Math.Abs((float)Math.Abs(x) - 4) / ((float)Math.Abs(x) - 4)));
        }

        float Eq4(float x)
        {
            return (float)((float)Math.Abs(x / 2) - 0.0913722 * x * x - 3 + (float)Math.Sqrt(1 - ((float)Math.Abs((float)Math.Abs(x) - 2) - 1) * ((float)Math.Abs((float)Math.Abs(x) - 2) - 1)));
        }
        
        private void DeseneazaFunctie(Func<float, float> f, float pas = 0.001f)
        {
            return;
            float marimePunct = 4;
            for (float x = -dimensiuneGrid; x < dimensiuneGrid; x += pas)
            {
                float y = f(x);

                float canvasX = Remap(x, -dimensiuneGrid, dimensiuneGrid, padding, canvas.Width - padding);
                float canvasY = Remap(y, dimensiuneGrid, -dimensiuneGrid, padding, canvas.Height - padding);

                grp.FillEllipse(Brushes.Black, canvasX - marimePunct/2, canvasY - marimePunct/2, marimePunct, marimePunct);
            }
            canvas.Image = bmp;

        }

        float Remap(float value, float from1, float to1, float from2, float to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            float marimePunct = 4;
            //for (float x = -dimensiuneGrid; x < dimensiuneGrid; x += 0.001f)
            {
                {
                    float y = Eq1(xI);
                    float canvasX = Remap(xI, -dimensiuneGrid, dimensiuneGrid, padding, canvas.Width - padding);
                    float canvasY = Remap(y, dimensiuneGrid, -dimensiuneGrid, padding, canvas.Height - padding);
                    grp.FillEllipse(Brushes.Black, canvasX - marimePunct / 2, canvasY - marimePunct / 2, marimePunct, marimePunct);
                    canvas.Image = bmp;

                }
                {
                    float y = Eq2(xI);
                    float canvasX = Remap(xI, -dimensiuneGrid, dimensiuneGrid, padding, canvas.Width - padding);
                    float canvasY = Remap(y, dimensiuneGrid, -dimensiuneGrid, padding, canvas.Height - padding);
                    grp.FillEllipse(Brushes.Black, canvasX - marimePunct / 2, canvasY - marimePunct / 2, marimePunct, marimePunct);
                    canvas.Image = bmp;
                }
                {
                    float y = Eq3(xI);
                    float canvasX = Remap(xI, -dimensiuneGrid, dimensiuneGrid, padding, canvas.Width - padding);
                    float canvasY = Remap(y, dimensiuneGrid, -dimensiuneGrid, padding, canvas.Height - padding);
                    grp.FillEllipse(Brushes.Black, canvasX - marimePunct / 2, canvasY - marimePunct / 2, marimePunct, marimePunct);
                    canvas.Image = bmp;
                }
                {
                    float y = Eq4(xI);
                    float canvasX = Remap(xI, -dimensiuneGrid, dimensiuneGrid, padding, canvas.Width - padding);
                    float canvasY = Remap(y, dimensiuneGrid, -dimensiuneGrid, padding, canvas.Height - padding);
                    grp.FillEllipse(Brushes.Black, canvasX - marimePunct / 2, canvasY - marimePunct / 2, marimePunct, marimePunct);
                    canvas.Image = bmp;
                }
                xI += 0.01f;
            }
        }
    }
}

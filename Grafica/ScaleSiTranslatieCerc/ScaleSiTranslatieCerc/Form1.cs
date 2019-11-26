using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScaleSiTranslatieCerc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Engine.Init(pictureBox1);

            Engine.r = 100;
            Engine.k = 0;
            Engine.theta = Math.PI / (4 * Engine.n);

            Engine.InitValues();
            Engine.Calc();
            Engine.Draw();

            //Scale(1);

            //Translate(new int[] { 10, 100 });
        }

        public void Scale(float s)
        {
            Engine.r *= s;

            Engine.InitValues();
            Engine.Calc();
            Engine.Draw();

        }

        public void Translate(int[] d)
        {
            int[,] m = { { 1, 0, d[0] }, { 0, 1, d[1] }, { 0, 0, 1 } };
            int[] b = { Engine.center.X, Engine.center.Y, 1 };
            int[] newCenter = new int[3];
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    newCenter[i] = 0;
                    for (int k = 0; k < b.Length; k++)
                        newCenter[i] += m[i, k] * b[k];
                }
            }
            Engine.center = new Point(newCenter[0], newCenter[1]);
            Engine.Draw();
        }

    

        private void button2_Click(object sender, EventArgs e)
        {
            Translate(new int[] { 50, 0 });

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Translate(new int[] { -50, 0 });

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Translate(new int[] { 0, -50 });

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Translate(new int[] { 0, 50 });

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Scale( 2 );
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Scale( 0.5f );

        }
    }
}

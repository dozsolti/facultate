using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScalareSiTranslatareElipsa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            Engine.Init(pictureBox1);

            Engine.r1 = 50;
            Engine.r2 = 100;

            Engine.InitValues();
            Engine.Calc();
            Engine.Draw();
        }

        public void Scale(float[] s)
        {
            float[,] m = { { s[0], 0, 0 }, { 0, s[1], 0 }, { 0, 0, 1 } };
            float[] b = { Engine.r1, Engine.r2, 1 };
            float[] newScale = new float[3];
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    newScale[i] = 0;
                    for (int k = 0; k < b.Length; k++)
                        newScale[i] += m[i, k] * b[k];
                }
            }
            Engine.r1 = newScale[0];
            Engine.r2 = newScale[1];

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
            Scale(new float[] { 1, 2 });
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Scale(new float[] { 1, 0.5f });

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Scale(new float[] { 0.5f,1 });

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Scale(new float[] { 2, 1 });

        }
    }
}

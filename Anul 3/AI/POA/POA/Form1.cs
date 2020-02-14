using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Engine.walle == null)
                Engine.walle = new Explorer();
            else
            {
                Engine.grp.Clear(Color.Black);
                for (int i = 0; i < Engine.n; i++)
                    for (int j = 0; j < Engine.m; j++)
                        if (!Engine.fog[i, j])
                            Engine.grp.FillRectangle(new SolidBrush(Color.Green), i * Engine.size, j * Engine.size, Engine.size, Engine.size);
                Engine.grp.FillRectangle(new SolidBrush(Color.Gold), Engine.walle.destination.X * Engine.size, Engine.walle.destination.Y * Engine.size, Engine.size, Engine.size);
                Engine.walle.Do();
                pictureBox1.Image = Engine.bmp;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.Init(this, pictureBox1);
        }
    }
}

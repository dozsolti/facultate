using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticPathFinding
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.Init(pictureBox1);
            Population.Populate();
        }
        public void FastRun()
        {
            for(int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 80; j++)
                {
                    Population.Update();
                }
                Population.Upgrade();
            }
            for (int j = 0; j < 80; j++)
                Population.Update(true);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Population.Update();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FastRun();
        }
    }
}

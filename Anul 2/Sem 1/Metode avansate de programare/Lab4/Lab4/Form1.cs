using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        MyLabel[,] labels;
        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.Init(panel1);
            labels = new MyLabel[Engine.n, Engine.m];
            for(int i=0;i<Engine.n;i++)
                for(int j = 0; j < Engine.m; j++)
                {
                    labels[i, j] = new MyLabel();
                    labels[i, j].AutoSize = false;
                    labels[i, j].Size = new Size(25,25);
                    labels[i, j].Location = new Point(i * 25, j * 25);
                    labels[i, j].BorderStyle = BorderStyle.FixedSingle;
                    labels[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    labels[i, j].Text = Engine.matrix[i, j].ToString();
                    labels[i, j].Parent = panel1;
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}


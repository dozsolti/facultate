using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication38
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Engine.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.Init(pictureBox1);
            Engine.Start();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Engine.Step(e.X, e.Y);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Partial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.Init(pictureBox1,this,label1);
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Engine.Update();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'd':
                    Engine.player.x+=25; 
                    break;
                case 'a':
                    Engine.player.x-=25;
                    break;
                case 'w':
                    Engine.player.Shoot();
                    break;
            }
            
        }

        
    }
}

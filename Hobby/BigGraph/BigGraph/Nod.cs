using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigGraph
{
    public class Nod
    {
        public int x, y, level;
        public int value;
        public Label label;
        public Nod(float x, float y, int val, int level, Color color)
        {
            this.x = (int)x;
            this.y = (int)y;
            this.value = val;
            this.level = level;
            Label label = new Label();
            label.Text = val.ToString();
            label.BackColor = color;
            label.ForeColor = Color.White;
            label.Padding = new Padding(16);
            label.AutoSize = true;
            label.Location = new Point(this.x, this.y);
            label.Parent = Engine.panel1;
            label.Click += Label_Click;
        }

        private void Label_Click(object sender, EventArgs e)
        {
            this.Extend();
        }

        public void Extend()
        {
            int xSpace = 60;
            int y = this.y + 60;

            //2*n for right
            Nod par = new Nod(this.x+xSpace, y, this.value*2,this.level+1, (this.value*2).ToString().Length == 15 ? Color.Blue : Color.Red);
            
            if ((this.value - 1) % 3  == 0 && this.value>2)
            {
                //(n-1)/3 for left
                Nod imPar = new Nod(this.x - xSpace, y, (this.value - 1) / 3, this.level + 1, ((this.value - 1) / 3).ToString().Length==15 ? Color.YellowGreen :  Color.Green);
                
            }
            
        }
    }
}

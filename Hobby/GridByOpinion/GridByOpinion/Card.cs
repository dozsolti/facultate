using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace GridByOpinion
{
    public partial class Card : UserControl
    {
        int index;

        public Card(int ind)
        {
            InitializeComponent();
            this.index = ind;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Engine.Select(this.index);
            pictureBox1.BackColor = Color.PeachPuff;
        }

        public void DrawPattern(int[,] m)
        {
            pictureBox1.BackColor = Color.Transparent;
            Bitmap bmp = new Bitmap(230, 90);
            Graphics grp = Graphics.FromImage(bmp);

            for (int i = 0; i < 23; i++)
                for (int j = 0; j < 9; j++)
                    if (m[i, j] == 1)
                        grp.FillEllipse(Brushes.Black, i * 10, j * 10, 9, 9);
            pictureBox1.Image = bmp;
        }
    }
}

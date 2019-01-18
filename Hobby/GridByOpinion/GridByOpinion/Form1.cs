using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridByOpinion
{
    public partial class Form1 : Form
    {
        int w = 230, h=90;
        int colCount = 3, rowCount = 2;
        int colSpace = 10, rowSpace = 10;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            Engine.cards = new Card[colCount*rowCount];
            int row = 0, col = 0;
            for (int i=0; i < Engine.cards.Length;i++)
            {
                if(col>=colCount)
                {
                    col = 0;
                    row++;
                }

                Engine.cards[i] = new Card(i);
                Engine.cards[i].Parent = panel1;
                Engine.cards[i].Location = new Point(col * (w+colSpace), row * (h+ rowSpace));
                Engine.cards[i].Size = new Size(w, h);
                col++;
            }
            Engine.Start();
        }
    }
}

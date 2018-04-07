using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumereRomane
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string s = "MCMLXXIV";
            int[] v = new int[s.Length];
            for(int i = 0; i < s.Length; i++)
            {
                v[i] = values(s[i]);
            }
            int sum = 0;
            for (int i = 0; i < s.Length-1; i++)
            {
                if (v[i] < v[i + 1])
                    sum -= v[i];
                else
                    sum += v[i];
            }
            sum += v[s.Length-1];
            textBox1.Text = s+"  ";
            textBox1.Text += sum+"  ";
        }

        private int values(char c)
        {
            if (c == 'I') return 1;
            if (c == 'V') return 5;
            if (c == 'X') return 10;
            if (c == 'L') return 50;
            if (c == 'C') return 100;
            if (c == 'D') return 500;
            if (c == 'M') return 1000;
            return 0;
        }
    }
}

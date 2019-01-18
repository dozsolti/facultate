using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tema2
{
    public partial class Form1 : Form
    {
        public string fileName;
        public Form1()
        {
            InitializeComponent();
        }
        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                textBox1.Text = fileName;
            }
        }

        private void cryptButton_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem)
            {
                case "AES":
                    {
                        MessageBox.Show("abc");
                    }
                    break;
            }
        }
    }
}

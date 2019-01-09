using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Criptare
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            MainWindowOnLoad();
            InitializeComponent();
        }
        string cript, key,decript;
        char[,] matrix;
        private void MainWindowOnLoad()
        {
            TextReader dataLoad = new StreamReader(@"../../TextFile1.txt");

            string buffer = dataLoad.ReadLine();
            txtb_msgCript.Text = buffer;
            cript = buffer;

            buffer = dataLoad.ReadLine();
            txb_key.Text = buffer;
            key = buffer;

            int n, m = key.Length;
            n = cript.Length / m;
            matrix = new char[n, m];

            int k = 0;
            for(int i=0;i<n;i++)
                for(int j = 0; j < m; j++)
                {
                    matrix[i, j] = cript[k];
                    k++;
                }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}

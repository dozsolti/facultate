using Microsoft.Win32;
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

namespace Tema2WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            String type = ((ComboBoxItem)sender).Content.ToString();
            Engine.SetAlgorithmType(type);

            Engine.Generate();
            UpdateUI();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == true)
            {
                String fileName = openFileDialog1.FileName;
                textBox.Text = fileName;

                Engine.Input = fileName;
            }
        }
        
        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            Engine.Generate();
            UpdateUI();
        }

        void UpdateUI()
        {
            textBox_Key.Text = Engine.Key;
            textBox_IV.Text = Engine.Iv;
        }



        private void btn_Crypt(object sender, RoutedEventArgs e) {
            Engine.Crypt();
            btnNext_Click(sender,e);
        }
        private void btn_Decrypt(object sender, RoutedEventArgs e) {
            Engine.Decrypt();
            btnNext_Click(sender, e);
        }

        private void ComboBoxItem_Selected_Padding(object sender, RoutedEventArgs e)
        {
            String type = ((ComboBoxItem)sender).Content.ToString();
            Engine.SetPaddingType(type);
        }
        private void ComboBoxItem_Selected_ChiperMode(object sender, RoutedEventArgs e)
        {
            String mode = ((ComboBoxItem)sender).Content.ToString();
            Engine.SetChiperMode(mode);
        }

        private void btnGoodbye_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
        private void btnBack_Click(object sender, RoutedEventArgs e) => viewPort.Margin = new Thickness(viewPort.Margin.Left + 300, 0, 0, 0);
        private void btnNext_Click(object sender, RoutedEventArgs e) => viewPort.Margin = new Thickness(viewPort.Margin.Left - 300, 0, 0, 0);

    }
}

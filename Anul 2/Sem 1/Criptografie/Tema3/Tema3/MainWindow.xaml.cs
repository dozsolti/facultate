using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
using Microsoft.Win32; 
namespace Tema3
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
        HashAlgorithm hashAlgorithm;
        FileStream openFileStream = null;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if(dialog.ShowDialog() == true)
            {
                textBox.Text = dialog.FileName;
                openFileStream = File.Open(dialog.FileName, FileMode.Open);
                openFileStream.Position = 0;
            }

        }

        private async void button1_ClickAsync(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "Incarcare...";
            if (openFileStream == null)
            {
                textBlock.Text = "Trebuie sa selectezi un fisier";
                return;
            }

            InitHashAlgorithm();
            textBlock.Text = await GetHash();
        }
        private async Task<string> GetHash()
        {
            Task<byte[]> hashValue = Task.Run(() => { return hashAlgorithm.ComputeHash(openFileStream); });
            byte[] result = await hashValue;
            return ByteArrayToString(result);
        }
        private void InitHashAlgorithm()
        {
            hashAlgorithm = HashAlgorithm.Create(comboBox.Text);
        }

        public static string ByteArrayToString(byte[] array)
        {
            StringBuilder text = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                text.Append($"{array[i]:X2}");
                if ((i % 4) == 3) text.Append(" ");
            }
            return text.ToString();

        }
    }
}

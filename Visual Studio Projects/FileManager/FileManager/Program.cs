using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            SetFileContent("content");
            Console.WriteLine("{0}",GetFileContent());
            Console.ReadKey();
        }

        private static void SetFileContent(string str)
        {
            TextWriter dl = new StreamWriter(@"./file.txt");
            dl.WriteLine(str);
            dl.Close();
        }

        private static string GetFileContent()
        {
            string str = "";
            TextReader dl = new StreamReader(@"./file.txt");
            string buffer;
            while((buffer = dl.ReadLine())!=null)
            {
                str += buffer;
                str += "\n";
            }
            dl.Close();
            return str;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1
{
    class Program
    {
        static void Main(string[] args)
        {
            Poly caesar = new Poly();
            Console.WriteLine(caesar.Encrypt("abcxyz"));
            Console.ReadKey();
        }
    }
}

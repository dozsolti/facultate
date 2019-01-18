using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tema4
{
    class Program
    {

        static Entity A;
        static void Main(string[] args)
        {
            GenerateKey();
            Console.WriteLine("Encrypt(10)= {0}",Encrypt(10).ToString());
            Console.WriteLine("Decrypt(Encrypt(10))= {0}", Decrypt(Encrypt(10)).ToString());
            Console.WriteLine("done.");
            Console.ReadKey();
        }

        
        static void GenerateKey()
        {
             A = new Entity(RandomSystem.GeneratePrimeRandomBigNumber(), RandomSystem.GeneratePrimeRandomBigNumber());
        }

        static BigInteger Encrypt(BigInteger m)
        {
            return BigInteger.ModPow(m, A.publicKeyE, A.publicKeyN);
        }

        static BigInteger Decrypt(BigInteger c)
        {
            return BigInteger.ModPow(c, A.privateKey, A.publicKeyN);
        }

    }
}

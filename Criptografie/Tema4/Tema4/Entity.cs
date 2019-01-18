using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Tema4
{
    public class Entity
    {
        public BigInteger publicKeyN, publicKeyE, privateKey;
        public Entity(BigInteger p, BigInteger q)
        {
            

            BigInteger n = p * q;
            BigInteger fi = (p - 1) * (q - 1);

            BigInteger e = RandomSystem.GenerateRandomBigNumber(2, fi);
            while (gcd(e, fi) != 1)
                e = RandomSystem.GenerateRandomBigNumber(2, fi);

            BigInteger d = gcdExtended(e,fi);
            d = (d % fi+fi)%fi;
            
            this.publicKeyN = n;
            this.publicKeyE = e;
            this.privateKey = d;


            Console.WriteLine("p=" + p.ToString());
            Console.WriteLine("q=" + q.ToString());
            Console.WriteLine();
            Console.WriteLine("n=" + n.ToString());
            Console.WriteLine("fi=" + fi.ToString());
            Console.WriteLine();
            Console.WriteLine("e=" + e.ToString());
            Console.WriteLine("d=" + d.ToString());
        }

        static BigInteger gcd(BigInteger a, BigInteger b)
        {
            BigInteger r = 0;
            do
            {
                r = a % b;
                a = b;
                b = r;
            } while (b != 0) ;
            return a;
        }
        static BigInteger gcdExtended(BigInteger a, BigInteger b)
        {
            if (b == 0)
                return 1;
            BigInteger x=0, y=0, x2 = 1,x1=0,y2=0,y1=1;
            BigInteger q, r;
            while (b > 0)
            {
                q = a / b;
                r = a - q * b;
                x = x2 - q * x1;
                y = y2 - q * y1;

                a = b;
                b = r;
                x2 = x1;
                x1 = x;
                y2 = y1;
                y1 = y;
            }
            return x2;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tema4
{

    public static class RandomSystem
    {
        private static bool isPrime(BigInteger n)
        {
            //Console.WriteLine("1");
            int k = 20;
            BigInteger d = n - 1;
            int s = 0;
            while(d%2 == 0)
            {
                d = d / 2;
                s++;
            }
            //Console.WriteLine("2");
            //Console.WriteLine("d:{0}",d);

            for (int i = 0; i < k; i++)
            {
                //Console.WriteLine("i:{0}",i);

                BigInteger a = GenerateRandomBigNumber(2,n-1);
                //Console.WriteLine("a:{0}",a.ToString());
                BigInteger x = BigInteger.ModPow(a, d,n );
                //Console.WriteLine("a^d:{0}",x.ToString());
                if(x==1 || x == n - 1)
                {
                    for(int r = 1; r <= s - 1; r++)
                    {
                        x = Pow(x,2) % n;
                        if (x == 1 || x == n - 1)
                            return false;
                    }
                    return false;
                }
            }
            return true;
        }

        public static BigInteger Pow(BigInteger a, BigInteger n)
        {
            BigInteger m;
            if (n == 0)
                return 1;
            if (n % 2 == 0)
            {
                m = Pow(a, n / 2);
                return m * m;
            }
            else
                return a * Pow(a, n - 1);
        }

        public static BigInteger GeneratePrimeRandomBigNumber()
        {
            BigInteger n = GenerateRandomBigNumber(true);
            while (isPrime(n) == false)
                n = GenerateRandomBigNumber(true);
            return n;
        }

        public static BigInteger GenerateRandomBigNumber(bool beOdd = false)
        {
            Random rnd = new Random();
            BigInteger n = 1;
            
            for (int i = 0; i < 15; i++)
                n = n * 10 + rnd.Next(10);

            if(beOdd)
                n = n * 10 + 2 * rnd.Next(5) + 1;
            else
                n = n * 10 + rnd.Next(10);

            return n;
        }

        public static BigInteger GenerateRandomBigNumber(BigInteger min, BigInteger max)
        {
            BigInteger r = GenerateRandomBigNumber()%max;
            while (r < min)
                r = GenerateRandomBigNumber()%max;
            return r;
        }

    }
}

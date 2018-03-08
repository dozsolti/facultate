using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        struct vector
        {
            public int x, y,z;

            public void init()
            {
                Random r = new Random(System.DateTime.Now.Millisecond);

                this.x = r.Next(10);
                this.y = r.Next(10);
                this.z = r.Next(10);

            }
            public string tostring(string name)
            {
                return name+": (" + this.x + ", " + this.y + ", " + this.z + ")";
            }
            public Boolean isEqual(vector c)
            {
                return (this.x==c.x && this.y==c.y && this.z==c.z);
            }

        }

        struct point
        {
            public int x, y;
            public void init()
            {
                Random r = new Random(System.DateTime.Now.Millisecond);

                this.x = r.Next(10);
                this.y = r.Next(10);
            }
            public string tostring(string name)
            {
                return name + ": (" + this.x + ", " + this.y + ")";
            }
            public Boolean isEqual(point c)
            {
                return (this.x == c.x && this.y == c.y);
            }
        }
        static void Main(string[] args)
        {
            //Exercitiul1();
            //Exercitiul2();
            //Exercitiul3();
            Exercitiul4();
            Console.ReadKey();
        }
        private static void Exercitiul4()
        {
            //a.x = 1;a.y = 3;
            point dp1 = new point();
            point dp2 = new point();

            dp1.init();
            dp2.init();
            point m = new point();

            m.init();
            while (dp2.isEqual(m))
                m.init();

            Console.WriteLine(dp1.tostring("dp1"));
            Console.WriteLine(dp2.tostring("dp2"));
            Console.WriteLine(m.tostring("m"));


            int a = sumMatrix(dp1.y, 1, dp2.y, 1);
            int b = sumMatrix(dp2.x, 1, dp1.x, 1);
            int c = sumMatrix(dp1.x, dp1.y, dp2.x, dp2.y);


            float dis = (float)( Math.Abs(a*m.x+b*m.y+c) / Math.Sqrt(a*a+c*c));
            Console.WriteLine("dist(M0,d)={0}",dis);

        }
        
        private static void Exercitiul3()
        {
            point a = new point();
            point b = new point();

            //a.x = 1;a.y = 3;
            //b.x = 4;b.y = 5;

            a.init();b.init();

            Console.WriteLine(a.tostring("a"));
            Console.WriteLine(a.tostring("b"));

            int qX = sumMatrix(a.y, 1, b.y, 1);
            int qY = sumMatrix( b.x, 1, a.x, 1);
            int qR = sumMatrix(a.x,a.y,b.x,b.y);

            Console.WriteLine("d: {0}*x+{1}*y+{2}=0",qX,qY,qR);

        }

        private static void Exercitiul2()
        {
            vector a = new vector();
            vector b = new vector();
            vector c = new vector();

            a.init(); b.init();
            c.init();

            while (b.isEqual(c))
                c.init();

            Console.WriteLine(a.tostring("a"));
            Console.WriteLine(b.tostring("b"));
            Console.WriteLine(c.tostring("c"));

            int sum = volum(a, b,c);

            Console.WriteLine("volum: "+Math.Abs(sum));
        }

        private static void Exercitiul1()
        {
            vector a = new vector();
            vector b = new vector();

            a.init(); b.init();

            Console.WriteLine(a.tostring("a"));
            Console.WriteLine(b.tostring("b"));
            string sum = produsScalar(a, b);

            Console.WriteLine("axb= " +sum);
        }

        private static string produsScalar(vector a, vector b)
        {
            string str = "";

            str += "i*";
            str += (sumMatrix(a.y,a.z,b.y,b.z)).ToString();
            str += "-j*";
            str += (sumMatrix(a.x, a.z, b.x, b.z)).ToString();
            str += "+k*";
            str += (sumMatrix(a.x, a.y, b.x, b.y)).ToString();
            return str;
        }

        private static vector produsScalarVector(vector a, vector b)
        {
            vector n = new vector();
            n.x = (sumMatrix(a.y, a.z, b.y, b.z));
            n.y = (sumMatrix(a.x, a.z, b.x, b.z));
            n.z = (sumMatrix(a.x, a.y, b.x, b.y));
            return n;
        }

        private static int volum(vector a, vector b, vector c)
        {
            vector _prodScalar = produsScalarVector(b,c);
            return a.x * _prodScalar.x + a.y * _prodScalar.y + a.z * _prodScalar.z;
        }

        /* General Staff */
        private static int sumMatrix(int a,int b,int c,int d)
        {
            return (a * d) - (b * c);
        }
    }
}

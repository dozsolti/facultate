using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partial
{
    class Program
    {
        static void Main(string[] args)
        {
            // ex1();
            //int[] v = new int[] { 1, 0, 12, 0, 2, 0, 2, 0, 0, 0, 8, 0, 1 };
            //v = Ex1((v));
            //print("V: ", v,"vector");
            /*
             * Exercitiul 2
            int[,] mat = new int[,] { { 1,2,3}, {4,5,6 }, {7,8,9 } };
            mat = Ex2(mat);
            for (int i = 0; i < mat.GetLength(0); i++) {
                Console.WriteLine();
                for (int j = 0; j < mat.GetLength(1); j++)
                    Console.Write(mat[i,j]+" ");
            }*/
            /*
             * Exercitiul 3
            int[] v = new int[] { 1, 0, 4, 4, 4, 4, 0, 1, 1, 0, 1, 1, 0, 0, 0, 4, 2, 1, 1, 0, 1 };
            Ex3(v);
            */
            /*
             * Exercitiul 4
            int n = 800020831;
            Console.WriteLine(Ex4(n));
            */
            Console.WriteLine(DateTime.MinValue);
            Console.WriteLine(Ex5(23, 04, 2011, 13, 23, 47));
            /*int[,] mat = new int[9,9];
            mat = Ex6(mat);
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < mat.GetLength(1); j++)
                    Console.Write(mat[i, j] + " ");
            }*/

            Console.ReadKey();
        }

        private static int[,] Ex6(int[,] mat)
        {
            for(int i=0;i<mat.GetLength(0);i = i+2)
            {
                mat = Rama(mat, i, mat.GetLength(0));
            }
            return mat;
        }
        private static int[,] Rama(int[,] mat, int k,int n)
        {
            for (int i = k; i < n - k; i++)
                mat[k,i] = 1;
            for (int i = k; i < n - k; i++)
                mat[n-1-k, i] = 1;

            for (int i = k; i < n - k; i++)
                mat[i, n-1-k] = 1;

            for (int i = k; i < n - k; i++)
                mat[i,k] = 1;

            return mat;
        }

        private static long Ex5(int zi, int luna, int an, int ora, int min, int sec)
        {
            /*long raspuns=ToSec(1,"ora");
            raspuns += sec;
            raspuns += ToSec(sec, "min");
            raspuns += ToSec(sec,"ora");
            raspuns += ToSec(sec,"zi");
            raspuns += ToSec(sec,"luna");
            raspuns += ToSec(sec,"an");*/
            DateTime dt = new DateTime(an, luna, zi, ora, min, sec);
            TimeSpan tp = dt - DateTime.MinValue;
            return (long)tp.TotalSeconds;
        }

        private static long ToSec(long val, string v)
        {
            /*
            if (v == "min")
            {
                return ToSec(val * 60, "sec");
            }
            if (v == "ora")
            {
                return ToSec(val*60, "min");
            }
            if (v == "zi")
            {
                
                return ToSec(val*24, "ora");
            }
            if (v == "luna")
            {
                return ToSec(MToD(val), "zi");
            }
            if (v == "an")
            {
                val = (val * 365) + (int)Math.Floor(((decimal)val) / 4);
                return ToSec(val * 365, "zi");
            }
            else
            */    return val;//val = sec
            
        }

        /*private static long MToD(long val)
        {
        }*/

        private static int Ex4(int n)
        {
            int[] v = new int[10];
            int _temp = n;
            while (_temp > 0){
                v[_temp % 10]++;
                _temp /= 10;
            }

            int newN = 0;
            for(int i = 1; i < v.Length; i++) {
                if(v[i]>0)
                {
                    newN = i;
                    v[i]--;
                    break;
                }
            }
            for (int i = 0; i < v.Length; i++)
            {
                for (int j = 0; j < v[i]; j++)
                {
                    newN = newN*10+ i;
                }
            }
            return newN;
        }

        private static void Ex3(int[] v)
        {
            for(int i = v.Length - 1; i > 0; i--)
            {
                if(v[i] == v[i-1] && v[i] > 0)
                {
                    v[i] *= 2;
                    v[i - 1] = -1;
                }
                v = RezEx3(v);
            }
            print("V: ", v, "vector");
        }

        private static int[] RezEx3(int[] v2)
        {

            int nrz = 0;
            for (int i = 0; i < v2.Length; i++)
                if (v2[i] == -1)
                    nrz++;
            int[] v3 = new int[v2.Length - nrz];
            int k = 0;
            for (int i = 0; i < v2.Length; i++)
                if (v2[i] != -1)
                {
                    v3[k] = v2[i];
                    k++;
                }
            return v3;
        }

        private static bool existaUrmPas(int[] v)
        {
            for (int i = 0; i < v.Length - 1; i++)
            {
                if (v[i] == v[i + 1])
                    return true;
            }
            return false;
        }
        private static int[,] Ex2(int[,] mat)
        {
            int n = mat.GetLength(0);
            int m = mat.GetLength(1);

            int[,] mat2 = new int[n, m];
            /*for(int i=0;i<n;i++)
                for (int j = 0; j < m; j++)
                {
                    mat2[i, j] = mat[ (i + j) % n,0];
                }*/
            /*for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    mat2[i, j] = mat[j,i]+ mat[(i + j) % n, (i * j) % m];
                }*/
            return mat2;
        }

        private static int[] Order(int[] v)
        {
            for(int i = 0; i < v.Length; i++)
            {
                for (int k = i; k>0 && v[k]<v[k-1];k--) {
                    swap(ref v[k], ref v[k - 1]);
                }
            }
            return v;
        }

        private static void swap(ref int v1, ref int v2)
        {
            int temp = v1;
            v1 = v2;
            v2 = temp;
        }

        private static int[] Ex1(int[] v)
        {
            int nrz = 0;
            for (int i = 0; i < v.Length; i++)
                if (v[i] == 0)
                    nrz++;
            int[] v2 = new int[v.Length - nrz];
            int k = 0;
            for (int i = 0; i < v.Length; i++)
                if (v[i] != 0)
                {
                    v2[k] = v[i];
                    k++;
                }
            return v2;
        }

        private static void print(string name, int[] v, string type)
        {
            string str = "";
            str = name + ": ";
            for (int i = 0; i < v.Length; i++)
                str += /*"i:"+i.ToString()+" "+ */v[i].ToString() + " ";
            Console.WriteLine(str);
        }
    }
}


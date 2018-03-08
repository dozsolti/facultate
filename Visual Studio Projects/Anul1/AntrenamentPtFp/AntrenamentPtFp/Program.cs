using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntrenamentPtFp
{
    class Program
    {
        static int[,] a;
        static int[] s;
        static int n = 5,m=5;
        static void Main(string[] args)
        {
            int lungime=0, valoare=9999;
            s = new int[] { 1, 2, 3, 4, 2, 2, 4, 4, 4, 5, 5,5, 1, 1, 1 };
            

                /*for (int i = 0; i < s.Length; i++)
                    s[i] = s.Length - i;

                for (int i = 0; i < s.Length; i++)
                    Console.Write("{0} ",s[i]);

                //SortBubble();
                //SortSelection();
                //SortInsertion();

                Console.WriteLine();
                for (int i = 0; i < s.Length; i++)
                    Console.Write("{0} ", s[i]);*/

                Console.ReadKey();
        }

        private static int[] getPlatou(int startIndex, int[] s)
        {

            int[] platou = new int[2]; // platou[0] va fi lungimea, platou[1] va fi valoarea
            int j = startIndex;
            while(s[j]== s[j + 1])
            {
                j++;
                if (j == s.Length - 1)
                    break;
            }
            platou[0] = j - startIndex + 1;
            platou[1] = s[startIndex];
            return platou;
        }

        static void SortInsertion()
        {
            for(int i = 1; i < s.Length; i++)
            {
                for (int j = i; j > 0 && s[j] < s[j - 1]; j--)
                    swap(ref s[j], ref s[j - 1]);
            }
        }
        static void SortSelection()
        {
            int k;
            for(int i = 0; i < s.Length; i++)
            {
                k = i;
                for (int j = i; j < s.Length; j++)
                {
                    if (s[k] > s[j])
                        k = j;
                }
                swap(ref s[k], ref s[i]);
            }
        }
        static void SortBubble()
        {
            bool swaped = false;
            for(int i = 0; i < s.Length; i++)
            {
                swaped = false;
                for (int j = s.Length-1; j>i; j--)
                {
                    if (s[j] < s[j - 1])
                    {
                        swap(ref s[j], ref s[j - 1]);
                        swaped = true;
                    }
                }
                if (!swaped)
                    break;
            }
        }
        static void Matricie()
        {
            a = new int[n, m];
            /*int k = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++) {
                    k++;
                    a[i, j] = k;
                }
            printA();
            a = RotateA("left");
            a = RotateA("right");
            printA();
            */
            
            /*
             * Deasupra diagonalei principale
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n-1-i; j++)
                a[i, j] = 1;
            */
            /*
             * Sub diagona principale
            for (int i = 0; i < n; i++)
                for (int j = n -1- i; j < n; j++)
                    a[i, j] = 1;*/

            /*for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    //if(j>n-1-i && j<i) //sud
                    //if(j>i && j<n-1-i) //nord
                    //if(j<i && j<n-1-i) //west
                    //if(j>n-1-i && i<j) //est
                        a[i, j] = 1;
            */
            for (int i = 0; i < n; i++)
                a[i, n - 1 - i] = 2;
            /*
             * Sub diagonala secundara
            for (int i = 0; i < n; i++)
                for (int j = n-i; j < m; j++)
                    a[i, j] = 1;
            */
            /*
             * Deasupra diagonala secundara
             * */
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m - 1 - i; j++)
                    a[i, j] = 1;

            printA();
        }
        private static int[,] RotateA(string dir)
        {
            for (int i = 0; i < n / 2; i++)
                for (int j = i; j < m - 1 - i; j++)
                {
                    if (dir == "right")
                    {
                        Rotate(i, j, dir);

                    }
                    else
                    {

                        Rotate(i, j, dir);
                    }
                }
            return a;
        }

        private static void Rotate(int i, int j,string dir)
        {
            if (dir == "right")
            {
                swap(ref a[i, j], ref a[m - 1 - j, i]);
                swap(ref a[m - 1 - j, i], ref a[n - 1 - i, m - 1 - j]);
                swap(ref a[n - 1 - i, m - 1 - j], ref a[j, m - 1 - i]);
            }else
            {
                swap(ref a[n - 1 - i, m - 1 - j], ref a[j, m - 1 - i]);
                swap(ref a[m - 1 - j, i], ref a[n - 1 - i, m - 1 - j]);
                swap(ref a[i, j], ref a[m - 1 - j, i]);
            }

        }

        private static void swap(ref int v1, ref int v2)
        {
            int temp = v1;
            v1 = v2;
            v2 = temp;
        }

        private static void printA()
        {
            for (int i = 0; i < n; i++) {
                Console.WriteLine();
                for (int j = 0; j < m; j++)
                {
                    //if(a[i,j]<10)
                    //    Console.Write("0{0} ",a[i, j]);
                    //else
                        Console.Write("{0} ",a[i, j]);
                }
            }
        }
    }
}

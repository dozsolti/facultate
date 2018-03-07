using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangtonAnt
{
    class Program
    {
        static int antX,antY, antDir;
        // 0 = up , abs(antDir mod 4) | dir-- => rotToLeft | dir++ => rotToRight
        static int[,] m;
        static int n;
        static Random rnd;

        static void Main(string[] args)
        {

            rnd = new Random();
            n = 45;
            m = new int[n, n];

            antX = n/2;
            antY = n/2;
            antDir = 0;

            for(int i=0;i<11000;i++)
            {
                Move();
                //System.Threading.Thread.Sleep(1);

            }
            Draw();

            Console.WriteLine("Terminat.");
            Console.ReadKey();
        }

        private static void Move()
        {
            if (m[antY, antX]%2 == 0)
            {
                Turn("right");
                m[antY, antX] = rnd.Next(20)*2+1;
                MoveForward();
            }else
            {
                Turn("left");
                m[antY, antX] = rnd.Next(20) * 2 ;
                MoveForward();
            }
        }

        private static void Turn(string v)
        {
            if(v == "right")
                antDir ++;
            else
                antDir --;

            if (antDir > 3)
                antDir = 0;

            if (antDir < 0)
                antDir = 3;
        }

        private static void MoveForward()
        {
            
            if (antDir == 0)
            {
                //up
                antY--;
                if (antY < 0)
                    antY = n-1;
            }
            if (antDir == 2)
            {
                //down
                antY++;
                if (antY > n - 1)
                    antY = 0;
            }

            if (antDir == 1)
            {
                //right
                antX++;
                if (antX > n - 1)
                    antX = 0;
            }
            if (antDir == 3)
            {
                //left
                antX--;
                if (antX < 0)
                    antX = n - 1;
            }
        }

        private static void Draw()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i==antY && j ==antX)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("██");
                    }else
                    {
                        if (m[i, j] %2 == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("██");

                        }
                        else
                        {
                            int nr = rnd.Next(100);
                            if (nr < 20)
                                Console.ForegroundColor = ConsoleColor.Gray;
                            else if (nr < 40)
                                Console.ForegroundColor = ConsoleColor.Red;
                            else if (nr < 60)
                                Console.ForegroundColor = ConsoleColor.Green;
                            else if (nr < 80)
                                Console.ForegroundColor = ConsoleColor.Blue;
                            else
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("██");
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace FloatAsList
{
    public partial class Floatz
    {
        public static class Teste
        {
            public static void RunAllTests()
            {
                if (!Floatz.Teste.TestAdunare().StartsWith("Nu"))
                {
                    Console.WriteLine(Floatz.Teste.TestAdunare()); Console.ReadKey();
                }
                else if (!Floatz.Teste.TestScadere().StartsWith("Nu"))
                {
                    Console.WriteLine(Floatz.Teste.TestScadere()); Console.ReadKey();
                }
                else if (!Floatz.Teste.TestInmultire().StartsWith("Nu"))
                {
                    Console.WriteLine(Floatz.Teste.TestInmultire()); Console.ReadKey();
                }
                else if (!Floatz.Teste.TestComparari().StartsWith("Nu"))
                {
                    Console.WriteLine(Floatz.Teste.TestComparari()); Console.ReadKey();
                }

                else if (!Floatz.Teste.TestDeCateOriIntra().StartsWith("Nu"))
                {
                    Console.WriteLine(Floatz.Teste.TestDeCateOriIntra()); Console.ReadKey();
                }
                else
                    Console.WriteLine("Nu exista probleme.");

            }
            public static string TestAdunare()
            {
                object[,] teste = new object[,] {
                    { "0","0","0" },
                    { "1","1","2" },
                    { "1","2","3"},
                    { "1","3","4"},
                    { "2","4","6"},
                    { "6","12","18"},
                    { "24","12","36"},
                    { "113","355","468"},
                    { "0,5","0,16","0,66" },
                    { "0,16","0,5","0,66" },
                    { "0,5","0,166","0,666" },
                    {"0,00416666","0,66666666","0,67083332" }
                };

                string str = "";
                for (int i = 0; i < teste.GetLength(0); i++)
                {
                    Floatz a = new Floatz((string)teste[i, 0]);
                    Floatz b = new Floatz((string)teste[i, 1]);
                    Floatz resultCorrect = new Floatz((string)teste[i, 2]);

                    Floatz result = a + b;

                    if (result != resultCorrect)
                        str += String.Format(
                            "\n Test failed:Adunare #{0} nereusita.\n \n {1}+\n {2}=\n {3} |corect e: {4}\n\n",
                            i, a, b, result, resultCorrect
                        );
                }
                if (str == "")
                    return "Nu exista probleme la Adunare.";
                return str;
            }
            public static string TestDeCateOriIntra()
            {
                object[,] teste = new object[,] {
                    { "0","0","0" },
                    { "1","1","1" },
                    { "1","2","2"},
                    { "1","3","3"},
                    { "2","4","2"},
                    { "6","12","2"},
                    { "24","12","0"},
                    { "113","355","3"},
                    { "456","1368","3"},
                    { "74916","674244","9"},
                    { "44","1242","28" },
                    { "51","500","9" }
                };

                string str = "";
                for (int i = 0; i < teste.GetLength(0); i++)
                {
                    List<int> b = new List<int>();

                    for (int j = 0; j < ((string)teste[i, 0]).Length; j++)
                        b.Add(Floatz.charToInt(((string)teste[i, 0])[j]));

                    List<int> temp = new List<int>();
                    for (int j = 0; j < ((string)teste[i, 1]).Length; j++)
                        temp.Add(Floatz.charToInt(((string)teste[i, 1])[j]));
                    List<int> resultCorrect = new List<int>();
                    for (int j = 0; j < ((string)teste[i, 2]).Length; j++)
                        resultCorrect.Add(Floatz.charToInt(((string)teste[i, 2])[j]));

                    List<int> result = Floatz.DeCateOriIntra(b, temp);
                    if (Floatz.Compare2Lists(result, resultCorrect) != 0)
                        str += String.Format(
                            "\n Test failed:DeCateOriIntra #{0} nereusita.\n \n b={1},temp={2}, result={3} |corect e: {4}\n\n",
                            i, Floatz.ListToString(b), Floatz.ListToString(temp), Floatz.ListToString(result), Floatz.ListToString(resultCorrect)
                        );
                }
                if (str == "")
                    return "Nu exista probleme la DeCateOriIntra.";
                return str;
            }
            public static string TestImpartire()
            {
                object[,] testeComparari = new object[,] {
                   { "4","2","2" },
                   { "355","113","3,14159292035398230088" },
                   {  "6","2","3" }
                };

                string str = "";
                for (int i = 0; i < testeComparari.GetLength(0); i++)
                {
                    Floatz a = new Floatz((string)testeComparari[i, 0]);
                    Floatz b = new Floatz((string)testeComparari[i, 1]);
                    Floatz resultCorrect = new Floatz((string)testeComparari[i, 2]);
                    Floatz c = a / b;

                    if (c != resultCorrect)
                        str += String.Format(
                            "\n Test failed:Impartire #{0} nereusita.\n \n {1}/{2}={3} |corect e: {4}\n\n",
                            i, a.ToString(), b.ToString(), c.ToString(), resultCorrect.ToString()
                        );
                }
                if (str == "")
                    return "Nu exista probleme la impartire.";
                return str;
            }

            public static string TestInmultire()
            {
                object[,] testeComparari = new object[,] {
                    { "0,0","0,0","0,0" },
                    { "0","1","0,0" },
                    { "1","1","1,0"},
                    { "2","1","2,0"},
                    { "2","2","4,0"},
                    { "2","6,2","12,4"},
                    { "384,1789454","-1","-384,1789454" },
                    { "3,1415","3,1415","9,86902225" },
                    { "31415","31415","986902225" },
                    { "384,1789454","98,87546","37985,869948739884" },
                    { "456","2","912,0" }
                };

                string str = "";
                for (int i = 0; i < testeComparari.GetLength(0); i++)
                {
                    Floatz a = new Floatz((string)testeComparari[i, 0]);
                    Floatz b = new Floatz((string)testeComparari[i, 1]);
                    Floatz resultCorrect = new Floatz((string)testeComparari[i, 2]);
                    Floatz c = Floatz.Multiply(a, b);

                    if (c != resultCorrect)
                        str += String.Format(
                            "\n Test failed:Inmultirea #{0} nereusita.\n \n {1}*{2}={3} |corect e: {4}\n\n",
                            i, a.ToString(), b.ToString(), c.ToString(), resultCorrect.ToString()
                        );
                }
                if (str == "")
                    return "Nu exista probleme la inmultirea.";
                return str;
            }
            public static string TestScadere()
            {
                object[,] testeComparari = new object[,] {
                    { "0","0","0,0" },
                    { "0","1","-1,0" },
                    { "1","0","1,0"},
                    { "2","1","1,0"},
                    { "1,32","1,12","0,2"},
                    { "1,2","1","0,2"},
                    { "-1,2","1,0","-2,2"},
                    { "1","-1,2","2,2"},
                    {"3,46666","0,57","2,89666"},
                    {"10","1","9,0" },
                    {"101","2","99,0" },
                    {"204,8900000011920928955078125","256", "-51,1099999"}
                };

                string str = "";
                for (int i = 0; i < testeComparari.GetLength(0); i++)
                {
                    Floatz a = new Floatz((string)testeComparari[i, 0]);
                    Floatz b = new Floatz((string)testeComparari[i, 1]);
                    string resultCorrect = (string)testeComparari[i, 2];
                    Floatz c = a - b;
                    if (c.ToString() != resultCorrect)
                        str += String.Format(
                            "\n Test failed:Scaderea #{0} nereusita.\n \n {1}-{2}={3} |corect e: {4}\n\n",
                            i, a.ToString(), b.ToString(), c.ToString(), resultCorrect
                        );
                }
                if (str == "")
                    return "Nu exista probleme la scadere.";
                return str;
            }
            public static string TestComparari()
            {
                object[,] testeComparari = new object[,] {
                    { "0",'<',"1",true },
                    { "1",'<',"0",false},
                    { "-1",'>',"2",false },
                    { "-1",'<',"2",true},
                    { "-1",'<',"-2",false},
                    { "-1",'>',"-2",true},
                    { "-1",'<',"0",true},
                    {"3,14159265358979323846264338327950",'>',"2,71828182845904523536028747135266",true },
                    { "-1.123123",'<',"-1.123023",true},
                    { "1,32",'>',"1,12",true},
                    { "1,2",'>',"0,2",true},
                    { "1,32",'<',"1,12",false},
                    { "1,2",'<',"0,2",false},
                    { "-1,2",'<',"1",true},
                    { "-1,2",'>',"1",false},
                    { "1",'<',"-1,2",false},
                    { "1",'>',"-1,2",true},
                    {"1,0000000000000000000" ,'>',"1",false},
                    {"1,0000000000000000000" ,'<',"1",false},
                    { "9",'<',"355",true },
                    { "355",'>',"9",true}
                };

                string str = "";
                for (int i = 0; i < testeComparari.GetLength(0); i++)
                {
                    Floatz a = new Floatz((string)testeComparari[i, 0]);
                    Floatz b = new Floatz((string)testeComparari[i, 2]);
                    bool result = (bool)testeComparari[i, 3];
                    char type = (char)testeComparari[i, 1];
                    if (type == '<')
                    {
                        if ((a < b) != result)
                            str += String.Format("\n Test failed:Compararea #{2} nereusita.\n \n {3}<{4}={0} |corect e: {1}\n\n", (a < b), result, i, a.ToString(), b.ToString());
                    }
                    else
                    {
                        if ((a > b) != result)
                            str += String.Format("\n Test failed:Compararea #{2} nereusita.\n \n {3}>{4}={0} |corect e: {1}\n\n", (a > b), result, i, a.ToString(), b.ToString());
                    }
                }
                if (str == "")
                    return "Nu exista probleme la comparari.";
                return str;
            }

            public static string TestPow()
            {
                object[,] testeComparari = new object[,] {
                    { "0","9","0,0" },
                    { "1","0","1,0" },
                    { "1","1","1,0"},
                    { "2","1","2,0"},
                    { "2","3","8,0" },
                    { "2","10","1024,0" },
                    { "20","9","512000000000,0" },
                    { "4","0,5","2" },
                    { "256","0,25","4" },
                    { "4","0,5","2" },
                    { "256","0,4","4" },
                    {"2","0,5","1" }
                };

                string str = "";
                for (int i = 0; i < testeComparari.GetLength(0); i++)
                {
                    Floatz a = new Floatz((string)testeComparari[i, 0]);
                    Floatz b = new Floatz((string)testeComparari[i, 1]);
                    //Console.WriteLine("{0}->{1}",b.ToString(),b.isOne());
                    string resultCorrect = (string)testeComparari[i, 2];
                    Floatz c = Floatz.Pow(a, b);
                    if (c.ToString() != resultCorrect)
                        str += String.Format(
                            "\n Test failed:Putere #{0} nereusita.\n \n Pow({1};{2})={3} |corect e: {4}\n\n",
                            i, a.ToString(), b.ToString(), c.ToString(), resultCorrect
                        );
                }
                if (str == "")
                    return "Nu exista probleme la putere.";
                return str;
            }

        }
    }
}

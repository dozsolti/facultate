using System;
using System.Collections.Generic;
using System.Linq;

namespace FloatAsList
{
    public partial class Floatz
    {
        public static class Teste
        {
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
                        b.Add( Floatz.charToInt(((string)teste[i, 0])[j]));

                    List<int> temp = new List<int>();
                    for (int j = 0; j < ((string)teste[i, 1]).Length; j++)
                        temp.Add(Floatz.charToInt(((string)teste[i, 1])[j]));
                    List<int> resultCorrect = new List<int>();
                    for (int j = 0; j < ((string)teste[i, 2]).Length; j++)
                        resultCorrect.Add(Floatz.charToInt(((string)teste[i,2])[j]));

                    List<int> result = Floatz.DeCateOriIntra(b,temp);
                    if (Floatz.Compare2Lists(result,resultCorrect)!=0)
                        str += String.Format(
                            "\n Test failed:DeCateOriIntra #{0} nereusita.\n \n b={1},temp={2}, result={3} |corect e: {4}\n\n",
                            i,Floatz.ListToString(b), Floatz.ListToString(temp), Floatz.ListToString(result), Floatz.ListToString(resultCorrect)
                        );
                }
                if (str == "")
                    return "Nu exista probleme la DeCateOriIntra.";
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
                    { "-1,2","1","-2,2"},
                    { "1","-1,2","2,2"}
                };

                string str = "";
                for (int i = 0; i < testeComparari.GetLength(0); i++)
                {
                    Floatz a = new Floatz((string)testeComparari[i, 0]);
                    Floatz b = new Floatz((string)testeComparari[i, 1]);
                    string resultCorrect = (string)testeComparari[i, 2];
                    Floatz c = Floatz.Subtract(a, b);
                    c.ComprimaZecimala();
                    if(c.ToString()!=resultCorrect)
                            str += String.Format(
                                "\n Test failed:Scaderea #{0} nereusita.\n \n {1}-{2}={3} |corect e: {4}\n\n",
                                i,a.ToString(),b.ToString(),c.ToString(),resultCorrect
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
                    {"3,14159265358979323846264338327950",'>',"2,71828182845904523536028747135266",true },
                    { "-1",'>',"2",false },
                    { "-1",'<',"2",true},
                    { "-1",'<',"2",true},
                    { "-1",'<',"-2",false},
                    { "-1",'>',"-2",true},
                    { "-1",'<',"0",true},
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
        }
    }
}

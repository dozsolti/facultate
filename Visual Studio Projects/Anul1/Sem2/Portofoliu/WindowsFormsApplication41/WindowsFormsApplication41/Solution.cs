using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication41
{
    public class Solution
    {
        public int[] values;

        public float FAdec()
        {
            float s = 0;
            for (int j = 0; j < Engine.v.Length; j++)
                for (int i = 0; i < values.Length; i++)
                {
                    if (Engine.v[j] == values[i])
                    {
                        if (i == j)
                            s += 10;
                        else
                            s++;
                    }
                }
            return s;
        }

        public string View()
        {
            string s = "";
            for (int i = 0; i < values.Length; i++)
                s += values[i].ToString();
            s += ","+FAdec().ToString();
            return s;
        }

        public Solution()
        {
            values = new int[Engine.n];

            for (int i = 0; i < values.Length; i++)
            {
                int nr = Engine.r.Next(10);

                while (isInValues(nr))
                    nr = Engine.r.Next(10);
                
                values[i] = nr;
            }

        }

        public bool isInValues(int x)
        {
            for (int i = 0; i < values.Length; i++)
                if (values[i] == x)
                    return true;
            return false;

        }
    }
}

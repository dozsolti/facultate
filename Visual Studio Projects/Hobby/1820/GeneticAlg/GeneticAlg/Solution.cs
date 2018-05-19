using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlg
{
    public class Solution
    {
        public long values;
        public int steps;

        public void CalcSteps()
        {
            long n = this.values;
            int p = 0;
            do
            {
                p++;
                if (n % 2 == 0)
                    n = n / 2;
                else
                    n = n * 3 + 1;
            } while (n != 1);
            this.steps = p;
        }

        public string View()
        {
            return values.ToString() + "," + this.steps.ToString(); ;
        }

        public Solution()
        {
            values = Engine.r.Next(1,10);
            for (int i = 1; i < 15; i++) 
                values = values * 10 + Engine.r.Next(10);
            CalcSteps();
        }
    }
}

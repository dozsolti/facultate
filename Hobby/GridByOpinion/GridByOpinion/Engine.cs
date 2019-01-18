using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridByOpinion
{
    public static class Engine
    {
        public static Random rnd = new Random();
        public static int count = 0;
        public static List<int[,]> cardsPattern = new List<int[,]>();
        public static Card[] cards;

        public static void Start() {
            for(int i = 0; i < cards.Length; i++)
            {
                int[,] m = GridManager.GetRandomGrid();
                cardsPattern.Add(m);
                cards[i].DrawPattern(m);
            }
        }
        public static void Select(int selected)
        {

            for (int i = 0; i < cards.Length; i++)
            {
                if (i != selected)
                {
                    int[,] m = GridManager.Mutate(cardsPattern[i]);
                    cardsPattern[i] = m;
                    cards[i].DrawPattern(m);
                }
            }
        }
    }
}

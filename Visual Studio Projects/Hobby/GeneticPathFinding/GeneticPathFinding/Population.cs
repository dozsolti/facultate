using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticPathFinding
{
    public class Population
    {
        public static int keep = 200;
        public static int popSize = 500;
        public static List<Bird> birds;

        public static void Populate()
        {
            birds = new List<Bird>();
            birds.Clear();
            for (int i = 0; i < popSize; i++)
                birds.Add(new Bird());
        }
        public static void Update(bool wDraw=false)
        {
            Engine.Grid();
            foreach (Bird bird in birds)
            {
                bird.Move();
                if(wDraw)
                    bird.Draw();

            }
            for (int i = birds.Count - 1; i >= 0; i--) {
                if (birds[i].isOut())
                    Population.birds.Remove(birds[i]);
                else if (birds[i].position == Engine.food)
                    birds[i].finished = true;
                    }
        }

        public static void Upgrade()
        {
            birds.Sort(delegate (Bird a,Bird b){ return (int) (a.GetFitness()-b.GetFitness()); });

            List<Bird> newBirds = new List<Bird>();
            for (int i = 0; i < Math.Min(birds.Count, keep); i++)
                newBirds.Add(new Bird(birds[i]));
            
            for(int i = 0; i < Math.Min(birds.Count, keep); i++)
                    newBirds.Add(birds[i].Mutate());

            for(int i = Math.Min(birds.Count, keep); i < popSize ; i++)
                newBirds.Add(new Bird());
            birds.Clear();
            foreach (Bird bird in newBirds)
                birds.Add(bird);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;

namespace GeneticPathFinding
{
    public enum POS { UP = 0, DOWN, LEFT, RIGHT }
    public class Bird
    {
        public List<POS> moves;
        public int movesI;
        public PointF position;
        public bool finished;

        public Bird()
        {
            position = new PointF(20 * Engine.size, 10 * Engine.size);
            movesI = 0;
            moves = new List<POS>();

            for (int i = 0; i < Engine.rnd.Next(30, 80); i++)
                moves.Add((POS)Engine.rnd.Next(4));

        }

        public Bird(Bird _bird)
        {
            finished = _bird.finished;
            position = new PointF(20 * Engine.size, 10 * Engine.size);
            movesI = 0;
            moves = new List<POS>();
            for (int i = 0; i < _bird.moves.Count; i++)
                moves.Add((POS)_bird.moves[i]);

        }

        public bool isOut()
        {
            return !(this.position.X >= 0 && this.position.X < Engine.display.Width && this.position.Y >= 0 && this.position.Y < Engine.display.Height);
        }

        public Bird(int size)
        {
            position = new PointF(20 * Engine.size, 10 * Engine.size);
            movesI = 0;
            moves = new List<POS>();
            for (int i = 0; i < size; i++)
                moves.Add((POS)Engine.rnd.Next(4));

        }
        public void Move()
        {
            if (movesI + 1 >= moves.Count)
                return;

            movesI++;
            Step(moves[movesI]);
            
        }

        private void Step(POS pOS)
        {
            switch (pOS)
            {
                case POS.UP:
                    position.Y -= Engine.size;
                    break;
                case POS.DOWN:
                    position.Y += Engine.size;
                    break;
                case POS.LEFT:
                    position.X -= Engine.size;
                    break;
                case POS.RIGHT:
                    position.X += Engine.size;
                    break;
                default:
                    break;
            }
        }

        public float GetFitness()
        {
            if (finished)
                return -9999;
            float fitness = 0;
            fitness += 1f / this.moves.Count;
            fitness += Math.Abs(Engine.food.X - this.position.X);
            fitness += Math.Abs(Engine.food.Y - this.position.Y);
            return fitness;
        }

        public Bird Mutate()
        {
            Bird mix = new Bird(this);
            for(int i = 0; i < mix.moves.Count; i++)
            {
                if (Engine.rnd.Next(100) < 40)
                {
                    int newMove = (int)mix.moves[i];
                    newMove += Engine.rnd.Next(-2, 2);
                    newMove %= 4;
                    mix.moves[i] = ((POS)newMove);
                }
            }
            return mix;
        }

        public void Draw()
        {
            Engine.grp.FillEllipse(new SolidBrush(Color.Black), position.X+ Engine.size * 0.25f, position.Y+ Engine.size * 0.25f, Engine.size*0.5f, Engine.size * 0.5f);
            Engine.display.Image = Engine.bmp;
        }
    }
}
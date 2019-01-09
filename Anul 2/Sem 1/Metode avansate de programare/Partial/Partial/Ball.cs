using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partial
{
    public class Ball : IPos
    {
        public float x, y;
        public float size = 128;
        public float forceY, forceX;
        public float jumpAmount = 40;
        public Color color = Color.Black;
        public int startLife;
        public int life;

        public Ball()
        {
            this.size = Engine.rnd.Next(60, 90);
            this.jumpAmount = Engine.Remap(this.size,60,90,50,40);
            this.x = Engine.rnd.Next(50, Engine.display.Width - 50) - this.size / 2;
            this.y = 0 - this.size / 2;
            this.forceX = (float) 1.2f;
            this.startLife = 5;
            this.life = startLife;
            this.color = Color.Green;
        }
        public Ball(int life, float size)
        {
            this.size = size;
            this.jumpAmount = Engine.Remap(this.size, 60, 90, 50, 40);
            this.x = Engine.rnd.Next(50, Engine.display.Width - 50) - this.size / 2;
            this.y = 0 - this.size / 2;
            this.forceX = (float)1.2f;
            this.startLife = life;
            this.life = startLife;
            this.color = Color.Red;
        }
        public Ball(int life , float size, Color color)
        {
            this.size = size;
            this.jumpAmount = Engine.Remap(this.size, 60, 90, 50, 40);
            this.x = Engine.rnd.Next(50, Engine.display.Width - 50) - this.size / 2;
            this.y = 0 - this.size / 2;
            this.forceX = (float)1.2f;
            this.startLife = life;
            this.life = startLife;
            this.color = color;
        }
        public void Draw()
        {
            if (this.isAlive())
            {
                Engine.grp.FillEllipse(new SolidBrush(this.color), this.x, this.y, this.size, this.size);
                Engine.grp.DrawString(this.life.ToString(), new Font("Arial", 32), Brushes.AliceBlue, this.x + this.size / 2 - 16, this.y + this.size / 2 - 16);
            }
        }
        public void Update()
        {
            if (this.isAlive())
            {
                if (this.forceY < 1)
                {
                    this.y += Engine.gravity;
                    this.forceY = 0;
                }
                else if (this.forceY != 1)
                {
                    this.y -= this.forceY;
                    this.forceY *= 0.9f;
                }
                if (this.y + this.size >= Engine.display.Height)
                    this.forceY = this.jumpAmount;

                if (this.y <= 0)
                    this.forceY *= -1;

                this.x += this.forceX;
                if (this.x + this.size > Engine.display.Width)
                    this.forceX = Math.Abs(this.forceX) * -1;
                if (this.x <= 0)
                    this.forceX = Math.Abs(this.forceX);
            }
        }

        public void Collide(Player player)
        {
            if (!Collideing(player))
                return;
            Engine.GameOver();
        }

        public void Collide(Ball ball)
        {
            /*float dx = (ball.x - this.x);
            float dy = (ball.y - this.y);
            if (!(dx * dx + dy * dy <= (this.size / 2 + ball.size / 2) * (this.size / 2 + ball.size / 2)))
                return;
            if (Math.Abs(dx) > Math.Abs(dy))
            {
                this.forceX = -1;
                ball.forceX *= -1;
            }
            else
                this.forceY += this.jumpAmount / 2;*/
        }
        public void Collide(Bullet bullet)
        {
            if (!bullet.isAlive)
                return;
            if(!Collideing(bullet))
                return;

            bullet.Destroy();
            this.life--;
            if (this.life < 1)
                this.Destroy();
            return;
        }
        public bool Collideing(IPos other)
        {
            float[] otherTransform = other.GetTransform();
            float dx = (otherTransform[0] - this.x);
            float dy = (otherTransform[1] - this.y);
            return (dx * dx + dy * dy <= (this.size / 2 + otherTransform[2] / 2) * (this.size / 2 + otherTransform[2] / 2));
                
        }

        public bool isAlive()
        {
            return this.life >0;
        }
        public float[] GetTransform()
        {
            return new float[] { this.x, this.y, this.size };
        }
        public void Destroy() {
            Engine.score++;
            Engine.balls.Remove(this);
            if (this.size < 60)
                return;
            Ball b1 = new Ball( Engine.rnd.Next(0, this.startLife/2), this.size / 1.5f );
            b1.forceY = 0;
            
            Engine.balls.Add(b1);
            if(Engine.rnd.Next(3)==0)
            Engine.Spawn();
            
        }
    }
}
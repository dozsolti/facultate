using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partial
{
    public class Player : IPos
    {
        public float x, y;
        public float size;
        public List<Bullet> bullets;
        public Player(float x,float y)
        {
            this.x = x;
            this.y = y;
            this.size = 30;
            this.bullets = new List<Bullet>();
        }
        public void Draw()
        {
            Engine.grp.FillEllipse(new SolidBrush(Color.Red), this.x - this.size / 2, this.y, this.size, this.size);
        }

        public void Shoot()
        {
            Bullet bullet = new Bullet(this.x, this.y);
            this.bullets.Add(bullet);
        }
        public float[] GetTransform()
        {
            return new float[] { this.x, this.y, this.size };
        }
    }
}

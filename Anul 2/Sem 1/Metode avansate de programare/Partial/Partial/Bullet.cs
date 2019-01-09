using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partial
{
    public class Bullet : IPos
    {
        public float x, y;
        public float size = 60;
        public bool isAlive;
        public Bullet(float x, float y)
        {
            this.x = x;
            this.y = y;
            this.isAlive = true;
        }
        public void Move()
        {
            this.y -=4;
            if (this.y < 0)
                this.Destroy();
        }
        public void Draw()
        {
            if(this.isAlive)
                Engine.grp.FillPie(new SolidBrush(Color.Red), this.x- this.size/2, this.y-this.size/2, this.size, this.size, 60, 60);
        }
        public void Destroy()
        {
            this.isAlive = false;
            Engine.player.bullets.Remove(this);
        }

        public float[] GetTransform()
        {
            return new float[]{ this.x, this.y, this.size};
        }
    }
}

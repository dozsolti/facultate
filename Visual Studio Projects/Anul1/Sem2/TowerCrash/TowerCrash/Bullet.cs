using System;
using System.Drawing;
using System.Windows.Forms;

namespace TowerCrash
{
    public class Bullet
    {
        public Tower parent;
        public Tower target;

        public float damage;
        public Color color;
        public PointF pos;
        public bool iMadeSomeDamage;
        public float t;

        public Bullet(Tower parent, Tower target)
        {
            this.parent = parent;
            this.target = target;
            this.damage = parent.damage;
            this.color = parent.color;
            this.pos = parent.pos;
            this.pos.X += parent.size / 2;

            this.t = 0;
            this.iMadeSomeDamage = false;
        }
        public void Move()
        {
            this.t += 0.007f;
            this.pos.X = (1 - t) * this.parent.pos.X + t * this.target.pos.X;
            this.pos.Y = (1 - t) * this.parent.pos.Y + t * this.target.pos.Y;
            //daca targetul moare inainte sa ajunga la el
            if (this.target.isDead)
            {
                this.iMadeSomeDamage = true;
                return;
            }
            if (this.iMadeSomeDamage==false)
            {

                Tower intersectedTower = Engine.BulletIntersects(this, this.target.owner);
                if (intersectedTower == null)
                    return;

                if (intersectedTower.armor > 0)
                    intersectedTower.armor -= this.damage;
                else
                    intersectedTower.hp -= this.damage;

                intersectedTower.UpdateIsDead();
                if (intersectedTower.isDead)
                    this.parent.target = null;
                this.iMadeSomeDamage = true;
            }
        }
        public void Draw()
        {
            Engine.grp.FillEllipse(new SolidBrush(this.color), this.pos.X - 2, this.pos.Y - 2, 5, 5);

        }
    }
}
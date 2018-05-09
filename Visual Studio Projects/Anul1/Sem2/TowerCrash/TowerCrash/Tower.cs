using System;
using System.Drawing;

namespace TowerCrash
{
    public partial class Tower
    {
        public float fullHp;
        public float hp;
        public float damage;
        public float fullArmor;
        public float armor;
        public Tower target;
        public float reload;
        public float reloadCurrentTime;
        public Color color;
        public Types owner;

        public bool isDead;

        public PointF pos;
        public float size = 65;

        public bool isSelected;

        public Tower(object[] template)
        {
            this.fullHp = (int)template[0];
            this.hp = (int)template[0];
            this.damage = (int)template[1];

            this.fullArmor = (int)template[2];
            this.armor = (int)template[2];

            this.reload = (int)template[3];
            this.reloadCurrentTime = 0;
            this.color = (Color)template[4];
            this.target = null;
            this.isDead = false;
        }

        public void SetOwner(Types owner,int i)
        {
            this.owner = owner;
            if(this.owner == Types.MY)
                this.pos.X = Engine.canvas.Width/4;
            else
                this.pos.X = Engine.canvas.Width*3 / 4;
            this.pos.Y = (5-i) * size*1.15f;
        }

        public void UpdateIsDead()
        {
            if (this.hp > 0)
                return;
            this.isDead = true;
        }

        public void Draw()
        {

            //Center point
            //Engine.grp.FillEllipse(new SolidBrush(this.color), this.pos.X - 2, this.pos.Y -  2, 5, 5);

            if (!this.isDead)
            {
                if (this.isSelected)
                {
                    size *= 1.15f;
                    Engine.grp.FillRectangle(new SolidBrush(Color.MediumPurple), this.pos.X - size / 2, this.pos.Y - size / 2, size, size);
                    size /= 1.15f;
                }
                Engine.grp.FillRectangle(new SolidBrush(this.color), this.pos.X - size / 2, this.pos.Y - size / 2, size, size);

                if (this.owner == Types.MY)
                {

                    Engine.grp.FillRectangle(
                        new SolidBrush(Color.Red), this.pos.X - size * 1.5f, this.pos.Y - size / 3, 40, 8);

                    Engine.grp.FillRectangle(
                        new SolidBrush(Color.Green), this.pos.X - size * 1.5f, this.pos.Y - size / 3, (40 * this.hp) / this.fullHp, 8);

                    if (this.armor > 0)
                    {
                        Engine.grp.FillRectangle(
                            new SolidBrush(Color.Black), this.pos.X - size * 1.5f, this.pos.Y - size / 6, 40, 8);

                        Engine.grp.FillRectangle(
                            new SolidBrush(Color.Gray), this.pos.X - size * 1.5f, this.pos.Y - size / 6, (40 * this.armor) / this.fullArmor, 8);
                    }
                    

                    Engine.grp.FillRectangle(
                        new SolidBrush(Color.Orange), this.pos.X - size * 1.5f, this.pos.Y + 20, (40 * this.reloadCurrentTime) / this.reload, 8);
                }
                else
                {

                    Engine.grp.FillRectangle(
                        new SolidBrush(Color.Red), this.pos.X + size * 1.05f, this.pos.Y - size / 3, 40, 8);

                    Engine.grp.FillRectangle(
                        new SolidBrush(Color.Green), this.pos.X + size * 1.05f, this.pos.Y - size / 3, (40 * this.hp) / this.fullHp, 8);

                    if (this.armor > 0)
                    {
                        Engine.grp.FillRectangle(
                            new SolidBrush(Color.Black), this.pos.X + size * 1.05f, this.pos.Y - size / 6, 40, 8);

                        Engine.grp.FillRectangle(
                            new SolidBrush(Color.Gray), this.pos.X + size * 1.05f, this.pos.Y - size / 6, (40 * this.armor) / this.fullArmor, 8);
                    }
                    Engine.grp.FillRectangle(
                        new SolidBrush(Color.Orange), this.pos.X + size * 1.05f, this.pos.Y + 20 , (40 * this.reloadCurrentTime) / this.reload, 8);
                }
                /*if (this.target != null && !this.isDead)
                {
                    Engine.grp.DrawLine(Pens.Red, this.pos, this.target.pos);
                    Engine.grp.FillEllipse(new SolidBrush(Color.Red), this.target.pos.X - 2, this.target.pos.Y - 2, 5, 5);
                }*/
            }
        }

        public void Fire()
        {
            if (this.target == null)
                return;
            if(this.target.isDead)
            {
                this.target = null;
                return;
            }
            Bullet bullet = new Bullet(this, target);
            Engine.bullets.Add(bullet);
        }

        public bool isClicked(float x, float y)
        {
            return (
                x>=this.pos.X - size/2 && 
                y>=this.pos.Y - size / 2 &&
                x<=this.pos.X+size/2 &&
                y<= this.pos.Y + size/2
            );
        }
    }
}

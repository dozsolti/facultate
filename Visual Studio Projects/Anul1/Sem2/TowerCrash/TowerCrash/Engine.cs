using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerCrash
{
    public enum Types { MY,ENEMY};
    public static class Engine
    {
        public static Random rnd;
        public static Bitmap bmp;
        public static Graphics grp;
        public static PictureBox canvas;
        public static Color colorDefault;

        public static List<Tower> towersMy = new List<Tower>();
        public static List<Tower> towersEnemy = new List<Tower>();
        public static List<Tower> selectedTowers = new List<Tower>();
        public static bool isGameOver;

        public static void SetEnemiesTarget()
        {
            int[] goodTowers = GetAvailableTowersMy();
            if (goodTowers.Length == 0)
            {
                updateGameOver();
                return;
            }
            foreach (Tower t in towersEnemy)
                if(t.target==null)
                    t.target = towersMy[goodTowers[rnd.Next(goodTowers.Length)]];
        }
        public static int[] GetAvailableTowersMy() {
            List<int> temp = new List<int>();
            for(int i=0;i<towersMy.Count;i++)
            {
                if (!towersMy[i].isDead)
                    temp.Add(i);
            }
            return temp.ToArray();
        }
        public static List<Bullet> bullets = new List<Bullet>();

        public static void InitGame(PictureBox pictureBox1)
        {
            canvas = pictureBox1;
            bmp = new Bitmap(canvas.Width, canvas.Height);
            grp = Graphics.FromImage(bmp);
            colorDefault = Color.White;
            rnd = new Random();
            isGameOver = false;
        }
        public static object[] GetRandomTemplate()
        {
            int temp = rnd.Next(5);
            switch (temp)
            {
                case 0:
                    return Tower.Template.HULK;
                case 1:
                    return Tower.Template.THOR;
                case 2:
                    return Tower.Template.IRON_MAN;
                case 3:
                    return Tower.Template.CAPTAIN_AMERICA;
                default:
                    return Tower.Template.HAWK_EYE;
            }
        }
        public static void updateGameOver()
        {
            bool isAllDead = true;
            foreach (Tower t in towersEnemy)
            {
                if (!t.isDead)
                {
                    isAllDead = false;
                    break;
                }
            }
            if (isAllDead)
            {
                isGameOver = true;
                MessageBox.Show("Ai Castigat");
                return;
            }
            isAllDead = true;
            foreach (Tower t in towersMy)
            {
                if (!t.isDead)
                {
                    isAllDead = false;
                    break;
                }
            }
            if (isAllDead)
            {
                isGameOver = true;
                MessageBox.Show("Ai pierdut!");
            }

        }

        public static void CreateTowers(Types type, int n)
        {
            if(type == Types.MY)
            {
                towersMy.Clear();
                for (int i = 0; i < n; i++)
                {
                    towersMy.Add(new Tower(GetRandomTemplate()));
                    towersMy[i].SetOwner(Types.MY,i);
                    
                }

           }else
            {
                towersEnemy.Clear();
                for (int i = 0; i < n; i++)
                {
                    towersEnemy.Add(new Tower(GetRandomTemplate()));
                    towersEnemy[i].SetOwner(Types.ENEMY,i);
                }

            }
        }

        public static void Draw()
        {
            grp.Clear(colorDefault);

            foreach (Tower t in towersMy)
                t.Draw();

            foreach (Tower t in towersEnemy)
                t.Draw();

            bullets = bullets.FindAll(delegate (Bullet b) { return !b.iMadeSomeDamage; });
            foreach (Bullet b in bullets)
            {
                b.Move();
                b.Draw();
            }

            RefreshCanvas();
        }

        public static void RefreshCanvas()
        {
            canvas.Image = bmp;
        }

        public static Tower GetClickedTower(float x,float y)
        {
            foreach(Tower t in towersMy)
                if (t.isClicked(x, y))
                    return t;
            foreach (Tower t in towersEnemy)
                if (t.isClicked(x, y))
                    return t;
            return null;

        }

        public static void AddToSelectedTower(Tower t)
        {
            if (t.owner == Types.ENEMY)
            {
                foreach (Tower tower in selectedTowers)
                {
                    tower.isSelected = false;
                    tower.target = t;
                }
                t.isSelected = false;
                selectedTowers.Clear();
            }
            else
            {
                if (selectedTowers.Contains(t))
                    selectedTowers.Remove(t);
                else
                    selectedTowers.Add(t);
            }
        }

        public static Tower BulletIntersects(Bullet b,Types targetOwner)
        {
            Tower t = GetClickedTower(b.pos.X, b.pos.Y);
            if (t == null)
                return null;
            if (t.owner == targetOwner)
                return t;
            else
                return null;
        }
    }
}

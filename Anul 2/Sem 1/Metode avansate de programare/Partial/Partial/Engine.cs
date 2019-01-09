using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Partial
{
    public static class Engine
    {
        public static Bitmap bmp;
        public static Graphics grp;
        public static PictureBox display;
        public static Form1 form;
        public static Label labelScore;
        public static Random rnd;
        public static float gravity = 0.91f*6;

        public static bool gameIsOn;
        public static int score;
        public static List<Ball> balls;
        public static Player player;

        public static void Init(PictureBox p,Form1 form1, Label scrLabel)
        {
            display = p;
            bmp = new Bitmap(display.Width, display.Height);
            grp = Graphics.FromImage(bmp);
            form = form1;
            labelScore = scrLabel;

            rnd = new Random();
            score = 0;
            player = new Player(display.Width / 2, display.Height - 30);

            int n = Enum.GetValues(typeof(ballType)).Length;


            balls = new List<Ball>();
            for(int i = 0; i < 3; i++)
                balls.Add(getBall((ballType)Enum.GetValues(typeof(ballType)).GetValue(rnd.Next(n))));

            gameIsOn = true;
        }

        public static void Spawn()
        {
            int n = Enum.GetValues(typeof(ballType)).Length;

            for (int i = 0; i < 1; i++)
                balls.Add(getBall((ballType)Enum.GetValues(typeof(ballType)).GetValue(rnd.Next(n))));

        }
        public static BallAttribute getAtribute(ballType t)
        {
            return (BallAttribute)Attribute.GetCustomAttribute(
                typeof(ballType).GetField(Enum.GetName(typeof(ballType), t)),
                typeof(BallAttribute));
        }
        public static Ball getBall(ballType t)
        {
            BallAttribute local = getAtribute(t);
            Ball r = new Ball(local.life, local.size, local.color);
            return r;
        }
        public static void Update()
        {
            rnd = new Random();
            balls = balls.Where(b => b.isAlive()).ToList();
            labelScore.Text = "Score: "+ (score * 1000).ToString()+"\n"+balls.Count+" bile ramase";
            if (gameIsOn)
            {
                grp.Clear(Color.AliceBlue);
                player.Draw();
                for (int i = 0; i < balls.Count; i++)
                {
                    balls[i].Update();

                    for (int j = 0; j < player.bullets.Count; j++)
                    {
                        player.bullets[j].Move();
                        if (i >= 0 && i < balls.Count && j >= 0 && j < player.bullets.Count)
                            balls[i].Collide(player.bullets[j]);
                    }
                    if (i > balls.Count - 1)
                        break;
                    for (int j = i; j < balls.Count; j++)
                        if (i != j)
                            balls[i].Collide(balls[j]);
                    balls[i].Collide(player);
                    balls[i].Draw();

                }
                foreach (Bullet bullet in player.bullets)
                    bullet.Draw();
            }
            UpdateEnd();
        }
        public static void UpdateEnd()
        {
            if (balls.Count == 0)
                GameWin();
            display.Image = bmp;
        }
        public static float Remap(this float value, float from1, float to1, float from2, float to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }
        public static void GameWin()
        {
            gameIsOn = false;
            MessageBox.Show("Ai castigat");
            form.Close();
        }
        public static void GameOver()
        {
            gameIsOn = false;
            MessageBox.Show("Ai pierdut");
            form.Close();
        }
    }
}

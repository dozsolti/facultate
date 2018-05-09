using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerCrash
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.InitGame(pictureBox1);
            Engine.CreateTowers(Types.MY, 5);
            Engine.CreateTowers(Types.ENEMY, 4);
            Engine.SetEnemiesTarget();
            timer1.Enabled = true;
            timer1.Start();
            timerAttack.Enabled = true;
            timerAttack.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Engine.isGameOver)
            {
                timer1.Stop();
                timerAttack.Stop();
                return;
            }
            Engine.Draw();
            Engine.updateGameOver();
        }

        private void timerAttack_Tick(object sender, EventArgs e)
        {
            
            if (Engine.isGameOver)
            {
                return;
            }
            foreach (Tower t in Engine.towersMy)
            {
                if (!t.isDead)
                {
                    if (t.reloadCurrentTime < t.reload)
                        t.reloadCurrentTime++;
                    if (t.target != null)
                    {
                        if (t.reloadCurrentTime >= t.reload)
                        {
                            t.Fire();
                            t.reloadCurrentTime = 0;
                        }
                    }
                }
            }
            foreach (Tower t in Engine.towersEnemy)
            {
                if (!t.isDead)
                {
                    Engine.SetEnemiesTarget();
                    if (t.reloadCurrentTime < t.reload)
                        t.reloadCurrentTime++;
                    if (t.target != null)
                    {
                        if (t.reloadCurrentTime >= t.reload)
                        {
                            t.Fire();
                            t.reloadCurrentTime = 0;
                        }
                    }
                }
            }
            Engine.updateGameOver();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Tower clickedTower = Engine.GetClickedTower(e.X,e.Y);
            
            //Nu am apasat pe un turn
            if (clickedTower == null)
                return;

            //turnul este mort
            if (clickedTower.owner == Types.ENEMY && clickedTower.isDead)
                return;

            //nu am selectat turnurile mele prima oara
            if (clickedTower.owner == Types.ENEMY && Engine.selectedTowers.Count==0)
                return;

            clickedTower.isSelected = !clickedTower.isSelected;
            Engine.AddToSelectedTower(clickedTower);
        }

    }
}

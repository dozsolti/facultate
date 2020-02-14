using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POA
{
    public class Ex2
    {

        public bool SeIntersecteaza(Point l1P1, Point l1P2, Point l2P1, Point l2P2)
        {

            double A1 = l1P2.Y - l1P1.Y;
            double B1 = l1P1.X - l2P2.X;
            double C1 = A1 * l1P1.X + B1 * l1P1.Y;

            double A2 = l2P2.Y - l2P1.Y;
            double B2 = l2P1.X - l2P2.X;
            double C2 = A2 * l2P1.X + B2 * l2P1.Y;

            double det = A1 * B2 - A2 * B1;
            if (det != 0)
            {
                double x = (B2 * C1 - B1 * C2) / det;
                double y = (A1 * C2 - A2 * C1) / det;

                return (Math.Min(l1P1.X, l1P2.X) < x &&
                Math.Max(l1P1.X, l1P2.X) > x &&
                Math.Min(l1P1.Y, l1P2.Y) < y &&
                Math.Max(l1P1.Y, l1P2.Y) > y &&
                Math.Min(l2P1.X, l2P2.X) < x &&
                Math.Max(l2P1.X, l2P2.X) > x &&
                Math.Min(l2P1.Y, l2P2.Y) < y &&
                Math.Max(l2P1.Y, l2P2.Y) > y);

            }
        }
    }
    public abstract class RObot
    {
        public List<Point> path = new List<Point>();
        public Point position, destination;

        public RObot()
        {
            position = Engine.Base;
            DrawRObot();
        }

        public abstract void Do();
        public abstract Point GetNewDestination();

        public void DrawRObot()
        {
            Engine.grp.FillEllipse(new SolidBrush(Color.DodgerBlue), position.X * Engine.size, position.Y * Engine.size, Engine.size, Engine.size);
        }
    }

    public class Explorer : RObot
    {
        public override void Do()
        {
            if (path.Count == 0)
            {
                destination = GetNewDestination();
                path = Engine.Lee(position, destination);
            }
            else
            {
                position = path[path.Count - 1];
                path.RemoveAt(path.Count - 1);
                for (int i = position.X - 2; i <= position.X + 2; i++)
                    for (int j = position.Y - 2; j <= position.Y + 2; j++)
                        if (i >= 0 && i < Engine.n && j >= 0 && j < Engine.m)
                            Engine.fog[i, j] = false;
                DrawRObot();
            }
        }

        public override Point GetNewDestination()
        {
            List<Point> points = new List<Point>();
            for (int i = 0; i < Engine.n; i++)
                for (int j = 0; j < Engine.m; j++)
                    if (Engine.fog[i, j])
                        points.Add(new Point(i, j));
            int p = Engine.rnd.Next(points.Count);
            if (points.Count == 0)
            {
                Engine.form.timer1.Stop();
                MessageBox.Show("You uncovered the whole map!");
                Engine.form.Close();
                return new Point();
            }
            return points[p];
        }
    }
}
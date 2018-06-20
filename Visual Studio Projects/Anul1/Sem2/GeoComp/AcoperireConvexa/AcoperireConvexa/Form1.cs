using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcoperireConvexa
{
    public partial class Form1 : Form
    {
        private int[] xcordinate;
        private int[] ycordinate;
        private int count;
        private int index = 0;
        private int[] finalPointArray;
        private Graphics grp;
        private double[] angle;
        private int[] pointName;
        private Color colorPrimary;
        private Color colorDanger;

        public Form1()
        {
            InitializeComponent();
            xcordinate = new int[100];
            ycordinate = new int[100];
            pointName = new int[100];

            count = 0;
            grp = pictureBox1.CreateGraphics();
            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            colorPrimary = Color.Green;
            colorDanger = Color.Red;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            findSmallestY();
            createAngleArray();
            sortAngleArray();
            findSmallestPolygon();

            string final = "" + pointName[0];

            for (int i = 1; i < count; i++)
                if (finalPointArray[i] == 1)
                    final = final + ", " + pointName[i];
            MessageBox.Show(final);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
                xcordinate[count] = e.X;
                ycordinate[count] = e.Y;
                Pen redPen = new Pen(colorPrimary, 5);

                grp.DrawEllipse(redPen, e.X, e.Y, 2, 2);

                pointName[count] = count + 1;
                count++;
        }

        private void findSmallestY()
        {
            int min = ycordinate[0], indice = 0;
            for (int i = 1; i < count; i++)
                if (min < ycordinate[i])
                {
                    min = ycordinate[i];
                    indice = i;
                }
            index = indice;
        }

        private int ccw(int m, int n, int i)
        {
            if (((xcordinate[n] - xcordinate[m]) * (ycordinate[i] - ycordinate[m])) - ((ycordinate[n] - ycordinate[m])) * (xcordinate[i] - xcordinate[m]) > 0)
                return 1;
            else
                return -1;
        }

        private void findSmallestPolygon()
        {
            int clockwise = 1;
            int countclockwise = -1;
            int a = 0, b = 1, c = 2;

            finalPointArray = new int[count];
            //take two point
            finalPointArray[a] = 1;
            finalPointArray[b] = 1;
            Pen redPen;

            redPen = new Pen(colorPrimary, 2);
            grp.DrawLine(redPen, new Point(xcordinate[0], ycordinate[0]), new Point(xcordinate[1], ycordinate[1]));

            while (true)
            {
                System.Threading.Thread.Sleep(1000);
                //if last point traversed
                if ((ccw(b, a, c) == clockwise) && (c == count - 1))
                {
                    finalPointArray[c] = 1;
                    redPen = new Pen(colorPrimary, 2);

                    grp.DrawLine(redPen, new Point(xcordinate[b], ycordinate[b]), new Point(xcordinate[c], ycordinate[c]));
                    System.Threading.Thread.Sleep(1000);
                    grp.DrawLine(redPen, new Point(xcordinate[c], ycordinate[c]), new Point(xcordinate[0], ycordinate[0]));
                    string str = "";
                    for (int j = 0; j < count; j++)
                        if (finalPointArray[j] == 1)
                            str = str + "    " + Convert.ToString(j);

                    break;
                }

                //three points take left turn then draw two lines
                if (ccw(b, a, c) == clockwise)
                {

                    grp.DrawLine(redPen, new Point(xcordinate[b], ycordinate[b]), new Point(xcordinate[c], ycordinate[c]));

                    finalPointArray[c] = 1;
                    a = b;
                    b = c;
                    c++;
                }

                //if three points take right turn then remove the line and middle point and move one step back
                else if (ccw(b, a, c) == countclockwise)
                {
                    
                    grp.DrawLine(redPen, new Point(xcordinate[b], ycordinate[b]), new Point(xcordinate[c], ycordinate[c]));
                    System.Threading.Thread.Sleep(1000);

                    System.Threading.Thread.Sleep(1000);
                    redPen = new Pen(colorDanger, 2);
                    grp.DrawLine(redPen, new Point(xcordinate[b], ycordinate[b]), new Point(xcordinate[c], ycordinate[c]));

                    grp.DrawLine(redPen, new Point(xcordinate[a], ycordinate[a]), new Point(xcordinate[b], ycordinate[b]));
                    redPen = new Pen(colorPrimary, 2);

                    grp.DrawEllipse(redPen, xcordinate[b], ycordinate[b], 2, 2);
                    grp.DrawEllipse(redPen, xcordinate[a], ycordinate[a], 2, 2);
                    grp.DrawEllipse(redPen, xcordinate[c], ycordinate[c], 2, 2);
                    finalPointArray[b] = 0;
                    b = a;
                    a = theTestBefore(a);
                }

            }

        }

        private int theTestBefore(int l)
        {
            int i;
            for (i = l - 1; i > 0; i--)
                if (finalPointArray[i] == 1)
                    break;
            return i;
        }

        private void sortAngleArray()
        {
            for (int i = (count - 1); i >= 0; i--)
                for (int j = 1; j <= i; j++)
                    if (angle[j - 1] > angle[j])
                    {
                        double temp = angle[j - 1];
                        angle[j - 1] = angle[j];
                        angle[j] = temp;

                        int tmp = xcordinate[j - 1];
                        xcordinate[j - 1] = xcordinate[j];
                        xcordinate[j] = tmp;

                        tmp = ycordinate[j - 1];
                        ycordinate[j - 1] = ycordinate[j];
                        ycordinate[j] = tmp;

                        tmp = pointName[j - 1];
                        pointName[j - 1] = pointName[j];
                        pointName[j] = tmp;
                    }
        }

        private void createAngleArray()
        {
            angle = new double[count];
            double kone;

            for (int i = 0; i < count; i++)
            {
                double mainPointX = (double)xcordinate[index];
                double mainPointY = (double)ycordinate[index];

                if ((double)xcordinate[i] == mainPointX && (double)ycordinate[i] == mainPointY)
                    kone = 0;
                else
                {
                    double otherPointX = (double)xcordinate[i] - (double)xcordinate[index];
                    double otherPointY = (double)ycordinate[index] - (double)ycordinate[i];
                    kone = Angle(otherPointX, otherPointY);
                }
                angle[i] = kone;
            }

        }

        public double Angle(double px2, double py2)
        {
            double angle = 0.0;
            //Calculate the angle
            angle = System.Math.Atan(System.Math.Abs(py2) / System.Math.Abs(px2));
            // Convert to degrees
            angle = angle * 180 / System.Math.PI;
            if (px2 < 0)
                angle = 180 - angle;
            return angle;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Pen redPen = new Pen(colorPrimary, 5);

            for (int i = 0; i < 7; i++)
            {
                grp.DrawEllipse(redPen, xcordinate[i] * 20, ycordinate[i] * 20, 2, 2);
                count++;
            }


            findSmallestY();
            createAngleArray();
            sortAngleArray();
            _findSmallestPolygon();

            button2.Enabled = false;
            string final = "" + pointName[0];

            for (int i = 1; i < count; i++)
                if (finalPointArray[i] == 1)
                    final = final + ", " + pointName[i];
            MessageBox.Show(final);
        }

        private void _findSmallestPolygon()
        {

            int clockwise = 1;
            int countclockwise = -1;
            int l = 0, m = 1, i = 2;

            finalPointArray = new int[count];
            //take two point
            finalPointArray[l] = 1;
            finalPointArray[m] = 1;
            Pen redPen;
            SolidBrush blueBrush = new SolidBrush(colorDanger);

            redPen = new Pen(colorPrimary, 2);
            grp.DrawLine(redPen, new Point(xcordinate[0] * 20, ycordinate[0] * 20), new Point(xcordinate[1] * 20, ycordinate[1] * 20));

            while (true)
            {
                System.Threading.Thread.Sleep(1000);
                //if last point traversed
                if ((ccw(m, l, i) == clockwise) && (i == count - 1))
                {
                    finalPointArray[i] = 1;
                    redPen = new Pen(colorPrimary, 2);

                    grp.DrawLine(redPen, new Point(xcordinate[m] * 20, ycordinate[m] * 20), new Point(xcordinate[i] * 20, ycordinate[i] * 20));
                    System.Threading.Thread.Sleep(1000);
                    grp.DrawLine(redPen, new Point(xcordinate[i] * 20, ycordinate[i] * 20), new Point(xcordinate[0] * 20, ycordinate[0] * 20));
                    string str = "";
                    for (int j = 0; j < count; j++)
                        if (finalPointArray[j] == 1)
                            str = str + "    " + Convert.ToString(j);


                    redPen = new Pen(colorPrimary, 2);
                    break;
                }

                //three points take left turn then draw two lines
                if (ccw(m, l, i) == clockwise)
                {
                    grp.FillRectangle(blueBrush, 2, 2, 800, 70);
                    redPen = new Pen(colorPrimary, 2);
                    redPen = new Pen(colorPrimary, 2);

                    grp.DrawLine(redPen, new Point(xcordinate[m] * 20, ycordinate[m] * 20), new Point(xcordinate[i] * 20, ycordinate[i] * 20));

                    finalPointArray[i] = 1;
                    l = m;
                    m = i;
                    i++;
                }

                //if three points take right turn then remove the line and middle point and move one step back
                else if (ccw(m, l, i) == countclockwise)
                {
                    grp.FillRectangle(blueBrush, 2, 2, 800, 70);
                    redPen = new Pen(colorPrimary, 2);

                    grp.DrawLine(redPen, new Point(xcordinate[m] * 20, ycordinate[m] * 20), new Point(xcordinate[i] * 20, ycordinate[i] * 20));
                    System.Threading.Thread.Sleep(1000);

                    System.Threading.Thread.Sleep(1000);
                    //redPen = new Pen(colorDanger, 2);
                    grp.DrawLine(redPen, new Point(xcordinate[m] * 20, ycordinate[m] * 20), new Point(xcordinate[i] * 20, ycordinate[i] * 20));

                    grp.DrawLine(redPen, new Point(xcordinate[l] * 20, ycordinate[l] * 20), new Point(xcordinate[m] * 20, ycordinate[m] * 20));
                    redPen = new Pen(colorPrimary, 2);

                    grp.DrawEllipse(redPen, xcordinate[m], ycordinate[m], 2, 2);
                    grp.DrawEllipse(redPen, xcordinate[l], ycordinate[l], 2, 2);
                    grp.DrawEllipse(redPen, xcordinate[i], ycordinate[i], 2, 2);
                    finalPointArray[m] = 0;
                    m = l;
                    l = theTestBefore(l);
                }

            }

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.White;
        }
    }

}


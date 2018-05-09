using System;
using System.Drawing;

namespace TowerCrash
{
    public partial class Tower
    {
        public static class Template
        {
            public static object[] HULK = new object[] { 200, 25, 0, 5, Color.ForestGreen };
            public static object[] THOR = new object[] { 120, 15, 40, 3, Color.Gold };
            public static object[] IRON_MAN = new object[] { 100, 13, 70, 3, Color.Red };
            public static object[] CAPTAIN_AMERICA = new object[] { 90, 10, 100, 4, Color.Blue };
            public static object[] HAWK_EYE = new object[] { 70, 6, 15, 15, Color.Black };
        }
    }
}

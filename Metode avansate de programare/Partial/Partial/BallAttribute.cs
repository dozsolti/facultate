using System;
using System.Drawing;

namespace Partial
{
    public  class BallAttribute : Attribute
    {
        public int life;
        public float size;
        public Color color;

        public BallAttribute(int life,float size, String colorHex)
        {
            this.life = life;
            this.size = size;
            int r = int.Parse(colorHex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            int g = int.Parse(colorHex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            int b = int.Parse(colorHex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            this.color = Color.FromArgb(r,g,b);
        }
    }
}
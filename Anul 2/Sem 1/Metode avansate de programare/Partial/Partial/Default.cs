using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partial
{
    public enum ballType
    {
        [BallAttribute(5, 128, "AD343E")]
        egy,
        [BallAttribute(6, 128, "533745")]
        ketto,
        [BallAttribute(3, 68, "009FFD")]
        harom,
        [BallAttribute(1, 28, "A03E99")]
        negy,
        [BallAttribute(5, 128, "36453B")]
        ot
    }
}

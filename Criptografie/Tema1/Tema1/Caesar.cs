using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1
{
    public class Caesar : RotN
    {
      
        public Caesar()
        {
            this.n = 3;
            this.GenerateKeys();
        }
    }
}

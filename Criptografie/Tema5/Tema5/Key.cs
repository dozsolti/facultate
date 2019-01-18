using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema5
{
    public struct Key
    {
        public int[] publicK;
        public PrivateKey privateK;
        public Key(int[] a, int M, int W, int[] pi, int[] b)
        {
            publicK = a;
            privateK = new PrivateKey(M, W, pi, b);
        }
        
    }
    public struct PrivateKey
    {
        public int M, W;
        public int[] pi, b;

        public PrivateKey(int _M, int _W, int[] _pi, int[] _b)
        {
            M = _M;
            W = _W;
            pi = _pi;
            b = _b;
        }
    }
}

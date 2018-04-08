using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatiiPeMatrici
{
    class Program
    {
        static Matrix weights_ih, weights_ho, bias_h, bias_o;
        static void Main(string[] args)
        {
            Matrix a = new Matrix(2, 3);
            //decimal nrpasi = getPasii(new ulong [] { 720309367573321 });

            weights_ih = new Matrix(2, 1);
            weights_ih.data = new decimal[,] { { 2.4702821531902077m }, { 2.5596411731597635m } };

            weights_ho = new Matrix(1, 2);
            weights_ho.data = new decimal[,] { { 3.489315413474426m, 2.1686170594885876m } };

            bias_h = new Matrix(2, 1);
            bias_h.data = new decimal[,] { { 7.86057963752604m }, { 7.285651486971966m } };
            bias_o = new Matrix(1, 1);
            bias_o.data = new decimal[,] { { 3.043032028650123m} };

            Matrix testFromArray = Matrix.fromArray({ 720309367573321 });
        }

        /*private static decimal getPasii(ulong[] input_array)
        {
            // Generating the Hidden Outputs
            Matrix inputs = Matrix.fromArray(input_array);
            Matrix hidden = Matrix.multiply(weights_ih, inputs);
            hidden.add(bias_h);
            // activation function!
            hidden.map(activation_function.func);

            // Generating the output's output!
            Matrix output = Matrix.multiply(weights_ho, hidden);
            output.add(bias_o);
            output.map(activation_function.func);

            // Sending back to the caller!
            return output.toArray();
        }*/
    }
}

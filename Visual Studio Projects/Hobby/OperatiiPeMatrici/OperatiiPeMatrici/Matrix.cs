using System;

namespace OperatiiPeMatrici
{
    internal class Matrix
    {
        private int rows;
        private int cols;
        public decimal[,] data;
        public Matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            this.data = new decimal[rows, cols];
        }

        internal static Matrix fromArray(ulong[] input_array)
        {
            Matrix result = new Matrix(input_array.Length, 1);

            for(int i=0;i<result.data.GetLength(0);i++)
                {
                result.data[i, 0] = input_array[i];
                }
            return result;
        }

        internal static Matrix multiply(Matrix weights_ih, Matrix inputs)
        {
            throw new NotImplementedException();
        }

        internal void add(Matrix bias_h)
        {
            throw new NotImplementedException();
        }

        internal void map(object func)
        {
            throw new NotImplementedException();
        }

        internal decimal toArray()
        {
            throw new NotImplementedException();
        }
    }
}
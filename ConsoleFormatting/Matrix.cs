using System;

namespace ConsoleFormatting
{
    /// <summary>
    /// This class implements two-dimensional matrix.
    /// </summary>
    class Matrix
    {

        /// <summary>
        /// Describes the random numbers boundaries.
        /// </summary>
        private readonly int _rand = 32;

        /// <summary>
        /// Instance of Random class used to generate numbers
        /// </summary>
        static private readonly Random _rnd = new Random();

        /// <summary>
        /// Variable for storing the matrix itself.
        /// </summary>
        private double[,] val;

        /// <summary>
        /// Represents the number of rows
        /// </summary>
        public int Rows { get => val.GetLength(0); }

        /// <summary>
        /// Represents the number of columns
        /// </summary>
        public int Cols { get => val.GetLength(1); }

        /// <summary>
        /// Indexer for easy access to the matrix.
        /// </summary>
        /// <param name="i">Row index</param>
        /// <param name="j">Column index</param>
        /// <returns></returns>
        public double this[int i, int j]
        {
            get { return val[i, j]; }
            set { val[i, j] = value; }
        }

        /// <summary>
        /// Creates n x m matrix.
        /// </summary>
        /// <param name="n">Rows count</param>
        /// <param name="m">Columns count</param>
        public Matrix(int n, int m)
        {
            if (n < 1 || m < 1)
                throw new ArgumentOutOfRangeException("n/m","Размерности должны быть больше нуля");

            val = new double[n, m];
        }

        /// <summary>
        /// Fills the matrix with random numbers in range [-_rand, _rand)
        /// </summary>
        public void FillRandom()
        {
            for (int i = 0; i < Rows; ++i)
                for (int j = 0; j < Cols; ++j)
                    val[i, j] =  (2 * _rnd.NextDouble() - 1) * _rand;
                    //val[i, j] = _rnd.Next(-_rand, _rand);

        }

        /// <summary>
        /// Prints the matrix to console output.
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < Rows; ++i)
            {
                for (int j = 0; j < Cols; ++j)
                    Console.Write("{0,9} ", val[i, j].ToString("0.0000"));
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Adds two matrices.
        /// </summary>
        /// <param name="a">First matrix</param>
        /// <param name="b">Second matrix</param>
        /// <returns></returns>
        static public Matrix Add(Matrix a, Matrix b) => a + b;

        /// <summary>
        /// Multiplies two matrices.
        /// </summary>
        /// <param name="a">First matrix</param>
        /// <param name="b">Second matrix</param>
        /// <returns></returns>
        static public Matrix Multiply(Matrix a, Matrix b) => a * b;

        /// <summary>
        /// Overloaded operator for matrix addition.
        /// </summary>
        /// <param name="left">Left operand</param>
        /// <param name="right">Right operand</param>
        /// <returns></returns>
        static public Matrix operator +(Matrix left, Matrix right)
        {
            if (left.Rows != right.Rows || left.Cols != right.Cols)
                throw new InvalidOperationException("Размерности матриц должны совпадать");

            Matrix result = new Matrix(left.Rows, left.Cols);
            for (int i = 0; i < left.Rows; ++i)
                for (int j = 0; j < left.Cols; ++j)
                    result[i, j] = left[i, j] + right[i, j];
            return result;
        }

        /// <summary>
        /// Overloaded operator for matrix multiplication.
        /// </summary>
        /// <param name="left">Left operand</param>
        /// <param name="right">Right operand</param>
        /// <returns></returns>
        static public Matrix operator *(Matrix left, Matrix right)
        {
            if (left.Cols != right.Rows)
                throw new InvalidOperationException("Количество столбцов первой матрицы должно равняться количеству строк второй матрицы");

            Matrix result = new Matrix(left.Rows, right.Cols);

            for (int i = 0; i < left.Rows; ++i)
                for (int j = 0; j < right.Cols; ++j)
                    for (int z = 0; z < left.Cols; ++z)
                        result[i, j] += left[i, z] * right[z, j];

            return result;
        }


    }

}

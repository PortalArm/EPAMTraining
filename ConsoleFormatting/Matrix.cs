using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Variable for storing the matrix itself.
        /// </summary>
        private double[,] val;



        /// <summary>
        /// Indexer for easy access to the matrix.
        /// </summary>
        /// <param name="i">Row index</param>
        /// <param name="j">Column index</param>
        /// <returns></returns>
        public double this[int i,int j]
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
            val = new double[n, m];
        }

        /// <summary>
        /// Fills the matrix with random values in range [-_rand, _rand)
        /// </summary>
        public void FillRandom()
        {
            
        }

        /// <summary>
        /// Prints the matrix to console output.
        /// </summary>
        public void Print()
        {

        }

        /// <summary>
        /// Adds two matrices.
        /// </summary>
        /// <param name="a">First matrix</param>
        /// <param name="b">Second matrix</param>
        /// <returns></returns>
        static public Matrix Add(Matrix a, Matrix b)
        {
            return null;

            
        }

        /// <summary>
        /// Multiplies two matrices.
        /// </summary>
        /// <param name="a">First matrix</param>
        /// <param name="b">Second matrix</param>
        /// <returns></returns>
        static public Matrix Multiply(Matrix a, Matrix b)
        {
            return null;
        }

        /// <summary>
        /// Overloaded operator for matrices addition.
        /// </summary>
        /// <param name="left">Left operand</param>
        /// <param name="right">Right operand</param>
        /// <returns></returns>
        static public Matrix operator +(Matrix left, Matrix right)
        {
            return null;
        }

        /// <summary>
        /// Overloaded operator for matrices multiplication.
        /// </summary>
        /// <param name="left">Left operand</param>
        /// <param name="right">Right operand</param>
        /// <returns></returns>
        static public Matrix operator *(Matrix left, Matrix right)
        {
            return null;
        }


    }

}

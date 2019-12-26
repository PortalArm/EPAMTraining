using System;
using System.Text;

namespace HomeworkTwo
{
    /// <summary>
    /// List of all conversion methods
    /// </summary>
    public enum ConversionMethod
    {
        StandardMethod,
        ImplementedMethod
    }

    /// <summary>
    /// Represents unsinged integer as a binary value in string format.
    /// </summary>
    public class BinaryUInt
    {
        private uint _decimalValue;

        /// <summary>
        /// Decimal integer value. Warning: Binary value is changed accordingly.
        /// </summary>
        public uint DecimalValue
        {
            get { return _decimalValue; }
            set { _decimalValue = value; BinaryValue = BuildBinaryFromDecimal(); }
        }

        /// <summary>
        /// Represents binary value of the decimal value
        /// </summary>
        public string BinaryValue { get; private set; }

        /// <summary>
        /// Varible to store conversion method
        /// </summary>
        public ConversionMethod Method { get; }

        /// <summary>
        /// Constructor used to setup method and decimal value. 
        /// </summary>
        /// <param name="val">Decimal value</param>
        /// <param name="method">Conversion method (<seealso cref="ConversionMethod"/> enum) </param>
        public BinaryUInt(uint val, ConversionMethod method = ConversionMethod.StandardMethod)
        {
            Method = method;
            DecimalValue = val;
        }

        /// <summary>
        /// Private method used to create binary representation based on the chosen method
        /// </summary>
        /// <returns></returns>
        private string BuildBinaryFromDecimal()
        {
            switch (Method)
            {
                case ConversionMethod.StandardMethod:
                    return Convert.ToString(DecimalValue, 2);
                case ConversionMethod.ImplementedMethod:
                    return ToBinaryString();
                default:
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// My own implementation of conversion from decimal to binary value
        /// </summary>
        /// <returns>Binary representation of a value</returns>
        private string ToBinaryString()
        {
            uint val = DecimalValue;
            StringBuilder output = new StringBuilder();
            while (val != 0)
            {
                output.Insert(0, val % 2);
                val /= 2;
            }
            return output.ToString();
        }

        public static implicit operator uint(BinaryUInt binary) => binary.DecimalValue;

    }
}

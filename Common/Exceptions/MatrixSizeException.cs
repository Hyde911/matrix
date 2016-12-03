using System;

namespace Common.Exceptions
{
    public class MatrixSizeException : Exception
    {
        public MatrixSizeException(string msg)
            : base(msg)
        { }
    }
}

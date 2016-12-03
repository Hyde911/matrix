using System;

namespace Common.Exceptions
{
    public class NumberOfMatrixesException : Exception
    {
        public NumberOfMatrixesException(string msg)
            : base(msg)
        { }
    }
}

using System;

namespace Common.Exceptions
{
    public class DataBaseAccessException : Exception
    {
        DataBaseAccessException(string msg)
            : base (msg)
        {}
    }
}

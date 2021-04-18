using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Exceptions
{
    public class FMNException : Exception
    {
        public FMNException()
        {
        }

        public FMNException(string message)
            : base(message)
        {
        }

        public FMNException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

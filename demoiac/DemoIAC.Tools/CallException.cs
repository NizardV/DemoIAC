using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities.Tools
{
    public class CallException : Exception
    {
        public CallException()
        {
        }

        public CallException(string message)
            : base(message)
        {
        }

        public CallException(string message, Exception inner)
            : base(message, inner)
        {
        }

    }
}

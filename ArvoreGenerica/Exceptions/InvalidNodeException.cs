using System;
using System.Collections.Generic;
using System.Text;

namespace ArvoreGenerica.Exceptions
{
    class InvalidNodeException : Exception
    {
        public InvalidNodeException(string message) : base(message)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ArvoreGenerica.Exceptions
{
    class EmptyTreeException : Exception
    {
        public string Message { get; set; }
        public EmptyTreeException(string message)
        {
            this.Message = message;
        }
    }
}

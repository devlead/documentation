using System;

namespace Sparrow.Testing
{
    public sealed class SparrowTestingException : Exception
    {
        public SparrowTestingException(string message)
            : base(message)
        {           
        }
    }
}

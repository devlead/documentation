using System;

namespace Sparrow
{
    /// <summary>
    /// Represents errors that occur within Sparrow.
    /// </summary>
    [Serializable]
    public sealed class SparrowException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SparrowException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public SparrowException(string message)
            : base(message)
        {            
        }
    }
}

using System;

namespace Docs.Compiler.Core.Diagnostics
{
    public sealed class ConsoleLog : ILog
    {
        public void Write(Verbosity verbosity, LogLevel level, string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }
    }
}

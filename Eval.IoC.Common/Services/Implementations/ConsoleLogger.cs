using System;

namespace Eval.IoC.Common.Services.Implementations
{
    internal class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
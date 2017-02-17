using System;
using System.IO;
using System.Text;

namespace Eval.IoC.Common.Services.Implementations
{
    internal class FileLogger : ILogger
    {
        private readonly string _filepath;

        public FileLogger(ISettingsService settings)
        {
            _filepath = settings.Get("LogFile") ?? "log.txt";
            if (File.Exists(_filepath)) File.Delete(_filepath);
        }

        public void Log(string message)
        {
            File.AppendAllText(_filepath, message + Environment.NewLine, Encoding.UTF8);
        }
    }
}
using System;

namespace Eval.IoC.Common.Services.Implementations
{
    internal class GermanService : ILanguageService, IDisposable
    {
        private readonly ILogger _logger;

        public GermanService(ILogger logger)
        {
            logger.Log($"{nameof(GermanService)}.ctor()");
            _logger = logger;
        }

        #region IDisposable implementation.

        public void Dispose()
        {
            _logger.Log($"{nameof(GermanService)}.Aufräumen()");
        }

        #endregion

        #region ILanguageService implementation.

        public string GetGreeting()
        {
            _logger.Log($"{nameof(GermanService)}.{nameof(GetGreeting)}()");
            return "Hallo Welt!";
        }

        #endregion
    }
}
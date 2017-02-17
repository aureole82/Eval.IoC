﻿using System;

namespace Eval.IoC.Common.Services.Implementations
{
    internal class EnglishService : ILanguageService, IDisposable
    {
        private readonly ILogger _logger;

        public EnglishService(ILogger logger)
        {
            logger.Log($"{nameof(EnglishService)}.ctor()");
            _logger = logger;
        }

        #region IDisposable implementation.

        public void Dispose()
        {
            _logger.Log($"{nameof(EnglishService)}.{nameof(Dispose)}()");
        }

        #endregion

        #region ILanguageService implementation.

        public string GetGreting()
        {
            _logger.Log($"{nameof(EnglishService)}.{nameof(GetGreting)}()");
            return "Hello World!";
        }

        #endregion
    }
}
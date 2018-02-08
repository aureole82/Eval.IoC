using System;
using System.Collections.Generic;
using System.Linq;

namespace Eval.IoC.Common.Services.Implementations
{
    internal class MainService : IMainService
    {
        private readonly ILogger _logger;
        private readonly ILanguageService[] _services;

        public MainService(ILogger logger, IEnumerable<ILanguageService> services)
        {
            logger.Log($"{nameof(MainService)}.ctor()");
            _logger = logger;
            _services =
                //new[] {service}
                services.ToArray()
                ;
        }

        #region IDisposable implementation.

        public void Dispose()
        {
            _logger.Log($"{nameof(MainService)}.{nameof(Dispose)}()");
        }

        #endregion

        #region IMainService implementation.

        public void SayHello()
        {
            _logger.Log($"{nameof(MainService)}.{nameof(SayHello)}()");
            foreach (var service in _services)
            {
                Console.WriteLine(service.GetGreeting());
            }
        }

        #endregion
    }
}
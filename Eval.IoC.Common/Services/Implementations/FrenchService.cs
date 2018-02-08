namespace Eval.IoC.Common.Services.Implementations
{
    internal class FrenchService : ILanguageService
    {
        private readonly ILogger _logger;

        public FrenchService(ILogger logger)
        {
            logger.Log($"{nameof(FrenchService)}.ctor()");
            _logger = logger;
        }

        public string GetGreeting()
        {
            _logger.Log($"{nameof(FrenchService)}.{nameof(GetGreeting)}()");
            return "Bonjour le monde!";
        }
    }
}
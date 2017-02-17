namespace Eval.IoC.Common.Services.Implementations
{
    internal class FrenchService : ILanguageService
    {
        public string GetGreting()
        {
            return "Bonjour le monde!";
        }
    }
}
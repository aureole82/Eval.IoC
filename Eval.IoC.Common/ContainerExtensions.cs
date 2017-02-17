using Eval.IoC.Common.Services;
using Eval.IoC.Common.Services.Implementations;

namespace Eval.IoC.Common
{
    public static class ContainerExtensions
    {
        public static void Register(this IContainer container)
        {
            //container.Register<ISettingsService, AppSettingsService>();

            container.Register(() =>
            {
                var settings = container.Resolve<ISettingsService>();
                return settings != null ? (ILogger) new FileLogger(settings) : new ConsoleLogger();
            });
            container.Register<IMainService, MainService>();
            container.RegisterAll<ILanguageService>();
            container.Verify();
        }
    }
}
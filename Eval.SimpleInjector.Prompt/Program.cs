using System;
using Eval.IoC.Common;
using Eval.IoC.Common.Services;
using SimpleInjector;

namespace Eval.SimpleInjector.Prompt
{
    internal class Program
    {
        private static void Main()
        {
            var container = new Container
            {
                Options = {DefaultLifestyle = Lifestyle.Singleton, SuppressLifestyleMismatchVerification = true}
            };
            using (var wrapper = new SimpleInjectorContainer(container))
            {
                // DiagnosticVerificationException: [Lifestyle Mismatch] MainService (Singleton) depends on ILanguageService[] (Transient).
                wrapper.Register();

                var service = wrapper.Resolve<IMainService>();
                service.SayHello();

                Console.WriteLine("Press enter to stop...");
                Console.ReadLine();
            }


            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Eval.IoC.Common;
using Eval.IoC.Common.Services;

namespace Eval.Autofac.Prompt
{
    internal class Program
    {
        private static void Main()
        {
            using (var wrapper = new AutoFacContainer())
            {
                wrapper.Register();

                var service = wrapper.Resolve<IMainService>();
                service.SayHello();

                Console.WriteLine("Press enter to stop...");
                Console.ReadLine();

                Console.WriteLine(@"Autofac doesn't implicitly call IDisposable.Dispose()!");
            }

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
    }
}
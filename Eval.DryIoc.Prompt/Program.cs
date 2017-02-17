using System;
using Eval.IoC.Common;
using Eval.IoC.Common.Services;

namespace Eval.DryIoc.Prompt
{
    internal class Program
    {
        private static void Main()
        {
            using (var wrapper = new DryIocContainer())
            {
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
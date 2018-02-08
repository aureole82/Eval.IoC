using System;
using System.Linq;
using Autofac;
using IContainer = Eval.IoC.Common.Services.IContainer;

namespace Eval.Autofac.Prompt
{
    internal class AutoFacContainer : IContainer
    {
        private readonly ContainerBuilder builder;
        private global::Autofac.IContainer container;

        public AutoFacContainer()
        {
            // Create your builder.
            builder = new ContainerBuilder();
        }

        public void Dispose()
        {
        }

        public void Register<TService, TImplementation>() where TService : class where TImplementation : class, TService
        {
            // Usually you're only interested in exposing the type via its interface.
            builder.RegisterType<TImplementation>().As<TService>();
        }

        public void Register<TService>(Func<TService> selector) where TService : class
        {
            // Expose a type via delegate.
            builder.Register(_ => selector());
        }

        public TService Resolve<TService>() where TService : class
        {
            return container.TryResolve(out TService instance)
                ? instance
                : default(TService);
        }

        public void RegisterAll<TService>() where TService : class
        {
            var serviceType = typeof(TService);
            var types = serviceType.Assembly.GetTypes()
                .Where(type => serviceType.IsAssignableFrom(type))
                .Where(type => !type.IsInterface);

            foreach (var type in types)
            {
                builder.RegisterType(type).As(serviceType);
            }
        }

        public void Verify()
        {
            container = builder.Build();
        }
    }
}
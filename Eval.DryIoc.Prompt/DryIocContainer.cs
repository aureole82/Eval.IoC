using System;
using System.Linq;
using System.Text;
using DryIoc;
using Eval.IoC.Common.Services;
using IContainer = Eval.IoC.Common.Services.IContainer;

namespace Eval.DryIoc.Prompt
{
    internal class DryIocContainer : IContainer
    {
        private readonly Container _container;

        public DryIocContainer()
        {
            _container = new Container();
        }

        public void Dispose()
        {
            _container.Dispose();
        }

        public void Register<TService, TImplementation>() where TService : class where TImplementation : class, TService
        {
            _container.Register<TService, TImplementation>(Reuse.Singleton);
        }

        public void Register<TService>(Func<TService> selector) where TService : class
        {
            _container.RegisterDelegate(_ => selector(), Reuse.Singleton);
        }

        public TService Resolve<TService>() where TService : class
        {
            return _container.Resolve<TService>(IfUnresolved.ReturnDefault);
        }

        public void RegisterAll<TService>() where TService : class
        {
            var serviceType = typeof(TService);
            var types = serviceType.Assembly.GetTypes()
                .Where(type => serviceType.IsAssignableFrom(type))
                .Where(type => !type.IsInterface);

            foreach (var type in types)
            {
                _container.Register(serviceType, type, Reuse.Singleton);
            }
        }

        public void Verify()
        {
            var keyValuePairs = _container.VerifyResolutions();
            if (!keyValuePairs.Any()) return;

            var errors = new StringBuilder();
            foreach (var pair in keyValuePairs)
            {
                errors.AppendLine();
                errors.Append($"- {pair.Key.ServiceType.FullName}: {pair.Value.Message}");
            }
            throw new ContainerVerificationException(errors.ToString());
        }
    }
}
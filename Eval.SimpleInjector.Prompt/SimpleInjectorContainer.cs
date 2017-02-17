using System;
using System.Linq;
using Eval.IoC.Common.Services;
using SimpleInjector;

namespace Eval.SimpleInjector.Prompt
{
    internal class SimpleInjectorContainer : IContainer
    {
        private readonly Container _container;

        public SimpleInjectorContainer(Container container)
        {
            _container = container;
        }

        public void Dispose()
        {
            _container?.Dispose();
        }

        public void Register<TService, TImplementation>() where TService : class where TImplementation : class, TService
        {
            _container.Register<TService, TImplementation>();
        }

        public void Register<TService>(Func<TService> selector) where TService : class
        {
            _container.Register(selector);
        }

        public TService Resolve<TService>() where TService : class
        {
            return _container.GetRegistration(typeof(TService)) != null
                ? _container.GetInstance<TService>()
                : default(TService);
        }

        public void RegisterAll<TService>() where TService : class
        {
            var baseType = typeof(TService);
            var allTypes = _container
                .GetTypesToRegister(baseType, new[] {baseType.Assembly})
                .ToArray();

            //if (allTypes.Length > 1)
            //    _container.Options.SuppressLifestyleMismatchVerification = true;

            var registrations = allTypes
                .Select(type => Lifestyle.Singleton.CreateRegistration(type, _container))
                .ToArray();

            _container.RegisterCollection<TService>(registrations);
        }

        public void Verify()
        {
            try
            {
                _container.Verify();
            }
            catch (Exception e)
            {
                throw new ContainerVerificationException(e);
            }
        }
    }
}
using System;

namespace Eval.IoC.Common.Services
{
    public interface IContainer : IDisposable
    {
        /// <summary> Registers a concrete type. </summary>
        void Register<TService, TImplementation>() where TService : class where TImplementation : class, TService;

        /// <summary> Registers by an instance selector (factory). </summary>
        void Register<TService>(Func<TService> selector) where TService : class;

        /// <summary> Resolve a singleton. Returns null if unknown. </summary>
        TService Resolve<TService>() where TService : class;

        /// <summary> Registers all concrete implementations of the interface found in its assembly. </summary>
        void RegisterAll<TService>() where TService : class;

        /// <summary> Checks if everything is correct. </summary>
        /// <exception cref="ContainerVerificationException"></exception>
        void Verify();
    }

    public class ContainerVerificationException : Exception
    {
        public ContainerVerificationException(Exception exception) : base("Container verification failed.", exception)
        {
        }

        public ContainerVerificationException(string message, Exception exception)
            : base("Container verification failed: " + message, exception)
        {
        }

        public ContainerVerificationException(string message) : base("Container verification failed: " + message)
        {
        }
    }
}
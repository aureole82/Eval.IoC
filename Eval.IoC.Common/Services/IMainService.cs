using System;

namespace Eval.IoC.Common.Services
{
    public interface IMainService : IDisposable
    {
        void SayHello();
    }
}
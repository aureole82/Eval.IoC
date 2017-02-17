## The Problem
Folks often overdose IoC and neglecting architecture by “sweeping everything under the carpet”. That’s the point where IoC often becomes OoC (Out of Control).
## The Solution
Don’t surrender! There are some principles you should follow to live long and happily with your faithful servant:

1. Always use constructor injection. Then it’s easy to inject mocks in your unit tests and let inject concrete instances by your IoC container at run-time. I know other patterns (like autowiring of properties) are tempting like paradise but will be confusing and error-prone very soon.
2. Never ever expose your IoC as a public global singleton where everybody can ask for instances. That would end up in an unresolvable dependency on your dependency injection. Just create the container and register all instances once at application startup and expose the necessary controllers / view models / factories (by eager or lazy loading). The IoC should be nothing more than a local variable in your startup method.
3. My personal recommendation: Consider your IoC container as a service like all the services you register it inside. E.g. cast your needs into an interface and hide the concrete IoC instance behind it. To state it clear, just must call it like this `IContainer ioc = new ContainerWrapper();`. By working with an interface only it’s easy to replace your concrete IoC container later on.

And so do I, here’s my `IContainer`:

```csharp
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
```

Take a glimpse on my implementations inside this repository. I provide one for the following IoC containers (all NuGet packages):
* DryIoc: [Documentation](https://bitbucket.org/dadhi/dryioc/wiki/Home), [NuGet](https://www.nuget.org/packages/DryIoc/)
* SimpleInjector: [Documentation](https://simpleinjector.readthedocs.io/en/latest/index.html), [NuGet](https://www.nuget.org/packages/SimpleInjector/)
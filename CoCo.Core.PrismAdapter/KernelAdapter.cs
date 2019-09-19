using System;
using System.Linq;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Bootstrapping;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.DependencyInjection;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.DependencyInjection.DataClasses;
using Prism.Ioc;

namespace Fateblade.Haushaltsbuch.CrossCutting.CoCo.Core.PrismAdapter
{
    public class KernelAdapter: ICoCoKernel
    {
        //members
        private readonly IContainerRegistry _innerRegistry;
        private readonly IContainerProvider _innerProvider;


        //ctors
        public KernelAdapter(IContainerRegistry innerRegistry, IContainerProvider associatedProvider)
        {
            _innerRegistry = innerRegistry;
            _innerProvider = associatedProvider;
        }



        //public methods
        public void Register<TContract, TImplementation>(RegisterScope scope = RegisterScope.PerInject) where TImplementation : TContract
        {
            switch (scope)
            {
                case RegisterScope.PerInject:
                case RegisterScope.PerContext:
                    _innerRegistry.Register<TContract, TImplementation>();
                    break;
                case RegisterScope.Unique:
                    _innerRegistry.RegisterSingleton<TContract, TImplementation>();
                    break;
                default:
                    throw new Exception($"Unkown scope type: '{scope}'");
            }
        }

        public void Register(Type contract, Type implementation, RegisterScope scope = RegisterScope.PerInject)
        {
            switch (scope)
            {
                case RegisterScope.PerInject:
                case RegisterScope.PerContext:
                    _innerRegistry.Register(contract, implementation);
                    break;
                case RegisterScope.Unique:
                    _innerRegistry.RegisterSingleton(contract, implementation);
                    break;
                default:
                    throw new Exception($"Unkown scope type: '{scope}'");
            }
        }

        public void RegisterToSelf<TImplementation>(RegisterScope scope = RegisterScope.PerInject)
        {
            throw new NotImplementedException("Is not supported in PrismAdapter implementation");
        }

        public void RegisterComponent<TComponent>() where TComponent : IComponentActivator
        {
            _innerRegistry.Register<IComponentActivator, TComponent>();
        }

        public TContract Get<TContract>()
        {
            return _innerProvider.Resolve<TContract>();
        }

        public TContract Get<TContract>(params ConstructorParameter[] parameters)
        {
            var prismParameters = parameters.Select(t => (t.Value.GetType(), t.Value));
            return _innerProvider.Resolve<TContract>(prismParameters.ToArray());
        }

        public object Get(Type contractType)
        {
            return _innerProvider.Resolve(contractType);
        }

        public object Get(Type contractType, params ConstructorParameter[] parameters)
        {
            var prismParameters = parameters.Select(t => (t.Value.GetType(), t.Value));
            return _innerProvider.Resolve(contractType, prismParameters.ToArray());
        }

        public void RegisterConfiguration<T>()
        {
            // Todo: try with Prism.ContainerExtensions
            //original from ninject _innerKernel.Bind<T>().ToMethod(c => c.Kernel.Get<IConfigObjectProvider>().Get<T>());
            throw new NotImplementedException("Not supported in PrismAdapter implementation");
        }

    }
}

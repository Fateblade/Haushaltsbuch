using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.DependencyInjection;
using Prism.Ioc;
using System;

namespace Fateblade.Haushaltsbuch.CrossCutting.CoCo.Core.PrismAdapter
{
    public class KernelContainer : IKernelContainer
    {
        //members
        private static ICoCoKernel _kernel;
        private static readonly object _lock = new object();
        private static IContainerRegistry _prismRegistry;
        private static IContainerProvider _associatedPrismProvider;



        //properties - singleton
        public ICoCoKernel Kernel
        {
            get
            {
                if(_prismRegistry==null) { throw new ArgumentNullException($"Registry has to be injected via the {nameof(InjectRegistry)}-Method or correct constructor call"); }
                if(_associatedPrismProvider == null) { throw new ArgumentNullException($"Provider has to be injected via the {nameof(InjectProvider)}-method or correct constructor call"); }
                lock (_lock)
                {
                    if (_kernel == null)
                    {
                        _kernel = new KernelAdapter(_prismRegistry, _associatedPrismProvider);
                        _kernel.Register<ICoCoKernel, KernelAdapter>();
                    }
                    return _kernel;
                }
            }
        }



        //ctor
        public KernelContainer()
        {

        }
        public KernelContainer(IContainerRegistry prismRegistry, IContainerProvider associatedPrismProvider)
        {
            _prismRegistry = prismRegistry;
            _associatedPrismProvider = associatedPrismProvider;
        }


        //public methods
        public void InjectRegistry(IContainerRegistry prismRegistry)
        {
            _prismRegistry = prismRegistry;
        }

        public void InjectProvider(IContainerProvider associatedPrismProvider)
        {
            _associatedPrismProvider = associatedPrismProvider;
        }
    }
}

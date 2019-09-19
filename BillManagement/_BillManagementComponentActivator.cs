using BillManagement.Contract;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Bootstrapping;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Configuration;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.DependencyInjection;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.EventBrokerage;

namespace BillManagement
{
    public class BillManagementComponentActivator : IComponentActivator
    {
        public void Activated()
        {
        }

        public void Activating()
        {
        }

        public void AddMessageSubscriptions(IEventBroker broker)
        {
        }

        public void Configure(IConfigurator config)
        {
        }

        public void Deactivated()
        {
        }

        public void Deactivating()
        {
        }

        public void RegisterMappings(ICoCoKernel kernel)
        {
            kernel.Register<IBillManager, BillManager>();
        }
    }
}

using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Bootstrapping;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Configuration;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.DependencyInjection;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.EventBrokerage;
using Fateblade.Haushaltsbuch.Logic.Domain.EntryManagement.Contract;

namespace Fateblade.Haushaltsbuch.Logic.Domain.EntryManagement
{
    public class EntryManagementComponentActivator : IComponentActivator
    {
        public void Activating()
        {
            
        }

        public void Activated()
        {
        }

        public void Deactivating()
        {
        }

        public void Deactivated()
        {
        }

        public void RegisterMappings(ICoCoKernel kernel)
        {
            kernel.Register<IEntryManager, EntryManager>();
        }

        public void AddMessageSubscriptions(IEventBroker broker)
        {
        }

        public void Configure(IConfigurator config)
        {
            
        }
    }
}

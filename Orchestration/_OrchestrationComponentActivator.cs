using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Bootstrapping;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Configuration;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.DependencyInjection;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.DependencyInjection.DataClasses;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.EventBrokerage;
using Fateblade.Haushaltsbuch.Logic.Foundation.Orchestration.Contract;

namespace Fateblade.Haushaltsbuch.Logic.Foundation.Orchestration
{
    public class OrchestrationComponentActivator : IComponentActivator
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
            kernel.Register<IOrchestrator, Orchestrator>(RegisterScope.Unique);
        }
    }
}

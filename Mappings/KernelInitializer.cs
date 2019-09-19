using BillManagement;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.DependencyInjection.DataClasses;
using Fateblade.Haushaltsbuch.CrossCutting.CoCo.Core.PrismAdapter;
using Fateblade.Haushaltsbuch.Data.DataStoring.SqLite;
using Fateblade.Haushaltsbuch.Logic.EntryManagement;
using Fateblade.Haushaltsbuch.Logic.ItemManagement;
using Fateblade.Haushaltsbuch.Logic.SourceManagement;
using ItemHistoryManagement;
using ItemHistoryWorkflow;
using Prism.Ioc;

namespace Infrastructure.Mappings
{
    public class KernelInitializer
    {

        public void Initialize(IContainerRegistry container, IContainerProvider provider)
        {
            var kernelContainer = new KernelContainer(container, provider);
            kernelContainer.Kernel.Register<ISqlLiteConnectionProvider, SqLiteFileConfiguration>(RegisterScope.Unique);

            //data
            kernelContainer.Kernel.RegisterComponent<SourceManagementComponentActivator>();


            //logic
            kernelContainer.Kernel.RegisterComponent<EntryManagementComponentActivator>();
            kernelContainer.Kernel.RegisterComponent<ItemManagementComponentActivator>();
            kernelContainer.Kernel.RegisterComponent<SourceManagementComponentActivator>();
            kernelContainer.Kernel.RegisterComponent<BillManagementComponentActivator>();
            kernelContainer.Kernel.RegisterComponent<ItemHistoryManagementComponentActivator>();

            kernelContainer.Kernel.RegisterComponent<ItemHistoryWorkflowComponentActivator>();
        }
    }
    
}

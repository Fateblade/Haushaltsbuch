using Fateblade.Haushaltsbuch.Logic.Foundation.Orchestration.Contract.DataClasses;

namespace Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.Contract.Callbacks
{
    public abstract class BaseDialogRequestMessage : BaseOrchestrationRequest
    {
        //properties
        public string DialogTitle { get; set; }



        //constructors
        protected BaseDialogRequestMessage(string title)
        {
            DialogTitle = title;
        }
    }
}

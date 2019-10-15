using Fateblade.Haushaltsbuch.Logic.Foundation.Orchestration.Contract.DataClasses;

namespace Fateblade.Haushaltsbuch.Logic.Foundation.Orchestration.Contract
{
    public interface IOrchestratable<in TOrchestrationRequest> : IOrchestratable
        where TOrchestrationRequest : BaseOrchestrationRequest
    {
        void HandleRequest(TOrchestrationRequest orchestrationRequest);
        bool CanHandleRequest(TOrchestrationRequest orchestrationRequest);
    }

    public interface IOrchestratable
    {
        void HandleRequest(BaseOrchestrationRequest orchestrationRequest);
        bool CanHandleRequest(BaseOrchestrationRequest orchestrationRequest);
    }
}

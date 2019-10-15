using System;
using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Aspects;
using Fateblade.Haushaltsbuch.Logic.Foundation.Orchestration.Contract.DataClasses;
using Fateblade.Haushaltsbuch.Logic.Foundation.Orchestration.Contract.Exceptions;

namespace Fateblade.Haushaltsbuch.Logic.Foundation.Orchestration.Contract
{
    [MapException(typeof(OrchestrationException), "Unbekannter Fehler beim Orchestrieren")]
    public interface IOrchestrator
    {
        [ExceptionMessage("Fehler beim Anfordern einer Orchestrierung")]
        void Request(BaseOrchestrationRequest orchestrationRequest);

        [ExceptionMessage("Fehler beim Prüfen ob eine Orchestrierung verfügbar ist")]
        bool CanOrchestrate(BaseOrchestrationRequest orchestrationRequest);

        [ExceptionMessage("Fehler beim Registrieren einer Orchestrierung")]
        void RegisterOrchestratable<TOrchestrationRequest>(IOrchestratable<TOrchestrationRequest> orchestratable) 
            where TOrchestrationRequest : BaseOrchestrationRequest;

        [ExceptionMessage("Fehler beim Registrieren einer Orchestrierung")]
        void RegisterOrchestratable<TOrchestrationRequest>(Action<BaseOrchestrationRequest> handler)
            where TOrchestrationRequest : BaseOrchestrationRequest;

        [ExceptionMessage("Fehler beim Registrieren einer Orchestrierung")]
        void RegisterOrchestratable(IMultiOrchestratable orchestratable);
    }
}

using System;
using System.Collections.Generic;
using Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.CommonUserInputDialogs.Contract.Callbacks;
using Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.CommonUserInputDialogs.Contract.DataClasses;
using Fateblade.Haushaltsbuch.Logic.Foundation.Orchestration.Contract;
using Fateblade.Haushaltsbuch.Logic.Foundation.Orchestration.Contract.DataClasses;
using Fateblade.Haushaltsbuch.Logic.Foundation.Orchestration.Contract.Exceptions;
using Prism.Services.Dialogs;

namespace Fateblade.Haushaltsbuch.UI.Haushaltsbuch.Dialogs.CommonDialogs
{
    public class CommonDialogRequestHandler : IMultiOrchestratable
    {
        //members
        private readonly IDialogService _dialogService;


        //constructors
        public CommonDialogRequestHandler(IDialogService dialogService, IOrchestrator orchestrator)
        {
            _dialogService = dialogService;

            orchestrator.RegisterOrchestratable(this);
        }



        //public methods
        public void HandleRequest(BaseOrchestrationRequest orchestrationRequest)
        {
            if (orchestrationRequest is ConfirmationDialogRequestMessage confirmationDialogRequest)
            {
                handleConfirmationDialogRequest(confirmationDialogRequest);
            }
            else if (orchestrationRequest is InfoDialogRequestMessage infoDialogRequest)
            {
                handleInfoDialogRequest(infoDialogRequest);
            }
            else
            {
                throw new OrchestrationException($"Unknown request message type '{orchestrationRequest?.GetType()}'");
            }
        }

        public bool CanHandleRequest(BaseOrchestrationRequest orchestrationRequest)
        {
            if (orchestrationRequest is ConfirmationDialogRequestMessage confirmationDialogRequest)
            {
                return confirmationDialogRequest.Request != null;
            }
            else if (orchestrationRequest is InfoDialogRequestMessage infoDialogRequest)
            {
                return infoDialogRequest.Request != null;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Type> GetHandleableRequestTypes()
        {
            return new List<Type>()
            {
                typeof(ConfirmationDialogRequestMessage),
                typeof(InfoDialogRequestMessage)
            };
        }



        //private methods
        private void handleInfoDialogRequest(InfoDialogRequestMessage infoDialogRequest)
        {
            _dialogService.Show(
                nameof(InfoDialogControl),
                new DialogParameters
                {
                    {"Request", infoDialogRequest.Request },
                    {"Title", infoDialogRequest.DialogTitle }
                },
                (result) =>
                {
                    if (result.Parameters.ContainsKey("Result"))
                    {
                        infoDialogRequest.Result = result.Parameters.GetValue<InfoDialogResult>("Result");
                    }
                    infoDialogRequest.OnDialogClose?.Invoke(
                        infoDialogRequest.Result, 
                        infoDialogRequest.Payload
                        );
                });
        }

        private void handleConfirmationDialogRequest(ConfirmationDialogRequestMessage confirmationDialogRequest)
        {
            _dialogService.Show(
                nameof(ConfirmationDialogControl),
                new DialogParameters
                {
                    {"Request", confirmationDialogRequest.Request},
                    { "Title", confirmationDialogRequest.DialogTitle}
                }, 
                (result) =>
                {
                    if (result.Result == ButtonResult.Yes)
                    {
                        if (result.Parameters.ContainsKey("Result"))
                        {
                            confirmationDialogRequest.Result =
                                result.Parameters.GetValue<ConfirmationDialogResult>("Result");
                        }
                        confirmationDialogRequest.OnUserConfirmed?.Invoke(
                            confirmationDialogRequest.Result,
                            confirmationDialogRequest.Payload
                            );
                    }
                    else
                    {
                        confirmationDialogRequest.OnUserAbort?.Invoke(confirmationDialogRequest.Payload);
                    }
                });
        }
    }
}

using Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.DomainUserInputDialogs.Contract.Callbacks;
using Fateblade.Haushaltsbuch.Logic.Foundation.Orchestration.Contract;
using Fateblade.Haushaltsbuch.Logic.Foundation.Orchestration.Contract.DataClasses;
using Fateblade.Haushaltsbuch.Logic.Foundation.Orchestration.Contract.Exceptions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;

namespace Fateblade.Haushaltsbuch.UI.Haushaltsbuch.Dialogs.DomainDialogs
{
    public class DomainDialogRequestHandler : IMultiOrchestratable
    {
        //members
        private readonly IDialogService _dialogService;



        //constructors
        public DomainDialogRequestHandler(IDialogService dialogService, IOrchestrator orchestrator)
        {
            _dialogService = dialogService;

            orchestrator.RegisterOrchestratable(this);
        }



        //public methods
        public void HandleRequest(BaseOrchestrationRequest orchestrationRequest)
        {
            if (orchestrationRequest is BillEditDialogRequestMessage billEditDialogRequest)
            {
                handleBillEditDialogRequest(billEditDialogRequest);
            }
            else if (orchestrationRequest is BillOverviewDialogRequestMessage billOverViewDialogRequest)
            {
                handleBillOverviewDialogRequest(billOverViewDialogRequest);
            }
            else if (orchestrationRequest is EntryOverviewDialogRequestMessage entryOverviewDialogRequest)
            {
                handleEntryOverviewDialogRequest(entryOverviewDialogRequest);
            }
            else if (orchestrationRequest is ItemDuplicateDialogRequestMessage itemDuplicateDialogRequest)
            {
                handleItemDuplicateDialogRequest(itemDuplicateDialogRequest);
            }
            else if (orchestrationRequest is ItemEditDialogRequestMessage itemEditDialogRequest)
            {
                handleItemEditDialogRequest(itemEditDialogRequest);
            }
            else if (orchestrationRequest is ItemOverviewDialogRequestMessage itemOverviewDialogRequest)
            {
                handleItemOverviewDialogRequest(itemOverviewDialogRequest);
            }
            else if (orchestrationRequest is SourceCopyDialogRequestMessage sourceCopyDialogRequest)
            {
                handleSourceCopyDialogRequest(sourceCopyDialogRequest);
            }
            else if (orchestrationRequest is SourceEditDialogRequestMessage sourceEditDialogRequest)
            {
                handleSourceEditDialogRequest(sourceEditDialogRequest);
            }
            else if (orchestrationRequest is SourceOverviewDialogRequestMessage sourceOverviewDialogRequest)
            {
                handleSourceOverviewDialogRequest(sourceOverviewDialogRequest);
            }
            else
            {
                throw new OrchestrationException($"Unknown request message type '{orchestrationRequest?.GetType()}'");
            }
        }

        public bool CanHandleRequest(BaseOrchestrationRequest orchestrationRequest)
        {
            if (orchestrationRequest is BillEditDialogRequestMessage confirmationDialogRequest)
            {
                return confirmationDialogRequest.Request != null;
            }
            else if (orchestrationRequest is BillOverviewDialogRequestMessage billOverViewDialogRequest)
            {
                return billOverViewDialogRequest.Request != null;
            }
            else if (orchestrationRequest is EntryOverviewDialogRequestMessage entryOverviewDialogRequest)
            {
                return entryOverviewDialogRequest.Request != null;
            }
            else if (orchestrationRequest is ItemDuplicateDialogRequestMessage itemDuplicateDialogRequest)
            {
                return itemDuplicateDialogRequest.Request != null;
            }
            else if (orchestrationRequest is ItemEditDialogRequestMessage itemEditDialogRequest)
            {
                return itemEditDialogRequest.Request != null;
            }
            else if (orchestrationRequest is ItemOverviewDialogRequestMessage itemOverviewDialogRequest)
            {
                return itemOverviewDialogRequest.Request != null;
            }
            else if (orchestrationRequest is SourceCopyDialogRequestMessage sourceCopyDialogRequest)
            {
                return sourceCopyDialogRequest.Request != null;
            }
            else if (orchestrationRequest is SourceEditDialogRequestMessage sourceEditDialogRequest)
            {
                return sourceEditDialogRequest.Request != null;
            }
            else if (orchestrationRequest is SourceOverviewDialogRequestMessage sourceOverviewDialogRequest)
            {
                return sourceOverviewDialogRequest.Request != null;
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
                typeof(BillEditDialogRequestMessage),
                typeof(BillOverviewDialogRequestMessage),
                typeof(EntryOverviewDialogRequestMessage),
                typeof(ItemDuplicateDialogRequestMessage),
                typeof(ItemEditDialogRequestMessage),
                typeof(ItemOverviewDialogRequestMessage),
                typeof(SourceCopyDialogRequestMessage),
                typeof(SourceEditDialogRequestMessage),
                typeof(SourceOverviewDialogRequestMessage)
            };
        }



        //private methods
        private void handleSourceOverviewDialogRequest(SourceOverviewDialogRequestMessage sourceOverviewDialogRequest)
        {
            throw new NotImplementedException();
        }

        private void handleSourceEditDialogRequest(SourceEditDialogRequestMessage sourceEditDialogRequest)
        {
            throw new NotImplementedException();
        }

        private void handleSourceCopyDialogRequest(SourceCopyDialogRequestMessage sourceCopyDialogRequest)
        {
            throw new NotImplementedException();
        }

        private void handleItemOverviewDialogRequest(ItemOverviewDialogRequestMessage itemOverviewDialogRequest)
        {
            throw new NotImplementedException();
        }

        private void handleItemEditDialogRequest(ItemEditDialogRequestMessage itemEditDialogRequest)
        {
            throw new NotImplementedException();
        }

        private void handleItemDuplicateDialogRequest(ItemDuplicateDialogRequestMessage itemDuplicateDialogRequest)
        {
            throw new NotImplementedException();
        }

        private void handleEntryOverviewDialogRequest(EntryOverviewDialogRequestMessage entryOverviewDialogRequest)
        {
            throw new NotImplementedException();
        }

        private void handleBillOverviewDialogRequest(BillOverviewDialogRequestMessage billOverViewDialogRequest)
        {
            throw new NotImplementedException();
        }

        private void handleBillEditDialogRequest(BillEditDialogRequestMessage billEditDialogRequest)
        {
            throw new NotImplementedException();
        }

        //private void handleConfirmationDialogRequest(ConfirmationDialogRequestMessage confirmationDialogRequest)
        //{
        //    _dialogService.Show(
        //        nameof(ConfirmationDialogControl),
        //        new DialogParameters
        //        {
        //            {"Request", confirmationDialogRequest.Request},
        //            { "Title", confirmationDialogRequest.DialogTitle}
        //        },
        //        (result) =>
        //        {
        //            if (result.Result == ButtonResult.Yes)
        //            {
        //                if (result.Parameters.ContainsKey("Result"))
        //                {
        //                    confirmationDialogRequest.Result =
        //                        result.Parameters.GetValue<ConfirmationDialogResult>("Result");
        //                }
        //                confirmationDialogRequest.OnUserConfirmed?.Invoke(
        //                    confirmationDialogRequest.Result,
        //                    confirmationDialogRequest.Payload
        //                    );
        //            }
        //            else
        //            {
        //                confirmationDialogRequest.OnUserAbort?.Invoke(confirmationDialogRequest.Payload);
        //            }
        //        });
        //}
    }
}

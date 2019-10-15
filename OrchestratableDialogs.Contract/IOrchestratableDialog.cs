namespace Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.Contract
{
    public interface IOrchestratableDialog<TDialogRequest, TDialogResult>
        where TDialogResult :IDialogResult
        where TDialogRequest : IDialogRequest
    {
        TDialogResult Result { get; set; }
        TDialogRequest Request { get; }
        object Payload { get; }
    }

    public interface IOrchestratableDialog<TDialogRequest, TDialogResult, TPayload>
        where TDialogResult : IDialogResult
        where TDialogRequest : IDialogRequest
    {
        TDialogResult Result { get; set; }
        TDialogRequest Request { get; }
        TPayload Payload { get; }
    }
}

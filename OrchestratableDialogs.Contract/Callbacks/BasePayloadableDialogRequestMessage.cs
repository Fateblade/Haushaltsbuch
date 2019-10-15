namespace Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.Contract.Callbacks
{
    public abstract class BasePayloadableDialogRequestMessage<TRequest, TResult> 
        : BaseDialogRequestMessage, IOrchestratableDialog<TRequest, TResult>
        where TRequest : IDialogRequest
        where TResult : IDialogResult
    {
        //properties
        public TRequest Request { get; }
        public TResult Result { get; set; }
        public object Payload { get; }



        //constructors
        protected BasePayloadableDialogRequestMessage(string title, TRequest request, TResult result, object payload) : base(title)
        {
            Request = request;
            Result = result;
            Payload = payload;
        }
    }

    public abstract class BasePayloadableDialogRequestMessage<TRequest, TResult, TPayload>
        : BaseDialogRequestMessage, IOrchestratableDialog<TRequest, TResult, TPayload>
        where TRequest : IDialogRequest
        where TResult : IDialogResult
    {
        //properties
        public TRequest Request { get; }
        public TResult Result { get; set; }
        public TPayload Payload { get; }



        //constructors
        protected BasePayloadableDialogRequestMessage(string title, TRequest request, TResult result, TPayload payload) : base(title)
        {
            Request = request;
            Result = result;
            Payload = payload;
        }
    }
}

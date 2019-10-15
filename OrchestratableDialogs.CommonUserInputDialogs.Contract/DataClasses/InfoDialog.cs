using System;
using System.Collections.Generic;
using System.Text;
using Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.Contract;

namespace Fateblade.Haushaltsbuch.Logic.Foundation.OrchestratableDialogs.CommonUserInputDialogs.Contract.DataClasses
{
    public class InfoDialogResult : IDialogResult
    {
    }

    public class InfoDialogRequest : IDialogRequest
    {
        public string Info { get; set; }
    }
}

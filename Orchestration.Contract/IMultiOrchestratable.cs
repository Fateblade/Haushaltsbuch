using System;
using System.Collections.Generic;

namespace Fateblade.Haushaltsbuch.Logic.Foundation.Orchestration.Contract
{
    public interface IMultiOrchestratable : IOrchestratable
    {
        IEnumerable<Type> GetHandleableRequestTypes();
    }
}

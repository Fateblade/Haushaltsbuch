using Fateblade.Haushaltsbuch.Logic.Foundation.Orchestration;
using Fateblade.Haushaltsbuch.Logic.Foundation.Orchestration.Contract;
using Fateblade.Haushaltsbuch.Logic.Foundation.Orchestration.Contract.DataClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Orchestration.Tests.OrchestratorTests
{
    [TestClass]
    public partial class OrchestratorTests
    {
        //members
        private IOrchestrator _target;


        //constructors
        [TestInitialize]
        public void Initialize()
        {
            _target = new Orchestrator();

        }
    }

    public class SampleRequest : BaseOrchestrationRequest { }
}

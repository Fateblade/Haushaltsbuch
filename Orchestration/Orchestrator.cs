using System;
using System.Collections.Generic;
using Fateblade.Haushaltsbuch.Logic.Foundation.Orchestration.Contract;
using Fateblade.Haushaltsbuch.Logic.Foundation.Orchestration.Contract.DataClasses;
using Fateblade.Haushaltsbuch.Logic.Foundation.Orchestration.Contract.Exceptions;

namespace Fateblade.Haushaltsbuch.Logic.Foundation.Orchestration
{
    public class Orchestrator : IOrchestrator
    {
        //members
        private readonly Dictionary<Type, OrchestrationTypes> _orchestratableAvailabilityDicitonaDictionary;
        private readonly Dictionary<Type, IOrchestratable> _orchestratableDictionary;
        private readonly Dictionary<Type, Action<BaseOrchestrationRequest>> _delegateOrchestratableDictionary;



        //constructors
        public Orchestrator()
        {
            _orchestratableAvailabilityDicitonaDictionary = new Dictionary<Type, OrchestrationTypes>();
            _orchestratableDictionary = new Dictionary<Type, IOrchestratable>();
            _delegateOrchestratableDictionary = new Dictionary<Type, Action<BaseOrchestrationRequest>>();
        }



        //public methods
        public void Request(BaseOrchestrationRequest orchestrationRequest)
        {
            if (orchestrationRequest == null)
            {
                throw new OrchestrationException("Anfrage zur Orchestrierung darf nicht null sein", new ArgumentNullException(nameof(orchestrationRequest)));
            }

            var orchestrationRequestType = orchestrationRequest.GetType();
            if (!_orchestratableAvailabilityDicitonaDictionary.ContainsKey(orchestrationRequestType))
            {
                throw new OrchestrationException($"Orchestration vom Typ '{orchestrationRequestType}' sind nicht möglich, da es keinen registrierten Orchestratable dafür gibt");
            }

            var registeredOrchestratableType = _orchestratableAvailabilityDicitonaDictionary[orchestrationRequestType];
            if (registeredOrchestratableType == OrchestrationTypes.Delegate)
            {
                _delegateOrchestratableDictionary[orchestrationRequestType].Invoke(orchestrationRequest);
            }
            else
            {
                _orchestratableDictionary[orchestrationRequestType].HandleRequest(orchestrationRequest);
            }
        }

        public bool CanOrchestrate(BaseOrchestrationRequest orchestrationRequest)
        {
            if (orchestrationRequest == null)
            {
                throw new OrchestrationException("Zu prüfende Orchestrierung darf nicht null sein", new ArgumentNullException(nameof(orchestrationRequest)));
            }

            var orchestrationRequestType = orchestrationRequest.GetType();
            if (!_orchestratableAvailabilityDicitonaDictionary.ContainsKey(orchestrationRequestType))
            {
                return false;
            }

            var registeredOrchestratableType = _orchestratableAvailabilityDicitonaDictionary[orchestrationRequestType];
            if (registeredOrchestratableType == OrchestrationTypes.Delegate)
            {
                return true;
            }
            var result = _orchestratableDictionary[orchestrationRequestType].CanHandleRequest(orchestrationRequest);
            return result;
        }

        public void RegisterOrchestratable<TOrchestrationRequest>(IOrchestratable<TOrchestrationRequest> orchestratable) where TOrchestrationRequest : BaseOrchestrationRequest
        {
            if (orchestratable == null)
            {
                throw new OrchestrationException("Zu registrierendes Orchestratable darf nicht null sein", new ArgumentNullException(nameof(orchestratable)));
            }

            var orchestrationType = typeof(TOrchestrationRequest);
            if (_orchestratableAvailabilityDicitonaDictionary.ContainsKey(orchestrationType))
            {
                _orchestratableAvailabilityDicitonaDictionary.Remove(orchestrationType);
                _orchestratableDictionary.Remove(orchestrationType);
                _delegateOrchestratableDictionary.Remove(orchestrationType);
            }

            _orchestratableAvailabilityDicitonaDictionary.Add(orchestrationType, OrchestrationTypes.Orchestratable);
            _orchestratableDictionary.Add(orchestrationType, orchestratable);
        }

        public void RegisterOrchestratable<TOrchestrationRequest>(Action<BaseOrchestrationRequest> handler) where TOrchestrationRequest : BaseOrchestrationRequest
        {
            if (handler == null)
            {
                throw new OrchestrationException("Zu registrierendes Aktion darf nicht null sein", new ArgumentNullException(nameof(handler)));
            }

            var orchestrationType = typeof(TOrchestrationRequest);
            if (_orchestratableAvailabilityDicitonaDictionary.ContainsKey(orchestrationType))
            {
                _orchestratableAvailabilityDicitonaDictionary.Remove(orchestrationType);
                _orchestratableDictionary.Remove(orchestrationType);
                _delegateOrchestratableDictionary.Remove(orchestrationType);
            }

            _orchestratableAvailabilityDicitonaDictionary.Add(orchestrationType, OrchestrationTypes.Delegate);
            _delegateOrchestratableDictionary.Add(orchestrationType, handler);
        }

        public void RegisterOrchestratable(IMultiOrchestratable orchestratable)
        {
            if (orchestratable == null)
            {
                throw new OrchestrationException("Zu registrierendes Orchestratable darf nicht null sein", new ArgumentNullException(nameof(orchestratable)));
            }

            foreach (var orchestratableRequestType in orchestratable.GetHandleableRequestTypes())
            {
                if (!orchestratableRequestType.IsSubclassOf(typeof(BaseOrchestrationRequest)))
                {
                    throw new OrchestrationException(
                        $"Rückgabe der {nameof(orchestratable.GetHandleableRequestTypes)}-Methode darf nur Typen auf Basis der '{nameof(BaseOrchestrationRequest)}'-Klasse enthalten", 
                        new ArgumentException(nameof(orchestratable))
                    );
                }

                if (_orchestratableAvailabilityDicitonaDictionary.ContainsKey(orchestratableRequestType))
                {
                    _orchestratableAvailabilityDicitonaDictionary.Remove(orchestratableRequestType);
                    _orchestratableDictionary.Remove(orchestratableRequestType);
                    _delegateOrchestratableDictionary.Remove(orchestratableRequestType);
                }

                _orchestratableAvailabilityDicitonaDictionary.Add(orchestratableRequestType, OrchestrationTypes.Orchestratable);
                _orchestratableDictionary.Add(orchestratableRequestType, orchestratable);
            }
        }
    }

    public enum ProcessState
    {
        Inactive,
        Active,
        Paused,
        Terminated
    }

    public enum Command
    {
        Begin,
        End,
        Pause,
        Resume,
        Exit
    }

    public class Process
    {
        class StateTransition
        {
            readonly ProcessState CurrentState;
            readonly Command Command;

            public StateTransition(ProcessState currentState, Command command)
            {
                CurrentState = currentState;
                Command = command;
            }

            public override int GetHashCode()
            {
                return 17 + 31 * CurrentState.GetHashCode() + 31 * Command.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                StateTransition other = obj as StateTransition;
                return other != null && this.CurrentState == other.CurrentState && this.Command == other.Command;
            }
        }

        Dictionary<StateTransition, ProcessState> transitions;
        public ProcessState CurrentState { get; private set; }

        public Process()
        {
            CurrentState = ProcessState.Inactive;
            transitions = new Dictionary<StateTransition, ProcessState>
            {
                { new StateTransition(ProcessState.Inactive, Command.Exit), ProcessState.Terminated },
                { new StateTransition(ProcessState.Inactive, Command.Begin), ProcessState.Active },
                { new StateTransition(ProcessState.Active, Command.End), ProcessState.Inactive },
                { new StateTransition(ProcessState.Active, Command.Pause), ProcessState.Paused },
                { new StateTransition(ProcessState.Paused, Command.End), ProcessState.Inactive },
                { new StateTransition(ProcessState.Paused, Command.Resume), ProcessState.Active }
            };
        }

        public ProcessState GetNext(Command command)
        {
            StateTransition transition = new StateTransition(CurrentState, command);
            ProcessState nextState;
            if (!transitions.TryGetValue(transition, out nextState))
                throw new Exception("Invalid transition: " + CurrentState + " -> " + command);
            return nextState;
        }

        public ProcessState MoveNext(Command command)
        {
            CurrentState = GetNext(command);
            return CurrentState;
        }
    }


    public class Program
    {
        static void Main(string[] args)
        {
            Process p = new Process();
            Console.WriteLine("Current State = " + p.CurrentState);
            Console.WriteLine("Command.Begin: Current State = " + p.MoveNext(Command.Begin));
            Console.WriteLine("Command.Pause: Current State = " + p.MoveNext(Command.Pause));
            Console.WriteLine("Command.End: Current State = " + p.MoveNext(Command.End));
            Console.WriteLine("Command.Exit: Current State = " + p.MoveNext(Command.Exit));
            Console.ReadLine();
        }
    }
}
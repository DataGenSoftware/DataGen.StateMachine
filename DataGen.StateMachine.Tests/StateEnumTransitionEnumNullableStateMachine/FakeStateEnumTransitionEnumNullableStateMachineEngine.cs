using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.StateMachine.Tests.StateEnumTransitionEnumNullableStateMachine
{
    internal class FakeStateEnumTransitionEnumNullableStateMachineEngine : StateMachineEngine<FakeStates, FakeTransitions?>
    {
        protected override IDictionary<StateTransition<FakeStates, FakeTransitions?>, FakeStates> InitStatesTransitionsDictionary()
        {
            return new Dictionary<StateTransition<FakeStates, FakeTransitions?>, FakeStates>
            {
                { new StateTransition<FakeStates, FakeTransitions?>() { State = FakeStates.Stopped, Transition = FakeTransitions.Play }, FakeStates.Playing},
                { new StateTransition<FakeStates, FakeTransitions?>() { State = FakeStates.Playing, Transition = FakeTransitions.Stop }, FakeStates.Stopped},
                { new StateTransition<FakeStates, FakeTransitions?>() { State = FakeStates.Playing, Transition = FakeTransitions.Pause }, FakeStates.Paused},
                { new StateTransition<FakeStates, FakeTransitions?>() { State = FakeStates.Paused, Transition = FakeTransitions.Play }, FakeStates.Playing},
                { new StateTransition<FakeStates, FakeTransitions?>() { State = FakeStates.Paused, Transition = FakeTransitions.Stop }, FakeStates.Stopped},
            };
        }
    }
}

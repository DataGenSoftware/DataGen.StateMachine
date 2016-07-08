using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.StateMachine.Tests.StateEnumTransitionEnumNullableStateMachine
{
    internal class StateEnumTransitionEnumNullableStateMachineEngine : StateMachineEngine<States, Transitions?>
    {
        protected override IDictionary<StateTransition<States, Transitions?>, States> InitStatesTransitionsDictionary()
        {
            return new Dictionary<StateTransition<States, Transitions?>, States>
            {
                { new StateTransition<States, Transitions?>() { State = States.Stopped, Transition = Transitions.Play }, States.Playing},
                { new StateTransition<States, Transitions?>() { State = States.Playing, Transition = Transitions.Stop }, States.Stopped},
                { new StateTransition<States, Transitions?>() { State = States.Playing, Transition = Transitions.Pause }, States.Paused},
                { new StateTransition<States, Transitions?>() { State = States.Paused, Transition = Transitions.Play }, States.Playing},
                { new StateTransition<States, Transitions?>() { State = States.Paused, Transition = Transitions.Stop }, States.Stopped},
            };
        }
    }
}

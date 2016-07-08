using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.StateMachine.Tests.StateStringTransitionStringStateMachine
{
    internal class StateStringTransitionStringStateMachineEngine : StateMachineEngine<string, string>
    {
        protected override IDictionary<StateTransition<string, string>, string> InitStatesTransitionsDictionary()
        {
            return new Dictionary<StateTransition<string, string>, string>
            {
                { new StateTransition<string, string>() { State = "Stopped", Transition = "Play" }, "Playing"},
                { new StateTransition<string, string>() { State = "Playing", Transition = "Stop" }, "Stopped"},
                { new StateTransition<string, string>() { State = "Playing", Transition = "Pause" }, "Paused"},
                { new StateTransition<string, string>() { State = "Paused", Transition = "Play" }, "Playing"},
                { new StateTransition<string, string>() { State = "Paused", Transition = "Stop" }, "Stopped"},
            };
        }
    }
}

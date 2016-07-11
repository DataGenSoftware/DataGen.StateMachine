using DataGen.StateMachine;
using DataGen.StateMachine.ObjectOriented;
using DataGen.StateMachine.Tests.StateObjectTransitionEnumStateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine.Tests.StateObjectTransitionEnumStateMachine.States
{
    public class Paused : IState<Transitions>
    {
        public void HandleStateTransition(IStateMachineContext<IState<Transitions>, Transitions> stateContext, Transitions transition)
        {
            if (transition == Transitions.Play)
            {
                stateContext.State = new Playing();
            }
            else
            {
                throw new InvalidStateTransitionException(transition);
            }
        }
    }
}

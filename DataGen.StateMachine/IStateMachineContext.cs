using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.StateMachine
{
    public interface IStateMachineContext<TState, TTransition>
    {
        TState State { get; set; }

        TTransition Transition { get; set; }

        StateTransition<TState, TTransition> StateTransition { get; }

        void HandleTransition(TTransition transition);
    }
}

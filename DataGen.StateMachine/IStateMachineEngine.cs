using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.StateMachine
{
    public interface IStateMachineEngine<TState, TTransition>
    {
        void HandleStateTransition(StateMachineContext<TState, TTransition> stateMachineContext);
    }
}

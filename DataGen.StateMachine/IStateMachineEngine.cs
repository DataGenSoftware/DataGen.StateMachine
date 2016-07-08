using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.StateMachine
{
    public abstract class BaseStateMachineEngine<TState, TTransition>
    {
        internal abstract void HandleStateTransition(StateMachineContext<TState, TTransition> stateMachineContext, TTransition transition);
    }
}

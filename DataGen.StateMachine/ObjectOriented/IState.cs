using DataGen.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.StateMachine.ObjectOriented
{
    public interface IState<TTransition>
    {
        void HandleStateTransition(IStateMachineContext<IState<TTransition>, TTransition> stateMachineContext, TTransition transition);
    }
}

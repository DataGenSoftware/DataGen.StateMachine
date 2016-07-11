using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGen.Extensions;

namespace DataGen.StateMachine.ObjectOriented
{
    public class ObjectOrientedStateMachineContext<IState, TTransition> : IStateMachineContext<IState<TTransition>, TTransition>
    {
        public virtual IState<TTransition> State { get; set; }

        public void HandleTransition(TTransition transition)
        {
            if(State.IsNull())
            {
                throw new UnspecifiedStateMachineEngineException();
            }
            this.State.HandleStateTransition(this, transition);
        }

        public ObjectOrientedStateMachineContext()
        {
        }
    }
}

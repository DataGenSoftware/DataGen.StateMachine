using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGen.Extensions;

namespace DataGen.StateMachine
{
    public class StateMachineEngineContext<TState, TTransition> : IStateMachineContext<TState, TTransition>
    {
        protected virtual BaseStateMachineEngine<TState, TTransition> StateMachineEngine { get; set; }

        public virtual TState State { get; set; }

        public virtual void HandleTransition(TTransition transition)
        {
            if (this.StateMachineEngine.IsNull())
            {
                throw new UnspecifiedStateMachineEngineException();
            }
            this.StateMachineEngine.HandleStateTransition(this, transition);
        }

        public StateMachineEngineContext(BaseStateMachineEngine<TState, TTransition> stateMachine, TState state)
        {
            this.StateMachineEngine = stateMachine;
            this.State = state;
        }

        public StateMachineEngineContext(BaseStateMachineEngine<TState, TTransition> stateMachine)
        {
            this.StateMachineEngine = stateMachine;
            this.State = default(TState);
        }

        public StateMachineEngineContext()
        {
            this.State = default(TState);
        }
    }
}

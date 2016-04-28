using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.StateMachine
{
    public class InvalidStateTransitionException: Exception
    {
        public InvalidStateTransitionException(object stateTransition)
            :base("Invalid state transition. " + stateTransition.ToString() + ".")
        {
        }
    }
}

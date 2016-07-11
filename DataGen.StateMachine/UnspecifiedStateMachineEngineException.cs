using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.StateMachine
{
    public class UnspecifiedStateMachineEngineException : Exception
    {
        public UnspecifiedStateMachineEngineException()
            :base("State machine engine not set.")
        {
        }
    }
}

using DataGen.StateMachine.Example.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.StateMachine.Example2
{
    class Program
    {
        static StateMachineEngineContext<States, Transitions?> Player;

        static void Main(string[] args)
        {
            Player = new StateMachineEngineContext<States, Transitions?>(new StateMachineEngine(), States.Stopped);

            DisplayMenu();
        }

        private static void DisplayMenu()
        {
            Player.DisplayState();

            Console.WriteLine();
            Console.WriteLine("---Menu---");
            DisplayMenuTransitionsOptions();
            Console.WriteLine("X - Exit");

            StateMachineExampleHelper.GetUserCommand(new Action<string>(HandleMenuCommand));
        }

        private static void DisplayMenuTransitionsOptions()
        {
            foreach (var state in Enum.GetValues(typeof(Transitions)))
            {
                Console.WriteLine(string.Format("{0} - {1}", (int)state, Enum.GetName(typeof(Transitions), state)));
            }
        }

        private static void HandleMenuCommand(string command)
        {
            if (command.ToUpper() == "X")
            {
                Environment.Exit(0);
            }
            else
            {
                int transition;
                if (!int.TryParse(command, out transition))
                {
                    StateMachineExampleHelper.WrongCommand();
                }
                else
                {
                    if (((Transitions[])Enum.GetValues(typeof(Transitions))).Contains((Transitions)transition))
                    {
                        StateMachineExampleHelper.HandleCommand((Transitions)transition, Player);
                    }
                    else
                    {
                        StateMachineExampleHelper.WrongCommand();
                    }
                }
            }

            DisplayMenu();
        }
    }
}

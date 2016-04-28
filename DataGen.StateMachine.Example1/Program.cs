using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.StateMachine.Example1
{
    class Program
    {
        static StateMachineContext<States, Transitions> Player;

        static void Main(string[] args)
        {
            Player = new StateMachineContext<States, Transitions>(new StateMachineEngine(), States.Stopped);

            DisplayMenu();
        }

        private static void DisplayState()
        {
            Console.WriteLine();
            Console.WriteLine(string.Format("Current state: {0}", Player.State.ToString()));
        }

        private static void DisplayMenu()
        {
            DisplayState();

            Console.WriteLine();
            Console.WriteLine("---Menu---");
            foreach (var state in Enum.GetValues(typeof(Transitions)))
            {
                Console.WriteLine(string.Format("{0} - {1}", (int)state, Enum.GetName(typeof(Transitions), state)));
            }
            Console.WriteLine("X - Exit");

            GetUserCommand(new Action<string>(HandleMenuCommand));
        }

        private static void GetUserCommand(Action<string> menuCommandHandler)
        {
            var key = Console.ReadKey();
            Console.WriteLine();
            menuCommandHandler(key.KeyChar.ToString());
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
                    WrongCommand();
                }
                else
                {
                    if (((Transitions[])Enum.GetValues(typeof(Transitions))).Contains((Transitions)transition))
                    {
                        HandleCommand((Transitions)transition);
                    }
                    else
                    {
                        WrongCommand();
                    }
                }
            }

            DisplayMenu();
        }

        private static void HandleCommand(Transitions transition)
        {
            try
            {
                Player.HandleTransition(transition);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void WrongCommand()
        {
            Console.WriteLine("Wrong command! Try again.");
        }
    }
}

using Calculator.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string arg;
            if (args.Length == 0)
            {
                arg = GetTypeOfInput();
            }
            else
            {
                arg = args[0];
            }
            try
            {
                IConsoleWrapper consoleWrapper = new ConsoleWrapper();
                IGetterOperation getterOperation = null;
                bool inputFromConsole = false;
                if (arg == InputFromConsole.OperationFromConsole)
                {
                    inputFromConsole = true;
                    getterOperation = new GetterOperationFromConsole(
                        new ConsoleManagerRecorsive(new ConsoleManager(consoleWrapper)));
                }
                else
                {
                    getterOperation = new GetterOperationFromFile(arg, new FileWrapper());
                }

                Calculator calculator = new Calculator(inputFromConsole, getterOperation, consoleWrapper);
                calculator.Calculate();
            }
            catch (Exception)
            {
                Environment.Exit(1);
            }

        }
        private static string GetTypeOfInput()
        {
            Console.WriteLine(ConsoleMessages.NullArgs);
            string arg = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(arg))
            {
                Program.GetTypeOfInput();
            }
            if (arg == "x")
            {
                Environment.Exit(0);
            }
            return arg;
        }
    }
}


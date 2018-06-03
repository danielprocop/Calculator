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
            IConsoleWrapper consoleWrapper = new ConsoleWrapper();
            IGetterOperation getterOperation = null;
            bool inputFromConsole = false;

            if (args.Length == 0)
            {
                consoleWrapper.WriteLine(ConsoleMessages.NullArgs);
                Environment.Exit(1);
            }

            try
            {
                if (args[0] == InputFromConsole.OperationFromConsole)
                {
                    inputFromConsole = true;
                    getterOperation = new GetterOperationFromConsole(
                        new ConsoleManagerRecorsive(new ConsoleManager(consoleWrapper)));
                }
                else
                {
                    getterOperation = new GetterOperationFromFile(args[0], new FileWrapper());
                }

                Calculator calculator = new Calculator(inputFromConsole, getterOperation, consoleWrapper);
                calculator.Calculate();
            }
            catch (Exception)
            {
                Environment.Exit(1);
            }

        }
    }
}


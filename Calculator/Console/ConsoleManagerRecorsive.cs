using Calculator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class ConsoleManagerRecorsive : IConsoleManager
    {
        IConsoleManager ConsoleManager;
        public ConsoleManagerRecorsive(IConsoleManager consoleManager)
        {
            this.ConsoleManager = consoleManager;
        }
        public bool GetParameter<T>(out T result, string message) where T : IConvertible
        {
            bool pass = false;
            result = default(T);
            while (!pass)
            {
                pass = this.ConsoleManager.GetParameter<T>(out result, message);
            }
            return pass;
        }

        public bool GetParameter<T>(out T result, string message, IValidator validator) where T : IConvertible
        {
            bool pass = false;
            result = default(T);
            while (!pass)
            {
                pass = this.ConsoleManager.GetParameter<T>(out result, message,validator);
            }
            return pass;
        }
    }
}

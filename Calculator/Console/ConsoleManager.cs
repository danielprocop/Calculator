using Calculator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class ConsoleManager:IConsoleManager
    {
        public IConsoleWrapper ConsoleWrapper { get; private set; }
        public ConsoleManager(IConsoleWrapper consoleWrapper)
        {
            if (consoleWrapper == null)
            {
                throw new ArgumentNullException("consoleWrapper");
            }
            this.ConsoleWrapper = consoleWrapper;
        }
        public bool GetParameter<T>(out T result, string message)
            where T : IConvertible
        {
            if (message == null)
            {
                throw new ArgumentNullException(message);
            }
            this.ConsoleWrapper.Write(message);
            result = default(T);

            string line = this.ConsoleWrapper.ReadLine();
            if (line == null)
            {
                throw new InvalidOperationException();
            }

            if (!Converter.StringConvertTo(line, out result))
            {
                this.ConsoleWrapper.WriteLine(ConsoleMessages.InvalidArgument, line);
                return false;
            }

            return true;
        }
        public bool GetParameter<T>(out T result, string message,IValidator validator)
            where T : IConvertible
        {
            bool pass = this.GetParameter<T>(out result, message);
            if(pass && validator!=null)
            {
                if (!validator.IsValid(result))
                {
                    this.ConsoleWrapper.WriteLine(ConsoleMessages.InvalidOperator, result.ToString());
                    pass = false;
                }
            }
           
            return pass;
        }
    }
}

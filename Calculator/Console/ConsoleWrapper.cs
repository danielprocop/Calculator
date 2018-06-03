using Calculator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class ConsoleWrapper:IConsoleWrapper
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message, string line)
        {
            Console.WriteLine(message, line);
        }
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}

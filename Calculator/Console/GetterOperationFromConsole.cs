using Calculator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class GetterOperationFromConsole : IGetterOperation
    {
        private IConsoleManager ConsoleManager;
        public GetterOperationFromConsole(IConsoleManager consoleManager)
        {
            if (consoleManager == null)
            {
                throw new ArgumentNullException("consoleManager");
            }
            this.ConsoleManager = consoleManager;
        }
        public IOperation GetOperation()
        {
            decimal firstNumber = default(decimal);
            decimal secondNumber = default(decimal);
            string operatorValue;

            ConsoleManager.GetParameter<decimal>(out firstNumber, ConsoleMessages.InsertFirstNumber);
            ConsoleManager.GetParameter<decimal>(out secondNumber, ConsoleMessages.InsertSecondNumber);
            ConsoleManager.GetParameter<string>(
                out operatorValue,
                string.Format(ConsoleMessages.InsertOperator, OperatorSymbols.GetOperators()),
                new OperatorValidator());

              return OperationCreator.Create(firstNumber, secondNumber, operatorValue); 
        }
      
    }
}

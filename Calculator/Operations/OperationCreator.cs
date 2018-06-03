using Calculator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class OperationCreator
    {
        public static IOperation Create(decimal firstNumber, decimal secondNumber, string operatorValue)
        {
            IOperation operation = null;
            switch (operatorValue)
            {
                case OperatorSymbols.Addition:
                    operation = new SumOperation(firstNumber, secondNumber);
                    break;
                case OperatorSymbols.Substraction:
                    operation = new SubstractOperation(firstNumber, secondNumber);
                    break;
                case OperatorSymbols.Multiplication:
                    operation = new MultiplyOperation(firstNumber, secondNumber);
                    break;
                case OperatorSymbols.Division:
                    operation = new DivideOperation(firstNumber, secondNumber);
                    break;
                default:
                    throw new InvalidOperationException("Invalid operator");
            }
            return operation;
        }
    }
}

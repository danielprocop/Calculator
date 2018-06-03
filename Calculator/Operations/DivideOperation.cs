using Calculator.Interface;
using System;

namespace Calculator
{
    public class DivideOperation : IOperation
    {
        public decimal FirstNumber { get;}
        public decimal SecondNumber { get;}
        public DivideOperation(decimal firstNumber,decimal secondNumber)
        {
            if (secondNumber == 0)
            {
                throw new InvalidOperationException(
                    string.Format(ConsoleMessages.DivideByZeroException, this.GetTextOperation()));
            }
            this.FirstNumber = firstNumber;
            this.SecondNumber = secondNumber;
        }
        public decimal Calculate()
        {
            return this.FirstNumber / this.SecondNumber;
        }

        public string GetTextOperation()
        {
            return string.Format("{0} / {1}", this.FirstNumber, this.SecondNumber);
        }
    }
}

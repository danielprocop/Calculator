using Calculator.Interface;
using System;

namespace Calculator
{
    public class MultiplyOperation : IOperation
    {
        public decimal FirstNumber { get;}
        public decimal SecondNumber { get; }
        public MultiplyOperation(decimal firstNumber, decimal secondNumber)
        {
            this.FirstNumber = firstNumber;
            this.SecondNumber = secondNumber;
        }
        public decimal Calculate()
        {
            return this.FirstNumber * this.SecondNumber;
        }
        public string GetTextOperation()
        {
            return string.Format("{0} * {1}", this.FirstNumber, this.SecondNumber);
        }
    }
}

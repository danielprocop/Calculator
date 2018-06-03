using Calculator.Interface;

namespace Calculator
{
    public class SubstractOperation : IOperation
    {
        public decimal FirstNumber { get; set; }
        public decimal SecondNumber { get; set; }
        public SubstractOperation(decimal firstNumber, decimal secondNumber)
        {
            this.FirstNumber = firstNumber;
            this.SecondNumber = secondNumber;
        }
        public decimal Calculate()
        {
            return this.FirstNumber - this.SecondNumber;
        }
        public string GetTextOperation()
        {
            return string.Format("{0} - {1}", this.FirstNumber, this.SecondNumber);
        }
    }
}

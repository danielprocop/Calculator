using Calculator.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class SumOperation: IOperation
    {
        public decimal FirstNumber { get; set; }
        public decimal SecondNumber { get; set; }
        public SumOperation(decimal firstNumber, decimal secondNumber)
        {
            this.FirstNumber = firstNumber;
            this.SecondNumber = secondNumber;
        }
        public decimal Calculate()
        {
            return this.FirstNumber + this.SecondNumber;
        }
        public string GetTextOperation()
        {
            return string.Format("{0} + {1}", this.FirstNumber, this.SecondNumber);
        }
    }
}

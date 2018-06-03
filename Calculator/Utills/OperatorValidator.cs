using Calculator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class OperatorValidator: IValidator
    {
        public bool IsValid<T>(T value) where T : IConvertible
        {
            if (value == null)
            {
                throw new ArgumentNullException("value to be convert");
            }
            var operation = value.ToString();
            String[] validOperation = new[]
            {
                OperatorSymbols.Addition,
                OperatorSymbols.Substraction,
                OperatorSymbols.Multiplication,
                OperatorSymbols.Division
            };

            return validOperation.Contains(operation);
        }
    }
}

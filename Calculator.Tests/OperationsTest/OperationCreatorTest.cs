using Calculator.Interface;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tests.OperationsTest
{
    [TestFixture]
    class OperationCreatorTest
    {
        [TestCase(4,4,"+")]
        public void CreateOperation_ValidOperator(decimal firstNumber,decimal secondNumber, string operatorValue)
        {
            IOperation operation = OperationCreator.Create(firstNumber, secondNumber, operatorValue);

            Assert.NotNull(operation);
            Assert.AreEqual(firstNumber, operation.FirstNumber);
            Assert.AreEqual(secondNumber, operation.SecondNumber);
            Assert.IsInstanceOf<SumOperation>(operation);
        }

        [TestCase(4, 4, "y")]
        public void CreateOperation_InvalidOperator_ThrowException(decimal firstNumber, decimal secondNumber, string operatorValue)
        {
            var ex = Assert.Throws<InvalidOperationException>(() =>
                 OperationCreator.Create(firstNumber, secondNumber, operatorValue));
        }
    }
}

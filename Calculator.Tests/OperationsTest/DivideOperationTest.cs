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
    public class DivideOperationTest
    {
        [Test]
        public void Create_DivideOperation_ReturnInstance()
        {
            IOperation sut = new DivideOperation(3, 9);

            Assert.IsNotNull(sut);
            Assert.AreEqual(sut.FirstNumber, 3);
            Assert.AreEqual(sut.SecondNumber, 9);
        }

        [Test]
        public void Create_DivideOperation_ThrowException()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => new DivideOperation(3, 0));

        }

        [Test]
        public void DivedeOperation_ReturnTheRightResult()
        {
            IOperation sut = new DivideOperation(1, 1);

            decimal result = sut.Calculate();

            Assert.AreEqual(1, result);
        }
        [Test]
        public void DivedeOperation_GetTextOperation()
        {
            IOperation sut = new DivideOperation(1, 1);

            string text = sut.GetTextOperation();

            Assert.AreEqual("1 / 1", text);
        }
    }
}

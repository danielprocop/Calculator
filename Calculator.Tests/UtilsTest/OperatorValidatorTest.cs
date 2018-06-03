using Calculator.Interface;
using NUnit.Framework;
using System;

namespace Calculator.Tests
{
    [TestFixture]
    public class OperatorValidatorTest
    {
        [TestCase("+")]
        [TestCase("-")]
        [TestCase("-")]
        [TestCase("/")]
        public void IsValidOperator_ValidOperator_ReturnTrue(string value)
        {
            IValidator sut = new OperatorValidator();

            bool isValid = sut.IsValid<string>(value);

            Assert.True(isValid);
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("//")]
        [TestCase("A")]
        [TestCase("0")]
        [TestCase("/r/n")]
        public void IsValidOperator_InvalidOperator_ReturnFalse(string value)
        {
            IValidator sut = new OperatorValidator();

            bool isValid = sut.IsValid<string>(value);

            Assert.False(isValid);
        }
        [TestCase(null)]
        public void IsValidOperator_IfNullOperator_ThrowException(string value)
        {
            IValidator sut = new OperatorValidator();

            var ex = Assert.Throws<ArgumentNullException>(() => sut.IsValid(value));

        }
    }
}

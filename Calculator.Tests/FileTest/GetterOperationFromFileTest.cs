using Calculator.Interface;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tests.FileTest
{
    [TestFixture]
    public class GetterOperationFromFileTest
    {
        [TestCase("1\n\r1\n\r+")]
        public void GetOperation_ValidFileWithSumOperation_ReturnSumOperation(string textFromFile)
        {
            IFileWrapper stubFileWrapper = Substitute.For<IFileWrapper>();
            stubFileWrapper.ReadAllText(Arg.Any<string>()).Returns(textFromFile);
            var sut = new GetterOperationFromFile("path", stubFileWrapper);

            IOperation operation=sut.GetOperation();
            Assert.AreEqual(1, operation.FirstNumber);
            Assert.AreEqual(1, operation.SecondNumber);

            Assert.IsInstanceOf<SumOperation>(operation);
        }
        [TestCase("1\n\r1\n\r-")]
        public void GetOperation_ValidFileWithSubstractOperation_ReturnSubstractOperation(string textFromFile)
        {
            IFileWrapper stubFileWrapper = Substitute.For<IFileWrapper>();
            stubFileWrapper.ReadAllText(Arg.Any<string>()).Returns(textFromFile);
            var sut = new GetterOperationFromFile("path", stubFileWrapper);

            IOperation operation = sut.GetOperation();
            Assert.AreEqual(1, operation.FirstNumber);
            Assert.AreEqual(1, operation.SecondNumber);

            Assert.IsInstanceOf<SubstractOperation>(operation);
        }
        [TestCase("1\n\r1\n\r*")]
        public void GetOperation_ValidFileWithMultiplyOperation_ReturnMultiplyOperation(string textFromFile)
        {
            IFileWrapper stubFileWrapper = Substitute.For<IFileWrapper>();
            stubFileWrapper.ReadAllText(Arg.Any<string>()).Returns(textFromFile);
            var sut = new GetterOperationFromFile("path", stubFileWrapper);

            IOperation operation = sut.GetOperation();
            Assert.AreEqual(1, operation.FirstNumber);
            Assert.AreEqual(1, operation.SecondNumber);

            Assert.IsInstanceOf<MultiplyOperation>(operation);
        }
        [TestCase("1\n\r1\n\r/")]
        public void GetOperation_ValidFileWithDivideOperation_ReturnDivedeOperation(string textFromFile)
        {
            IFileWrapper stubFileWrapper = Substitute.For<IFileWrapper>();
            stubFileWrapper.ReadAllText(Arg.Any<string>()).Returns(textFromFile);
            var sut = new GetterOperationFromFile("path", stubFileWrapper);

            IOperation operation = sut.GetOperation();
            Assert.AreEqual(1, operation.FirstNumber);
            Assert.AreEqual(1, operation.SecondNumber);

            Assert.IsInstanceOf<DivideOperation>(operation);
        }
        [TestCase("1\n\r0\n\r/")]
        public void GetOperation_FileWithInvalidDivideOperation_Throw(string textFromFile)
        {
            IFileWrapper stubFileWrapper = Substitute.For<IFileWrapper>();
            stubFileWrapper.ReadAllText(Arg.Any<string>()).Returns(textFromFile);
            var sut = new GetterOperationFromFile("path", stubFileWrapper);

            var ex = Assert.Throws<InvalidOperationException>(() =>
                        sut.GetOperation());

        }
        [TestCase("1\n\r0\n\r/")]
        [TestCase("1\n\r1\n\rs")]
        [TestCase("s\n\r1\n\r/")]
        [TestCase("\n\r\n\r/")]
        [TestCase("\n\\n\r")]
        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        public void GetOperation_FileWithInvalidArgumentOperation_Throw(string textFromFile)
        {
            IFileWrapper stubFileWrapper = Substitute.For<IFileWrapper>();
            stubFileWrapper.ReadAllText(Arg.Any<string>()).Returns(textFromFile);
            var sut = new GetterOperationFromFile("path", stubFileWrapper);

            var ex = Assert.Throws<InvalidOperationException>(() =>
                        sut.GetOperation());

        }
        [TestCase("1\n\r1\n\r+")]
        public void GetOperation_ReadFromFile_FileMethodIsCalled(string textFromFile)
        {
            IFileWrapper mockFileWrapper = Substitute.For<IFileWrapper>();
            mockFileWrapper.ReadAllText(Arg.Any<string>()).Returns(textFromFile);
            var sut = new GetterOperationFromFile("path", mockFileWrapper);

            IOperation operation = sut.GetOperation();

            mockFileWrapper.Received().ReadAllText(Arg.Any<string>());
        }
    }
}

using Calculator.Interface;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tests
{
    [TestFixture]
    public class ConsoleManagerTest
    {
        [TestCase("1",1)]
        [TestCase("1,1", 1.1)]
        [TestCase("0", 0)]
        public void GetParameter_ValidValueInserted_ReturnTheNumber(string valueInserted,decimal numberInserted)
        {
            IConsoleWrapper stubConsole = Substitute.For<IConsoleWrapper>();
            stubConsole.ReadLine().Returns(valueInserted);
            ConsoleManager sut = new ConsoleManager(stubConsole);

            decimal firstArgument;
            bool isValid=sut.GetParameter(out firstArgument, "Insert first number");

            Assert.True(isValid);
            Assert.AreEqual(numberInserted, firstArgument);
        }

        [TestCase("+")]
        [TestCase("-")]
        [TestCase("*")]
        [TestCase("/")]
        public void GetParameter_ValidOperatorInserted_ReturnTheOperator(string valueInserted)
        {
            IConsoleWrapper stubConsole = Substitute.For<IConsoleWrapper>();
            IValidator stubOperatorValidator = Substitute.For<IValidator>();
            stubConsole.ReadLine().Returns(valueInserted);
            stubOperatorValidator.IsValid(Arg.Any<string>()).Returns(true);
            ConsoleManager sut = new ConsoleManager(stubConsole);

            string operation;
            bool isValid = sut.GetParameter(out operation, "Insert the Operation", stubOperatorValidator);

            Assert.True(isValid);
            Assert.AreEqual(valueInserted, operation);
        }

        [TestCase("+")]
        [TestCase("-")]
        [TestCase("*")]
        [TestCase("/")]
        public void GetParameter_GetOperator_CheckIfValid(string valueInserted)
        {
            IConsoleWrapper stubConsole = Substitute.For<IConsoleWrapper>();
            IValidator mockOperatorValidator = Substitute.For<IValidator>();
            stubConsole.ReadLine().Returns(valueInserted);
            mockOperatorValidator.IsValid(Arg.Any<string>()).Returns(true);
            ConsoleManager sut = new ConsoleManager(stubConsole);

            string operation;
            sut.GetParameter(out operation, "Insert the Operation", mockOperatorValidator);

            mockOperatorValidator.Received().IsValid(valueInserted);
        }

        [TestCase("A")]
        [TestCase("/")]
        [TestCase("")]
        [TestCase(" ")]
        public void GetParameter_InvalidValueInserted_WriteErrorLogToConsole(string valueInserted)
        {
            IConsoleWrapper mockConsole = Substitute.For<IConsoleWrapper>();
            mockConsole.ReadLine().Returns(valueInserted);
            ConsoleManager sut = new ConsoleManager(mockConsole);

            decimal number;
            sut.GetParameter(out number, ConsoleMessages.InsertFirstNumber);

            mockConsole.Received().WriteLine(ConsoleMessages.InvalidArgument, valueInserted);
        }
        [TestCase("1")]
        public void GetParameter_ValidValueInserted_NotWriteErrorLogToConsole(string valueInserted)
        {
            IConsoleWrapper mockConsole = Substitute.For<IConsoleWrapper>();
            mockConsole.ReadLine().Returns(valueInserted);
            ConsoleManager sut = new ConsoleManager(mockConsole);

            decimal number;
            sut.GetParameter(out number, ConsoleMessages.InsertFirstNumber);

            mockConsole.DidNotReceive().WriteLine(ConsoleMessages.InvalidArgument, valueInserted);
        }
        [Test]
        public void GetParameter_AskForParameterToConsole_ConsoleReceveMessage()
        {
            IConsoleWrapper mockConsole = Substitute.For<IConsoleWrapper>();
            ConsoleManager sut = new ConsoleManager(mockConsole);

            string operation;
            sut.GetParameter(out operation, ConsoleMessages.InsertOperator);

            mockConsole.Received().Write(ConsoleMessages.InsertOperator);
        }
    }
}

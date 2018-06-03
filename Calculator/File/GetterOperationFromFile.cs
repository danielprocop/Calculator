using Calculator.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class GetterOperationFromFile : IGetterOperation
    {
        private string Path;
        private IFileWrapper FileWrapper;
        public GetterOperationFromFile(string path,IFileWrapper fileWrapper)
        {
            if (fileWrapper == null)
            {
                throw new ArgumentNullException("fileWrapper");
            }
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException("path");
            }
            this.Path = path;
            this.FileWrapper = fileWrapper;
        }
        public IOperation GetOperation()
        {

            string readAllText = FileWrapper.ReadAllText(this.Path);
            if (readAllText == null)
            {
                throw new InvalidOperationException("readAllText");
            }

            string[] parameters = readAllText.Split(new char[] { '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries);

            if (parameters.Length != 3)
            {
                throw new InvalidOperationException(
                    ConsoleMessages.InvalidFile);
            }
            decimal firstNumber = this.GetParameter<decimal>(parameters[0]);
            decimal secondNumber = this.GetParameter<decimal>(parameters[1]);
            string operatorValue = this.GetParameter<string>(parameters[2],new OperatorValidator());
            return OperationCreator.Create(firstNumber, secondNumber, operatorValue);
        }
        private T GetParameter<T>(string line)
    where T : IConvertible
        {
            if (line == null)
            {
                throw new ArgumentNullException("line");
            }
            T result = default(T);

            if (!Converter.StringConvertTo(line, out result))
            {
                throw new InvalidOperationException(string.Format(ConsoleMessages.InvalidArgument, line));
            }

            return result;
        }
        private T GetParameter<T>(string line, IValidator validator)
            where T : IConvertible
        {
            T result = this.GetParameter<T>(line);
            if (validator != null)
            {
                if (!validator.IsValid(result))
                {
                    throw new InvalidOperationException(string.Format(ConsoleMessages.InvalidOperator, line));
                }
            }

            return result;
        }
    }
}

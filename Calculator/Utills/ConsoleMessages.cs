namespace Calculator
{
    public class ConsoleMessages
    {
        public const string NullArgs ="the argument is required, please insert 'interactive' for input from console or the path of the file";
        public const string PressEnterCloseApplication = "press enter to close!";
        public const string CheckIfNewOperation = "please insert [y] for another operation or [x] for close: ";
        public const string InvalidArgument = "The argument [{0}] is invalid...";
        public const string InvalidOperator = "The operator [{0}] is invalid...";
        public const string InsertFirstNumber = "Insert the first number: ";
        public const string InsertSecondNumber = "Insert the first number: ";
        public const string InsertOperator = "Insert the operator ({0}): ";
        public const string FileNotFound = "File not found! ";
        public const string InvalidFile = "The parameters in the file must be 3, in this format:\r\n" +
                    "first number\r\n" +
                    "secondNumber\r\n" +
                    "operator";
        public const string DivideByZeroException = "Invalid Operation {0}: Divide by zero it's not a valid operation";
    }
}

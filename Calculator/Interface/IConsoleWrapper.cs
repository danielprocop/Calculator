namespace Calculator.Interface
{
    public interface IConsoleWrapper
    {
        string ReadLine();
        void Write(string message);
        void WriteLine(string message, string line);
        void WriteLine(string message);
    }
}
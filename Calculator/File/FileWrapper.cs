
using Calculator.Interface;
using System.IO;

namespace Calculator
{
    public class FileWrapper:IFileWrapper
    {
        public  string ReadAllText(string path)
        {
            if (!System.IO.File.Exists(path))
            {
                throw new FileNotFoundException(ConsoleMessages.FileNotFound,path);
            }
            return System.IO.File.ReadAllText(path);
        }
    }
}

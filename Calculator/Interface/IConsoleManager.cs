using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Interface
{
    public interface IConsoleManager
    {
        bool GetParameter<T>(out T result, string message) where T:IConvertible;
        bool GetParameter<T>(out T result, string message,IValidator validator) where T : IConvertible;
    }
}

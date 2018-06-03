using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Interface
{
    public interface IOperation
    {
        decimal FirstNumber { get;}
        decimal SecondNumber { get;}
        decimal Calculate();
        string GetTextOperation();
    }
}

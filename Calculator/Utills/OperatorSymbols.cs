using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class OperatorSymbols
    {
        public const string Addition = "+";
        public const string Substraction = "-";
        public const string Multiplication = "*";
        public const string Division = "/";

        public static string GetOperators()
        {
            return string.Format("[{0}] [{1}] [{2}] [{3}]", 
                Addition, Substraction, Multiplication, Division);
        }
    }
}

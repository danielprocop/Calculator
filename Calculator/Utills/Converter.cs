using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Converter
    {
        public static bool StringConvertTo<T>(string line, out T resultValue)
        {
            if (line == null)
            {
                throw new ArgumentNullException();
            }
            var type = typeof(T);
            resultValue = default(T);
            if (line.Contains("."))
            {
                return false;
            }
            try
            {
                resultValue =(T) Convert.ChangeType(line,typeof(T));
                return true;
            }
            catch
            {
                return false;
            }
        }
 
    }
}

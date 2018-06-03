using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tests
{
    [TestFixture]
    public class ConverterTest
    {
        [TestCase("1")]
        [TestCase("1,0")]
        public void StringConvertTo_Decimal_ReturnTheDecimalNumber(string value)
        {
            decimal result;
            bool convertable=Converter.StringConvertTo<Decimal>(value,out result);

            Assert.True(convertable);
            Assert.AreEqual(1.0m, result);
        }
        [TestCase("1")]
        public void StringConvertTo_Integer_ReturnTheIntegerNumber(string value)
        {
            int result;
            bool convertable = Converter.StringConvertTo<Int32>(value, out result);

            Assert.True(convertable);
            Assert.AreEqual(1, result);
        }
        [TestCase("1")]
        public void StringConvertTo_String_ReturnTheString(string value)
        {
            string result;
            bool convertable = Converter.StringConvertTo<String>(value, out result);

            Assert.True(convertable);
            Assert.AreEqual(value, result);
        }
        [TestCase("A")]
        [TestCase("")]
        [TestCase(" ")]
        public void StringConvertTo_Decimal_ReturnFalse(string value)
        {
            decimal result;
            bool convertable = Converter.StringConvertTo<Decimal>(value, out result);

            Assert.False(convertable);
            Assert.AreNotEqual(1.0m, result);
            Assert.AreEqual(0m, result);
        }

        [TestCase(null)]
        public void StringConvertToDecimal_NullValue_ThrowException(string value)
        {
            decimal result;
            var ex = Assert.Throws<ArgumentNullException>(() =>
                 Converter.StringConvertTo<Decimal>(value, out result));
        }
    }
}

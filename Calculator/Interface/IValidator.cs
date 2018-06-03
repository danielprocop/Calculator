using System;

namespace Calculator.Interface
{
    public interface IValidator
    {
        bool IsValid<T>(T result) where T : IConvertible;
    }
}
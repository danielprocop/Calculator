using Calculator.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator
    {
        public decimal Result { get; set; }
        public bool IsInputFromConsole { get; set; }
        private IConsoleWrapper ConsoleWrapper;
        private IGetterOperation GetterOperation;
        public Calculator(bool inputFromConsole,IGetterOperation getterOperation, IConsoleWrapper consoleWrapper)
        {
            if (getterOperation == null)
            {
                throw new ArgumentNullException("getterOperation");
            }
            if (consoleWrapper == null)
            {
                throw new ArgumentNullException("consoleWrapper");
            }
            this.IsInputFromConsole = inputFromConsole;
            this.GetterOperation = getterOperation;
            this.ConsoleWrapper = consoleWrapper;
        }

        public void Calculate()
        {
            try
            {
                IOperation operation =this.GetterOperation.GetOperation();
                this.Result = operation.Calculate();
                this.ConsoleWrapper.WriteLine(
                        string.Format("->: {0} = {1}", operation.GetTextOperation(), this.Result));
                
            }
            catch (InvalidOperationException ex)
            {
                this.ConsoleWrapper.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                this.ConsoleWrapper.WriteLine(ex.Message + ex.FileName);
            }
            catch (ArgumentNullException ex)
            {
                this.ConsoleWrapper.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                this.ConsoleWrapper.WriteLine(ex.Message);
            }
            finally
            {
                if (IsInputFromConsole)
                {
                    CheckIfNewOperation();
                }
                else
                {
                    this.ConsoleWrapper.WriteLine(ConsoleMessages.PressEnterCloseApplication);
                    this.ConsoleWrapper.ReadLine();
                }
            }
        }
        private void CheckIfNewOperation()
        {
            this.ConsoleWrapper.Write(ConsoleMessages.CheckIfNewOperation);
            string input = this.ConsoleWrapper.ReadLine();
            switch (input)
            {
                case InputFromConsole.Close:
                    break;
                case InputFromConsole.Continue:
                    this.Calculate();
                    break;
                default:
                    this.CheckIfNewOperation();
                    break;
            }
        }

    }
}

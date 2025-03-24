using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CalculatorApp.Data;

namespace CalculatorApp.Logic
{
    public class Calculator
    {
        public CalculationResult Add(double a, double b)
        {
            return new CalculationResult
            {
                Result = a + b,
                Operation = "Addition"
            };
        }

        public CalculationResult Subtract(double a, double b)
        {
            return new CalculationResult
            {
                Result = a - b,
                Operation = "Subtraction"
            };
        }

        public CalculationResult Multiply(double a, double b)
        {
            return new CalculationResult
            {
                Result = a * b,
                Operation = "Multiplication"
            };
        }

        public CalculationResult Divide(double a, double b)
        {
            if (b == 0)
                throw new InvalidOperationException("Cannot divide by zero");

            return new CalculationResult
            {
                Result = a / b,
                Operation = "Division"
            };
        }
    }
}


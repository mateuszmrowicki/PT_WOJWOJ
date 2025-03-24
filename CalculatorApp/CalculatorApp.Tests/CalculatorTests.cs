using CalculatorApp.Logic;
using CalculatorApp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorApp.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [TestInitialize]
        public void SetUp()
        {
            _calculator = new Calculator();
        }

        [TestMethod]
        public void Add_ShouldReturnCorrectResult()
        {
            double a = 5;
            double b = 3;
            var result = _calculator.Add(a, b);
            Assert.AreEqual(8, result.Result);
            Assert.AreEqual("Addition", result.Operation);
        }

        [TestMethod]
        public void Subtract_ShouldReturnCorrectResult()
        {
            double a = 5;
            double b = 3;
            var result = _calculator.Subtract(a, b);
            Assert.AreEqual(2, result.Result);
            Assert.AreEqual("Subtraction", result.Operation);
        }

        [TestMethod]
        public void Multiply_ShouldReturnCorrectResult()
        {
            double a = 5;
            double b = 3;
            var result = _calculator.Multiply(a, b);
            Assert.AreEqual(15, result.Result);
            Assert.AreEqual("Multiplication", result.Operation);
        }

        [TestMethod]
        public void Divide_ShouldReturnCorrectResult()
        {
            double a = 6;
            double b = 3;
            var result = _calculator.Divide(a, b);
            Assert.AreEqual(2, result.Result);
            Assert.AreEqual("Division", result.Operation);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Divide_ByZero_ShouldThrowException()
        {
            double a = 5;
            double b = 0;
            _calculator.Divide(a, b);
        }
    }
}

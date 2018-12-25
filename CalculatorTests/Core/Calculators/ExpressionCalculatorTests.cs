using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Core.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Calculators.Tests
{
    [TestClass()]
    public class ExpressionCalculatorTests
    {
        [TestMethod()]
        public void Calculate_CorrectExpression_ReturnTrue()
        {
            var expression = "2+2";
            var calculator = new ExpressionCalculator();
            var result = calculator.Calculate(expression);
            Assert.IsTrue(result == 4);
        }
    }
}
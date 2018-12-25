using System;
using System.Data;

namespace Calculator.Core.Calculators
{
    public class ExpressionCalculator : ICalculator
    {
        public double Calculate(string expression)
        {
            var dataTable = new DataTable();
            var result = dataTable.Compute(expression, "");
            return Convert.ToDouble(result);
        }
    }
}

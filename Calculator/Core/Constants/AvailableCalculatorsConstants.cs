using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Constants
{
    public static class AvailableCalculatorsConstants
    {
        public static string[] AvailableCalculators()
        {
            return new string[]
            {
                "BasicCalculatorViewModel",
                "ScientificCalculatorViewModel",
            };
        }
    }
}

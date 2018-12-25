using Calculator.Core.Calculators;
using Calculator.Models;
using Calculator.ViewModels.Base;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModels.Calculators
{
    public class ScientificCalculatorViewModel : CalculatorViewModelBase
    {

        public ScientificCalculatorViewModel(ICalculator calculator):base(calculator)
        {
        }

        public override string CalculatorType => "Scientific";
    }
}

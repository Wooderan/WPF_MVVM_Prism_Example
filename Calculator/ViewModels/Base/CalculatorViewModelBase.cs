using Calculator.Models;
using Calculator.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModels.Base
{
    public abstract class CalculatorViewModelBase : ViewModelBase, ICalculatorViewModel
    {
        public abstract string CalculatorType { get; }

        public abstract ICollection<Calculation> Calculations { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.ViewModels.Interfaces;

namespace Calculator.Core.Helpers
{
    public interface IContainerHelpers
    {
        //T Create<T>(string typeName) where T : class,new();
        ObservableCollection<ICalculatorViewModel> GetAvailableCalculators();
    }
}

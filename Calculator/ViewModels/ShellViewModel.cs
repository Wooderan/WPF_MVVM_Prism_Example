using Calculator.Core.Calculators;
using Calculator.ViewModels.Base;
using Calculator.ViewModels.Calculators;
using Prism.Commands;

namespace Calculator.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        public ShellViewModel(ICalculator calculator)
        {
            var view = new BasicCalculatorViewModel(calculator);
            this.SelectedCalculatorViewModel = view;
        }

        public static string Title { get; } = "Cool Calculator";

        #region Fields
        private ViewModelBase _selectedCalculatorViewModel;

        public ViewModelBase SelectedCalculatorViewModel
        {
            get { return _selectedCalculatorViewModel; }
            set { SetProperty(ref _selectedCalculatorViewModel, value); }
        }
        #endregion
    }
}

using Calculator.Core.Calculators;
using Calculator.ViewModels.Base;
using Prism.Commands;

namespace Calculator.ViewModels
{
    internal class ShellViewModel : ViewModelBase
    {

        #region Fields
        private ICalculator _calculator;
        private string _expressionText;
        private bool _justCulculated ;


        public static string Title { get; } = "Cool Calculator";
        public string ExpressionText
            {
                get => _expressionText;
                set => SetProperty(ref _expressionText, value);
            }
        #endregion

        #region Commands
        #region AddNumberCommand
        private DelegateCommand<string> _addNumberCommand;
        public DelegateCommand<string> AddNumberCommand =>
            _addNumberCommand ?? (_addNumberCommand = new DelegateCommand<string>(ExecuteAddNumberCommand));

        private void ExecuteAddNumberCommand(string num)
        {
            int n;
            if (_justCulculated)
            {
                if (int.TryParse(num, out n))//if it's number clear field, else it's sign, and we continue to calculate
                {
                    this.ExecuteClearCommand();
                }
                _justCulculated = false;
            }
            ExpressionText += num;
        }
        #endregion
        #region ClearCommand
        private DelegateCommand _clearCommand;
        public DelegateCommand ClearCommand =>
            _clearCommand ?? (_clearCommand = new DelegateCommand(ExecuteClearCommand));

        private void ExecuteClearCommand()
        {
            ExpressionText = string.Empty;
        }
        #endregion
        #region EqualsCommand
        private DelegateCommand _equalsCommand;

        public DelegateCommand EqualsCommand =>
            _equalsCommand ?? (_equalsCommand = new DelegateCommand(ExecuteEqualsCommand));

        private void ExecuteEqualsCommand()
        {
            ExpressionText = _calculator.Calculate(ExpressionText).ToString();
            _justCulculated = true;
        }
        #endregion
        #endregion

        public ShellViewModel(ICalculator calculator)
        {
            _calculator = calculator;
        }
    }
}

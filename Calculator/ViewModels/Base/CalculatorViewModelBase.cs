using Calculator.Core.Calculators;
using Calculator.Models;
using Calculator.ViewModels.Interfaces;
using Prism.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Calculator.ViewModels.Base
{
    public abstract class CalculatorViewModelBase : ViewModelBase, ICalculatorViewModel
    {
        #region Fields

        protected ICalculator _calculator;
        public abstract string CalculatorType { get; }
        public ICollection<Calculation> Calculations { get;} = new ObservableCollection<Calculation>();
        protected string _expressionText;
        protected bool _justCulculated;



        public string ExpressionText
        {
            get => _expressionText;
            set => SetProperty(ref _expressionText, value);
        }

        #endregion

        #region Constructors

        public CalculatorViewModelBase(ICalculator calculator)
        {
            _calculator = calculator;
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
            string result = _calculator.Calculate(ExpressionText).ToString();
            var calculation = new Calculation(ExpressionText, result);

            this.Calculations.Add(calculation);
            ExpressionText = result;
            _justCulculated = true;
        }

        #endregion

        #endregion
    }
}

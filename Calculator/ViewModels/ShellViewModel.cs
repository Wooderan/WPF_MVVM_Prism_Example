using Calculator.Core.Helpers;
using Calculator.ViewModels.Base;
using Calculator.ViewModels.Interfaces;
using Prism.Commands;
using System.Collections.ObjectModel;

namespace Calculator.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        public ShellViewModel(IContainerHelpers containerHelper)
        {
            this.Calculators = containerHelper.GetAvailableCalculators();
            this.SelectedCalculatorViewModel = this.Calculators[0];
        }


        #region Fields

        private ObservableCollection<ICalculatorViewModel> _calculators;
        private ICalculatorViewModel _selectedCalculatorViewModel;


        public static string Title { get; } = "Cool Calculator";
        public ObservableCollection<ICalculatorViewModel> Calculators { get => _calculators; private set => _calculators = value; }
        public ICalculatorViewModel SelectedCalculatorViewModel
        {
            get { return _selectedCalculatorViewModel; }
            set { SetProperty(ref _selectedCalculatorViewModel, value); }
        }

        private bool _isLeftFlyOpened;
        public bool IsLeftFlyOpened
        {
            get { return _isLeftFlyOpened; }
            set { SetProperty(ref _isLeftFlyOpened, value); }
        }

        private bool _isBottomFlyOpened;
        public bool IsBottomFlyOpened
        {
            get { return _isBottomFlyOpened; }
            set { SetProperty(ref _isBottomFlyOpened, value); }
        }


        #endregion

        #region Commands
        private DelegateCommand<string> _toggleFlyoutCommand;
        public DelegateCommand<string> ToggleFlyoutCommand =>   
            _toggleFlyoutCommand ?? (_toggleFlyoutCommand = new DelegateCommand<string>(ExecuteToggleFlyoutCommand));

        void ExecuteToggleFlyoutCommand(string property)
        {
            var prop = this.GetType().GetProperty(property);
            prop.SetValue(this, !(bool)prop.GetValue(this));
        }       

        #endregion

    }
}

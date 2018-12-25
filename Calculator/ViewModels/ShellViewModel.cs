using Calculator.Core.Calculators;
using Calculator.Core.Helpers;
using Calculator.ViewModels.Base;
using Calculator.ViewModels.Calculators;
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

        public static string Title { get; } = "Cool Calculator";

        #region Fields

        private ObservableCollection<ICalculatorViewModel> _calculators;
        private ICalculatorViewModel _selectedCalculatorViewModel;


        public ObservableCollection<ICalculatorViewModel> Calculators { get => _calculators; private set => _calculators = value; }
        public ICalculatorViewModel SelectedCalculatorViewModel
        {
            get { return _selectedCalculatorViewModel; }
            set { SetProperty(ref _selectedCalculatorViewModel, value); }
        }

        private bool _isFlyOpened;
        public bool IsFlyOpened
        {
            get { return _isFlyOpened; }
            set { SetProperty(ref _isFlyOpened, value); }
        }


        #endregion

        #region Commands
        private DelegateCommand _toggleFlyoutCommand;
        public DelegateCommand ToggleFlyoutCommand =>
            _toggleFlyoutCommand ?? (_toggleFlyoutCommand = new DelegateCommand(ExecuteToggleFlyoutCommand));


        void ExecuteToggleFlyoutCommand()
        {
            this.IsFlyOpened = !this.IsFlyOpened;
        }
        #endregion

    }
}

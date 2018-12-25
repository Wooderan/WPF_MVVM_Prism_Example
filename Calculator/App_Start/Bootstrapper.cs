using Calculator.Views;
using Prism.Unity;
using System.Windows;
using Microsoft.Practices.Unity;

namespace Calculator.App_Start
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return this.Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();  
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            this.Container.RegisterInstances()
                          .RegisterSingletones();
        }
    }
}

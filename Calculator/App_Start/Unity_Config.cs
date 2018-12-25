using Calculator.Core.Calculators;
using Calculator.Core.Helpers;
using Microsoft.Practices.Unity;

namespace Calculator.App_Start
{
    public static class Unity_Config
    {
        public static IUnityContainer RegisterInstances(this IUnityContainer container)
        {
            container.RegisterType<ICalculator, ExpressionCalculator>();
            return container;
        }

        public static IUnityContainer RegisterSingletones(this IUnityContainer container)
        {
            container.RegisterType<IContainerHelpers, ContainerHelper>(new ContainerControlledLifetimeManager());
            return container;
        }
    }
}

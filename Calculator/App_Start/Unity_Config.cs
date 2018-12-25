using Calculator.Core.Calculators;
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
    }
}

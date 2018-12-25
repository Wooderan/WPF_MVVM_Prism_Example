using Calculator.Core.Constants;
using Calculator.ViewModels.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Helpers
{
    class ContainerHelper : IContainerHelpers
    {
        private IUnityContainer _container;

        public ContainerHelper(IUnityContainer container)
        {
            _container = container;
        }

        //public T Create<T>(string typeName) where T:class,new()
        //{
        //    var type = Assembly.GetExecutingAssembly().GetType(typeName);
        //    if (type == null)
        //    {
        //        throw new InvalidOperationException("There is no type - " + typeName);
        //    }
        //    else
        //    {
        //        return (T)_container.Resolve(type);
        //    }
        //}

        public ObservableCollection<ICalculatorViewModel> GetAvailableCalculators()
        {
            string[] availableCalculators = AvailableCalculatorsConstants.AvailableCalculators();
            ObservableCollection<ICalculatorViewModel> resultCollection = new ObservableCollection<ICalculatorViewModel>();

            foreach (string calcType in availableCalculators)
            {
                var type = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(t => t.Name == calcType);
                if (type == null)
                {
                    throw new InvalidOperationException("There is no type - " + calcType);
                }
                else
                {
                    resultCollection.Add((ICalculatorViewModel)_container.Resolve(type));
                }
            }
            return resultCollection;
        }
    }
}

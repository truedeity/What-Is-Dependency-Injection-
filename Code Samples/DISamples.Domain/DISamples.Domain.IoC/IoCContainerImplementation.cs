using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DISamples.Domain.IoC
{
    public class IoCContainerImplementation : IoCContainer
    {
        private readonly StructureMap.IContainer _container;

        public IoCContainerImplementation(StructureMap.IContainer container)
        {
            _container = container;
        }

        public object GetInstance(Type instanceType)
        {
            return _container.GetInstance(instanceType);
        }

        public IEnumerable<object> GetAllInstances()
        {
            return _container.GetAllInstances<object>();
        }

        public object TryGetInstance(Type instanceType)
        {
            return _container.TryGetInstance(instanceType);
        }
    }
}

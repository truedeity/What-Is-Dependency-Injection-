using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DISamples.Domain.IoC.StructureMap
{
    public class IoCContainerImplementation : IoCContainer
    {
        private readonly IContainer Container;

        public IoCContainerImplementation(IContainer container)
        {
            Container = container;
        }

        public object GetInstance(Type instanceType)
        {
            return Container.GetInstance(instanceType);
        }

        public IEnumerable<object> GetAllInstances()
        {
            return Container.GetAllInstances<object>();
        }

        public object TryGetInstance(Type instanceType)
        {
            return Container.TryGetInstance(instanceType);
        }
    }
}

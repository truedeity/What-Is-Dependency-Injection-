using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace DISamples.Domain.IoC
{
    public class Container : Domain.IContainer
    {
        private readonly StructureMap.IContainer _container;

        public Container(StructureMap.IContainer container)
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

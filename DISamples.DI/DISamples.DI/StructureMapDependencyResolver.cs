using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DISamples.DI
{
    public class StructureMapDependencyResolver : IDependencyResolver
    {
        private readonly IContainer Container;

        public StructureMapDependencyResolver(IContainer container)
        {
            Container = container;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType.IsAbstract || serviceType.IsInterface)
                return Container.TryGetInstance(serviceType);
            else
                return Container.GetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Container.GetAllInstances<object>()
                            .Where(s => s.GetType() == serviceType);
        }
    }
}
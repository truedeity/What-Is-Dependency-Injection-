using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DISamples.Domain.Web
{
    public class DomainDependencyResolver : IDependencyResolver
    {
        private readonly IContainer _container;

        public DomainDependencyResolver(IContainer container)
        {
            _container = container;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType.IsAbstract || serviceType.IsInterface)
                return _container.TryGetInstance(serviceType);
            else
                return _container.GetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.GetAllInstances()
                             .Where(s => s.GetType() == serviceType);
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DISamples.Domain.Application.Web
{
    public class DomainDependencyResolver : IDependencyResolver
    {
        private readonly IoCContainer Container;

        public DomainDependencyResolver(IoCContainer container)
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
            return Container.GetAllInstances()
                            .Where(s => s.GetType() == serviceType);
        }
    }
}
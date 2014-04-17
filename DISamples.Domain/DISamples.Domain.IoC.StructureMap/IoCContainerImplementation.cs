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

        public T GetInstance<T>()
        {
            return Container.GetInstance<T>();
        }
    }
}

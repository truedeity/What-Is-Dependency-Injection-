using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;

namespace DISamples.Domain.IoC
{
    public static class Initializer
    {
        public static void Initialize()
        {
            ObjectFactory.Configure(x =>
            {
                x.For<DISamples.Domain.ProductRepository>().Use<DISamples.Domain.DAL.ProductRepositoryImplementation>();
            });

            DISamples.Domain.IoCContainerFactory.Current = new IoCContainerImplementation(ObjectFactory.Container);
        }
    }
}

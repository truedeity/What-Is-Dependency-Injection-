using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace DISamples.Domain.IoC
{
    public static class Initializer
    {
        public static void Initialize()
        {
            ObjectFactory.Configure(x =>
            {
                x.For<DISamples.Domain.Repositories.IProductRepository>().Use<DISamples.Domain.DAL.ProductRepository>();
            });

            DISamples.Domain.ContainerFactory.Current = new Container(ObjectFactory.Container);
        }
    }
}

﻿using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DISamples.Domain.IoC.StructureMap
{
    public static class Initializer
    {
        public static void Initialize()
        {
            ObjectFactory.Configure(x =>
            {
                x.For<DISamples.Domain.Repositories.ProductRepository>()
                 .Use<DISamples.Domain.DAL.LINQ.ProductRepositoryImplementation>();
                x.For<DISamples.Domain.Logger>()
                 .Use<DISamples.Domain.Logging.Log4Net.LoggerImplementation>();
            });

            DISamples.Domain.IoCContainerFactory.Current = new IoCContainerImplementation(ObjectFactory.Container);
        }
    }
}











using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DISamples.Domain
{
    public interface IContainer
    {
        object GetInstance(Type instanceType);
        IEnumerable<object> GetAllInstances();
        object TryGetInstance(Type instanceType);
    }

    public static class ContainerFactory
    {
        public static IContainer Current { get; set; }
    }
}

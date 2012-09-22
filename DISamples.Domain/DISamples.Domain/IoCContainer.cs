using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DISamples.Domain
{
    public interface IoCContainer
    {
        object GetInstance(Type instanceType);
        IEnumerable<object> GetAllInstances();
        object TryGetInstance(Type instanceType);
    }

    public static class IoCContainerFactory
    {
        public static IoCContainer Current { get; set; }
    }
}

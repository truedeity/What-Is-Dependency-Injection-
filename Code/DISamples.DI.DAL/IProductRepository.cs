using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DISamples.DI.DAL
{
    public interface IProductRepository
    {
        IEnumerable<Product> Get();
        Product Save(Product product);
    }
}

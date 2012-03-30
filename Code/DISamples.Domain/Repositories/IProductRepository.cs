using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DISamples.Domain.Models;

namespace DISamples.Domain.Repositories
{
    public interface IProductRepository
    {
        Product Get(int productID);
        IEnumerable<Product> Get();
        Product Save(Product product);
    }
}

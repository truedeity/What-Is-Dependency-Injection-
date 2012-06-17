using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DISamples.Domain.DAL
{
    public class ProductRepositoryImplementation : ProductRepository
    {
        private AdventureWorksDataContext _db = new AdventureWorksDataContext();

        public Domain.Product Get(int productID)
        {
            return _db.Products.Where(p => p.ProductID == productID)
                               .Select(p => new Domain.Product
                               {
                                   ProductID = p.ProductID,
                                   Name = p.Name,
                                   ProductNumber = p.ProductNumber,
                                   ListPrice = p.ListPrice
                               }).Single();
        }

        public IEnumerable<Domain.Product> Get()
        {
            return _db.Products.Select(p => new Domain.Product
            {
                ProductID = p.ProductID,
                Name = p.Name,
                ProductNumber = p.ProductNumber,
                ListPrice = p.ListPrice
            });
        }

        public Domain.Product Save(Domain.Product product)
        {
            if (product.ProductID > 0)
            {
                var existingProduct = _db.Products.Where(p => p.ProductID == product.ProductID).Single();
                existingProduct.Name = product.Name;
                existingProduct.ProductNumber = product.ProductNumber;
                existingProduct.ListPrice = product.ListPrice;
            }
            else
            {
                _db.Products.InsertOnSubmit(new Product
                {
                    ProductID = product.ProductID,
                    Name = product.Name,
                    ProductNumber = product.ProductNumber,
                    ListPrice = product.ListPrice
                });
            }
            _db.SubmitChanges();
            return product;
        }
    }
}

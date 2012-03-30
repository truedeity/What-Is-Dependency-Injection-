using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DISamples.DI.DAL.LINQ
{
    public class ProductRepository : DISamples.DI.DAL.IProductRepository
    {
        private AdventureWorksDataContext _db = new AdventureWorksDataContext();

        public IEnumerable<DAL.Product> Get()
        {
            return _db.Products.Select(p => new DAL.Product
                               {
                                   ProductID = p.ProductID,
                                   Name = p.Name,
                                   ProductNumber = p.ProductNumber,
                                   ListPrice = p.ListPrice
                               });
        }

        public DAL.Product Save(DAL.Product product)
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

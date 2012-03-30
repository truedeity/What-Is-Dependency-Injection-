using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DISamples.Layers.DAL
{
    public class ProductRepository
    {
        private AdventureWorksDataContext _db = new AdventureWorksDataContext();

        public Product Get(int productID)
        {
            return _db.Products.Where(p => p.ProductID == productID).Single();
        }

        public IEnumerable<Product> Get()
        {
            return _db.Products;
        }

        public Product Save(Product product)
        {
            if (product.ProductID > 0)
            {
                var existingProduct = Get(product.ProductID);
                existingProduct.Name = product.Name;
                existingProduct.ProductNumber = product.ProductNumber;
                existingProduct.ListPrice = product.ListPrice;
                product = existingProduct;
            }
            else
            {
                _db.Products.InsertOnSubmit(product);
            }
            _db.SubmitChanges();
            return product;
        }
    }
}

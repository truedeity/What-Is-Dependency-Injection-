using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DISamples.Layers.DAL
{
    public class ProductRepository
    {
        private AdventureWorksDataContext db = new AdventureWorksDataContext();

        public IEnumerable<Product> Get()
        {
            return db.Products;
        }

        public Product Save(Product product)
        {
            if (product.ProductID > 0)
            {
                var existingProduct = Get().Single(p => p.ProductID == product.ProductID);
                existingProduct.Name = product.Name;
                existingProduct.ProductNumber = product.ProductNumber;
                existingProduct.ListPrice = product.ListPrice;
                product = existingProduct;
            }
            else
            {
                db.Products.InsertOnSubmit(product);
            }
            db.SubmitChanges();
            return product;
        }
    }
}

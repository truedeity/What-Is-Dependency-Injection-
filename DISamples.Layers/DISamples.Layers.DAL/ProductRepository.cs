using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DISamples.Layers.DAL
{
    public class ProductRepository
    {
        private AdventureWorksDataContext DB = new AdventureWorksDataContext();

        public IEnumerable<Product> Get()
        {
            return DB.Products;
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
                DB.Products.InsertOnSubmit(product);
            }
            DB.SubmitChanges();
            return product;
        }
    }
}

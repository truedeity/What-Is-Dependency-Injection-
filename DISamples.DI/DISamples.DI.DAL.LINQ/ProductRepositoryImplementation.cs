using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DISamples.DI.DAL.LINQ
{
    public class ProductRepositoryImplementation : ProductRepository
    {
        private AdventureWorksDataContext DB = new AdventureWorksDataContext();

        public IEnumerable<DAL.Product> Get()
        {
            return DB.Products.Select(p => new DAL.Product
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
                var existingProduct = DB.Products.Where(p => p.ProductID == product.ProductID).Single();
                existingProduct.Name = product.Name;
                existingProduct.ProductNumber = product.ProductNumber;
                existingProduct.ListPrice = product.ListPrice;
            }
            else
            {
                DB.Products.InsertOnSubmit(new Product
                {
                    ProductID = product.ProductID,
                    Name = product.Name,
                    ProductNumber = product.ProductNumber,
                    ListPrice = product.ListPrice
                });
            }
            DB.SubmitChanges();
            return product;
        }
    }
}

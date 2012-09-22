using DISamples.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DISamples.Domain.DAL.LINQ
{
    public class ProductRepositoryImplementation : ProductRepository
    {
        private AdventureWorksDataContext DB = new AdventureWorksDataContext();

        public IEnumerable<Models.Product> Get()
        {
            return DB.Products.Select(p => BuildModelFromDB(p));
        }

        public Models.Product Save(Models.Product product)
        {
            if (product.ProductID > 0)
                UpdateExistingProduct(product);
            else
                InsertNewProduct(product);
            DB.SubmitChanges();
            return product;
        }

        private Models.Product BuildModelFromDB(Product p)
        {
            return new Models.Product
            {
                ProductID = p.ProductID,
                Name = p.Name,
                ProductNumber = p.ProductNumber,
                ListPrice = p.ListPrice
            };
        }

        private void UpdateExistingProduct(Models.Product product)
        {
            var existingProduct = DB.Products.Where(p => p.ProductID == product.ProductID).Single();
            existingProduct.Name = product.Name;
            existingProduct.ProductNumber = product.ProductNumber;
            existingProduct.ListPrice = product.ListPrice;
        }

        private void InsertNewProduct(Models.Product product)
        {
            DB.Products.InsertOnSubmit(BuildDBFromModel(product));
        }

        private Product BuildDBFromModel(Models.Product product)
        {
            return new Product
            {
                ProductID = product.ProductID,
                Name = product.Name,
                ProductNumber = product.ProductNumber,
                ListPrice = product.ListPrice
            };
        }
    }
}

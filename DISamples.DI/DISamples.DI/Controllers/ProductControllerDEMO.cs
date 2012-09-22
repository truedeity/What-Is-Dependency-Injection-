using DISamples.DI.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DISamples.DI.Controllers
{
    public class ProductController : Controller
    {
        private DISamples.DI.DAL.LINQ.AdventureWorksDataContext DB = new DAL.LINQ.AdventureWorksDataContext();

        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View(DB.Products.Select(p => new Product { ProductID = p.ProductID, Name = p.Name, ProductNumber = p.ProductNumber, ListPrice = p.ListPrice }));
        }

        //
        // GET: /Product/Edit/5

        public ActionResult Edit(int id)
        {
            return View(DB.Products.Select(p => new Product { ProductID = p.ProductID, Name = p.Name, ProductNumber = p.ProductNumber, ListPrice = p.ListPrice }).Single(p => p.ProductID == id));
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                var existingProduct = DB.Products.Single(p => p.ProductID == product.ProductID);
                existingProduct.Name = product.Name;
                existingProduct.ProductNumber = product.ProductNumber;
                existingProduct.ListPrice = product.ListPrice;
                DB.SubmitChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

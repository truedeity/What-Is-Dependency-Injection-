using DISamples.NoLayers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DISamples.NoLayers.Controllers
{
    public class ProductController : Controller
    {
        private AdventureWorksDataContext DB = new AdventureWorksDataContext();

        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View(DB.Products);
        }

        //
        // GET: /Product/Edit/5

        public ActionResult Edit(int id)
        {
            return View(DB.Products.Single(p => p.ProductID == id));
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
                return View(product);
            }
        }
    }
}

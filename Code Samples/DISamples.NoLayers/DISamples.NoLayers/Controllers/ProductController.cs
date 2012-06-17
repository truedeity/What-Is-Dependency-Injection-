using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DISamples.NoLayers.Models;

namespace DISamples.NoLayers.Controllers
{
    public class ProductController : Controller
    {
        private AdventureWorksDataContext db = new AdventureWorksDataContext();

        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View(db.Products);
        }

        //
        // GET: /Product/Edit/5

        public ActionResult Edit(int id)
        {
            return View(db.Products.Single(p => p.ProductID == id));
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, string name, string productNumber, decimal listPrice)
        {
            var product = db.Products.Where(p => p.ProductID == id).Single();
            product.Name = name;
            product.ProductNumber = productNumber;
            product.ListPrice = listPrice;
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}

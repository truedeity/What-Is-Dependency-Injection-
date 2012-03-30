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
        private AdventureWorksDataContext _db = new AdventureWorksDataContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View(_db.Products);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(_db.Products.Where(p => p.ProductID == id).Single());
        }

        [HttpPost]
        public ActionResult Edit(int id, string name, string productNumber, decimal listPrice)
        {
            var product = _db.Products.Where(p => p.ProductID == id).Single();
            product.Name = name;
            product.ProductNumber = productNumber;
            product.ListPrice = listPrice;
            _db.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}

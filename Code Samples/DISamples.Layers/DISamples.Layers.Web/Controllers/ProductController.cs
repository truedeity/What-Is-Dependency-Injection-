using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DISamples.Layers.DAL;

namespace DISamples.Layers.Web.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository repository = new ProductRepository();

        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View(repository.Get());
        }

        //
        // GET: /Product/Edit/5

        public ActionResult Edit(int id)
        {
            return View(repository.Get().Single(p => p.ProductID == id));
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, string name, string productNumber, decimal listPrice)
        {
            repository.Save(new Product
            {
                ProductID = id,
                Name = name,
                ProductNumber = productNumber,
                ListPrice = listPrice
            });
            return RedirectToAction("Index");
        }
    }
}
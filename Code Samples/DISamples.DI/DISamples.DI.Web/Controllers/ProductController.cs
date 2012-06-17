using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DISamples.DI.DAL;

namespace DISamples.DI.Web.Controllers
{
    public class ProductController : Controller
    {
        private ProductRepository repository;

        public ProductController(ProductRepository repo)
        {
            repository = repo;
        }

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
            return View(repository.Get().Where(p => p.ProductID == id).Single());
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

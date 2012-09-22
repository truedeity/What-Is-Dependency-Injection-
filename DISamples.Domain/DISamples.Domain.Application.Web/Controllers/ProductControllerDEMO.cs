using DISamples.Domain.Models;
using DISamples.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DISamples.Domain.Application.Web.Controllers
{
    public class ProductController : Controller
    {
        private ProductRepository Repository;
        private Logger Logger;

        public ProductController(ProductRepository repository, Logger logger)
        {
            Repository = repository;
            Logger = logger;
        }

        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View(Repository.Get());
        }

        //
        // GET: /Product/Edit/5

        public ActionResult Edit(int id)
        {
            return View(Repository.Get().Single(p => p.ProductID == id));
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                Repository.Save(product);
                Logger.Info(string.Format("Somebody edited Product ID {0}", product.ProductID.ToString()));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

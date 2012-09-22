using DISamples.Layers.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DISamples.Layers.Controllers
{
    public class ProductController : Controller
    {
        private ProductRepository Repository = new ProductRepository();

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

                return RedirectToAction("Index");
            }
            catch
            {
                return View(product);
            }
        }
    }
}

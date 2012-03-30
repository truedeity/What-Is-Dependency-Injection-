using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DISamples.Layers.DAL;

namespace DISamples.Layers.Controllers
{
    public class ProductController : Controller
    {
        private ProductRepository _repository = new ProductRepository();

        [HttpGet]
        public ActionResult Index()
        {
            return View(_repository.Get());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(_repository.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, string name, string productNumber, decimal listPrice)
        {
            _repository.Save(new Product
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

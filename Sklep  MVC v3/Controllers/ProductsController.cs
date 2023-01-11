using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sklep__MVC_v3.Models;

namespace Sklep__MVC_v3.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            SklepDbContext db = new SklepDbContext();
            List<Product> products = db.Products.ToList();

            return View(products);
        }
    }
}
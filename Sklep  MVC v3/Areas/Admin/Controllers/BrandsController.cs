using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sklep__MVC_v3.Models;

namespace Sklep__MVC_v3.Areas.Admin.Controllers
{
    public class BrandsController : Controller
    {
        // GET: Admin/Brands
        public ActionResult Index()
        {
            SklepDbContext db = new SklepDbContext();
            List<Brand> brands = db.Brands.ToList();
            return View(brands);
        }
    }
}
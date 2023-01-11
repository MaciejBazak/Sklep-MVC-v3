using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sklep__MVC_v3.Models;

namespace Sklep__MVC_v3.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Admin/Categories
        public ActionResult Index()
        {
            SklepDbContext db = new SklepDbContext();
            List<Category> categories = db.Categories.ToList();


            return View(categories);
        }
    }
}
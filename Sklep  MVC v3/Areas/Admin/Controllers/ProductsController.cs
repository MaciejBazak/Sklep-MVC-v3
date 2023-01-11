using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sklep__MVC_v3.Models;

namespace Sklep__MVC_v3.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        SklepDbContext db = new SklepDbContext();

        // GET: Products
        public ActionResult Index(string search = "", string SortColumn = "ProductName", string IconClass = "fa-sort-asc")
        {

            ViewBag.search = search;
            //List<Product> products = db.Products.ToList();
            List<Product> products = db.Products.Where(temp => temp.ProductName.Contains(search)).ToList();

            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;
            if (ViewBag.SortColumn == "ProductID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.ProductID).ToList();
                else
                    products = products.OrderByDescending(temp => temp.ProductID).ToList();
            }
            else if (ViewBag.SortColumn == "ProductName")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.ProductName).ToList();
                else
                    products = products.OrderByDescending(temp => temp.ProductName).ToList();
            }
            else if (ViewBag.SortColumn == "Price")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.Price).ToList();
                else
                    products = products.OrderByDescending(temp => temp.Price).ToList();
            }
            else if (ViewBag.SortColumn == "DateOfPurchase")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.DateOfPurchase).ToList();
                else
                    products = products.OrderByDescending(temp => temp.DateOfPurchase).ToList();
            }
            else if (ViewBag.SortColumn == "AvailabilityStatus")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.AvailabilityStatus).ToList();
                else
                    products = products.OrderByDescending(temp => temp.AvailabilityStatus).ToList();
            }
            else if (ViewBag.SortColumn == "CategoryID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.Category.CategoryName).ToList();
                else
                    products = products.OrderByDescending(temp => temp.Category.CategoryName).ToList();
            }
            else if (ViewBag.SortColumn == "BrandID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.Brand.BrandName).ToList();
                else
                    products = products.OrderByDescending(temp => temp.Brand.BrandName).ToList();
            }


            return View(products);
        }

        public ActionResult Details(long id)
        {

            Product p = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();

            return View(p);
        }

        public ActionResult Create()
        {

            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "ProductID, ProductName, Price, DateOfPurchase, AvailabilityStatus, CategoryID, BrandID, Active, Photo")] Product product)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    var imgBytes = new Byte[file.ContentLength];
                    file.InputStream.Read(imgBytes, 0, file.ContentLength);
                    var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                    product.Photo = base64String;
                }
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = db.Categories.ToList();
                ViewBag.Brands = db.Brands.ToList();
                return View();
            }


        }

        public ActionResult Edit(long id)
        {

            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();

            Product ProductToEdit = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            return View(ProductToEdit);
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                Product editedProduct = db.Products.Where(temp => temp.ProductID == p.ProductID).FirstOrDefault();
                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    var imgBytes = new Byte[file.ContentLength];
                    file.InputStream.Read(imgBytes, 0, file.ContentLength);
                    var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                    editedProduct.Photo = base64String;
                }
                editedProduct.ProductName = p.ProductName;
                editedProduct.Price = p.Price;
                editedProduct.DateOfPurchase = p.DateOfPurchase;
                editedProduct.CategoryID = p.CategoryID;
                editedProduct.BrandID = p.BrandID;
                editedProduct.AvailabilityStatus = p.AvailabilityStatus;
                editedProduct.Active = p.Active;

                db.SaveChanges();
            }

            return RedirectToAction("Index", "Products");
        }


        public ActionResult Delete(long id)
        {

            Product ProductToDelete = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();

            return View(ProductToDelete);
        }

        [HttpPost]
        public ActionResult Delete(Product p)
        {

            Product ProductToDelete = db.Products.Where(temp => temp.ProductID == p.ProductID).FirstOrDefault();
            db.Products.Remove(ProductToDelete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
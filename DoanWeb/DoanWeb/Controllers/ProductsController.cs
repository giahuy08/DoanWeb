using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoanWeb.Models;

namespace DoanWeb.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        DoanWebEntities db = new DoanWebEntities();
        public ActionResult ListProducts()
        {
            var products = db.Products.Include(p => p.Category);
            ViewBag.Products = products;
            return View(products.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
    }
}
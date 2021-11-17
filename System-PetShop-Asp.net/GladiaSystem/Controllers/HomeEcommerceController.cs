using GladiaSystem.Database;
using GladiaSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GladiaSystem.Controllers
{
    public class HomeEcommerceController : Controller
    {
        Queries queries = new Queries();

        // GET: HomeEcommerce
        public ActionResult Home()
        {
            return View();
        }   
        public ActionResult ProductSelected(int productID)
        {
            Product product = new Product();
            product = queries.GetProductByID(productID);
            return View(product);
        }

        public ActionResult Search()
        {
            var ShowProducts = new Queries();
            ViewBag.AllProduct = ShowProducts.ListProduct();
            return View();
        }

        public ActionResult AddCart(int productID, int productQuant)
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("access");
            Session.Abandon();
            return RedirectToAction("Home", "HomeEcommerce");
        }
    }
}
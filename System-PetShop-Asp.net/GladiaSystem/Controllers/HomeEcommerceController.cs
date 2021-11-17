using GladiaSystem.Database;
using GladiaSystem.Models;
using Hanssens.Net;
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

        [HttpPost]
        public ActionResult AddCart(Product product)
        {
            var config = new LocalStorageConfiguration(){};
            var storage = new LocalStorage(config);

            int quantInput = product.Quant;

            product = queries.GetProductByID(product.ID);

            product.Quant = quantInput;

            storage.Store("DT"+product.ID, product);
            storage.Persist();

            return RedirectToAction("Cart", "PaymentEcommerce");
        }

        public ActionResult Logout()
        {
            Session.Remove("access");
            Session.Abandon();
            return RedirectToAction("Home", "HomeEcommerce");
        }

        public ActionResult EmptyCart()
        {
            return View();
        }
    }
}
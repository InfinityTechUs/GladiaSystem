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
            var ShowProducts = new Queries();
            ViewBag.AllProduct = ShowProducts.ListProduct();
            return View();
        }   
        public ActionResult ProductSelected(int productID)
        {
            Product product = new Product();
            product = queries.GetProductByID(productID);
            return View(product);
        }

        public ActionResult Search(string categoryFilter)
        {
            var ShowProducts = new Queries();

            if(categoryFilter == "SearchPriceOne")
            {
                ViewBag.AllProduct = queries.ListProductByPrice(5,20);
            }
            else if(categoryFilter == "SearchPriceTwo")
            {
                ViewBag.AllProduct = queries.ListProductByPrice(20, 40);

            }
            else if(categoryFilter == "SearchPriceThree")
            {
                ViewBag.AllProduct = queries.ListProductByPrice(40, 80);
            }
            else if (categoryFilter == null)
            {
                ViewBag.AllProduct = ShowProducts.ListProduct();
            }
            else
            {
                ViewBag.AllProduct = ShowProducts.ListProductByCategory(categoryFilter);
            }

            return View();
        }

        [HttpPost]
        public ActionResult AddCart(Product product)
        {
            var config = new LocalStorageConfiguration(){};
            var storage = new LocalStorage(config);

            int quantInput = product.Quant;

            product = queries.GetProductByID(product.ID);

            if (quantInput > product.Quant)
            {
                return RedirectToAction("Search", "HomeEcommerce");
            }

            product.Quant = quantInput;

            string userinfo = (string)Session["userID"];
            storage.Store("DT" + userinfo + product.ID, product);
            storage.Persist();

            return RedirectToAction("Cart", "PaymentEcommerce");
        }

        [HttpPost]
        public ActionResult SearchProduct(Product product)
        {
            product = queries.GetProduct(product.Name);

            List<int> IDs = new List<int>();
            List<string> Names = new List<string>();
            List<string> Descs = new List<string>();
            List<string> Brands = new List<string>();
            List<int> Prices = new List<int>();
            List<int> Quants = new List<int>();
            List<int> QuantMin = new List<int>();
            List<string> CategoryName = new List<string>();
            List<string> Images = new List<string>();

            IDs.Add(product.ID);
            Names.Add(product.Name);
            Descs.Add(product.Desc);
            Brands.Add(product.Brand);
            Prices.Add(product.Price);
            Quants.Add(product.Quant);
            QuantMin.Add(product.QuantMin);
            CategoryName.Add(product.Category.name);
            Images.Add(product.img);


            ViewBag.IDs = IDs;
            ViewBag.Name = Names;
            ViewBag.Brand = Brands;
            ViewBag.Desc = Descs;
            ViewBag.Price = Prices;
            ViewBag.Quant = Quants;
            ViewBag.QuantMin = QuantMin;
            ViewBag.CategoryName = CategoryName;
            ViewBag.Images = Images;

            return View("Search");
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
using GladiaSystem.Database;
using GladiaSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GladiaSystem.Controllers
{
    public class AccountEcommerceController : Controller
    {
        public ActionResult MyAccount()
        {
            return View();
        }
        
        Queries queries = new Queries();

        public ActionResult TrackOrder()
        {
            string userIDString = Convert.ToString(Session["userID"]);
            ViewBag.AllOrders = queries.ListOrder(userIDString);
            return View();
        }

        public ActionResult TrackOrderDetail(int orderID)
        {
            Order order = new Order();
            order = queries.GetOrderByID(orderID);
            return View();
        }

        public ActionResult ProductEdit(int productID)
        {
            Product product = new Product();
            product = queries.GetProductByID(productID);
            return View(product);
        }
    }
}
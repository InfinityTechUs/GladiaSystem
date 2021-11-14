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
            User user = new User();
            string userinfo = (string)Session["userID"];
            user = queries.GetUser(userinfo);
            return View(user);
        }

        Queries queries = new Queries();

        public ActionResult ChangeName()
        {
            string session = (string)Session["userID"];
            User changeName = new User();
            return View(changeName);
        }

        [HttpPost]
        public ActionResult ChangeNam(User changeName)
        {
            string session = (string)Session["userID"];
            queries.ChangeName(changeName.name, session);
            return RedirectToAction("Login", "LoginEcommerce");
        }

        public ActionResult ChangePassword()
        {
            string session = (string)Session["userID"];
            ViewBag.Img = queries.GetUserImages(session);
            User changePassword = new User();
            return View(changePassword);
        }

        [HttpPost]
        public ActionResult ChangePass(User changePassword)
        {
            if (changePassword.password == changePassword.confPassword)
            {
                string session = (string)Session["userID"];
                queries.ChangePass(changePassword.password, session);
            }
            return RedirectToAction("MyAccount", "AccountEcommerce");
        }

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
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
    public class LoginEcommerceController : Controller
    {
        Queries queries = new Queries();
        private string userID;

        // GET: LoginEcommerce
        public ActionResult Login()
        {
            var user = new User();
            return View(user);
        }


        public ActionResult RegisterAddress()
        {
            User user = new User();
            return View(user);

         
        }

        [HttpPost]
        public ActionResult LoginUser(User user)
        {
            string acessLevel = queries.Login(user);
            Session["name"] = queries.GetUserName(user);
            Session["email"] = queries.GetUserEmail(user);
            Session["userID"] = queries.GetUserID(user);

            if (acessLevel == "0")
            {
                Session["access"] = "0";
                return RedirectToAction("Home", "HomeEcommerce");
            }
            else if (acessLevel == "1")
            {
                Session["access"] = "1";
                return RedirectToAction("Home", "HomeEcommerce");
            }
            else
            {
                return Redirect("Login");
            }
        }
         public ActionResult Register()
        {
            User user = new User();
            return View(user);
        }

        [HttpPost]
        public ActionResult RegisterUserEcommerce(User user)
        {
            queries.RegisterUserEcommerce(user);
            Session["normalUserID"] = queries.GetUserID(user);
            return RedirectToAction("Register");
        }

        [HttpPost]
        public ActionResult RegisterNewAddress(User user)
        {
            userID = (string)(Session["normalUserID"]);
            int userIDInt = Convert.ToInt32(userID);
            queries.RegisterNewAddress(user, userIDInt);
            return RedirectToAction("Login");
        }
    }
}
using GladiaSystem.Database;
using GladiaSystem.Models;
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

        public ActionResult Login()
        {
            var user = new User();
            return View(user);
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult RegisterAddress()
        {
            return View();
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
                return RedirectToAction("Home", "Home");
            }
            else
            {
                return Redirect("Login");
            }
        }
    }
}
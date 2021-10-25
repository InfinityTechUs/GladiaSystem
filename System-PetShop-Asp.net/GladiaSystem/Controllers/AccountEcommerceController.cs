using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GladiaSystem.Controllers
{
    public class AccountEcommerceController : Controller
    {
        // GET: AccountEcommerce
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MyAccount()
        {
            return View();
        }
    }
}
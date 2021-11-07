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

        public ActionResult TrackOrder()
        {
            return View();
        }
    }
}
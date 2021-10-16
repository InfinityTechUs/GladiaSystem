using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GladiaSystem.Controllers
{
    public class HomeEcommerceController : Controller
    {
        // GET: HomeEcommerce
        public ActionResult Home()
        {
            return View();
        }   
        public ActionResult ProductSelected()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }
    }
}
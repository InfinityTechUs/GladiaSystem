using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GladiaSystem.Controllers
{
    public class PaymentEcommerceController : Controller
    {
        // GET: PaymentEcommerce
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EmptyCart()
        {
            return View();
        }
        public ActionResult Cart()
        {
            return View();
        }

        public ActionResult Payment()
        {
            return View();
        }
    }
}
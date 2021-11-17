using GladiaSystem.Models;
using Hanssens.Net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GladiaSystem.Controllers
{
    public class PaymentEcommerceController : Controller
    { 
        public ActionResult EmptyCart()
        {
            return View();
        }

        public ActionResult Cart()
        {
            var config = new LocalStorageConfiguration()
            {
            };

            var storage = new LocalStorage(config);

            var produto = new Product();

            produto.Name = "Ração11";
            produto.Desc = "Ração11";
            produto.Brand = "Golden";

            storage.Store("DT"+produto.ID, produto);

            storage.Persist();

            //ViewBag.Teste = storage.Get("Produtos");

            //var teste2 = storage.Keys();
            //List<String> a = new List<string>();
            //foreach (string value in teste2)
            //{
            //    a.Add(value);
            //}

            //List<string> dts = (from name in a where name.StartsWith("DT") select name).ToList();
            //List<Product> productList = new List<Product>();


            //for(int j = 0; j < dts.Count; j++)
            //{

            //    var aghj = storage.Get<Product>(dts[j]);
            //    productList.Add(aghj);
            //    Console.WriteLine("as");
            //}
            

            return View();
        }

        public ActionResult Payment()
        {
            var config = new LocalStorageConfiguration()
            {
            };

            var storage = new LocalStorage(config);

            storage.Remove("Produtos");
            storage.Persist();

            return View();
        }

        public ActionResult Receipt()
        {
            return View();
        }
    }
}
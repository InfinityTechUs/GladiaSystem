using GladiaSystem.Database;
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
        public ActionResult Cart()
        {
            var config = new LocalStorageConfiguration() { };
            var storage = new LocalStorage(config);

            var keys = storage.Keys();

            if (keys.Count == 0)
            {
                return RedirectToAction("EmptyCart","HomeEcommerce");
            }

            List<String> keysStringList = new List<string>();

            foreach (string value in keys)
            {
                keysStringList.Add(value);
            }

            List<string> keyStringListFiltered = (from name in keysStringList where name.StartsWith("DT") select name).ToList();
            List<Product> productList = new List<Product>();

            for (int j = 0; j < keyStringListFiltered.Count; j++)
            {
                var product = storage.Get<Product>(keyStringListFiltered[j]);
                productList.Add(product);
            }

            ViewBag.AllProducts = productList;
            return View();
        }



        public ActionResult DeleteItemCart(int productID)
        {
            var config = new LocalStorageConfiguration() { };
            var storage = new LocalStorage(config);
            string keyToRemove = "DT" + productID;
            storage.Remove(keyToRemove);
            storage.Persist();

            return RedirectToAction("Cart");
        }

        public ActionResult Payment()
        {
            var config = new LocalStorageConfiguration() { };
            var storage = new LocalStorage(config);

            var keys = storage.Keys();
            List<String> keysStringList = new List<string>();

            foreach (string value in keys)
            {
                keysStringList.Add(value);
            }

            List<string> keyStringListFiltered = (from name in keysStringList where name.StartsWith("DT") select name).ToList();
            List<Product> productList = new List<Product>();

            for (int j = 0; j < keyStringListFiltered.Count; j++)
            {
                var product = storage.Get<Product>(keyStringListFiltered[j]);
                productList.Add(product);
            }

            ViewBag.AllProducts = productList;

            return View();
        }

        public ActionResult FinishOrder(int totalValue)
        {
            Queries queries = new Queries();
            string userOwner = (string)Session["userID"];

            queries.OpenOrder(userOwner, totalValue);
            int orderOpenID = queries.GetOrderOpen(userOwner);

            var config = new LocalStorageConfiguration() { };
            var storage = new LocalStorage(config);

            var keys = storage.Keys();
            List<String> keysStringList = new List<string>();

            foreach (string value in keys)
            {
                keysStringList.Add(value);
            }

            List<string> keyStringListFiltered = (from name in keysStringList where name.StartsWith("DT") select name).ToList();
            List<Product> productList = new List<Product>();

            for (int j = 0; j < keyStringListFiltered.Count; j++)
            {
                var product = storage.Get<Product>(keyStringListFiltered[j]);
                productList.Add(product);
            }

            ViewBag.AllProducts = productList;

            queries.InserItemsOrder(orderOpenID, productList);
            queries.CloseOrder(orderOpenID);

            return RedirectToAction("Receipt");
        }

        public ActionResult Receipt()
        {
            var config = new LocalStorageConfiguration() { };
            var storage = new LocalStorage(config);

            var keys = storage.Keys();
            List<String> keysStringList = new List<string>();

            foreach (string value in keys)
            {
                keysStringList.Add(value);
            }

            List<string> keyStringListFiltered = (from name in keysStringList where name.StartsWith("DT") select name).ToList();
            List<Product> productList = new List<Product>();

            for (int j = 0; j < keyStringListFiltered.Count; j++)
            {
                var product = storage.Get<Product>(keyStringListFiltered[j]);
                productList.Add(product);
            }
            ViewBag.AllProducts = productList;

            foreach (var item in productList)
            {
                string keyToRemove = "DT" + item.ID;
                storage.Remove(keyToRemove);
                storage.Persist();
            }

            return View();
        }
    }
}
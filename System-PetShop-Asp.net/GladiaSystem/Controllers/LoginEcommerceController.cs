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
            List<BrUf> ufs = new List<BrUf>();
            BrUf uf = new BrUf();
            BrUf uf2 = new BrUf();
            BrUf uf3 = new BrUf();
            BrUf uf4 = new BrUf();
            BrUf uf5 = new BrUf();
            BrUf uf6 = new BrUf();
            BrUf uf7 = new BrUf();
            BrUf uf8 = new BrUf();
            BrUf uf9 = new BrUf();
            BrUf uf10 = new BrUf();
            BrUf uf11 = new BrUf();
            BrUf uf12 = new BrUf();
            BrUf uf13 = new BrUf();
            BrUf uf14 = new BrUf();
            BrUf uf15 = new BrUf();
            BrUf uf16 = new BrUf();
            BrUf uf17 = new BrUf();
            BrUf uf18 = new BrUf();
            BrUf uf19 = new BrUf();
            BrUf uf20 = new BrUf();
            BrUf uf21 = new BrUf();
            BrUf uf22 = new BrUf();
            BrUf uf23 = new BrUf();
            BrUf uf24 = new BrUf();
            BrUf uf25 = new BrUf();
            BrUf uf26 = new BrUf();
            BrUf uf27 = new BrUf();
            uf.Name = "RO";
            uf2.Name = "AC";
            uf3.Name = "AM";
            uf4.Name = "RR";
            uf5.Name = "PA";
            uf6.Name = "AP";
            uf7.Name = "TO";
            uf8.Name = "MA";
            uf9.Name = "PI";
            uf10.Name = "CE";
            uf11.Name = "RN";
            uf12.Name = "PB";
            uf13.Name = "PE";
            uf14.Name = "AL";
            uf15.Name = "SE";
            uf16.Name = "BA";
            uf17.Name = "MG";
            uf18.Name = "ES";
            uf19.Name = "RJ";
            uf20.Name = "SP";
            uf21.Name = "PR";
            uf22.Name = "SC";
            uf23.Name = "RS";
            uf24.Name = "MS";
            uf25.Name = "MT";
            uf26.Name = "GO";
            uf27.Name = "DF";
            uf.ID = 1;
            uf2.ID = 2;
            uf3.ID = 3;
            uf4.ID = 4;
            uf5.ID = 5;
            uf6.ID = 6;
            uf7.ID = 7;
            uf8.ID = 8;
            uf9.ID = 9;
            uf10.ID = 10;
            uf11.ID = 11;
            uf12.ID = 12;
            uf13.ID = 13;
            uf14.ID = 14;
            uf15.ID = 15;
            uf16.ID = 16;
            uf17.ID = 17;
            uf18.ID = 18;
            uf19.ID = 19;
            uf20.ID = 20;
            uf21.ID = 21;
            uf22.ID = 22;
            uf23.ID = 23;
            uf24.ID = 24;
            uf25.ID = 25;
            uf26.ID = 26;
            uf27.ID = 27;
            ufs.Add(uf);
            ufs.Add(uf2);
            ufs.Add(uf3);
            ufs.Add(uf4);
            ufs.Add(uf5);
            ufs.Add(uf6);
            ufs.Add(uf7);
            ufs.Add(uf8);
            ufs.Add(uf9);
            ufs.Add(uf10);
            ufs.Add(uf11);
            ufs.Add(uf12);
            ufs.Add(uf13);
            ufs.Add(uf14);
            ufs.Add(uf15);
            ufs.Add(uf16);
            ufs.Add(uf17);
            ufs.Add(uf18);
            ufs.Add(uf19);
            ufs.Add(uf20);
            ufs.Add(uf21);
            ufs.Add(uf22);
            ufs.Add(uf23);
            ufs.Add(uf24);
            ufs.Add(uf25);
            ufs.Add(uf26);
            ufs.Add(uf27);

            ViewBag.ListUfs = ufs;
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
            return RedirectToAction("RegisterAddress");
        }

        [HttpPost]
        public ActionResult RegisterNewAddress(User user)
        {
            userID = (string)(Session["normalUserID"]);
            int userIDInt = Convert.ToInt32(userID);

            switch (user.BrUf.ID)
            {
                case 1:
                    user.UF = "RO";
                    break;
                case 2:
                    user.UF = "AC";
                    break;
                case 3:
                    user.UF = "RR";
                    break;
                case 4:
                    user.UF = "PA";
                    break;
                case 5:
                    user.UF = "AC";
                    break;
                case 6:
                    user.UF = "AP";
                    break;
                case 7:
                    user.UF = "TO";
                    break;
                case 8:
                    user.UF = "MA";
                    break;
                case 9:
                    user.UF = "PI";
                    break;
                case 10:
                    user.UF = "CE";
                    break;
                case 11:
                    user.UF = "RN";
                    break;
                case 12:
                    user.UF = "PB";
                    break;
                case 13:
                    user.UF = "PE";
                    break;
                case 14:
                    user.UF = "AL";
                    break;
                case 15:
                    user.UF = "SE";
                    break;
                case 16:
                    user.UF = "BA";
                    break;
                case 17:
                    user.UF = "MG";
                    break;
                case 18:
                    user.UF = "ES";
                    break;
                case 19:
                    user.UF = "RJ";
                    break;
                case 20:
                    user.UF = "SP";
                    break;
                case 21:
                    user.UF = "PR";
                    break;
                case 22:
                    user.UF = "SC";
                    break;
                case 23:
                    user.UF = "RS";
                    break;
                case 24:
                    user.UF = "MS";
                    break;
                case 25:
                    user.UF = "MT";
                    break;
                case 26:
                    user.UF = "GO";
                    break;
                case 27:
                    user.UF = "DF";
                    break;
            }

            queries.RegisterNewAddress(user, userIDInt);
            return RedirectToAction("Login");

        }
    }
}
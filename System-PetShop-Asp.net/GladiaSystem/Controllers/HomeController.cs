using GladiaSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using GladiaSystem.Database;
using System.Collections.ObjectModel;
using System.Web.UI.WebControls;
using System.Web.Helpers;
using System.IO;

namespace GladiaSystem.Controllers
{
    public class HomeController : Controller
    {
        [HandleError]
        // GET: Home
        public ActionResult Home()
        {
            ViewBag.OrderedNumber = queries.OrderedNumber();
            ViewBag.AdministratorNumber = queries.AdministratorNumber();
            ViewBag.ClientNumber = queries.ClientNumber();
            ViewBag.ProductNumber = queries.ProductNumber();

            return View();
        }

        Queries queries = new Queries();

        public ActionResult Adm()
        {
            User adm = new User();
            return View(adm);
        }

        [HttpPost]
        public ActionResult CadAdm(User adm)
        {
            WebImage photo = null;
            var newFileName = "";
            var imagePath = "";

            photo = WebImage.GetImageFromRequest();
            if (photo != null)
            {
                newFileName = Guid.NewGuid().ToString() + "_" +
                Path.GetFileName(photo.FileName);
                imagePath = @"/" + newFileName;

                photo.Save(@"~/Images" + imagePath);
                imagePath = photo.FileName;
            }

            queries.RegisterAdm(adm, imagePath);
            TempData["Success"] = "Feito! 😄";
            return RedirectToAction("Adm");
        }

        public ActionResult ProdDelete(int ProductID)
        {
            queries.DeleteItemProduct(ProductID);
            return RedirectToAction("ProductList");
        }

        [HttpPost]
        public ActionResult ProductGet(Pos pos)
        {
            ViewBag.QuantOrder = pos.QuantOrder;

            queries.AddProduct(pos);

            string session = (string)Session["userID"];
            ViewBag.Img = queries.GetUserImages(session);

            return RedirectToAction("POS");
        }

        public ActionResult Logout()
        {
            Session.Remove("access");
            Session.Abandon();
            return RedirectToAction("Home", "HomeEcommerce");
        }
        
        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            queries.UpdateProduct(product);
            return View("Home");
        }

        public ActionResult ProductEdit(int productID)
        {
            Product product = new Product();
            product = queries.GetProductByID(productID);
            return View(product);
        }
       
        public ActionResult Category()
        {
            Category category = new Category();
            return View(category);
        }

        [HttpPost]
        public ActionResult RegisterCategory(Category category)
        {
            Queries queries = new Queries();
            if (ModelState.IsValid && !queries.CategoryExists(category))
            {
                queries.RegisterCategory(category);
                TempData["Success"] = "Feito! 😄";
            }
            else
            {
                ViewData["Error"] = "Opss, algo deu errado 😢.";
            }
            return RedirectToAction("Category");
        }

        public ActionResult Product()
        {
            Product product = new Product();

            ViewBag.ListCategory = queries.ListCategory();
            return View(product);
        }

        [HttpPost]
        public ActionResult RegisterProd(Product product)
        {
            WebImage photo = null;
            var newFileName = "";
            var imagePath = "";

            photo = WebImage.GetImageFromRequest();
            if (photo != null)
            {
                newFileName = Guid.NewGuid().ToString() + "_" +
                Path.GetFileName(photo.FileName);
                imagePath = @"/" + newFileName;

                photo.Save(@"~/Images" + imagePath);
                imagePath = photo.FileName;
            }

            queries.RegisterProd(product, imagePath);
            TempData["Success"] = "Feito! 😄";
            ViewBag.ListCategory = queries.ListCategory();
            return RedirectToAction("Product");


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
            if(changePassword.password == changePassword.confPassword)
            {
                string session = (string)Session["userID"];
                queries.ChangePass(changePassword.password, session);
            }
            return RedirectToAction("ChangePassword", "Home");
        }

        public ActionResult ChangeName()
        {
            string session = (string)Session["userID"];
            ViewBag.Img = queries.GetUserImages(session);
            User changeName = new User();
            return View(changeName);
        }

        [HttpPost]
        public ActionResult ChangeNam(User changeName)
        {
            if (changeName.name == changeName.confName )
            {
                string session = (string)Session["userID"];
                queries.ChangeName(changeName.name, session);
            }
            return RedirectToAction("Login", "LoginEcommerce");
        }

        [HttpPost]
        public ActionResult ChangePhoto(User user)
        {
            WebImage photo = null;
            var newFileName = "";
            var imagePath = "";
            string sessionID = (string)Session["userID"];

            photo = WebImage.GetImageFromRequest();
            if (photo != null)
            {
                newFileName = Guid.NewGuid().ToString() + "_" +
                Path.GetFileName(photo.FileName);
                imagePath = @"/" + newFileName;

                photo.Save(@"~/Images" + imagePath);
                imagePath = photo.FileName;
            }

            queries.ChangePhoto(imagePath,sessionID);
            TempData["Success"] = "Feito! 😄";
            return RedirectToAction("DeleteAccount");
        }

        [HttpPost]
        public ActionResult ChangePhotoName(User user)
        {
            WebImage photo = null;
            var newFileName = "";
            var imagePath = "";
            string sessionID = (string)Session["userID"];

            photo = WebImage.GetImageFromRequest();
            if (photo != null)
            {
                newFileName = Guid.NewGuid().ToString() + "_" +
                Path.GetFileName(photo.FileName);
                imagePath = @"/" + newFileName;

                photo.Save(@"~/Images" + imagePath);
                imagePath = photo.FileName;
            }

            queries.ChangePhoto(imagePath, sessionID);
            TempData["Success"] = "Feito! 😄";
            return RedirectToAction("ChangeName");
        }

        [HttpPost]
        public ActionResult ChangePhotoPassword(User user)
        {
            WebImage photo = null;
            var newFileName = "";
            var imagePath = "";
            string sessionID = (string)Session["userID"];

            photo = WebImage.GetImageFromRequest();
            if (photo != null)
            {
                newFileName = Guid.NewGuid().ToString() + "_" +
                Path.GetFileName(photo.FileName);
                imagePath = @"/" + newFileName;

                photo.Save(@"~/Images" + imagePath);
                imagePath = photo.FileName;
            }

            queries.ChangePhoto(imagePath, sessionID);
            TempData["Success"] = "Feito! 😄";
            return RedirectToAction("ChangePassword");
        }

        [HttpPost]
        public ActionResult ChangePhotoDelete(User user)
        {
            WebImage photo = null;
            var newFileName = "";
            var imagePath = "";
            string sessionID = (string)Session["userID"];

            photo = WebImage.GetImageFromRequest();
            if (photo != null)
            {
                newFileName = Guid.NewGuid().ToString() + "_" +
                Path.GetFileName(photo.FileName);
                imagePath = @"/" + newFileName;

                photo.Save(@"~/Images" + imagePath);
                imagePath = photo.FileName;
            }

            queries.ChangePhoto(imagePath, sessionID);
            TempData["Success"] = "Feito! 😄";
            return RedirectToAction("DeleteAccount");
        }

        public ActionResult DeleteAccount()
        {
            string session = (string)Session["userID"];
            ViewBag.Img = queries.GetUserImages(session);
            return View();
        }

        public ActionResult Delete()
        {
            string deleteID = (string)Session["userID"];
            queries.DeleteAccount(deleteID);
            return RedirectToAction("Login" , "Login");
        }

        public ActionResult ProductList()
        {
            var ShowProducts = new Queries();
            ViewBag.AllProduct = ShowProducts.ListProduct();
            return View("ProductList");
        }

        [HttpPost]
        public ActionResult SearchProduct(Product product)
        {
            product = queries.GetProduct(product.Name);

            List<int> IDs = new List<int>();
            List<string> Names = new List<string>();
            List<string> Descs = new List<string>();
            List<string> Brands = new List<string>();
            List<double> Prices = new List<double>();
            List<double> Quants = new List<double>();
            List<int> QuantMin = new List<int>();
            List<string> CategoryName = new List<string>();
            List<string> Images = new List<string>();

            IDs.Add(product.ID);
            Names.Add(product.Name);
            Descs.Add(product.Desc);
            Brands.Add(product.Brand);
            Prices.Add(product.Price);
            Quants.Add(product.Quant);
            QuantMin.Add(product.QuantMin);
            CategoryName.Add(product.Category.name);
            Images.Add(product.img);


            ViewBag.IDs = IDs;
            ViewBag.Name = Names;
            ViewBag.Brand = Brands;
            ViewBag.Desc = Descs;
            ViewBag.Price = Prices;
            ViewBag.Quant = Quants;
            ViewBag.QuantMin = QuantMin;
            ViewBag.CategoryName = CategoryName;
            ViewBag.Images = Images;

            return View("ProductList");
        }
    }
}
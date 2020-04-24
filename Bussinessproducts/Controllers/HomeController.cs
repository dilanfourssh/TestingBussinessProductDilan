using Bussinessproducts.DataAccessLayer;
using Bussinessproducts.ExtraClass;
using Bussinessproducts.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bussinessproducts.Controllers
{
    public class HomeController : Controller
    {
        private BussinessProductContext db = new BussinessProductContext(); // create object database (Using Data Access Layer) Add mssql server name conection string of web.config file
        public ActionResult Index()
        {
            var a = db.admins.ToList();  // if migrate project create a database
            return View();
        }

        public ActionResult Product(string category)
        {

            ViewBag.product = db.products.Where(d => d.productCategory == category).ToList(); // select Product List
            int countingposition = db.products.Where(d => d.productCategory == category).Count(); // Get Count select product
            ViewBag.positions = (countingposition / 3) + 1;// becouse one row assign to 3 product from wiew, seperate row by row using view logic
            ViewBag.countingposition = countingposition; // All product count           

            return View();
        }
        [HttpPost]
        public ActionResult Product(int id, string sellprice, string title)
        {
            if(Session["name"] != null) { 
                int userid = Convert.ToInt32(Session["id"]);//session assign to int value
                Purchase perchases = Singleton.GetInstancePurchese(userid,Convert.ToDouble( sellprice), id);//call object assign method
                Singleton.PurcheseSave(perchases);//db save purchases
                return RedirectToAction("Thankyou", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Home"); //if user session is null redirect login page
            }
            
        }
        public ActionResult Thankyou()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin) //submit call method login
        {
            string pwd = SHA.GenerateSHA256String(admin.email + admin.password);// concat password and convert to sha256
            var adminpossible = db.admins.Where(d => d.email == admin.email && d.password == pwd).FirstOrDefault();//serch database continue administrator 
            if (adminpossible != null)
            {
                Session["name"] = adminpossible.name;
                Session["id"] = adminpossible.id;
                Session["type"] = adminpossible.type;

                return RedirectToAction("Administor", "Home");
            }
            return View();
        }
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Register(Admin adminvlaue) // submit method register page
        {
            if (adminvlaue != null)
            {
                if (adminvlaue.password == adminvlaue.confirmPassword)
                {
                    string pwd = SHA.GenerateSHA256String(adminvlaue.email + adminvlaue.password);// concat password and convert to sha256
                    adminvlaue.password = pwd;
                    adminvlaue.confirmPassword = pwd;
                    adminvlaue.registerDate = DateTime.Now;
                    Singleton.AdminSave(adminvlaue);
                }

            }
            return View();
        }
        public ActionResult Administor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Administor(string title, double productPrice, string productCategory, string description, int descountPresentage, HttpPostedFileBase image)
        {
            string sessiontype = Session["type"].ToString();// convert to string session type
            if (Session["name"] != null && sessiontype == "admin")
            {
                {
                    int adminid = Convert.ToInt32(Session["id"]);// convert integer
                    string path = Server.MapPath("~/Image/Product/");
                    if (!Directory.Exists(path))// create uploading image derectory
                    {
                        Directory.CreateDirectory(path);
                    }
                    int count = db.products.Count();
                    string imaagename = Session["name"].ToString() + count + ".jpg";//upload image name change 
                    image.SaveAs(path + System.IO.Path.GetFileName(imaagename));
                    DateTime projectdatetime = DateTime.Now;
                    Product product = Singleton.GetInstanceProduct(title, imaagename, productPrice, productCategory, description, projectdatetime, adminid, descountPresentage);
                    Singleton.ProductSave(product);
                }

            }
            return View();

        }
        public ActionResult SignOut()
        {
            Session["name"] = null;
            Session["id"] = null;
            Session["type"] = null;

            return RedirectToAction("Index", "Home");
        }
    }
}
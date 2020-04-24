using Bussinessproducts.DataAccessLayer;
using Bussinessproducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bussinessproducts.ExtraClass
{
    public class Singleton
    { 
        private static Admin _admin;
        private static Product _product;
        private static Purchase _purchase;
        // This is the static method that controls the access to the singleton

        public static Admin GetInstanceAdmin()// Get instance object admin
        {
            if (_admin == null)
            {
                _admin = new Admin();
                
            }
            return _admin;
        }
        public static Purchase GetInstancePurchese(int userid,double sellPrice,int productid ){// Get instance object admin
      
            if (_purchase == null)
            {
                _purchase = new Purchase();
                _purchase.userId =userid;
                _purchase.sellPrice = sellPrice;
                _purchase.productId = productid;

            }
            return _purchase;
        }
        public static Product GetInstanceProduct(string title,string image,double productprice,string productcategory,string description,DateTime currenttime,int adminid,int descountpresentage)// Get instance object Product
        {
            if (_admin == null)
            {
                _product = new Product();
                _product.title = title;
                _product.image = image;
                _product.productPrice = productprice;
                _product.productCategory = productcategory;
                _product.description = description;
                _product.CurrentDateTime = currenttime;
                _product.adminId = adminid;
                _product.descountPresentage = descountpresentage;
                
            }
            return _product;
        }

        
        public static void AdminSave(Admin admin) //admin object save database
        {
            using (BussinessProductContext db =new BussinessProductContext())// database object using DataAccessLayer , we define using becouse still runing project change database value show
            {
                db.admins.Add(admin);
                db.SaveChanges();
            }
            
        }
        public static void ProductSave(Product product) //product object save database
        {
            using (BussinessProductContext db = new BussinessProductContext())// database object using DataAccessLayer , we define using becouse still runing project change database value show
            {
                db.products.Add(product);
                db.SaveChanges();
            }

        }
        public static void PurcheseSave(Purchase purchase) //product object save database
        {
            using (BussinessProductContext db = new BussinessProductContext())// database object using DataAccessLayer , we define using becouse still runing project change database value show
            {
                db.purchases.Add(purchase);
                db.SaveChanges();
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bussinessproducts.Models
{
    public class Product
    {
        public int id{ get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public double productPrice { get; set; }
        public string productCategory { get; set; }
        public string description { get; set; }
        public DateTime CurrentDateTime { get; set; }
        public int adminId { get; set; }
        public int descountPresentage { get; set; }
    }
}
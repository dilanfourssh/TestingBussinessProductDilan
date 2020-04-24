using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bussinessproducts.Models
{
    public class Purchase
    {
        public int id { get; set; }
        public int userId { get; set; }
        public double sellPrice { get; set; }
        public int productId { get; set; }
    }
}
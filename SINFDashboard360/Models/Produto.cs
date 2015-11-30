using Interop.StdBE800;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SINFDashboard360.Models
{
    public class Produto
    {
        public string product_id;
        public string description;
        public double price;
        public string category_id;
        public double stock;
        public double stockMin;
        public double stockMax;
        public string marca;
        //public List<Produto> components = new List<Produto>();
    }
}
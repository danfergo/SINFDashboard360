using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SINFDashboard360.Models
{
    public class User
    {
        public String nome { get; set; }

        public int idade { get; set; }
        public int id { get; set; }
        public int department_id { get; set; }
        public bool is_admin { get; set; }

    }
}
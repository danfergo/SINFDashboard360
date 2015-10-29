using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SINFDashboard360.Models
{
    public class Error: Exception
    {
        public string error = "";

        public Error(string e)
        {
            this.error = e;
        }

    }
}
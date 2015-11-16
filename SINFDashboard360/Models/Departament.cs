using Interop.StdBE800;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SINFDashboard360.Models
{
    public class Departament
    {
        public string department_id;
        public string description;
        public List<Funcionario> employees = new List<Funcionario>();
    }
}
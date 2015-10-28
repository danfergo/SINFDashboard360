using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SINFDashboard360.Controllers
{
    public class DepartmentsController : ApiController
    {
        // GET api/department
        public IEnumerable<Object> Get()
        {
            return Models.Departamento.getListaDepartamentos();
        }
    }
}

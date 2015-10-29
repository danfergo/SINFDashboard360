using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SINFDashboard360.Controllers
{
    public class InvoicesController : ApiController
    {
        // GET api/invoices
        public IEnumerable<Lib_Primavera.Model.Factura> Get()
        {
            return Lib_Primavera.PriIntegration.ListaFacturas();
        }

        /*
        // GET api/invoices/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/invoices
        public void Post([FromBody]string value)
        {
        }

        // PUT api/invoices/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/invoices/5
        public void Delete(int id)
        {
        }
        */
    }
}

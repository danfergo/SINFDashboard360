using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SINFDashboard360.Lib_Primavera.Model;
using Interop.StdBE800;
using SINFDashboard360.Lib_Primavera;


namespace SINFDashboard360.Controllers
{
    public class ClientsController : ApiController
    {

        // GET: /Clientes/

        public IEnumerable<Models.Client> Get()
        {
            return Pri_Bridge.Clients.ListaClientes();
        }

        [HttpGet]
        // GET api/cliente/5    
        public Models.Client Get(string id)
        {
            System.Diagnostics.Debug.WriteLine(id);
            Models.Client cliente = Pri_Bridge.Clients.GetCliente(id);
            if (cliente == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));

            }
            else
            {
                return cliente;
            }
        }


        [HttpGet]
        public IEnumerable<Lib_Primavera.Model.Factura> GetClientInvoices(string id)
        {

            return Pri_Bridge.Clients.getClientInvoices(id);
        }
       
    }
}

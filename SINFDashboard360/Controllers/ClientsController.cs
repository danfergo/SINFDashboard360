using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SINFDashboard360.Lib_Primavera.Model;


namespace SINFDashboard360.Controllers
{
    public class ClientsController : ApiController
    {

        // GET: /Clientes/

        public IEnumerable<Lib_Primavera.Model.Cliente> Get()
        {
            return Lib_Primavera.PriIntegration.ListaClientes();
        }


        // GET api/cliente/5    
        public Lib_Primavera.Model.Cliente Get(string id)
        {
            System.Diagnostics.Debug.WriteLine(id);
            Lib_Primavera.Model.Cliente cliente = Lib_Primavera.PriIntegration.GetCliente(id);
            if (cliente == null)
            {
                throw new HttpResponseException(
                        Request.CreateResponse(HttpStatusCode.NotFound));

            }
            else
            {
                return cliente;
            }
        }

        [HttpGet]
        public string clientInvoices(string id)
        {

            return "ok";
        }

    }
}

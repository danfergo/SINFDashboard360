using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SINFDashboard360.Lib_Primavera.Model;
using Interop.StdBE800;
using SINFDashboard360.Lib_Primavera;

namespace SINFDashboard360.Controllers.Api
{
    public class ProvidersController : ApiController
    {
        public IEnumerable<Models.Fornecedor> Get()
        {
            return Pri_Bridge.Providers.ListaFornecedores();
        }
    }
}

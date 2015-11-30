using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SINFDashboard360.Controllers.Api
{
    public class IndexController : ApiController
    {
        public IEnumerable<Models.Produto> Get()
        {
            return Pri_Bridge.Products.getListaProdutosBaixoStock();
        }
    }
}

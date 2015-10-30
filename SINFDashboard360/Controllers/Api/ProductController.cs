using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SINFDashboard360.Controllers
{
    public class ProductController : ApiController
    {
        // GET api/product/5
        public Models.Produto Get(String id)
        {
            return Pri_Bridge.Products.getProdutoPeloId(id);
        }

    }
}

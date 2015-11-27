﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SINFDashboard360.Controllers
{
    public class ProductsController : ApiController
    {
        // GET api/products
        public IEnumerable<Models.Produto> Get(string id)
        {
            return Pri_Bridge.Products.getListaProdutosByCategory(id);
        }

    }
}

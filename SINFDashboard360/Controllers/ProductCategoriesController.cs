using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SINFDashboard360.Controllers
{
    public class ProductCategoriesController : ApiController
    {
        // GET api/productcategories
        public IEnumerable<Models.Category> Get()
        {
            return Models.Category.getCategories();
        }

    }
}

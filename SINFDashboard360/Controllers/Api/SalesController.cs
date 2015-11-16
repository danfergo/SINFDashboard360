using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Interop.ErpBS800;
using Interop.StdPlatBS800;
using Interop.StdBE800;
using Interop.GcpBE800;
using ADODB;
using Interop.IGcpBS800;
using SINFDashboard360.Lib_Primavera.Model;
using SINFDashboard360.Lib_Primavera;
 
namespace SINFDashboard360.Controllers
{
    public class SalesController : ApiController
    {
        //// GET api/sales
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        public IEnumerable<DocVenda> Get(string min_date, string max_date)
        {
            return Pri_Bridge.Sales.ListaFiltradaPorDatas(min_date, max_date);
        }

        // GET api/sales/5
        public DocVenda Get(int id)
        {
            string numdoc = id.ToString();
            return Pri_Bridge.Purchases.Encomenda_Get(numdoc);
        }

    }
}
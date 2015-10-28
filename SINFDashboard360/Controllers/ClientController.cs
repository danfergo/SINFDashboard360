using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SINFDashboard360.Controllers
{
    public class ClientController : ApiController
    {
        // GET api/client
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/client/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/client
        public void Post([FromBody]string value)
        {
        }

        // PUT api/client/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/client/5
        public void Delete(int id)
        {
        }
    }
}

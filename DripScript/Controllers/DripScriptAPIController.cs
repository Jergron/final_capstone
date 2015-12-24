using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DripScript.Controllers
{
    public class DripScriptAPIController : ApiController
    {
        // GET: api/DripScriptAPI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/DripScriptAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DripScriptAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/DripScriptAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DripScriptAPI/5
        public void Delete(int id)
        {
        }
    }
}

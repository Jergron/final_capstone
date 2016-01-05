using DripScript.Models;
using Microsoft.AspNet.Identity;
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
        public DSRepository Repo { get; set; }

        public DripScriptAPIController() : base()
        {
            Repo = new DSRepository();
        }


        // GET: api/DripScriptAPI
        public string Get()
        {
            return "Hello World!";
        }

        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/DripScriptAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DripScriptAPI

        public void Post(JournalEntry new_entry)
        {
            string user_id = User.Identity.GetUserId();
            ApplicationUser new_user = Repo.Context.Users.FirstOrDefault(u => u.Id == user_id);
            DSUser me = Repo.GetAllUsers().Where(u => u.RealUser.Id == user_id).First();

            if (me != null)
            {
                Repo.CreateEntry(me, new_entry.Body, new_entry.Title);
            } 
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

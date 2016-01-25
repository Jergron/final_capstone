using DripScript.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Data;
using System.Web.Http;
using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;

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
        //public string Get()
        //{
        //    return "value";
        //}

        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/DripScriptAPI/5
        [HttpPost]
        [Route("api/DripScriptAPI/search")]
        public string Get(QueryViewModel query)
        {
            string html = string.Empty;
            string key = "anC4Qq15vtD7ZAd2y2poER47lzCaIYcAT7RRgegR";
            if (query != null)
            {
                var uri = new Uri("https://bibles.org/v2/search.js?query="+ query.Book +" " + query.Chapter + ":" + query.Verse + "&version=eng-KJVA");
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential(key, "arst"));
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Credentials = cache;
                request.AutomaticDecompression = DecompressionMethods.GZip;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())

                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    html = reader.ReadToEnd();
                }
                return html;
            } else
            {
                return "Type in something";
            }
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
        public void Put(DSUser update)
        {
            string user_id = User.Identity.GetUserId();
            DSUser me = Repo.GetAllUsers().Where(u => u.RealUser.Id == user_id).First();

            if (me != null)
            {
                Repo.UpdateUser(me.UserId, update);  
            }
        }

        // DELETE: api/DripScriptAPI/5
        public void Delete(int id)
        {
            Repo.RemoveEntry(id);           
        }
    }
}

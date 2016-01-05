using DripScript.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace DripScript.Controllers
{
    public class DripScriptController : Controller
    {
        public DSRepository Repo { get; set; }

        public DripScriptController() : base()
        {
            Repo = new DSRepository();
        }

        private DSContext db = new DSContext();
        // GET: DripScript
        public ActionResult Index()
        {
            List<JournalEntry> my_entries = Repo.GetAllEntries();
            return View(my_entries);
        }

        [Authorize]
        public ActionResult Dashboard()
        {
            string user_id = User.Identity.GetUserId();
            ApplicationUser new_user = Repo.Context.Users.FirstOrDefault(u => u.Id == user_id);
            DSUser me = null;
            if (Repo.GetAllUsers().Where(u => u.RealUser.Id == user_id).Count() < 1)
            {
                bool successful = Repo.CreateDSUser(new_user);
            }
            else
            {
                me = Repo.GetAllUsers().Where(u => u.RealUser.Id == user_id).First();
            }

            List<JournalEntry> list_of_entries = Repo.GetUserEntries(me);
            return View(list_of_entries);
        }

        [Authorize]
        public ActionResult NewProfile()
        {
            DSUser user = new DSUser();
            return View(db.Entries.Where(e => e.UserId == user.UserId).ToList());
        }

        [Authorize]
        public ActionResult JournalEntry()
        {
            return View();
        }

        // GET: DripScript/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DripScript/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DripScript/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DripScript/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DripScript/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DripScript/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DripScript/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

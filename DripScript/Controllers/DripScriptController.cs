using DripScript.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DripScript.Controllers
{
    public class DripScriptController : Controller
    {
        private DSContext db = new DSContext();
        // GET: DripScript
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult NewProfile()
        {
            
            //List<string> list_of_items = new List<string>();
            //list_of_items.Add("My Journal");
            //list_of_items.Add("Today's News");
            //list_of_items.Add("How About That");
            return View(db.Entries.ToList());
        }

        
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

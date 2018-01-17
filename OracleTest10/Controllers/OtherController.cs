using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OracleTest10.Models;
using System.Net;

namespace OracleTest10.Controllers
{
    public class OtherController : Controller
    {
        // GET: Other
        public ActionResult Index()
        {

            //Models.MailTrackingEntities gvbd = new Models.MailTrackingEntities();
            Models.OREntities gvbd = new Models.OREntities();

            // LINQ QUERY ???
            var SchemeList = (from scheme in gvbd.MAINs select scheme).ToList();

            return View(SchemeList);


            //return View();
        }


        // ActionResult = Result of action method 
        // Returns View(singleuser) = View with model of single user passed to it.
        // Model of single user is a table row with the same fields. Model can have more than one rows.
        // Takes id input.
        public ActionResult Snapshot(decimal id)
        {
            if (id.Equals(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.OREntities gvbd = new Models.OREntities();
            MAIN singleuser = gvbd.MAINs.Find(id);
            if (singleuser == null)
            {
                return HttpNotFound();
            }
            return View(singleuser);

        }



        // GET: Other/Details/5
        public ActionResult Details(string id)
        {
            return View();
        }

        // GET: Other/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Other/Create
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

        // GET: Other/Edit/5
        /// <summary>
        /// ///////
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET METHOD
        // Function : Brings up the edit form URL.
        // Input: string ID 
        // Output : EditView with model supplied, new user
        public ActionResult Edit(decimal id)
        {
            if (id.Equals(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.OREntities gvbd = new Models.OREntities();
            MAIN newuser = gvbd.MAINs.Find(id);
            if (newuser == null)
            {
                return HttpNotFound();
            }
            return View(newuser);
        }

        // POST: Other/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
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

        // GET: Other/Delete/5
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: Other/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
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

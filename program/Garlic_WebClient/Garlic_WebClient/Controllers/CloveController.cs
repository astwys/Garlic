using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garlic_WebClient;

namespace Garlic_WebClient.Controllers
{
    public class CloveController : Controller
    {
        private garlicEntities db = new garlicEntities();

        // GET: Clove
        public ActionResult Index()
        {
            return View(db.c_clove.ToList());
        }

        // GET: Clove/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            c_clove c_clove = db.c_clove.Find(id);
            if (c_clove == null)
            {
                return HttpNotFound();
            }
            return View(c_clove);
        }

        // GET: Clove/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clove/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "c_id,c_name,c_access,c_description")] c_clove c_clove)
        {
            if (ModelState.IsValid)
            {
                db.c_clove.Add(c_clove);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(c_clove);
        }

        // GET: Clove/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            c_clove c_clove = db.c_clove.Find(id);
            if (c_clove == null)
            {
                return HttpNotFound();
            }
            return View(c_clove);
        }

        // POST: Clove/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "c_id,c_name,c_access,c_description")] c_clove c_clove)
        {
            if (ModelState.IsValid)
            {
                db.Entry(c_clove).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c_clove);
        }

        // GET: Clove/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            c_clove c_clove = db.c_clove.Find(id);
            if (c_clove == null)
            {
                return HttpNotFound();
            }
            return View(c_clove);
        }

        // POST: Clove/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            c_clove c_clove = db.c_clove.Find(id);
            db.c_clove.Remove(c_clove);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

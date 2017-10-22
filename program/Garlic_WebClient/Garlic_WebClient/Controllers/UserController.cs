using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garlic_WebClient.Models;

namespace Garlic_WebClient.Controllers
{
    public class UserController : Controller
    {
        private garlicEntities db = new garlicEntities();

        // GET: User
        public ActionResult Index()
        {
            return View(db.u_users.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            u_users u_users = db.u_users.Find(id);
            if (u_users == null)
            {
                return HttpNotFound();
            }
            return View(u_users);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "u_username,u_password,u_email")] u_users u_users)
        {
            if (ModelState.IsValid)
            {
                db.u_users.Add(u_users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(u_users);
        }

        // GET: User/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            u_users u_users = db.u_users.Find(id);
            if (u_users == null)
            {
                return HttpNotFound();
            }
            return View(u_users);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "u_username,u_password,u_email")] u_users u_users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(u_users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(u_users);
        }

        // GET: User/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            u_users u_users = db.u_users.Find(id);
            if (u_users == null)
            {
                return HttpNotFound();
            }
            return View(u_users);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            u_users u_users = db.u_users.Find(id);
            db.u_users.Remove(u_users);
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

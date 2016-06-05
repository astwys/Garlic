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
    public class ReadController : Controller
    {
        private garlicEntities db = new garlicEntities();

        // GET: Read
        public ActionResult Index(int? article_id)
        {
            var articles = (from p in db.p_posts
                            where p.p_id == article_id
                            select p).Distinct();
            //var p_posts = db.p_posts.Include(p => p.a_articles).Include(p => p.u_users);
            return View(articles.ToList());
        }

        // GET: Read/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_posts p_posts = db.p_posts.Find(id);
            if (p_posts == null)
            {
                return HttpNotFound();
            }
            return View(p_posts);
        }

        // GET: Read/Create
        public ActionResult Create()
        {
            ViewBag.p_id = new SelectList(db.a_articles, "a_p_id", "a_title");
            ViewBag.p_u_username = new SelectList(db.u_users, "u_username", "u_password");
            return View();
        }

        // POST: Read/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "p_id,p_content,p_date,p_u_username")] p_posts p_posts)
        {
            if (ModelState.IsValid)
            {
                db.p_posts.Add(p_posts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.p_id = new SelectList(db.a_articles, "a_p_id", "a_title", p_posts.p_id);
            ViewBag.p_u_username = new SelectList(db.u_users, "u_username", "u_password", p_posts.p_u_username);
            return View(p_posts);
        }

        // GET: Read/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_posts p_posts = db.p_posts.Find(id);
            if (p_posts == null)
            {
                return HttpNotFound();
            }
            ViewBag.p_id = new SelectList(db.a_articles, "a_p_id", "a_title", p_posts.p_id);
            ViewBag.p_u_username = new SelectList(db.u_users, "u_username", "u_password", p_posts.p_u_username);
            return View(p_posts);
        }

        // POST: Read/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "p_id,p_content,p_date,p_u_username")] p_posts p_posts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_posts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.p_id = new SelectList(db.a_articles, "a_p_id", "a_title", p_posts.p_id);
            ViewBag.p_u_username = new SelectList(db.u_users, "u_username", "u_password", p_posts.p_u_username);
            return View(p_posts);
        }

        // GET: Read/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_posts p_posts = db.p_posts.Find(id);
            if (p_posts == null)
            {
                return HttpNotFound();
            }
            return View(p_posts);
        }

        // POST: Read/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            p_posts p_posts = db.p_posts.Find(id);
            db.p_posts.Remove(p_posts);
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

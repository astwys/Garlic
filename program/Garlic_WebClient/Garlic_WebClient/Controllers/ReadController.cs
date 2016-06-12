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
            var article = (from p in db.p_posts
                            where p.p_id == article_id
                            select p).FirstOrDefault();
            ViewBag.Clove = article.a_articles.c_clove.c_name;
            ViewBag.ATitle = article.a_articles.a_title;
            return View(article);
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

        // GET: Read/Edit/5
        [Authorize]
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
            ViewBag.id = p_posts.p_id;
            ViewBag.clove = new SelectList(db.c_clove.Where(c => c.c_access || c.u_users.Contains(UserInformation.User)), "c_id", "c_name");
            ViewBag.atitle = p_posts.a_articles.a_title;
            ViewBag.content = p_posts.p_content;
            return View(p_posts);
        }

        
        public ActionResult EditArticle (FormCollection form, int? post_id) {

            int id = post_id == null ? 1 : (int)post_id;
            int clove = Convert.ToInt32(form["clove"]);
            string title = form["atitle"];
            string content = form["content"];

            db.a_articles.Find(id).a_c_clove = clove;
            db.a_articles.Find(id).a_title = title;
            db.p_posts.Find(id).p_content = content;

            db.SaveChanges();

            return RedirectToAction("Index", new { article_id = id });
        }

        // GET: Read/Delete/5
        [Authorize]
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

        private ActionResult RedirectToLocal (string returnUrl) {
            if (Url.IsLocalUrl(returnUrl)) {
                return Redirect(returnUrl);
            } else {
                return RedirectToAction("Index", "Home");
            }

        }

    }
}

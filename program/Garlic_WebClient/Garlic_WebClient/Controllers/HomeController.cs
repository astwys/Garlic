using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Garlic_WebClient.Models;

namespace Garlic_WebClient.Controllers {

    public class HomeController : Controller {

        garlicEntities db = new garlicEntities();

        public ActionResult Index (int? clove) {
            if (!Request.IsAuthenticated)
                UserInformation.User = null;

            var list = new List<HomePageModel>();
            var model = new HomePageModel();
            model.CloveID = clove;
            list.Add(model);

            ViewBag.clove = new SelectList(model.Cloves, "c_id", "c_name");
            return View(list);            
        }

        [Authorize]
        public ActionResult Write () {
            ViewBag.clove = new SelectList(db.c_clove, "c_id", "c_name");
            return View();
        }

        [HttpPost]
        public ActionResult CreateArticle (FormCollection form) {

            string clove = form["clove"];
            string title = form["atitle"];
            string content = form["content"];

            p_posts post = new p_posts();
            post.p_id = ((from p in db.p_posts
                          select p.p_id).Max()) + 1;
            post.p_content = content;
            post.p_date = DateTime.Now;
            post.p_u_username = "aadams5f2";

            a_articles article = new a_articles();
            article.a_p_id = post.p_id;
            article.a_title = title;
            article.a_c_clove = Convert.ToInt32(clove);
            article.a_r_rank = null;

            db.p_posts.Add(post);
            db.a_articles.Add(article);

            db.SaveChanges();

            RedirectToLocal("~/Home/Index");

            return View();
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
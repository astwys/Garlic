using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Garlic_WebClient.Models;

namespace Garlic_WebClient.Controllers
{
    public class AccountController : Controller
    {

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login (LoginModel model, string returnUrl) {
            u_users login;

            if (ModelState.IsValid) {
                using (var db = new garlicEntities()) {
                    var erg = from u in db.u_users
                              where u.u_username.Equals(model.Username) && u.u_password.Equals(model.Password)
                              select u;
                    login = erg.FirstOrDefault();
                }

                if (login != null) {
                    UserInformation.User = login;
                    FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);
                    return RedirectToLocal(returnUrl);  // Url  ?? "~/Home/Index"
                } else {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff () {
            FormsAuthentication.SignOut();
            UserInformation.User = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Manage (string username) {

            garlicEntities db = new garlicEntities();

            var user = db.u_users.Where(u => u.u_username.Equals(username));

            ViewBag.User = username;
            ViewBag.Email = user.First().u_email;
            ViewBag.Password = user.First().u_password;

            return View();
        }

        public ActionResult Update (FormCollection form, string username) {

            garlicEntities db = new garlicEntities();

            var password = form["Password"];

            u_users user = (from u in db.u_users
                            where u.u_username.Equals(username)
                            select u).ToList().First();

            if (!String.IsNullOrEmpty(password)) {
                user.u_password = password;
            }

            db.SaveChanges();

            return RedirectToAction("Index", "Home");

        }


        private ActionResult RedirectToLocal (string returnUrl) {
            if (Url.IsLocalUrl(returnUrl)) {
                return Redirect(returnUrl);
            } else {
                return RedirectToAction("Index", "Home");
            }

        }

        public ActionResult Register(RegisterModel model, string returnUrl) {
            u_users user;

            if (ModelState.IsValid) {
                using (var db = new garlicEntities()) {
                    user = new u_users
                    {
                        u_username = model.Username,
                        u_email = model.Email,
                        u_password = model.Password
                    };

                    db.u_users.Add(user);
                    db.SaveChanges();
                }


                if (user != null) {
                    UserInformation.User = user;
                    FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);
                    return RedirectToLocal(returnUrl);  // Url  ?? "~/Home/Index"
                } else {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            return View(model);
        }

    }
}
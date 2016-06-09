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

        public ActionResult Manage () {
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
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

            var list = new List<Fusion>();
            list.Add(new Fusion(-1));

            return View(list);

            if (clove == null)
                return View();
            
        }

        public ActionResult About () {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact () {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
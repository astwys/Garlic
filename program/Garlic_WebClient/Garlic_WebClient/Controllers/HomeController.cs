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
            var fusion = new Fusion();
            fusion.CloveID = clove;
            list.Add(fusion);

            ViewBag.clove = new SelectList(fusion.Cloves, "c_id", "c_name");
            return View(list);            
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
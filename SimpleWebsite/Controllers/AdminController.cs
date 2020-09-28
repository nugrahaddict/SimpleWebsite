using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleWebsite.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
            //return Login();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Icon()
        {
            return View();
        }

        public ActionResult Template()
        {
            return View();
        }

        public ActionResult Latihan()
        {
            return View();
        }
    }
}
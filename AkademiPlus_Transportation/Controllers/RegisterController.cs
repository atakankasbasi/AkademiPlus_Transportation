using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AkademiPlus_Transportation.Models;

namespace AkademiPlus_Transportation.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        DbTransportEntities db = new DbTransportEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(tbl_Admin p)
        {
            db.tbl_Admin.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index","Login"); //Login indexe gider
        }
    }
}
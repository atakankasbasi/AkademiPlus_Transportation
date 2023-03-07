using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AkademiPlus_Transportation.Models;

namespace AkademiPlus_Transportation.Controllers
{
    public class SettingsController : Controller
    {
        DbTransportEntities db = new DbTransportEntities();
        // GET: Setting
        [HttpGet]
        public ActionResult Index()
        {
            var values = Session["Username"];
            var uservalue = db.tbl_Admin.Where(x => x.Username == values).FirstOrDefault();
            return View(uservalue);
        }
        [HttpPost]
        public ActionResult Index(tbl_Admin tbl_Admin)
        {
            return View();
        }
    }
}
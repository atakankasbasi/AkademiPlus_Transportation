using AkademiPlus_Transportation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AkademiPlus_Transportation.Controllers
{
    
    public class LoginController : Controller
    {
        DbTransportEntities db = new DbTransportEntities();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(tbl_Admin t)
        {
            var values = db.tbl_Admin.Where(x => x.Username == t.Username &x.Password == t.Password).FirstOrDefault();
            if(values != null)
            {
                FormsAuthentication.SetAuthCookie(values.Username, false);
                Session["UserName"] = t.Username;
                return RedirectToAction("Index", "Customer");
            }
            return View();
        }
    }
}
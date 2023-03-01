using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AkademiPlus_Transportation.Models;

namespace AkademiPlus_Transportation.Controllers
{
    public class ProcessController : Controller
    {
        // GET: Process
        DbTransportEntities db = new DbTransportEntities();

        public ActionResult Index()
        {
            var values = db.TblProcess.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddProcess()
        {
            List<SelectListItem> value1 = (from x in db.TblTransportation.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.TransportationID.ToString(),
                                               Value = x.TransportationID.ToString()
                                           }).ToList();
            ViewBag.v1 = value1;
            return View();
        }
        [HttpPost]
        public ActionResult AddProcess(TblProcess tblProcess)
        {
            db.TblProcess.Add(tblProcess);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult DeleteProcess(int id)
        {
            var value = db.TblProcess.Find(id);
            db.TblProcess.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateProcess(int id) 
        {
            List<SelectListItem> value1 = (from x in db.TblTransportation.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.TransportationID.ToString(),
                                               Value = x.TransportationID.ToString()
                                           }).ToList();
            ViewBag.v1 = value1;
            var values = db.TblProcess.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateProcess(TblProcess tblProcess)
        {
            var values = db.TblProcess.Find(tblProcess.ProcessID);
            values.Transportation = tblProcess.Transportation;
            values.Description = tblProcess.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
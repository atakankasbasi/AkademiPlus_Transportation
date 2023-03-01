using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AkademiPlus_Transportation.Models;

namespace AkademiPlus_Transportation.Controllers
{
    public class TransportationController : Controller
    {
        // GET: Transportation
        DbTransportEntities db = new DbTransportEntities();
        public ActionResult Index()
        {
            var values = db.TblTransportation.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddTransportation()
        {
            List<SelectListItem> value1 = (from x in db.TblCustomer.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CustomerName + " " + x.CustomerSurname,
                                              Value = x.CustomerID.ToString()
                                          }).ToList();

            List<SelectListItem> value2 = (from x in db.TblCategory.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CategoryName,
                                              Value = x.CategoryID.ToString()
                                          }).ToList();

            List<SelectListItem> value3 = (from x in db.TblProduct.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductID.ToString()
                                           }).ToList();

            List<SelectListItem> value4 = (from x in db.TblEmployee.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName,
                                               Value = x.EmployeeID.ToString()
                                           }).ToList();
            ViewBag.v1 = value1;
            ViewBag.v2 = value2;
            ViewBag.v3 = value3;
            ViewBag.v4 = value4;
            return View();
        }
        [HttpPost]
        public ActionResult AddTransportation(TblTransportation tblTransportation)
        {
            tblTransportation.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblTransportation.Add(tblTransportation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteTransportation(int id)
        {
            var value = db.TblTransportation.Find(id);
            db.TblTransportation.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTransportation(int id)
        {
            List<SelectListItem> value1 = (from x in db.TblCustomer.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CustomerName + " " + x.CustomerSurname,
                                               Value = x.CustomerID.ToString()
                                           }).ToList();

            List<SelectListItem> value2 = (from x in db.TblCategory.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();

            List<SelectListItem> value3 = (from x in db.TblProduct.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductID.ToString()
                                           }).ToList();

            List<SelectListItem> value4 = (from x in db.TblEmployee.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName,
                                               Value = x.EmployeeID.ToString()
                                           }).ToList();
            ViewBag.v1 = value1;
            ViewBag.v2 = value2;
            ViewBag.v3 = value3;
            ViewBag.v4 = value4;
            var value = db.TblTransportation.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateTransportation(TblTransportation tblTransportation)
        {
            var value = db.TblTransportation.Find(tblTransportation.TransportationID);
            value.Customer = tblTransportation.Customer;
            value.Category = tblTransportation.Category;
            value.Product = tblTransportation.Product;
            value.Employee = tblTransportation.Employee;
            value.Status = tblTransportation.Status;
            value.Departure = tblTransportation.Departure;
            value.Arrival = tblTransportation.Arrival;
            value.Date = tblTransportation.Date;
            value.Description = tblTransportation.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
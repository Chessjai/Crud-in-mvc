using S3Q1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S3Q1.Controllers
{
    public class HomeController : Controller
    {
        Interface1 student = null;
        dbcontext db = new dbcontext();
        public ActionResult Index()
        {
            var db = student.ReadAll();

            return View(db);
        }
        public HomeController()
        {
            student = new studentrepo();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(studentmodel model)
        {
            if (ModelState.IsValid)
            {
                var db = student.Create(model);

                ViewBag.Msg = "Student is inserted Successfully";

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Msg2 = "Somthing Problem";
                return View();
            }
        }


            public ActionResult Delete(long id)
        {
            var res = db.models.Where(s => s.Id == id).FirstOrDefault();


            return View(res);

        }
        [HttpPost]
        public ActionResult Delete(studentmodel stud)
        {
            var db = student.Delete(stud);

            if (db.Id > 0)
            {
                TempData["DeleteMessage"] = "<scrip>alret('Deleted!')</script>";

                return RedirectToAction("Index");
            }
            else
            {
                TempData["DeleteDeleteMessage"] = "<scrip>alret('Data Not Delete!')</script>";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(long id)
        {
            var res = db.models.Where(s => s.Id == id).FirstOrDefault();


            return View(res);
        }
        public ActionResult Details(long id)
        {
            var res = db.models.Where(s => s.Id == id).FirstOrDefault();


            return View(res);
        }


        [HttpPost]
        public ActionResult Edit(studentmodel model)
        {
            if (ModelState.IsValid == true)
            {
                var db = student.Edit(model);
                if (db.Id > 0)
                {
                    TempData["UpdateMessage"] = "Data Update !";

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.UpdateMesssage = "<scrip>alret('Data Not Update!')</script>";
                }
            }
            return View();

        }
    }
}
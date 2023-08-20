using CRUDAjaxDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDAjaxDemo.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            StudentEntities db = new StudentEntities();
            List<Std_Login> studentList = db.Std_Login.ToList();
            return Json(new { data = studentList },
            JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult StoreOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Std_Login());
            else
            {
                using (StudentEntities db = new StudentEntities())
                {
                    return View(db.Std_Login.Where(x => x.UserID == id).FirstOrDefault<Std_Login>());
                }
            }
        }

        [HttpPost]
        public ActionResult StoreOrEdit(Std_Login studentob)
        {
            using (StudentEntities db = new StudentEntities())
            {
                if (studentob.UserID == 0)
                {
                    db.Std_Login.Add(studentob);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully", JsonRequestBehavior.AllowGet });
                }
                else
                {
                    db.Entry(studentob).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully", JsonRequestBehavior.AllowGet });
                }
            }

        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (StudentEntities db = new StudentEntities())
            {
                Std_Login emp = db.Std_Login.Where(x => x.UserID == id).FirstOrDefault<Std_Login>();
                db.Std_Login.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully", JsonRequestBehavior.AllowGet });
            }
        }
    }
}

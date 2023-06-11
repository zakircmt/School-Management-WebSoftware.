using SMStudent.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SMStudent.Website.Teacher.Controllers
{
    public class TeacherDashboardController : Controller
    {
        private SMStudentContext db = new SMStudentContext();
        // GET: TeacherDashboard
        public ActionResult Index(int? id)
        {
            var teacherid = id;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out studentid);
            //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["TUsername"]);
            var password = Convert.ToString(Session["TPassword"]);

            var findTeacher = db.TeacherTables.Where(teacher => teacher.Username == username && teacher.Password == password && teacher.ID== teacherid).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            return View();
        }

        // GET: Teachers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var teacher = db.TeacherTables.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var teacher = db.TeacherTables.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            ViewBag.Gender_ID = new SelectList(db.GenderTables, "ID", "Name", teacher.Gender_ID);
            ViewBag.Nationality_ID = new SelectList(db.Nationalities, "ID", "Name", teacher.Nationality_ID);
            ViewBag.PostOffice_ID = new SelectList(db.PostOffices, "ID", "Name", teacher.PostOffice_ID);
            ViewBag.Religious_ID = new SelectList(db.ReligiousTables, "ID", "Name", teacher.Religious_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", teacher.User_ID);
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TeacherTable teacher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Gender_ID = new SelectList(db.GenderTables, "ID", "Name", teacher.Gender_ID);
            ViewBag.Nationality_ID = new SelectList(db.Nationalities, "ID", "Name", teacher.Nationality_ID);
            ViewBag.PostOffice_ID = new SelectList(db.PostOffices, "ID", "Name", teacher.PostOffice_ID);
            ViewBag.Religious_ID = new SelectList(db.ReligiousTables, "ID", "Name", teacher.Religious_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", teacher.User_ID);
            return View(teacher);
        }

        public ActionResult ErrorPage()
        {
            ViewBag.message = "You Are Temporary Suspend";
            return View();
        }
    }
}
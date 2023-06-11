using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SMStudent.Database;

namespace SMStudent.Website.Admin.Controllers
{
    public class TeachersController : Controller
    {
        private SMStudentContext db = new SMStudentContext();

        // GET: Teachers
        public ActionResult Index(int? id)
        {
            var adminid = id;
            var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out adminid);
            int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var findTeacher = db.UserTables.Where(teacher => teacher.Username == username && teacher.Password == password && teacher.ID == adminid).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var teachers = db.TeacherTables.Include(t => t.GenderTable).Include(t => t.Nationality).Include(t => t.PostOffice).Include(t => t.ReligiousTable).Include(t => t.UserTable);
            return View(teachers.ToList());
        }

        // GET: Teachers/Details/5
        public ActionResult Details(int? id)
        {
            var adminid = id;
            var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out adminid);
            int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var findTeacher = db.UserTables.Where(t => t.Username == username && t.Password == password && t.ID == adminid).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }
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

        // GET: Teachers/Create
        public ActionResult Create(int? id)
        {
            var adminid = id;
            var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out adminid);
            int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var findTeacher = db.UserTables.Where(teacher => teacher.Username == username && teacher.Password == password && teacher.ID == adminid).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            ViewBag.Gender_ID = new SelectList(db.GenderTables, "ID", "Name");
            ViewBag.Nationality_ID = new SelectList(db.Nationalities, "ID", "Name");
            ViewBag.PostOffice_ID = new SelectList(db.PostOffices, "ID", "Name");
            ViewBag.Religious_ID = new SelectList(db.ReligiousTables, "ID", "Name");
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName");
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeacherTable teacher)
        {
            var adminid = 0;
            var userTypeId = 0;
            int.TryParse(Convert.ToString(Session["SID"]), out adminid);
            int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var findTeacher = db.UserTables.Where(t => t.Username == username && t.Password == password && t.ID == adminid).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            if (ModelState.IsValid)
            {
                db.TeacherTables.Add(teacher);
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

        // GET: Teachers/Edit/5
        public ActionResult Edit(int? id)
        {
            var adminid = id;
            var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out adminid);
            int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var findTeacher = db.UserTables.Where(u => u.Username == username && u.Password == password && u.ID == adminid).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var  teacher = db.TeacherTables.Find(id);
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
            var adminid = 0;
            var userTypeId = 0;
            int.TryParse(Convert.ToString(Session["SID"]), out adminid);
            int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var findTeacher = db.UserTables.Where(u => u.Username == username && u.Password == password && u.ID == adminid).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }
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

        // GET: Teachers/Delete/5
        public ActionResult Delete(int? id)
        {
            var adminid = id;
            var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out adminid);
            int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var findTeacher = db.UserTables.Where(u => u.Username == username && u.Password == password && u.ID == adminid).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }
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

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var adminid = id;
            var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out adminid);
            int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var findTeacher = db.UserTables.Where(u => u.Username == username && u.Password == password && u.ID == adminid).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var teacher = db.TeacherTables.Find(id);
            db.TeacherTables.Remove(teacher);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

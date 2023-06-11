using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SMStudent.Database;

namespace SMStudent.Website.Users.Controllers
{
    public class StudyTourFeelTablesController : Controller
    {
        private SMStudentContext db = new SMStudentContext();

        // GET: StudyTourFeelTables
        public ActionResult Index(int? id)
        {
            var userid = id;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out userid);
            //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var findTeacher = db.UserTables.Where(u => u.Username == username && u.Password == password).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var studyTourFeelTables = db.StudyTourFeelTables.Include(s => s.ClassTable).Include(s => s.DivisionTable).Include(s => s.SessionTable).Include(s => s.TeacherTable).Include(s => s.UserTable);
            return View(studyTourFeelTables.ToList());
        }

        // GET: StudyTourFeelTables/Details/5
        public ActionResult Details(int? id)
        {
            var userid = id;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out userid);
            //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var findTeacher = db.UserTables.Where(u => u.Username == username && u.Password == password).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyTourFeelTable studyTourFeelTable = db.StudyTourFeelTables.Find(id);
            if (studyTourFeelTable == null)
            {
                return HttpNotFound();
            }
            return View(studyTourFeelTable);
        }

        // GET: StudyTourFeelTables/Create
        public ActionResult Create(int? id)
        {
            var userid = id;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["ID"]), out userid);
            //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var findTeacher = db.UserTables.Where(u => u.Username == username && u.Password == password).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name");
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name");
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name");
            ViewBag.Teacher_ID = new SelectList(db.TeacherTables, "ID", "Name");
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name");
            return View();
        }

        // POST: StudyTourFeelTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( StudyTourFeelTable studyTourFeelTable)
        {
            var userid = 0;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out userid);
            //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var findTeacher = db.UserTables.Where(u => u.Username == username && u.Password == password).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", studyTourFeelTable.Class_ID);
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", studyTourFeelTable.Division_ID);
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name", studyTourFeelTable.Session_ID);
            ViewBag.Teacher_ID = new SelectList(db.TeacherTables, "ID", "Name", studyTourFeelTable.Teacher_ID);
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name", studyTourFeelTable.Student_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", studyTourFeelTable.User_ID = Convert.ToInt32(Session["ID"]));
            studyTourFeelTable.EditDate = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                db.StudyTourFeelTables.Add(studyTourFeelTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           return View(studyTourFeelTable);
        }

        // GET: StudyTourFeelTables/Edit/5
        public ActionResult Edit(int? id)
        {

            var userid = id;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out userid);
            //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var findTeacher = db.UserTables.Where(u => u.Username == username && u.Password == password).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyTourFeelTable studyTourFeelTable = db.StudyTourFeelTables.Find(id);
            if (studyTourFeelTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", studyTourFeelTable.Class_ID);
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", studyTourFeelTable.Division_ID);
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name", studyTourFeelTable.Session_ID);
            ViewBag.Teacher_ID = new SelectList(db.TeacherTables, "ID", "Name", studyTourFeelTable.Teacher_ID);
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name", studyTourFeelTable.Student_ID);
            return View(studyTourFeelTable);
        }

        // POST: StudyTourFeelTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudyTourFeelTable studyTourFeelTable)
        {
            var userid = 0;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out userid);
            //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var findTeacher = db.UserTables.Where(u => u.Username == username && u.Password == password).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", studyTourFeelTable.Class_ID);
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", studyTourFeelTable.Division_ID);
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name", studyTourFeelTable.Session_ID);
            ViewBag.Teacher_ID = new SelectList(db.TeacherTables, "ID", "Name", studyTourFeelTable.Teacher_ID);
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name", studyTourFeelTable.Student_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", studyTourFeelTable.User_ID=Convert.ToInt32(Session["ID"]));
            studyTourFeelTable.EditDate = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(studyTourFeelTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studyTourFeelTable);
        }

        // GET: StudyTourFeelTables/Delete/5
        public ActionResult Delete(int? id)
        {
            var userid = id;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out userid);
            //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var findTeacher = db.UserTables.Where(u => u.Username == username && u.Password == password).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyTourFeelTable studyTourFeelTable = db.StudyTourFeelTables.Find(id);
            if (studyTourFeelTable == null)
            {
                return HttpNotFound();
            }
            return View(studyTourFeelTable);
        }

        // POST: StudyTourFeelTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var userid = id;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out userid);
            //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var findTeacher = db.UserTables.Where(u => u.Username == username && u.Password == password).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            StudyTourFeelTable studyTourFeelTable = db.StudyTourFeelTables.Find(id);
            db.StudyTourFeelTables.Remove(studyTourFeelTable);
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

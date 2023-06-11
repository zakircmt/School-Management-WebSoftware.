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
    public class ExamMarksTablesController : Controller
    {
        private SMStudentContext db = new SMStudentContext();

        // GET: ExamMarksTables
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
            var examMarksTables = db.ExamMarksTables.Include(e => e.ClassTable).Include(e => e.DivisionTable).Include(e => e.ExamTable).Include(e => e.GradeTable).Include(e => e.SessionTable).Include(e => e.StudentTable).Include(e => e.SubjectTable).Include(e => e.UserTable);
            return View(examMarksTables.ToList());
        }

        // GET: ExamMarksTables/Details/5
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
            ExamMarksTable examMarksTable = db.ExamMarksTables.Find(id);
            if (examMarksTable == null)
            {
                return HttpNotFound();
            }
            return View(examMarksTable);
        }

        // GET: ExamMarksTables/Create
        public ActionResult Create(int ? id)
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
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name");
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name");
            ViewBag.Exam_ID = new SelectList(db.ExamTables, "ID", "Title");
            ViewBag.Grade_ID = new SelectList(db.GradeTables, "ID", "Name");
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name");
            ViewBag.Subject_ID = new SelectList(db.SubjectTables, "ID", "Name");
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName");
            ViewBag.Student_ID = new SelectList(db.StudentTables.Where(s => s.IsActive == true).ToList(), "ID", "Name");

            return View();
        }

        // POST: ExamMarksTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExamMarksTable examMarksTable)
        {
            //var userid = id;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out userid);
            //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var findTeacher = db.UserTables.Where(u => u.Username == username && u.Password == password && u.UserType_ID==1).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", examMarksTable.Class_ID);
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", examMarksTable.Division_ID);
            ViewBag.Exam_ID = new SelectList(db.ExamTables, "ID", "Title", examMarksTable.Exam_ID);
            ViewBag.Grade_ID = new SelectList(db.GradeTables, "ID", "Name", examMarksTable.Grade_ID);
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name", examMarksTable.Session_ID);
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name", examMarksTable.Student_ID);
            ViewBag.Subject_ID = new SelectList(db.SubjectTables, "ID", "Name", examMarksTable.Subject_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", examMarksTable.User_ID=Convert.ToInt32(Session["ID"]));
            examMarksTable.EditDate = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                db.ExamMarksTables.Add(examMarksTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(examMarksTable);
        }

        // GET: ExamMarksTables/Edit/5
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
            ExamMarksTable examMarksTable = db.ExamMarksTables.Find(id);
            if (examMarksTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", examMarksTable.Class_ID);
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", examMarksTable.Division_ID);
            ViewBag.Exam_ID = new SelectList(db.ExamTables, "ID", "Title", examMarksTable.Exam_ID);
            ViewBag.Grade_ID = new SelectList(db.GradeTables, "ID", "Name", examMarksTable.Grade_ID);
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name", examMarksTable.Session_ID);
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name", examMarksTable.Student_ID);
            ViewBag.Subject_ID = new SelectList(db.SubjectTables, "ID", "Name", examMarksTable.Subject_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", examMarksTable.User_ID);
            return View(examMarksTable);
        }

        // POST: ExamMarksTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExamMarksTable examMarksTable)
        {
           // var userid = id;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out userid);
            //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var findTeacher = db.UserTables.Where(u => u.Username == username && u.Password == password && u.UserType_ID==1).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", examMarksTable.Class_ID);
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", examMarksTable.Division_ID);
            ViewBag.Exam_ID = new SelectList(db.ExamTables, "ID", "Title", examMarksTable.Exam_ID);
            ViewBag.Grade_ID = new SelectList(db.GradeTables, "ID", "Name", examMarksTable.Grade_ID);
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name", examMarksTable.Session_ID);
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name", examMarksTable.Student_ID);
            ViewBag.Subject_ID = new SelectList(db.SubjectTables, "ID", "Name", examMarksTable.Subject_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", examMarksTable.User_ID=Convert.ToInt32(Session["ID"]));
            examMarksTable.EditDate = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(examMarksTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(examMarksTable);
        }

        // GET: ExamMarksTables/Delete/5
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
            ExamMarksTable examMarksTable = db.ExamMarksTables.Find(id);
            if (examMarksTable == null)
            {
                return HttpNotFound();
            }
            return View(examMarksTable);
        }

        // POST: ExamMarksTables/Delete/5
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
            ExamMarksTable examMarksTable = db.ExamMarksTables.Find(id);
            db.ExamMarksTables.Remove(examMarksTable);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SMStudent.Database;

namespace SMStudent.Website.Student.Controllers
{
    public class StudentDailyWorklTablesController : Controller
    {
        private SMStudentContext db = new SMStudentContext();

        // GET: StudentDailyWorklTables
        public ActionResult Index(int ? id)
        {
            var studentid = id;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out studentid);
            //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["sUsername"]);
            var password = Convert.ToString(Session["SPassword"]);

            var findUser = db.StudentTables.Where(user => user.Username == username && user.Password == password && user.ID == studentid).FirstOrDefault();

            if (findUser == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var studentDailyWorklTables = db.StudentDailyWorklTables.Where(s=>s.Student_ID==studentid).Include(s => s.ClassTable).Include(s => s.DivisionTable).Include(s => s.SessionTable).Include(s => s.TeacherTable);
            return View(studentDailyWorklTables.ToList());
        }

        // GET: StudentDailyWorklTables/Details/5
        public ActionResult Details(int? id)
        {
            var studentid = id;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out studentid);
            //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["sUsername"]);
            var password = Convert.ToString(Session["SPassword"]);

            var findUser = db.StudentTables.Where(user => user.Username == username && user.Password == password).FirstOrDefault();

            if (findUser == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentDailyWorklTable studentDailyWorklTable = db.StudentDailyWorklTables.Find(id);
            if (studentDailyWorklTable == null)
            {
                return HttpNotFound();
            }
            return View(studentDailyWorklTable);
        }

        // GET: StudentDailyWorklTables/Create
        public ActionResult Create(int ? id)
        {
            var studentid = id;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out studentid);
            //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["sUsername"]);
            var password = Convert.ToString(Session["SPassword"]);

            var findUser = db.StudentTables.Where(user => user.Username == username && user.Password == password).FirstOrDefault();

            if (findUser == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name");
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name");
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name");
            ViewBag.Teacher_ID = new SelectList(db.TeacherTables, "ID", "Name");
            return View();
        }

        // POST: StudentDailyWorklTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentDailyWorklTable studentDailyWorklTable)
        {
            var studentid = 0;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out studentid);
            //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["sUsername"]);
            var password = Convert.ToString(Session["SPassword"]);

            var findUser = db.StudentTables.Where(user => user.Username == username && user.Password == password).FirstOrDefault();

            if (findUser == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", studentDailyWorklTable.Class_ID = Convert.ToInt32(Session["SClass_ID"]));
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", studentDailyWorklTable.Division_ID = Convert.ToInt32(Session["SDivision_ID"]));
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name", studentDailyWorklTable.Session_ID = Convert.ToInt32(Session["SSession_ID"]));
            ViewBag.Teacher_ID = new SelectList(db.TeacherTables, "ID", "Name", studentDailyWorklTable.Teacher_ID);
            studentDailyWorklTable.EditDate = System.DateTime.Now;

            if (ModelState.IsValid)
            {
                db.StudentDailyWorklTables.Add(studentDailyWorklTable);
                db.SaveChanges();
                var id = Convert.ToInt32(Session["SID"]);
                return RedirectToAction("Index", new { id });
            }

            return View(studentDailyWorklTable);          
        }

        // GET: StudentDailyWorklTables/Edit/5
        public ActionResult Edit(int? id)
        {
            var studentid = id;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out studentid);
            //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["sUsername"]);
            var password = Convert.ToString(Session["SPassword"]);

            var findUser = db.StudentTables.Where(user => user.Username == username && user.Password == password).FirstOrDefault();

            if (findUser == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentDailyWorklTable studentDailyWorklTable = db.StudentDailyWorklTables.Find(id);
            if (studentDailyWorklTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", studentDailyWorklTable.Class_ID);
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", studentDailyWorklTable.Division_ID);
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name", studentDailyWorklTable.Session_ID);
            ViewBag.Teacher_ID = new SelectList(db.TeacherTables, "ID", "Name", studentDailyWorklTable.Teacher_ID);
            return View(studentDailyWorklTable);
        }

        // POST: StudentDailyWorklTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentDailyWorklTable studentDailyWorklTable)
        {
            var studentid = 0;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out studentid);
            //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["sUsername"]);
            var password = Convert.ToString(Session["SPassword"]);

            var findUser = db.StudentTables.Where(user => user.Username == username && user.Password == password).FirstOrDefault();

            if (findUser == null)
            {
                return RedirectToAction("Login", "Auth");
            
            }
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", studentDailyWorklTable.Class_ID = Convert.ToInt32(Session["SClass_ID"]));
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", studentDailyWorklTable.Division_ID = Convert.ToInt32(Session["SDivision_ID"]));
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name", studentDailyWorklTable.Session_ID = Convert.ToInt32(Session["SSession_ID"]));
            ViewBag.Teacher_ID = new SelectList(db.TeacherTables, "ID", "Name", studentDailyWorklTable.Teacher_ID);
            studentDailyWorklTable.EditDate = System.DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Entry(studentDailyWorklTable).State = EntityState.Modified;
                db.SaveChanges(); 
                var id = Convert.ToInt32(Session["SID"]);
                return RedirectToAction("Index", new { id });
            }

            return View(studentDailyWorklTable);
        }

        // GET: StudentDailyWorklTables/Delete/5
        public ActionResult Delete(int? id)
        {
            var studentid = id;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out studentid);
            //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["sUsername"]);
            var password = Convert.ToString(Session["SPassword"]);

            var findUser = db.StudentTables.Where(user => user.Username == username && user.Password == password).FirstOrDefault();

            if (findUser == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentDailyWorklTable studentDailyWorklTable = db.StudentDailyWorklTables.Find(id);
            if (studentDailyWorklTable == null)
            {
                return HttpNotFound();
            }
            return View(studentDailyWorklTable);
        }

        // POST: StudentDailyWorklTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Id)
        {
            var studentid = Id;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out studentid);
            //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["sUsername"]);
            var password = Convert.ToString(Session["SPassword"]);

            var findUser = db.StudentTables.Where(user => user.Username == username && user.Password == password).FirstOrDefault();

            if (findUser == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            StudentDailyWorklTable studentDailyWorklTable = db.StudentDailyWorklTables.Find(Id);
            db.StudentDailyWorklTables.Remove(studentDailyWorklTable);
            db.SaveChanges();
            var id = Convert.ToInt32(Session["SID"]);
            return RedirectToAction("Index", new { id });
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

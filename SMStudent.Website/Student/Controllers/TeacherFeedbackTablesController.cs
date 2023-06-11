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
    public class TeacherFeedbackTablesController : Controller
    {
        private SMStudentContext db = new SMStudentContext();

        // GET: TeacherFeedbackTables
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
            var teacherFeedbackTables = db.TeacherFeedbackTables.Where(s=>s.Student_ID==studentid).Include(t => t.ClassTable).Include(t => t.SessionTable).Include(t => t.StudentTable).Include(t => t.TeacherTable);
            return View(teacherFeedbackTables.ToList());
        }

        // GET: TeacherFeedbackTables/Details/5
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
            TeacherFeedbackTable teacherFeedbackTable = db.TeacherFeedbackTables.Find(id);
            if (teacherFeedbackTable == null)
            {
                return HttpNotFound();
            }
            return View(teacherFeedbackTable);
        }

        // GET: TeacherFeedbackTables/Create
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
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name");
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name");
            ViewBag.Teacher_ID = new SelectList(db.TeacherTables, "ID", "Name");
            return View();
        }

        // POST: TeacherFeedbackTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeacherFeedbackTable teacherFeedbackTable)
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

            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", teacherFeedbackTable.Class_ID = Convert.ToInt32(Session["SClass_ID"]));
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name", teacherFeedbackTable.Session_ID = Convert.ToInt32(Session["SSession_ID"]));
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name", teacherFeedbackTable.Student_ID = Convert.ToInt32(Session["SID"]));
            ViewBag.Teacher_ID = new SelectList(db.TeacherTables, "ID", "Name", teacherFeedbackTable.Teacher_ID);
            teacherFeedbackTable.EditTime = System.DateTime.Now;

            if (ModelState.IsValid)
            {
                db.TeacherFeedbackTables.Add(teacherFeedbackTable);
                db.SaveChanges();
                var id = Convert.ToInt32(Session["SID"]);
                return RedirectToAction("Index", new { id });
            }

           
            return View(teacherFeedbackTable);
        }

        // GET: TeacherFeedbackTables/Edit/5
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
            TeacherFeedbackTable teacherFeedbackTable = db.TeacherFeedbackTables.Find(id);
            if (teacherFeedbackTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", teacherFeedbackTable.Class_ID);
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name", teacherFeedbackTable.Session_ID);
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name", teacherFeedbackTable.Student_ID);
            ViewBag.Teacher_ID = new SelectList(db.TeacherTables, "ID", "Name", teacherFeedbackTable.Teacher_ID);
            return View(teacherFeedbackTable);
        }

        // POST: TeacherFeedbackTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TeacherFeedbackTable teacherFeedbackTable)
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

            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", teacherFeedbackTable.Class_ID = Convert.ToInt32(Session["SClass_ID"]));
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name", teacherFeedbackTable.Session_ID = Convert.ToInt32(Session["SSession_ID"]));
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name", teacherFeedbackTable.Student_ID = Convert.ToInt32(Session["SID"]));
            ViewBag.Teacher_ID = new SelectList(db.TeacherTables, "ID", "Name", teacherFeedbackTable.Teacher_ID);
            teacherFeedbackTable.EditTime = System.DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Entry(teacherFeedbackTable).State = EntityState.Modified;
                db.SaveChanges();
                var id = Convert.ToInt32(Session["SID"]);
                return RedirectToAction("Index", new { id });
            }
           
            return View(teacherFeedbackTable);
        }

        // GET: TeacherFeedbackTables/Delete/5
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
            TeacherFeedbackTable teacherFeedbackTable = db.TeacherFeedbackTables.Find(id);
            if (teacherFeedbackTable == null)
            {
                return HttpNotFound();
            }
            return View(teacherFeedbackTable);
        }

        // POST: TeacherFeedbackTables/Delete/5
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
            TeacherFeedbackTable teacherFeedbackTable = db.TeacherFeedbackTables.Find(Id);
            db.TeacherFeedbackTables.Remove(teacherFeedbackTable);
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

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
    public class ClassRoutinelTablesController : Controller
    {
        private SMStudentContext db = new SMStudentContext();

        // GET: ClassRoutinelTables
        public ActionResult Index(int? id)
        {
            var userid = id;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out studentid);
            //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var findTeacher = db.UserTables.Where(u => u.Username == username && u.Password == password).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var classRoutinelTables = db.ClassRoutinelTables.Include(c => c.ClassTable).Include(c => c.DivisionTable).Include(c => c.SessionTable).Include(c => c.StudentTable).Include(c => c.TeacherTable).Include(c => c.UserTable);
            return View(classRoutinelTables.ToList());
        }

        // GET: ClassRoutinelTables/Details/5
        public ActionResult Details(int? id)
        {
            var userid = id;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out studentid);
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
            ClassRoutinelTable classRoutinelTable = db.ClassRoutinelTables.Find(id);
            if (classRoutinelTable == null)
            {
                return HttpNotFound();
            }
            return View(classRoutinelTable);
        }

        // GET: ClassRoutinelTables/Create
        public ActionResult Create(int? id)
        {
            var userid = id;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out studentid);
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
            ViewBag.SessionID = new SelectList(db.SessionTables, "ID", "Name");
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name");
            ViewBag.Teacher_ID = new SelectList(db.TeacherTables, "ID", "Name");
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName");
            ViewBag.Subject_ID = new SelectList(db.SubjectTables,"ID","Name");
            return View();
        }

        // POST: ClassRoutinelTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClassRoutinelTable classRoutinelTable)
        {
            var userid = 0;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out studentid);
            //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var findTeacher = db.UserTables.Where(u => u.Username == username && u.Password == password).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", classRoutinelTable.Class_ID);
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", classRoutinelTable.Division_ID);
            ViewBag.SessionID = new SelectList(db.SessionTables, "ID", "Name", classRoutinelTable.SessionID);
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name", classRoutinelTable.Student_ID = 8);
            ViewBag.Teacher_ID = new SelectList(db.TeacherTables, "ID", "Name", classRoutinelTable.Teacher_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", classRoutinelTable.User_ID = Convert.ToInt32(Session["ID"]));
            ViewBag.Subject_ID = new SelectList(db.SubjectTables, "ID", "Name", classRoutinelTable.SubJect_ID);
            classRoutinelTable.EditDate = System.DateTime.Now;

            if (ModelState.IsValid)
            {
                db.ClassRoutinelTables.Add(classRoutinelTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classRoutinelTable);
        }

        // GET: ClassRoutinelTables/Edit/5
        public ActionResult Edit(int? id)
        {
            var userid = id;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out studentid);
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


            ClassRoutinelTable classRoutinelTable = db.ClassRoutinelTables.Find(id);

            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", classRoutinelTable.Class_ID);
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", classRoutinelTable.Division_ID);
            ViewBag.SessionID = new SelectList(db.SessionTables, "ID", "Name", classRoutinelTable.SessionID);
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name", classRoutinelTable.Student_ID);
            ViewBag.Teacher_ID = new SelectList(db.TeacherTables, "ID", "Name", classRoutinelTable.Teacher_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", classRoutinelTable.User_ID);
            ViewBag.Subject_ID = new SelectList(db.SubjectTables, "ID", "Name", classRoutinelTable.SubJect_ID);


            if (classRoutinelTable == null)
            {
                return HttpNotFound();
            }
             return View(classRoutinelTable);
        }

        // POST: ClassRoutinelTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClassRoutinelTable classRoutinelTable)
        {
            var userid = 0;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out studentid);
            //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var findTeacher = db.UserTables.Where(u => u.Username == username && u.Password == password).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", classRoutinelTable.Class_ID);
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", classRoutinelTable.Division_ID);
            ViewBag.SessionID = new SelectList(db.SessionTables, "ID", "Name", classRoutinelTable.SessionID);
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name", classRoutinelTable.Student_ID=8);
            ViewBag.Teacher_ID = new SelectList(db.TeacherTables, "ID", "Name", classRoutinelTable.Teacher_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", classRoutinelTable.User_ID=1);
            ViewBag.Subject_ID = new SelectList(db.SubjectTables, "ID", "Name", classRoutinelTable.SubJect_ID);
            classRoutinelTable.EditDate = System.DateTime.Now;


            if (ModelState.IsValid)
            {
                db.Entry(classRoutinelTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classRoutinelTable);
        }

        // GET: ClassRoutinelTables/Delete/5
        public ActionResult Delete(int? id)
        {
            var userid = id;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out studentid);
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
            ClassRoutinelTable classRoutinelTable = db.ClassRoutinelTables.Find(id);
            if (classRoutinelTable == null)
            {
                return HttpNotFound();
            }
            return View(classRoutinelTable);
        }

        // POST: ClassRoutinelTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var userid = id;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out studentid);
            //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var findTeacher = db.UserTables.Where(u => u.Username == username && u.Password == password).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            ClassRoutinelTable classRoutinelTable = db.ClassRoutinelTables.Find(id);
            db.ClassRoutinelTables.Remove(classRoutinelTable);
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

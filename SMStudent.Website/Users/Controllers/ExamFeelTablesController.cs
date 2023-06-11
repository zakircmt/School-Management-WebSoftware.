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
    public class ExamFeelTablesController : Controller
    {
        private SMStudentContext db = new SMStudentContext();

        // GET: ExamFeelTables
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
            var examFeelTables = db.ExamFeelTables.Include(e => e.ClassTable).Include(e => e.DivisionTable).Include(e => e.SessionTable).Include(e => e.UserTable).Include(e=>e.StudentTable);
            return View(examFeelTables.ToList());
        }

        // GET: ExamFeelTables/Details/5
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
            ExamFeelTable examFeelTable = db.ExamFeelTables.Find(id);
            if (examFeelTable == null)
            {
                return HttpNotFound();
            }
            return View(examFeelTable);
        }

        // GET: ExamFeelTables/Create
        public ActionResult Create(int?id)
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
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name");
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name");
            return View();
        }

        // POST: ExamFeelTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExamFeelTable examFeelTable)
        {
            var userid = 0;
            //var userTypeId = 0;
            int.TryParse(Convert.ToString(Session["SID"]), out userid);
            //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var findTeacher = db.UserTables.Where(u => u.Username == username && u.Password == password).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", examFeelTable.Class_ID);
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", examFeelTable.Division_ID);
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name", examFeelTable.Session_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", examFeelTable.User_ID = Convert.ToInt32(Session["ID"]));
            ViewBag.Student_ID = new SelectList(db.StudentTables.Where(s=>s.IsActive==true).ToList(), "ID", "Name", examFeelTable.Student_ID);
            examFeelTable.EditDate = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                db.ExamFeelTables.Add(examFeelTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(examFeelTable);
        }

        // GET: ExamFeelTables/Edit/5
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
            ExamFeelTable examFeelTable = db.ExamFeelTables.Find(id);
            if (examFeelTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", examFeelTable.Class_ID);
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", examFeelTable.Division_ID);
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name", examFeelTable.Session_ID);
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name", examFeelTable.Student_ID);
            return View(examFeelTable);
        }

        // POST: ExamFeelTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExamFeelTable examFeelTable)
        {
            var userid = 0;
            //var userTypeId = 0;
            int.TryParse(Convert.ToString(Session["ID"]), out userid);
            //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var findTeacher = db.UserTables.Where(u => u.Username == username && u.Password == password).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", examFeelTable.Class_ID);
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", examFeelTable.Division_ID);
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name", examFeelTable.Session_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", examFeelTable.User_ID=Convert.ToInt32(Session["ID"]));
            ViewBag.Student_ID = new SelectList(db.StudentTables.Where(s=>s.IsActive==true).ToList(), "ID", "Name", examFeelTable.User_ID);
            examFeelTable.EditDate = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(examFeelTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(examFeelTable);
        }

        // GET: ExamFeelTables/Delete/5
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
            ExamFeelTable examFeelTable = db.ExamFeelTables.Find(id);
            if (examFeelTable == null)
            {
                return HttpNotFound();
            }
            return View(examFeelTable);
        }

        // POST: ExamFeelTables/Delete/5
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
            ExamFeelTable examFeelTable = db.ExamFeelTables.Find(id);
            db.ExamFeelTables.Remove(examFeelTable);
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

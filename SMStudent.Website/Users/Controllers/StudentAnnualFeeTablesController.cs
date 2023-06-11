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
    public class StudentAnnualFeeTablesController : Controller
    {
        private SMStudentContext db = new SMStudentContext();

        // GET: StudentAnnualFeeTables
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
            var studentAnnualFeeTables = db.StudentAnnualFeeTables.Include(s => s.ClassTable).Include(s => s.DivisionTable).Include(s => s.StudentTable).Include(s => s.UserTable);
            return View(studentAnnualFeeTables.ToList());
        }

        // GET: StudentAnnualFeeTables/Details/5
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
            StudentAnnualFeeTable studentAnnualFeeTable = db.StudentAnnualFeeTables.Find(id);
            if (studentAnnualFeeTable == null)
            {
                return HttpNotFound();
            }
            return View(studentAnnualFeeTable);
        }

        // GET: StudentAnnualFeeTables/Create
        public ActionResult Create(int? id)
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
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name");
            return View();
        }

        // POST: StudentAnnualFeeTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentAnnualFeeTable studentAnnualFeeTable)
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
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", studentAnnualFeeTable.Class_ID);
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", studentAnnualFeeTable.Division_ID);
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name", studentAnnualFeeTable.Student_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", studentAnnualFeeTable.User_ID=Convert.ToInt32(Session["ID"]));
            studentAnnualFeeTable.EditDate = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                db.StudentAnnualFeeTables.Add(studentAnnualFeeTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

  
            return View(studentAnnualFeeTable);
        }

        // GET: StudentAnnualFeeTables/Edit/5
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
            StudentAnnualFeeTable studentAnnualFeeTable = db.StudentAnnualFeeTables.Find(id);
            if (studentAnnualFeeTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", studentAnnualFeeTable.Class_ID);
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", studentAnnualFeeTable.Division_ID);
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name", studentAnnualFeeTable.Student_ID);
            return View(studentAnnualFeeTable);
        }

        // POST: StudentAnnualFeeTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentAnnualFeeTable studentAnnualFeeTable)
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
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", studentAnnualFeeTable.Class_ID);
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", studentAnnualFeeTable.Division_ID);
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name", studentAnnualFeeTable.Student_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", studentAnnualFeeTable.User_ID=Convert.ToInt32(Session["ID"]));
            studentAnnualFeeTable.EditDate = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(studentAnnualFeeTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentAnnualFeeTable);
        }

        // GET: StudentAnnualFeeTables/Delete/5
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
            StudentAnnualFeeTable studentAnnualFeeTable = db.StudentAnnualFeeTables.Find(id);
            if (studentAnnualFeeTable == null)
            {
                return HttpNotFound();
            }
            return View(studentAnnualFeeTable);
        }

        // POST: StudentAnnualFeeTables/Delete/5
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
            StudentAnnualFeeTable studentAnnualFeeTable = db.StudentAnnualFeeTables.Find(id);
            db.StudentAnnualFeeTables.Remove(studentAnnualFeeTable);
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

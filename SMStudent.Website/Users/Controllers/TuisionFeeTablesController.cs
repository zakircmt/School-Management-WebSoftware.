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
    public class TuisionFeeTablesController : Controller
    {
        private SMStudentContext db = new SMStudentContext();

        // GET: TuisionFeeTables
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
            var tuisionFeeTables = db.TuisionFeeTables.Include(t => t.ClassTable).Include(t => t.SessionTable).Include(t => t.StudentTable).Include(t => t.UserTable);
            return View(tuisionFeeTables.ToList());
        }

        // GET: TuisionFeeTables/Details/5
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
            TuisionFeeTable tuisionFeeTable = db.TuisionFeeTables.Find(id);
            if (tuisionFeeTable == null)
            {
                return HttpNotFound();
            }
            return View(tuisionFeeTable);
        }

        // GET: TuisionFeeTables/Create
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
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name");
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name");
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName");
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name");
            return View();
        }

        // POST: TuisionFeeTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TuisionFeeTable tuisionFeeTable)
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

            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", tuisionFeeTable.Class_ID);
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name", tuisionFeeTable.Session_ID);
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name", tuisionFeeTable.Student_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", tuisionFeeTable.User_ID=Convert.ToInt32(Session["ID"]));
            tuisionFeeTable.EditDate = System.DateTime.Now;
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", tuisionFeeTable.Division_ID);
            if (ModelState.IsValid)
            {
                db.TuisionFeeTables.Add(tuisionFeeTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tuisionFeeTable);
        }

        // GET: TuisionFeeTables/Edit/5
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
            TuisionFeeTable tuisionFeeTable = db.TuisionFeeTables.Find(id);
            if (tuisionFeeTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", tuisionFeeTable.Class_ID);
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name", tuisionFeeTable.Session_ID);
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name", tuisionFeeTable.Student_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", tuisionFeeTable.User_ID);
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", tuisionFeeTable.Division_ID);
            return View(tuisionFeeTable);
        }

        // POST: TuisionFeeTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TuisionFeeTable tuisionFeeTable)
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

            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", tuisionFeeTable.Class_ID);
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name", tuisionFeeTable.Session_ID);
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name", tuisionFeeTable.Student_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", tuisionFeeTable.User_ID=Convert.ToInt32(Session["ID"]));
            tuisionFeeTable.EditDate = System.DateTime.Now;
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", tuisionFeeTable.Division_ID);
            if (ModelState.IsValid)
            {
                db.Entry(tuisionFeeTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tuisionFeeTable);
        }

        // GET: TuisionFeeTables/Delete/5
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
            TuisionFeeTable tuisionFeeTable = db.TuisionFeeTables.Find(id);
            if (tuisionFeeTable == null)
            {
                return HttpNotFound();
            }
            return View(tuisionFeeTable);
        }

        // POST: TuisionFeeTables/Delete/5
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
            TuisionFeeTable tuisionFeeTable = db.TuisionFeeTables.Find(id);
            db.TuisionFeeTables.Remove(tuisionFeeTable);
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

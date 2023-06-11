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
    public class DivisionTablesController : Controller
    {
        private SMStudentContext db = new SMStudentContext();

        // GET: DivisionTables
        public ActionResult Index(int ? id)
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
            var divisionTables = db.DivisionTables.Include(d => d.TeacherTable).Include(d => d.UserTable);
            return View(divisionTables.ToList());
        }

        // GET: DivisionTables/Details/5
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
            DivisionTable divisionTable = db.DivisionTables.Find(id);
            if (divisionTable == null)
            {
                return HttpNotFound();
            }
            return View(divisionTable);
        }

        // GET: DivisionTables/Create
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
            ViewBag.Teacher_ID = new SelectList(db.TeacherTables, "ID", "ContactNO");
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName");
            return View();
        }

        // POST: DivisionTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DivisionTable divisionTable)
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

            ViewBag.Teacher_ID = new SelectList(db.TeacherTables, "ID", "ContactNO", divisionTable.Teacher_ID=1);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", divisionTable.User_ID=Convert.ToInt32(Session["ID"]));
            divisionTable.EditDate = System.DateTime.Now;

            divisionTable.User_ID = Convert.ToInt32(Session["ID"]);
            divisionTable.Teacher_ID = Convert.ToInt32(Session["ID"]);
            if (ModelState.IsValid)
            {
                db.DivisionTables.Add(divisionTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(divisionTable);
        }

        // GET: DivisionTables/Edit/5
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
            DivisionTable divisionTable = db.DivisionTables.Find(id);
            if (divisionTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.Teacher_ID = new SelectList(db.TeacherTables, "ID", "ContactNO", divisionTable.Teacher_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", divisionTable.User_ID);
            return View(divisionTable);
        }

        // POST: DivisionTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DivisionTable divisionTable)
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

            ViewBag.Teacher_ID = new SelectList(db.TeacherTables, "ID", "ContactNO", divisionTable.Teacher_ID=1);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", divisionTable.User_ID=Convert.ToInt32(Session["ID"]));
            divisionTable.EditDate = System.DateTime.Now;

            divisionTable.User_ID = Convert.ToInt32(Session["ID"]);
            divisionTable.Teacher_ID = Convert.ToInt32(Session["ID"]);
            if (ModelState.IsValid)
            {
                db.Entry(divisionTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(divisionTable);
        }

        // GET: DivisionTables/Delete/5
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
            DivisionTable divisionTable = db.DivisionTables.Find(id);
            if (divisionTable == null)
            {
                return HttpNotFound();
            }
            return View(divisionTable);
        }

        // POST: DivisionTables/Delete/5
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
            DivisionTable divisionTable = db.DivisionTables.Find(id);
            db.DivisionTables.Remove(divisionTable);
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

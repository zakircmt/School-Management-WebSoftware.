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
    public class UserAttendanceTablesController : Controller
    {
        private SMStudentContext db = new SMStudentContext();

        // GET: UserAttendanceTables
        public ActionResult Index(int ? id)
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
            var userAttendanceTables = db.UserAttendanceTables.Include(u => u.UserTable);
            return View(userAttendanceTables.ToList());
        }

        // GET: UserAttendanceTables/Details/5
        public ActionResult Details(int? id)
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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAttendanceTable userAttendanceTable = db.UserAttendanceTables.Find(id);
            if (userAttendanceTable == null)
            {
                return HttpNotFound();
            }
            return View(userAttendanceTable);
        }

        // GET: UserAttendanceTables/Create
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
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName");
            return View();
        }

        // POST: UserAttendanceTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserAttendanceTable userAttendanceTable)
        {
            var adminid = 0;
            var userTypeId = 0;
            int.TryParse(Convert.ToString(Session["ID"]), out adminid);
            int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var findTeacher = db.UserTables.Where(teacher => teacher.Username == username && teacher.Password == password && teacher.ID == adminid).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", userAttendanceTable.User_ID);
            userAttendanceTable.EditDate = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                db.UserAttendanceTables.Add(userAttendanceTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userAttendanceTable);
        }

        // GET: UserAttendanceTables/Edit/5
        public ActionResult Edit(int? id)
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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAttendanceTable userAttendanceTable = db.UserAttendanceTables.Find(id);
            if (userAttendanceTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", userAttendanceTable.User_ID);
            return View(userAttendanceTable);
        }

        // POST: UserAttendanceTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserAttendanceTable userAttendanceTable)
        {
            var adminid = 0;
            var userTypeId = 0;
            int.TryParse(Convert.ToString(Session["ID"]), out adminid);
            int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var findTeacher = db.UserTables.Where(teacher => teacher.Username == username && teacher.Password == password && teacher.ID == adminid).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", userAttendanceTable.User_ID);
            userAttendanceTable.EditDate = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(userAttendanceTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userAttendanceTable);
        }

        // GET: UserAttendanceTables/Delete/5
        public ActionResult Delete(int? id)
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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAttendanceTable userAttendanceTable = db.UserAttendanceTables.Find(id);
            if (userAttendanceTable == null)
            {
                return HttpNotFound();
            }
            return View(userAttendanceTable);
        }

        // POST: UserAttendanceTables/Delete/5
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

            var findTeacher = db.UserTables.Where(teacher => teacher.Username == username && teacher.Password == password && teacher.ID == adminid).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            UserAttendanceTable userAttendanceTable = db.UserAttendanceTables.Find(id);
            db.UserAttendanceTables.Remove(userAttendanceTable);
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

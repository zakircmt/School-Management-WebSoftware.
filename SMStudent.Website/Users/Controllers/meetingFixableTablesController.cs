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
    public class meetingFixableTablesController : Controller
    {
        private SMStudentContext db = new SMStudentContext();

        // GET: meetingFixableTables
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
            var meetingFixableTables = db.meetingFixableTables.Include(m => m.UserTable);
            return View(meetingFixableTables.ToList());
        }

        // GET: meetingFixableTables/Details/5
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
            meetingFixableTable meetingFixableTable = db.meetingFixableTables.Find(id);
            if (meetingFixableTable == null)
            {
                return HttpNotFound();
            }
            return View(meetingFixableTable);
        }

        // GET: meetingFixableTables/Create
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
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName");
            return View();
        }

        // POST: meetingFixableTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(meetingFixableTable meetingFixableTable)
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

            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", meetingFixableTable.User_ID=Convert.ToInt32(Session["ID"]));
            meetingFixableTable.EditTime = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                db.meetingFixableTables.Add(meetingFixableTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meetingFixableTable);
        }

        // GET: meetingFixableTables/Edit/5
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
            meetingFixableTable meetingFixableTable = db.meetingFixableTables.Find(id);

            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", meetingFixableTable.User_ID = Convert.ToInt32(Session["ID"]));
            meetingFixableTable.EditTime = System.DateTime.Now;
            if (meetingFixableTable == null)
            {
                return HttpNotFound();
            }
            return View(meetingFixableTable);
        }

        // POST: meetingFixableTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(meetingFixableTable meetingFixableTable)
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
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", meetingFixableTable.User_ID = Convert.ToInt32(Session["ID"]));
            meetingFixableTable.EditTime = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(meetingFixableTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meetingFixableTable);
        }

        // GET: meetingFixableTables/Delete/5
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
            meetingFixableTable meetingFixableTable = db.meetingFixableTables.Find(id);
            if (meetingFixableTable == null)
            {
                return HttpNotFound();
            }
            return View(meetingFixableTable);
        }

        // POST: meetingFixableTables/Delete/5
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
            meetingFixableTable meetingFixableTable = db.meetingFixableTables.Find(id);
            db.meetingFixableTables.Remove(meetingFixableTable);
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

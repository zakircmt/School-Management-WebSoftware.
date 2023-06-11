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
    public class SessionTablesController : Controller
    {
        private SMStudentContext db = new SMStudentContext();

        // GET: SessionTables
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
            var sessionTables = db.SessionTables.Include(s=>s.UserTable);
            return View(db.SessionTables.ToList().OrderByDescending(x => x.ID));
        }

        // GET: SessionTables/Details/5
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
            SessionTable sessionTable = db.SessionTables.Find(id);
            if (sessionTable == null)
            {
                return HttpNotFound();
            }
            return View(sessionTable);
        }

        // GET: SessionTables/Create
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
            return View();
        }

        // POST: SessionTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SessionTable sessionTable)
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

            sessionTable.User_ID = Convert.ToInt32(Session["ID"]);
            sessionTable.EditDate = System.DateTime.Now;

            if (ModelState.IsValid)
            {
                db.SessionTables.Add(sessionTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sessionTable);
        }

        // GET: SessionTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SessionTable sessionTable = db.SessionTables.Find(id);
            if (sessionTable == null)
            {
                return HttpNotFound();
            }
            return View(sessionTable);
        }

        // POST: SessionTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SessionTable sessionTable)
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

            sessionTable.User_ID = Convert.ToInt32(Session["ID"]);
            sessionTable.EditDate = System.DateTime.Now;


            if (ModelState.IsValid)
            {
                db.Entry(sessionTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sessionTable);
        }

        // GET: SessionTables/Delete/5
        public ActionResult Delete(int? id)
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

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SessionTable sessionTable = db.SessionTables.Find(id);
            if (sessionTable == null)
            {
                return HttpNotFound();
            }
            return View(sessionTable);
        }

        // POST: SessionTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
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

            SessionTable sessionTable = db.SessionTables.Find(id);
            db.SessionTables.Remove(sessionTable);
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

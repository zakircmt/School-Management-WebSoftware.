using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SMStudent.Database;
using SMStudent.Website.Student.Models;

namespace SMStudent.Website.Student.Controllers
{
    public class ApplicationForInstallmentTablesController : Controller
    {
        private SMStudentContext db = new SMStudentContext();

        // GET: ApplicationForInstallmentTables
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
            var applicationForInstallmentTables = db.ApplicationForInstallmentTables.Where(s=>s.Student_ID==studentid).Include(a => a.ClassTable).Include(a => a.DivisionTable).Include(a => a.SessionTable).Include(a => a.StudentTable).Include(a => a.UserTable);
            return View(applicationForInstallmentTables.ToList());
        }

        // GET: ApplicationForInstallmentTables/Details/5
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

            ApplicationForInstallmentTable applicationForInstallmentTable = db.ApplicationForInstallmentTables.Find(id);

            if (applicationForInstallmentTable == null)
            {
                return HttpNotFound();
            }
            return View(applicationForInstallmentTable);
        }

        // GET: ApplicationForInstallmentTables/Create
        public ActionResult Create(int ? id)
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
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name");
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name");
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name");
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name");
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName");
            return View();
        }

        // POST: ApplicationForInstallmentTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ApplicationForInstallmentTable applicationForInstallmentTable)
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
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", applicationForInstallmentTable.Class_ID=Convert.ToInt32(Session["SClass_ID"]));
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", applicationForInstallmentTable.Division_ID= Convert.ToInt32(Session["SDivision_ID"]));
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name", applicationForInstallmentTable.Session_ID = Convert.ToInt32(Session["SSession_ID"]));
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name", applicationForInstallmentTable.Student_ID = Convert.ToInt32(Session["SID"]));
            applicationForInstallmentTable.EditTime = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                db.ApplicationForInstallmentTables.Add(applicationForInstallmentTable);
                db.SaveChanges();

                var id = Convert.ToInt32(Session["SID"]);
                return RedirectToAction("Index",new { id});
            }

         return View(applicationForInstallmentTable);
        }

        // GET: ApplicationForInstallmentTables/Edit/5
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
            ApplicationForInstallmentTable applicationForInstallmentTable = db.ApplicationForInstallmentTables.Find(id);
            if (applicationForInstallmentTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", applicationForInstallmentTable.Class_ID);
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", applicationForInstallmentTable.Division_ID);
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name", applicationForInstallmentTable.Session_ID);
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name", applicationForInstallmentTable.Student_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", applicationForInstallmentTable.User_ID);
            return View(applicationForInstallmentTable);
        }

        // POST: ApplicationForInstallmentTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( ApplicationForInstallmentTable applicationForInstallmentTable)
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
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", applicationForInstallmentTable.Class_ID = Convert.ToInt32(Session["SClass_ID"]));
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", applicationForInstallmentTable.Division_ID = Convert.ToInt32(Session["SDivision_ID"]));
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name", applicationForInstallmentTable.Session_ID = Convert.ToInt32(Session["SSession_ID"]));
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name", applicationForInstallmentTable.Student_ID = Convert.ToInt32(Session["SID"]));
            applicationForInstallmentTable.EditTime = System.DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Entry(applicationForInstallmentTable).State = EntityState.Modified;
                db.SaveChanges();
                var id = Convert.ToInt32(Session["SID"]);
                return RedirectToAction("Index",new { id});
            }
            
                return View(applicationForInstallmentTable);
        }

        // GET: ApplicationForInstallmentTables/Delete/5
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
            ApplicationForInstallmentTable applicationForInstallmentTable = db.ApplicationForInstallmentTables.Find(id);
            if (applicationForInstallmentTable == null)
            {
                return HttpNotFound();
            }
            return View(applicationForInstallmentTable);
        }

        // POST: ApplicationForInstallmentTables/Delete/5
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
            ApplicationForInstallmentTable applicationForInstallmentTable = db.ApplicationForInstallmentTables.Find(studentid);
            db.ApplicationForInstallmentTables.Remove(applicationForInstallmentTable);
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

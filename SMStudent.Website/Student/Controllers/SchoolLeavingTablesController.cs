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
    public class SchoolLeavingTablesController : Controller
    {
        private SMStudentContext db = new SMStudentContext();

        // GET: SchoolLeavingTables
        public ActionResult Index(int? id)
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
            var schoolLeavingTables = db.SchoolLeavingTables.Where(s=>s.Student_ID==studentid).Include(s => s.ClassTable).Include(s => s.StudentTable).Include(s => s.TeacherTable).Include(s => s.UserTable);
            return View(schoolLeavingTables.ToList());
        }

        // GET: SchoolLeavingTables/Details/5
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
            SchoolLeavingTable schoolLeavingTable = db.SchoolLeavingTables.Find(id);
            if (schoolLeavingTable == null)
            {
                return HttpNotFound();
            }
            return View(schoolLeavingTable);
        }

        // GET: SchoolLeavingTables/Create
        public ActionResult Create(int? id)
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
            return View();
        }

        // POST: SchoolLeavingTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SchoolLeavingTable schoolLeavingTable)
        {
            var studentid = Convert.ToInt32(Session["SID"]);
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

            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", schoolLeavingTable.Class_ID);
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name", schoolLeavingTable.Student_ID = Convert.ToInt32(Session["SID"]));
            ViewBag.Teacher_ID = new SelectList(db.TeacherTables, "ID", "ContactNO", schoolLeavingTable.Teacher_ID = 1);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", schoolLeavingTable.User_ID = 1);
            schoolLeavingTable.EditDate = System.DateTime.Now;

            if (ModelState.IsValid)
            {
                db.SchoolLeavingTables.Add(schoolLeavingTable);
                db.SaveChanges();

                var id = Convert.ToInt32(Session["SID"]);
                return RedirectToAction("Index", new {id});
            }

           return View(schoolLeavingTable);
        }

        // GET: SchoolLeavingTables/Edit/5
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
            SchoolLeavingTable schoolLeavingTable = db.SchoolLeavingTables.Find(id);
            if (schoolLeavingTable == null)
            {
                return HttpNotFound();
            }
            return View(schoolLeavingTable);
        }

        // POST: SchoolLeavingTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SchoolLeavingTable schoolLeavingTable)
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
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", schoolLeavingTable.Class_ID = Convert.ToInt32(Session["SClass_ID"]));
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name", schoolLeavingTable.Student_ID = Convert.ToInt32(Session["SID"]));
            ViewBag.Teacher_ID = new SelectList(db.TeacherTables, "ID", "ContactNO", schoolLeavingTable.Teacher_ID=1);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", schoolLeavingTable.User_ID=1);

            if (ModelState.IsValid)
            {
                db.Entry(schoolLeavingTable).State = EntityState.Modified;
                db.SaveChanges();

                var id = Convert.ToInt32(Session["SID"]);
                return RedirectToAction("Index", new { id });
            }
            return View(schoolLeavingTable);
        }

        // GET: SchoolLeavingTables/Delete/5
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
            SchoolLeavingTable schoolLeavingTable = db.SchoolLeavingTables.Find(id);
            if (schoolLeavingTable == null)
            {
                return HttpNotFound();
            }
            return View(schoolLeavingTable);
        }

        // POST: SchoolLeavingTables/Delete/5
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

            var findUser = db.StudentTables.Where(user => user.Username == username && user.Password == password ).FirstOrDefault();

            if (findUser == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            SchoolLeavingTable schoolLeavingTable = db.SchoolLeavingTables.Find(studentid);
            db.SchoolLeavingTables.Remove(schoolLeavingTable);
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

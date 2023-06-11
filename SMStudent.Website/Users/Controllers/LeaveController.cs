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
    public class LeaveController : Controller
    {
        private SMStudentContext db = new SMStudentContext();

        // GET: Leave
        public ActionResult Index(int ID)
        {
            var schoolLeavingTables = db.SchoolLeavingTables.Include(s => s.ClassTable).Include(s => s.StudentTable).Include(s => s.TeacherTable).Include(s => s.UserTable);
            return View(schoolLeavingTables.Where(x=>x.User_ID==ID && x.IsActive==true).ToList());
        }

        // GET: Leave/Details/5
        public ActionResult Details(int? id)
        {
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

        // GET: Leave/Create
        public ActionResult Create()
        {
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name");
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name");
            ViewBag.Teacher_ID = new SelectList(db.TeacherTables, "ID", "ContactNO");
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName");
            return View();
        }

        // POST: Leave/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SchoolLeavingTable schoolLeavingTable)
        {
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", schoolLeavingTable.Class_ID);
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name", schoolLeavingTable.Student_ID);
            ViewBag.Teacher_ID = new SelectList(db.TeacherTables, "ID", "ContactNO", schoolLeavingTable.Teacher_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", schoolLeavingTable.User_ID);
            schoolLeavingTable.User_ID = Convert.ToInt32(Session["ID"]);
            schoolLeavingTable.EditDate = System.DateTime.Now;
            schoolLeavingTable.CreatedDate = System.DateTime.Now;

            if (ModelState.IsValid)
            {
                db.SchoolLeavingTables.Add(schoolLeavingTable);
                db.SaveChanges();
                return RedirectToAction("Index", new { ID = Convert.ToInt32(Session["ID"]) });
            }
            return View(schoolLeavingTable);
        }

        // GET: Leave/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolLeavingTable schoolLeavingTable = db.SchoolLeavingTables.Find(id);
            if (schoolLeavingTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", schoolLeavingTable.Class_ID);
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name", schoolLeavingTable.Student_ID);
            ViewBag.Teacher_ID = new SelectList(db.TeacherTables, "ID", "ContactNO", schoolLeavingTable.Teacher_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", schoolLeavingTable.User_ID);
            return View(schoolLeavingTable);
        }

        // POST: Leave/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SchoolLeavingTable schoolLeavingTable)
        {
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", schoolLeavingTable.Class_ID);
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name", schoolLeavingTable.Student_ID);
            ViewBag.Teacher_ID = new SelectList(db.TeacherTables, "ID", "ContactNO", schoolLeavingTable.Teacher_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", schoolLeavingTable.User_ID);
            schoolLeavingTable.User_ID = Convert.ToInt32(Session["ID"]);
            schoolLeavingTable.EditDate = System.DateTime.Now;
            schoolLeavingTable.CreatedDate = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(schoolLeavingTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index",new { ID=Convert.ToInt32(Session["ID"])});
            }

            return View(schoolLeavingTable);
        }

        // GET: Leave/Delete/5
        public ActionResult Delete(int? id)
        {
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

        // POST: Leave/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SchoolLeavingTable schoolLeavingTable = db.SchoolLeavingTables.Find(id);
            db.SchoolLeavingTables.Remove(schoolLeavingTable);
            db.SaveChanges();
            return RedirectToAction("Index",new { ID = Convert.ToInt32(Session["ID"])});
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

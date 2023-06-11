using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SMStudent.Database;

namespace SMStudent.Website.Teacher.Controllers
{
    public class StudentAttendanceTablesController : Controller
    {
        private SMStudentContext db = new SMStudentContext();

        // GET: StudentAttendanceTables
        public ActionResult Index()
        {
            var studentAttendanceTables = db.StudentAttendanceTables.Include(s => s.ClassTable).Include(s => s.DivisionTable).Include(s => s.SessionTable).Include(s => s.StudentTable).Include(s => s.TeacherTable).Include(s => s.UserTable);
            return View(studentAttendanceTables.ToList());
        }

        // GET: StudentAttendanceTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAttendanceTable studentAttendanceTable = db.StudentAttendanceTables.Find(id);
            if (studentAttendanceTable == null)
            {
                return HttpNotFound();
            }
            return View(studentAttendanceTable);
        }

        // GET: StudentAttendanceTables/Create
        public ActionResult Create()
        {
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name");
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name");
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name");
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name");
            ViewBag.Teacher_ID = new SelectList(db.TeacherTables, "ID", "ContactNO");
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName");
            return View();
        }

        // POST: StudentAttendanceTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Session_ID,Student_ID,Division_ID,Class_ID,AttendDate,AttendTime,EditDate,IsActive,User_ID,Teacher_ID")] StudentAttendanceTable studentAttendanceTable)
        {
            if (ModelState.IsValid)
            {
                db.StudentAttendanceTables.Add(studentAttendanceTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", studentAttendanceTable.Class_ID);
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", studentAttendanceTable.Division_ID);
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name", studentAttendanceTable.Session_ID);
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name", studentAttendanceTable.Student_ID);
            ViewBag.Teacher_ID = new SelectList(db.TeacherTables, "ID", "ContactNO", studentAttendanceTable.Teacher_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", studentAttendanceTable.User_ID);
            return View(studentAttendanceTable);
        }

        // GET: StudentAttendanceTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAttendanceTable studentAttendanceTable = db.StudentAttendanceTables.Find(id);
            if (studentAttendanceTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", studentAttendanceTable.Class_ID);
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", studentAttendanceTable.Division_ID);
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name", studentAttendanceTable.Session_ID);
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name", studentAttendanceTable.Student_ID);
            ViewBag.Teacher_ID = new SelectList(db.TeacherTables, "ID", "ContactNO", studentAttendanceTable.Teacher_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", studentAttendanceTable.User_ID);
            return View(studentAttendanceTable);
        }

        // POST: StudentAttendanceTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Session_ID,Student_ID,Division_ID,Class_ID,AttendDate,AttendTime,EditDate,IsActive,User_ID,Teacher_ID")] StudentAttendanceTable studentAttendanceTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentAttendanceTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", studentAttendanceTable.Class_ID);
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", studentAttendanceTable.Division_ID);
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name", studentAttendanceTable.Session_ID);
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name", studentAttendanceTable.Student_ID);
            ViewBag.Teacher_ID = new SelectList(db.TeacherTables, "ID", "ContactNO", studentAttendanceTable.Teacher_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", studentAttendanceTable.User_ID);
            return View(studentAttendanceTable);
        }

        // GET: StudentAttendanceTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAttendanceTable studentAttendanceTable = db.StudentAttendanceTables.Find(id);
            if (studentAttendanceTable == null)
            {
                return HttpNotFound();
            }
            return View(studentAttendanceTable);
        }

        // POST: StudentAttendanceTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentAttendanceTable studentAttendanceTable = db.StudentAttendanceTables.Find(id);
            db.StudentAttendanceTables.Remove(studentAttendanceTable);
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

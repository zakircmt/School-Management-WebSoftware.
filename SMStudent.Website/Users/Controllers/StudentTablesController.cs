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
    public class StudentTablesController : Controller
    {
        private SMStudentContext db = new SMStudentContext();

        // GET: StudentTables
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
            var studentTables = db.StudentTables.Include(s => s.ClassTable).Include(s => s.DivisionTable).Include(s => s.FatherProfesion).Include(s => s.GenderTable).Include(s => s.Kota).Include(s => s.Nationality).Include(s => s.PostOffice).Include(s => s.ReligiousTable).Include(s => s.SessionTable).Include(s => s.UserTable);
            return View(studentTables.ToList());
        }

        // GET: StudentTables/Details/5
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
            StudentTable studentTable = db.StudentTables.Find(id);
            if (studentTable == null)
            {
                return HttpNotFound();
            }
            return View(studentTable);
        }

        // GET: StudentTables/Create
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
            ViewBag.FatherProffesion_ID = new SelectList(db.FatherProfesions, "ID", "Name");
            ViewBag.Gender_ID = new SelectList(db.GenderTables, "ID", "Name");
            ViewBag.Kota_ID = new SelectList(db.Kotas, "ID", "Name");
            ViewBag.Nationality_ID = new SelectList(db.Nationalities, "ID", "Name");
            ViewBag.PostOffice_ID = new SelectList(db.PostOffices, "ID", "Name");
            ViewBag.Religious_ID = new SelectList(db.ReligiousTables, "ID", "Name");
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name");
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName");
            return View();
        }

        // POST: StudentTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentTable studentTable)
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
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", studentTable.Class_ID);
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", studentTable.Division_ID);
            ViewBag.FatherProffesion_ID = new SelectList(db.FatherProfesions, "ID", "Name", studentTable.FatherProffesion_ID);
            ViewBag.Gender_ID = new SelectList(db.GenderTables, "ID", "Name", studentTable.Gender_ID);
            ViewBag.Kota_ID = new SelectList(db.Kotas, "ID", "Name", studentTable.Kota_ID);
            ViewBag.Nationality_ID = new SelectList(db.Nationalities, "ID", "Name", studentTable.Nationality_ID);
            ViewBag.PostOffice_ID = new SelectList(db.PostOffices, "ID", "Name", studentTable.PostOffice_ID);
            ViewBag.Religious_ID = new SelectList(db.ReligiousTables, "ID", "Name", studentTable.Religious_ID);
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name", studentTable.Session_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", studentTable.User_ID=Convert.ToInt32(Session["ID"]));
            studentTable.EditDate = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                db.StudentTables.Add(studentTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(studentTable);
        }

        // GET: StudentTables/Edit/5
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
            StudentTable studentTable = db.StudentTables.Find(id);
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", studentTable.Class_ID);
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", studentTable.Division_ID);
            ViewBag.FatherProffesion_ID = new SelectList(db.FatherProfesions, "ID", "Name", studentTable.FatherProffesion_ID);
            ViewBag.Gender_ID = new SelectList(db.GenderTables, "ID", "Name", studentTable.Gender_ID);
            ViewBag.Kota_ID = new SelectList(db.Kotas, "ID", "Name", studentTable.Kota_ID);
            ViewBag.Nationality_ID = new SelectList(db.Nationalities, "ID", "Name", studentTable.Nationality_ID);
            ViewBag.PostOffice_ID = new SelectList(db.PostOffices, "ID", "Name", studentTable.PostOffice_ID);
            ViewBag.Religious_ID = new SelectList(db.ReligiousTables, "ID", "Name", studentTable.Religious_ID);
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name", studentTable.Session_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", studentTable.User_ID=Convert.ToInt32(Session["ID"]));
            studentTable.EditDate = System.DateTime.Now;
            if (studentTable == null)
            {
                return HttpNotFound();
            }
           
            return View(studentTable);
        }

        // POST: StudentTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentTable studentTable)
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

            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", studentTable.Class_ID);
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", studentTable.Division_ID);
            ViewBag.FatherProffesion_ID = new SelectList(db.FatherProfesions, "ID", "Name", studentTable.FatherProffesion_ID);
            ViewBag.Gender_ID = new SelectList(db.GenderTables, "ID", "Name", studentTable.Gender_ID);
            ViewBag.Kota_ID = new SelectList(db.Kotas, "ID", "Name", studentTable.Kota_ID);
            ViewBag.Nationality_ID = new SelectList(db.Nationalities, "ID", "Name", studentTable.Nationality_ID);
            ViewBag.PostOffice_ID = new SelectList(db.PostOffices, "ID", "Name", studentTable.PostOffice_ID);
            ViewBag.Religious_ID = new SelectList(db.ReligiousTables, "ID", "Name", studentTable.Religious_ID);
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name", studentTable.Session_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", studentTable.User_ID);
            studentTable.EditDate = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(studentTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentTable);
        }

        // GET: StudentTables/Delete/5
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
            StudentTable studentTable = db.StudentTables.Find(id);
            if (studentTable == null)
            {
                return HttpNotFound();
            }
            return View(studentTable);
        }

        // POST: StudentTables/Delete/5
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
            StudentTable studentTable = db.StudentTables.Find(id);
            db.StudentTables.Remove(studentTable);
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

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
    public class EstablishmentFeelTablesController : Controller
    {
        private SMStudentContext db = new SMStudentContext();

        // GET: EstablishmentFeelTables
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
            var establishmentFeelTables = db.EstablishmentFeelTables.Include(e => e.ClassTable).Include(e => e.DivisionTable).Include(e => e.SessionTable).Include(e => e.UserTable).Include(e=>e.StudentTable);
            return View(establishmentFeelTables.ToList());
        }

        // GET: EstablishmentFeelTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstablishmentFeelTable establishmentFeelTable = db.EstablishmentFeelTables.Find(id);
            if (establishmentFeelTable == null)
            {
                return HttpNotFound();
            }
            return View(establishmentFeelTable);
        }

        // GET: EstablishmentFeelTables/Create
        public ActionResult Create()
        {
            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name");
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name");
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name");
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName");
            ViewBag.Student_ID = new SelectList(db.StudentTables.Where(s=>s.IsActive==true).ToList(),"ID","Name");
            return View();
        }

        // POST: EstablishmentFeelTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EstablishmentFeelTable establishmentFeelTable)
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

            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", establishmentFeelTable.Class_ID);
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", establishmentFeelTable.Division_ID);
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name", establishmentFeelTable.Session_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", establishmentFeelTable.User_ID=Convert.ToInt32(Session["ID"]));
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID","Name", establishmentFeelTable.Student_ID);
            establishmentFeelTable.EditDate = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                db.EstablishmentFeelTables.Add(establishmentFeelTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(establishmentFeelTable);
        }

        // GET: EstablishmentFeelTables/Edit/5
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
            EstablishmentFeelTable establishmentFeelTable = db.EstablishmentFeelTables.Find(id);

            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", establishmentFeelTable.Class_ID);
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", establishmentFeelTable.Division_ID);
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name", establishmentFeelTable.Session_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", establishmentFeelTable.User_ID = Convert.ToInt32(Session["ID"]));
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name", establishmentFeelTable.Student_ID);
            establishmentFeelTable.EditDate = System.DateTime.Now;
            if (establishmentFeelTable == null)
            {
                return HttpNotFound();
            }
            return View(establishmentFeelTable);
        }

        // POST: EstablishmentFeelTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EstablishmentFeelTable establishmentFeelTable)
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

            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", establishmentFeelTable.Class_ID);
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", establishmentFeelTable.Division_ID);
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name", establishmentFeelTable.Session_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", establishmentFeelTable.User_ID = Convert.ToInt32(Session["ID"]));
            ViewBag.Student_ID = new SelectList(db.StudentTables, "ID", "Name", establishmentFeelTable.Student_ID);
            establishmentFeelTable.EditDate = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(establishmentFeelTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(establishmentFeelTable);
        }

        // GET: EstablishmentFeelTables/Delete/5
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
            EstablishmentFeelTable establishmentFeelTable = db.EstablishmentFeelTables.Find(id);
            if (establishmentFeelTable == null)
            {
                return HttpNotFound();
            }
            return View(establishmentFeelTable);
        }

        // POST: EstablishmentFeelTables/Delete/5
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
            EstablishmentFeelTable establishmentFeelTable = db.EstablishmentFeelTables.Find(id);
            db.EstablishmentFeelTables.Remove(establishmentFeelTable);
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

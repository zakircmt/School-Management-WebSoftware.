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
    public class UserTablesController : Controller
    {
        private SMStudentContext db = new SMStudentContext();

        // GET: UserTables
        public ActionResult Index()
        {
            var userTables = db.UserTables.Include(u => u.GenderTable).Include(u => u.Nationality).Include(u => u.PostOffice).Include(u => u.ReligiousTable).Include(u => u.UserTypeTable);
            return View(userTables.ToList());
        }

        // GET: UserTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTable userTable = db.UserTables.Find(id);
            if (userTable == null)
            {
                return HttpNotFound();
            }
            return View(userTable);
        }

        // GET: UserTables/Create
        public ActionResult Create()
        {
            ViewBag.Gender_ID = new SelectList(db.GenderTables, "ID", "Name");
            ViewBag.Nationality_ID = new SelectList(db.Nationalities, "ID", "Name");
            ViewBag.PostOffice_ID = new SelectList(db.PostOffices, "ID", "Name");
            ViewBag.Religious_ID = new SelectList(db.ReligiousTables, "ID", "Name");
            ViewBag.UserType_ID = new SelectList(db.UserTypeTables, "ID", "TypeName");
            return View();
        }

        // POST: UserTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserType_ID,Gender_ID,Nationality_ID,Religious_ID,PostOffice_ID,FullName,Username,Password,Photo,ContactNO,EmailAddress,Address,IsActive,EditDate")] UserTable userTable)
        {
            if (ModelState.IsValid)
            {
                db.UserTables.Add(userTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Gender_ID = new SelectList(db.GenderTables, "ID", "Name", userTable.Gender_ID);
            ViewBag.Nationality_ID = new SelectList(db.Nationalities, "ID", "Name", userTable.Nationality_ID);
            ViewBag.PostOffice_ID = new SelectList(db.PostOffices, "ID", "Name", userTable.PostOffice_ID);
            ViewBag.Religious_ID = new SelectList(db.ReligiousTables, "ID", "Name", userTable.Religious_ID);
            ViewBag.UserType_ID = new SelectList(db.UserTypeTables, "ID", "TypeName", userTable.UserType_ID);
            return View(userTable);
        }

        // GET: UserTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTable userTable = db.UserTables.Find(id);
            if (userTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.Gender_ID = new SelectList(db.GenderTables, "ID", "Name", userTable.Gender_ID);
            ViewBag.Nationality_ID = new SelectList(db.Nationalities, "ID", "Name", userTable.Nationality_ID);
            ViewBag.PostOffice_ID = new SelectList(db.PostOffices, "ID", "Name", userTable.PostOffice_ID);
            ViewBag.Religious_ID = new SelectList(db.ReligiousTables, "ID", "Name", userTable.Religious_ID);
            ViewBag.UserType_ID = new SelectList(db.UserTypeTables, "ID", "TypeName", userTable.UserType_ID);
            return View(userTable);
        }

        // POST: UserTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserType_ID,Gender_ID,Nationality_ID,Religious_ID,PostOffice_ID,FullName,Username,Password,Photo,ContactNO,EmailAddress,Address,IsActive,EditDate")] UserTable userTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Gender_ID = new SelectList(db.GenderTables, "ID", "Name", userTable.Gender_ID);
            ViewBag.Nationality_ID = new SelectList(db.Nationalities, "ID", "Name", userTable.Nationality_ID);
            ViewBag.PostOffice_ID = new SelectList(db.PostOffices, "ID", "Name", userTable.PostOffice_ID);
            ViewBag.Religious_ID = new SelectList(db.ReligiousTables, "ID", "Name", userTable.Religious_ID);
            ViewBag.UserType_ID = new SelectList(db.UserTypeTables, "ID", "TypeName", userTable.UserType_ID);
            return View(userTable);
        }

        // GET: UserTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTable userTable = db.UserTables.Find(id);
            if (userTable == null)
            {
                return HttpNotFound();
            }
            return View(userTable);
        }

        // POST: UserTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserTable userTable = db.UserTables.Find(id);
            db.UserTables.Remove(userTable);
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

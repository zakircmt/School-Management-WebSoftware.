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
    public class ExtraCaricualActiviesTablesController : Controller
    {
        private SMStudentContext db = new SMStudentContext();

        // GET: ExtraCaricualActiviesTables
        public ActionResult Index()
        {
            var extraCaricualActiviesTables = db.ExtraCaricualActiviesTables.Include(e => e.UserTable);
            return View(extraCaricualActiviesTables.ToList());
        }

        // GET: ExtraCaricualActiviesTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExtraCaricualActiviesTable extraCaricualActiviesTable = db.ExtraCaricualActiviesTables.Find(id);
            if (extraCaricualActiviesTable == null)
            {
                return HttpNotFound();
            }
            return View(extraCaricualActiviesTable);
        }

        // GET: ExtraCaricualActiviesTables/Create
        public ActionResult Create()
        {
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName");
            return View();
        }

        // POST: ExtraCaricualActiviesTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,User_ID,Name,StartDate,EndDate,EditDate,IsActive")] ExtraCaricualActiviesTable extraCaricualActiviesTable)
        {
            if (ModelState.IsValid)
            {
                db.ExtraCaricualActiviesTables.Add(extraCaricualActiviesTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", extraCaricualActiviesTable.User_ID);
            return View(extraCaricualActiviesTable);
        }

        // GET: ExtraCaricualActiviesTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExtraCaricualActiviesTable extraCaricualActiviesTable = db.ExtraCaricualActiviesTables.Find(id);
            if (extraCaricualActiviesTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", extraCaricualActiviesTable.User_ID);
            return View(extraCaricualActiviesTable);
        }

        // POST: ExtraCaricualActiviesTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,User_ID,Name,StartDate,EndDate,EditDate,IsActive")] ExtraCaricualActiviesTable extraCaricualActiviesTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(extraCaricualActiviesTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", extraCaricualActiviesTable.User_ID);
            return View(extraCaricualActiviesTable);
        }

        // GET: ExtraCaricualActiviesTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExtraCaricualActiviesTable extraCaricualActiviesTable = db.ExtraCaricualActiviesTables.Find(id);
            if (extraCaricualActiviesTable == null)
            {
                return HttpNotFound();
            }
            return View(extraCaricualActiviesTable);
        }

        // POST: ExtraCaricualActiviesTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExtraCaricualActiviesTable extraCaricualActiviesTable = db.ExtraCaricualActiviesTables.Find(id);
            db.ExtraCaricualActiviesTables.Remove(extraCaricualActiviesTable);
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

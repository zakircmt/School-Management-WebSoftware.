using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SMStudent.Database;

namespace SMStudent.Website.Parents.Controllers
{
    public class ParentsInformationTablesController : Controller
    {
        private SMStudentContext db = new SMStudentContext();

        // GET: ParentsInformationTables
        public ActionResult Index()
        {
            var parentsInformationTables = db.ParentsInformationTables.Include(p => p.FatherProfesion).Include(p => p.GenderTable).Include(p => p.Nationality).Include(p => p.PostOffice).Include(p => p.ReligiousTable).Include(p => p.UserTable);
            return View(parentsInformationTables.ToList());
        }

        // GET: ParentsInformationTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParentsInformationTable parentsInformationTable = db.ParentsInformationTables.Find(id);
            if (parentsInformationTable == null)
            {
                return HttpNotFound();
            }
            return View(parentsInformationTable);
        }

        // GET: ParentsInformationTables/Create
        public ActionResult Create()
        {
            ViewBag.Profession_ID = new SelectList(db.FatherProfesions, "ID", "Name");
            ViewBag.Gender_ID = new SelectList(db.GenderTables, "ID", "Name");
            ViewBag.Nationality_ID = new SelectList(db.Nationalities, "ID", "Name");
            ViewBag.PostOffice_ID = new SelectList(db.PostOffices, "ID", "Name");
            ViewBag.Religious_ID = new SelectList(db.ReligiousTables, "ID", "Name");
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName");
            return View();
        }

        // POST: ParentsInformationTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,User_ID,Profession_ID,Gender_ID,Nationality_ID,Religious_ID,PostOffice_ID,UserName,Password,PhoneNumber,Address,Photo,IsActive,EditTime")] ParentsInformationTable parentsInformationTable)
        {
            if (ModelState.IsValid)
            {
                db.ParentsInformationTables.Add(parentsInformationTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Profession_ID = new SelectList(db.FatherProfesions, "ID", "Name", parentsInformationTable.Profession_ID);
            ViewBag.Gender_ID = new SelectList(db.GenderTables, "ID", "Name", parentsInformationTable.Gender_ID);
            ViewBag.Nationality_ID = new SelectList(db.Nationalities, "ID", "Name", parentsInformationTable.Nationality_ID);
            ViewBag.PostOffice_ID = new SelectList(db.PostOffices, "ID", "Name", parentsInformationTable.PostOffice_ID);
            ViewBag.Religious_ID = new SelectList(db.ReligiousTables, "ID", "Name", parentsInformationTable.Religious_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", parentsInformationTable.User_ID);
            return View(parentsInformationTable);
        }

        // GET: ParentsInformationTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParentsInformationTable parentsInformationTable = db.ParentsInformationTables.Find(id);
            if (parentsInformationTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.Profession_ID = new SelectList(db.FatherProfesions, "ID", "Name", parentsInformationTable.Profession_ID);
            ViewBag.Gender_ID = new SelectList(db.GenderTables, "ID", "Name", parentsInformationTable.Gender_ID);
            ViewBag.Nationality_ID = new SelectList(db.Nationalities, "ID", "Name", parentsInformationTable.Nationality_ID);
            ViewBag.PostOffice_ID = new SelectList(db.PostOffices, "ID", "Name", parentsInformationTable.PostOffice_ID);
            ViewBag.Religious_ID = new SelectList(db.ReligiousTables, "ID", "Name", parentsInformationTable.Religious_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", parentsInformationTable.User_ID);
            return View(parentsInformationTable);
        }

        // POST: ParentsInformationTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,User_ID,Profession_ID,Gender_ID,Nationality_ID,Religious_ID,PostOffice_ID,UserName,Password,PhoneNumber,Address,Photo,IsActive,EditTime")] ParentsInformationTable parentsInformationTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parentsInformationTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Profession_ID = new SelectList(db.FatherProfesions, "ID", "Name", parentsInformationTable.Profession_ID);
            ViewBag.Gender_ID = new SelectList(db.GenderTables, "ID", "Name", parentsInformationTable.Gender_ID);
            ViewBag.Nationality_ID = new SelectList(db.Nationalities, "ID", "Name", parentsInformationTable.Nationality_ID);
            ViewBag.PostOffice_ID = new SelectList(db.PostOffices, "ID", "Name", parentsInformationTable.PostOffice_ID);
            ViewBag.Religious_ID = new SelectList(db.ReligiousTables, "ID", "Name", parentsInformationTable.Religious_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", parentsInformationTable.User_ID);
            return View(parentsInformationTable);
        }

        // GET: ParentsInformationTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParentsInformationTable parentsInformationTable = db.ParentsInformationTables.Find(id);
            if (parentsInformationTable == null)
            {
                return HttpNotFound();
            }
            return View(parentsInformationTable);
        }

        // POST: ParentsInformationTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParentsInformationTable parentsInformationTable = db.ParentsInformationTables.Find(id);
            db.ParentsInformationTables.Remove(parentsInformationTable);
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

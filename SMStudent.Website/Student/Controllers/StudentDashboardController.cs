using SMStudent.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SMStudent.Website.Student.Controllers
{
    public class StudentDashboardController : Controller
    {
        private SMStudentContext db = new SMStudentContext();
        // GET: StudentDashboard
        public ActionResult Index(int? id)
        {
            var studentid = id;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out studentid);
            //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["sUsername"]);
            var password = Convert.ToString(Session["SPassword"]);

            var findUser = db.StudentTables.Where(student => student.Username == username && student.Password == password && student.ID== studentid).FirstOrDefault();

            if (findUser == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            //if (findUser.Username == Convert.ToString(Session["Username"]) && findUser.ID == userid && findUser.UserType_ID == 1)
            //{
            //    return RedirectToAction("Index", "AdminDashboard");
            //}


            //if (findUser.Username == Convert.ToString(Session["Username"]) && findUser.ID == userid && findUser.UserType_ID == 5)
            //{
            //    return RedirectToAction("Index", "ParentDashboard");
            //}


            //if (findUser.Username == Convert.ToString(Session["Username"]) && findUser.ID == userid && findUser.UserType_ID == 3)
            //{
            //    return RedirectToAction("Index", "TeacherDashboard");
            //}


            //if (findUser.Username == Convert.ToString(Session["Username"]) && findUser.ID == userid && findUser.UserType_ID == 2)
            //{
            //    return RedirectToAction("Index", "User" +
            //        "Dashboard");
            //}

            return View();
        }


        // GET: StudentTables/Details/5
        public ActionResult Details(int? id)
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


        // GET: StudentTables/Edit/5
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
            StudentTable studentTable = db.StudentTables.Find(id);
            if (studentTable == null)
            {
                return HttpNotFound();
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
            return View(studentTable);
        }

        // POST: StudentTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentTable studentTable)
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

            ViewBag.Class_ID = new SelectList(db.ClassTables, "ID", "Name", studentTable.Class_ID);
            ViewBag.Division_ID = new SelectList(db.DivisionTables, "ID", "Name", studentTable.Division_ID);
            ViewBag.FatherProffesion_ID = new SelectList(db.FatherProfesions, "ID", "Name", studentTable.FatherProffesion_ID);
            ViewBag.Gender_ID = new SelectList(db.GenderTables, "ID", "Name", studentTable.Gender_ID);
            ViewBag.Kota_ID = new SelectList(db.Kotas, "ID", "Name", studentTable.Kota_ID);
            ViewBag.Nationality_ID = new SelectList(db.Nationalities, "ID", "Name", studentTable.Nationality_ID);
            ViewBag.PostOffice_ID = new SelectList(db.PostOffices, "ID", "Name", studentTable.PostOffice_ID);
            ViewBag.Religious_ID = new SelectList(db.ReligiousTables, "ID", "Name", studentTable.Religious_ID);
            ViewBag.Session_ID = new SelectList(db.SessionTables, "ID", "Name", studentTable.Session_ID);
            ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName", studentTable.User_ID=Convert.ToInt32(Session["SUser_ID"]));
            studentTable.EditDate = System.DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Entry(studentTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(studentTable);
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SMStudent.Database;
using SMStudent.Website.Users.ViewModels;

namespace SMStudent.Website.Users.Controllers
{
    public class TeacherAttendanceTablesController : Controller
    {
        private SMStudentContext db = new SMStudentContext();

        // GET: TeacherAttendanceTables
        public ActionResult Index(int? id)
        {
            var userid = id;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out studentid);
            //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var findTeacher = db.UserTables.Where(u => u.Username == username && u.Password == password).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var teacherAttendanceTables = db.TeacherAttendanceTables.Include(t => t.TeacherTable).OrderByDescending(s=>s.ID);
            return View(teacherAttendanceTables.ToList());
        }
        public ActionResult Absence(int? id)
        {
            var userid = id;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out studentid);
            //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var findTeacher = db.UserTables.Where(u => u.Username == username && u.Password == password).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var teacherAttendanceTables = db.TeacherAttendanceTables.Where(x=>x.AttendDate==null).Include(t => t.TeacherTable).OrderByDescending(s => s.ID);
            return View(teacherAttendanceTables.ToList());
        }


        // GET: TeacherAttendanceTables/Details/5
        public ActionResult Details(int? id)
        {
            var userid = id;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out studentid);
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
            TeacherAttendanceTable teacherAttendanceTable = db.TeacherAttendanceTables.Find(id);
            if (teacherAttendanceTable == null)
            {
                return HttpNotFound();
            }
            return View(teacherAttendanceTable);
        }

        // GET: TeacherAttendanceTables/Create
        public ActionResult Create(int?id)
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
            ViewBag.Teacher_ID = new SelectList(db.TeacherTables, "ID", "Name");
            //ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName");
            return View();
        }

        // POST: TeacherAttendanceTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeacherAttendanceTable teacherAttendanceTable)
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

            ViewBag.Teacher_ID = new SelectList(db.TeacherTables, "ID", "Name", teacherAttendanceTable.Teacher_ID);
            //ViewBag.Teacher_ID = new SelectList(db.Teachers, "ID", "Name", teacherAttendanceTable.Teacher_ID = Convert.ToInt32(Session["ID"]));
            teacherAttendanceTable.User_ID = Convert.ToInt32(Session["ID"]);
            teacherAttendanceTable.EditDate = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                db.TeacherAttendanceTables.Add(teacherAttendanceTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teacherAttendanceTable);
        }

        // GET: TeacherAttendanceTables/Edit/5
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
            TeacherAttendanceTable teacherAttendanceTable = db.TeacherAttendanceTables.Find(id);
            if (teacherAttendanceTable == null)
            {
                return HttpNotFound();
            }
            //ViewBag.Teacher_ID = new SelectList(db.Teachers, "ID", "Name", teacherAttendanceTable.Teacher_ID);
            return View(teacherAttendanceTable);
        }

        // POST: TeacherAttendanceTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, TeacherAttendanceTable teacherAttendanceTable)
        {
            //var userid = 0;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["ID"]), out userid);
            //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var findTeacher = db.UserTables.Where(u => u.Username == username && u.Password == password).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            
            teacherAttendanceTable.User_ID = Convert.ToInt32(Session["ID"]);
            teacherAttendanceTable.EditDate = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(teacherAttendanceTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacherAttendanceTable);
        }

        // GET: TeacherAttendanceTables/Delete/5
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
            TeacherAttendanceTable teacherAttendanceTable = db.TeacherAttendanceTables.Find(id);
            if (teacherAttendanceTable == null)
            {
                return HttpNotFound();
            }
            return View(teacherAttendanceTable);
        }

        // POST: TeacherAttendanceTables/Delete/5
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
            TeacherAttendanceTable teacherAttendanceTable = db.TeacherAttendanceTables.Find(id);
            db.TeacherAttendanceTables.Remove(teacherAttendanceTable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Attendence(int? id)  
        {
            var userid = id;
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var findTeacher = db.UserTables.Where(u => u.Username == username && u.Password == password).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            //var userId = id;
            var findUser = db.UserTables.Find(id);

            if (findUser != null)
            {
                ViewBag.TeacherList = db.TeacherTables.ToList();
                //AttendanceViewModel model = new AttendanceViewModel();
                //model.TeacherList= db.TeacherTables.ToList();

                return View(ViewBag.TeacherList);
            }
            else
            {
                ViewBag.message = "You are not User";
            }
            return View();
        }
        [HttpPost]
        public ActionResult Attendence(int[] markedStudentId, DateTime attendanceDate)
        {
            int[] mark = markedStudentId;
            var checkdate = db.TeacherAttendanceTables.Where(c => c.AttendDate == attendanceDate).FirstOrDefault();
            if (checkdate == null)
            {
                foreach (var id in mark)
                {
                    TeacherAttendanceTable at = new TeacherAttendanceTable();
                    at.Teacher_ID = id;
                    at.AttendDate = attendanceDate;
                    at.User_ID = Convert.ToInt32(Session["ID"]);
                    at.EditDate = System.DateTime.Now;
                    db.TeacherAttendanceTables.Add(at);
                    db.SaveChanges();
                    TempData["message"] = "Attendance marked for " + attendanceDate.ToString("d");
                }
            }
            else
            {
                TempData["message"] = "Sorry Attendance already marked for " + attendanceDate.ToString("d");
            }

            return RedirectToAction("Index");

        }
        //[HttpPost]
        //public ActionResult Index(List<Employee> employees)
        //{
        //    CompanyEntities DbCompany = new CompanyEntities();
        //    foreach (Employee Emp in employees)
        //    {
        //        Employee Existed_Emp = DbCompany.Employees.Find(Emp.ID);
        //        Existed_Emp.Name = Emp.Name;
        //        Existed_Emp.Gender = Emp.Gender;
        //        Existed_Emp.Company = Emp.Company;
        //    }
        //    DbCompany.SaveChanges();
        //    return View();
        //}
        //public ActionResult AttendenceSave(int? id)
        //{
        //    //var userid = id;
        //    //var userTypeId = 0;
        //    //int.TryParse(Convert.ToString(Session["ID"]), out userid);
        //    //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
        //    var username = Convert.ToString(Session["Username"]);
        //    var password = Convert.ToString(Session["Password"]);

        //    var findTeacher = db.UserTables.Where(u => u.Username == username && u.Password == password).FirstOrDefault();

        //    if (findTeacher == null)
        //    {
        //        return RedirectToAction("Login", "Auth");
        //    }

        //    var teacherId = id;
        //    var findUser = db.TeacherTables.Find(teacherId);

        //    if (findUser != null)
        //    {
        //        AttendanceViewModel model = new AttendanceViewModel();

        //        //model.ID = findUser.ID;
        //        //model.User_ID = Convert.ToInt32(Session["ID"]);
        //        //model.Name = findUser.Name;
        //        return View(model);
        //    }
        //    else {
        //        ViewBag.messate = "";
        //    }
        //    return RedirectToAction("Error");
        //}
        //[HttpPost]
        //public ActionResult Attendence(List<AttendanceViewModel> attendanceViewModel)
        //{
        //    //var userid = id;
        //    //var userTypeId = 0;
        //    //int.TryParse(Convert.ToString(Session["ID"]), out userid);
        //    //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
        //    var username = Convert.ToString(Session["Username"]);
        //    var password = Convert.ToString(Session["Password"]);

        //    var findTeacher = db.UserTables.Where(u => u.Username == username && u.Password == password).FirstOrDefault();

        //    if (findTeacher == null)
        //    {
        //        return RedirectToAction("Login", "Auth");
        //    }


        //    //var teacherId = id;
        //    //var findUser = db.TeacherTables.Find(teacherId);



        //    //ViewBag.Teacher_ID = findUser.ID;
        //    //ViewBag.User_ID = new SelectList(db.UserTables, "ID", "FullName",teacherAttendanceTable.User_ID);

        //    foreach (var item in attendanceViewModel)
        //    {
        //        TeacherAttendanceTable teacherAttendanceTable = new TeacherAttendanceTable();

        //        teacherAttendanceTable.User_ID= Convert.ToInt32(Session["ID"]);
        //        teacherAttendanceTable.Teacher_ID = item.Teacher_ID;
        //        teacherAttendanceTable.IsActive = item.IsActive;

        //        //teacherAttendanceTable.Teacher_ID = item.TeacherList.i;
        //        ////item.EditDate = System.DateTime.Now;
        //        ////teacherAttendanceTable.Teacher_ID = findUser.ID;
        //        ////item.User_ID = Convert.ToInt32(Session["ID"]);

        //        db.TeacherAttendanceTables.Add(teacherAttendanceTable);
        //        db.SaveChanges();
        //    }


        //    //teacherAttendanceTable.EditDate = System.DateTime.Now;
        //    ////teacherAttendanceTable.Teacher_ID = findUser.ID;
        //    //teacherAttendanceTable.User_ID = Convert.ToInt32(Session["ID"]);



        //    //if (findUser != null)
        //    //{
        //    //    db.TeacherAttendanceTables.Add(teacherAttendanceTable);
        //    //    db.SaveChanges();

        //    //    var tid = Convert.ToInt32(Session["ID"]);

        //    //    return RedirectToAction("Attendence",new { id=tid});
        //    //}
        //    //else
        //    //{
        //    //    ViewBag.message = "You are not User";
        //    //}
        //    return RedirectToAction("Index");
        //}


        //public ActionResult attendance()
        //{
        //    return View();
        //}

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

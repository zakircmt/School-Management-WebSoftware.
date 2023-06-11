using SMStudent.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMStudent.Website.Admin.Controllers
{
    public class AdminDashboardController : Controller
    {
        private SMStudentContext db = new SMStudentContext();
        // GET: AdminDashboard
        public ActionResult Index(int? id)
        {
            var adminid = id;
            var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out adminid);
            //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var findTeacher = db.UserTables.Where(teacher => teacher.Username == username && teacher.Password == password && teacher.ID == adminid && teacher.UserType_ID==1).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            return View();
        }
    }
}
using SMStudent.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMStudent.Website.Users.Controllers
{
    public class UserDashboardController : Controller
    {
        private SMStudentContext db = new SMStudentContext();
        // GET: UserDashboard
        public ActionResult Index(int? id)
        {

            var userid = id;
            var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out studentid);
            int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["Username"]);
            var password = Convert.ToString(Session["Password"]);

            var findTeacher = db.UserTables.Where(u => u.Username == username && u.Password == password && u.ID == userid && u.UserType_ID== userTypeId).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            return View();
        }
    }
}
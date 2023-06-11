using SMStudent.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMStudent.Website.Parents.Controllers
{
    public class ParentDashboardController : Controller
    {
        private SMStudentContext db = new SMStudentContext();
        // GET: ParentDashboard
        public ActionResult Index(int? id)
        {
            var parentid = id;
            //var userTypeId = 0;
            //int.TryParse(Convert.ToString(Session["SID"]), out studentid);
            //int.TryParse(Convert.ToString(Session["UserType_ID"]), out userTypeId);
            var username = Convert.ToString(Session["PUsername"]);
            var password = Convert.ToString(Session["PPassword"]);

            var findTeacher = db.ParentsInformationTables.Where(p => p.UserName == username && p.Password == password && p.ID==parentid).FirstOrDefault();

            if (findTeacher == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            return View();
        }
    }
}
using SMStudent.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMStudent.Website.Authontication.Controllers
{
    public class AuthController : Controller
    {
        SMStudentContext context = new SMStudentContext();
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {
            var headUser = context.UserTables.Where(h => h.Username == Username && h.Password == Password && h.UserType_ID == 1).FirstOrDefault();
            var userFind = context.UserTables.Where(user => user.Username == Username && user.Password == Password).FirstOrDefault();
            var findStudent = context.StudentTables.Where(s => s.Username == Username && s.Password == Password).FirstOrDefault();

            var findTeacher = context.TeacherTables.Where(t => t.Username == Username && t.Password == Password).FirstOrDefault();

            var findParent = context.ParentsInformationTables.Where(p => p.UserName == Username && p.Password == Password).FirstOrDefault();

            if (userFind!=null || findStudent!=null || findTeacher!=null || findParent!=null || findTeacher==null)
            {
                if (headUser != null)
                {
                    Session["ID"] = userFind.ID;
                    Session["UserType_ID"] = userFind.UserType_ID;
                    Session["GenderName"] = userFind.GenderTable.Name;
                    Session["FullName"] = userFind.FullName;
                    Session["Username"] = userFind.Username;
                    Session["Password"] = userFind.Password;
                    Session["Email"] = userFind.EmailAddress;

                    return RedirectToAction("Index", "AdminDashboard", new { id = Session["ID"] });
                }
                if (userFind!=null)
                {
                    Session["ID"] = userFind.ID;
                    Session["UserType_ID"] = userFind.UserType_ID;
                    Session["GenderName"] = userFind.GenderTable.Name;
                    Session["FullName"] = userFind.FullName;
                    Session["Username"] = userFind.Username;
                    Session["Password"] = userFind.Password;

                    return RedirectToAction("Index", "UserDashboard",new { id=Session["ID"]});
                }
                if (findStudent!=null)
                {
                    Session["SID"] = findStudent.ID;
                    Session["SPassword"] = findStudent.Password;
                    Session["Name"] = findStudent.Name;
                    Session["sUsername"] = findStudent.Username;
                    Session["SSession_ID"] = findStudent.Session_ID;
                    Session["SDivision_ID"] = findStudent.Division_ID;
                    Session["SClass_ID"] = findStudent.Class_ID;
                    Session["skota_ID"] = findStudent.Kota_ID;
                    Session["SGender_ID"] = findStudent.Gender_ID;
                    Session["SNationality_ID"] = findStudent.Nationality_ID;
                    Session["SFatherProffesion_ID"] = findStudent.FatherProffesion_ID;
                    Session["SReligious_ID"] = findStudent.Religious_ID;
                    Session["SPostOffice_ID"] = findStudent.PostOffice_ID;
                    Session["SUser_ID"] = findStudent.User_ID;

                    return RedirectToAction("Index", "StudentDashboard",new { id=Session["SiD"]});
                }


                if (findTeacher!=null)
                {
                    if (findTeacher.IsActive == false)
                    {
                        return RedirectToAction("ErrorPage", "TeacherDashboard");
                    }
                    else { 

                    Session["TID"] = findTeacher.ID;
                    Session["TPassword"] = findTeacher.Password;
                    Session["TName"] = findTeacher.Name;
                    Session["TUsername"] = findTeacher.Username;
                    Session["TUser_ID"] = findTeacher.User_ID;
                    Session["TPostOffice_ID"] =findTeacher.PostOffice_ID;
                    Session["TNationality_ID"] = findTeacher.Nationality_ID;
                    Session["TGender_ID"] = findTeacher.Gender_ID;

                    return RedirectToAction("Index","TeacherDashboard",new { id=Session["TID"]});
                    }
                }
                if (findParent != null)
                {
                    Session["PID"] = findParent.ID;
                    Session["PPassword"] = findParent.Password;
                    Session["PName"] = findParent.Name;
                    Session["PUsername"] = findParent.UserName;
                    Session["PUser_ID"] = findParent.User_ID;
                    Session["PPostOffice_ID"] = findParent.PostOffice_ID;
                    Session["PNationality_ID"] = findParent.Nationality_ID;
                    Session["PGender_ID"] = findParent.Gender_ID;

                    return RedirectToAction("Index", "ParentDashboard",new { id=Session["PID"]});
                }
            }
            else {
               
                ViewBag.message = "Username or Password is incorrect !";
                

            }

            Session["ID"] = string.Empty;
            Session["UserType_ID"] = string.Empty;
            Session["GenderName"] = string.Empty;
            Session["FullName"] = string.Empty;
            Session["Username"] = string.Empty;

            ViewBag.message ="Username or Password is incorrect !";

            return View();
        }

        public ActionResult LogOut()
        {

            Session["ID"] = string.Empty;
            Session["UserType_ID"] = string.Empty;
            Session["GenderName"] = string.Empty;
            Session["FullName"] = string.Empty;
            Session["Username"] = string.Empty;

            return RedirectToAction("Login");
        }

    }
}
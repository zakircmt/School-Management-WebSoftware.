using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMStudent.Database;

namespace SMStudent.Website.Users.ViewModels
{
    public class AttendanceViewModel
    {
        public int ID { get; set; }
        public int Teacher_ID { get; set; }
        public System.DateTime AttendDate { get; set; }
        public string ComingTime { get; set; }
        public string ClosingTime { get; set; }
        public Nullable<System.DateTime> EditDate { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> User_ID { get; set; }
        public List<TeacherAttendanceTable> TeacherAttendance { get; set; }
        public List<TeacherTable> TeacherList { get; set; }
    }
}
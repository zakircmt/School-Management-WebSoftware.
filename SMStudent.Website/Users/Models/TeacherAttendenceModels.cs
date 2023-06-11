using SMStudent.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMStudent.Website.Users.Models
{
    public class TeacherAttendenceModels
    {
        public int ID { get; set; }
        public int Teacher_ID { get; set; }
        public System.DateTime AttendDate { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public string ComingTime { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public string ClosingTime { get; set; }
        public Nullable<System.DateTime> EditDate { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> User_ID { get; set; }

        public virtual TeacherTable Teacher { get; set; }
        public virtual UserTable UserTable { get; set; }
    }
}
﻿using SMStudent.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMStudent.Website.Teacher.Models
{
    public class StudentAttendenceModel
    {
        public int ID { get; set; }
        public int Session_ID { get; set; }
        public int Student_ID { get; set; }
        public int Division_ID { get; set; }
        public int Class_ID { get; set; }
        public System.DateTime AttendDate { get; set; }
        public System.DateTime AttendTime { get; set; }
        public Nullable<System.DateTime> EditDate { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> User_ID { get; set; }
        public Nullable<int> Teacher_ID { get; set; }

        public virtual ClassTable ClassTable { get; set; }
        public virtual DivisionTable DivisionTable { get; set; }
        public virtual SessionTable SessionTable { get; set; }
        public virtual StudentTable StudentTable { get; set; }
        public virtual TeacherTable Teacher { get; set; }
        public virtual UserTable UserTable { get; set; }
    }
}
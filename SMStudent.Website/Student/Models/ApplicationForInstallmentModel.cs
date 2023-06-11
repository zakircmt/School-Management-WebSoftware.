using SMStudent.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMStudent.Website.Student.Models
{
    public class ApplicationForInstallmentModel
    {
        public int ID { get; set; }
        public Nullable<int> User_ID { get; set; }
        public int Student_ID { get; set; }
        public int Class_ID { get; set; }
        public int Session_ID { get; set; }
        public int Division_ID { get; set; }
        public string Description { get; set; }
        public System.DateTime SubmisionDate { get; set; }
        public bool IsActive { get; set; }
        public Nullable<System.DateTime> EditTime { get; set; }

        public virtual ClassTable ClassTable { get; set; }
        public virtual DivisionTable DivisionTable { get; set; }
        public virtual SessionTable SessionTable { get; set; }
        public virtual StudentTable StudentTable { get; set; }
        public virtual UserTable UserTable { get; set; }
    }
}
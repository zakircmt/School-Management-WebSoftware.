using SMStudent.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMStudent.Website.Teacher.Models
{
    public class ExtraCariculamActivitiesModel
    {
        public int ID { get; set; }
        public int User_ID { get; set; }
        public string Name { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public Nullable<System.DateTime> EditDate { get; set; }
        public bool IsActive { get; set; }

        public virtual UserTable UserTable { get; set; }
    }
}
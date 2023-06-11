using SMStudent.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMStudent.Website.Teacher.Models
{
    public class TeacherModel
    {
        public int ID { get; set; }
        public int User_ID { get; set; }
        public int Gender_ID { get; set; }
        public int Nationality_ID { get; set; }
        public int Religious_ID { get; set; }
        public int PostOffice_ID { get; set; }
        public string ContactNO { get; set; }
        public double BasicSalary { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string Qualification { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string HomePhone { get; set; }
        public Nullable<System.DateTime> RegistrationDate { get; set; }
        public Nullable<System.DateTime> EditDate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClassRoutinelTable> ClassRoutinelTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DivisionTable> DivisionTables { get; set; }
        public virtual GenderTable GenderTable { get; set; }
        public virtual Nationality Nationality { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<notificationTable> notificationTables { get; set; }
        public virtual PostOffice PostOffice { get; set; }
        public virtual ReligiousTable ReligiousTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SchoolLeavingTable> SchoolLeavingTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentDailyWorklTable> StudentDailyWorklTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudyTourFeelTable> StudyTourFeelTables { get; set; }
        public virtual UserTable UserTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeacherAttendanceTable> TeacherAttendanceTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeacherFeedbackTable> TeacherFeedbackTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentAttendanceTable> StudentAttendanceTables { get; set; }
    }
}
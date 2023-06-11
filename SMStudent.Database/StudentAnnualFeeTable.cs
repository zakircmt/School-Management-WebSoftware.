//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SMStudent.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudentAnnualFeeTable
    {
        public int ID { get; set; }
        public int User_ID { get; set; }
        public int Student_ID { get; set; }
        public int Class_ID { get; set; }
        public int Division_ID { get; set; }
        public System.DateTime SubmisionDate { get; set; }
        public double AnnualFee { get; set; }
        public bool IsActive { get; set; }
        public bool IsSubmit { get; set; }
        public Nullable<System.DateTime> EditDate { get; set; }
    
        public virtual ClassTable ClassTable { get; set; }
        public virtual DivisionTable DivisionTable { get; set; }
        public virtual StudentTable StudentTable { get; set; }
        public virtual UserTable UserTable { get; set; }
    }
}
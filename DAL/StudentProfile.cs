//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudentProfile
    {
        public int StudentID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Gender { get; set; }
        public string District_Zone { get; set; }
        public string School_Attending { get; set; }
        public Nullable<System.DateTime> Initial_Inquiry_Date { get; set; }
        public Nullable<System.DateTime> Assessment_Date { get; set; }
        public Nullable<System.DateTime> Report_Discussion_Date { get; set; }
        public Nullable<System.DateTime> Tutoring_Start_Date { get; set; }
        public Nullable<System.DateTime> Tutoring_Stop_Date { get; set; }
        public bool Active { get; set; }
        public string InitialNotes { get; set; }
    }
}

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
    
    public partial class StudentCurrentReadingLevel
    {
        public int key { get; set; }
        public Nullable<int> StudentId { get; set; }
        public string Reading_Level { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> Hour_Number { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BackLogInfo
    {
        public int Id { get; set; }
        public string subject { get; set; }
        public bool current_status { get; set; }
    
        public virtual studentInfo studentInfo { get; set; }
    }
}
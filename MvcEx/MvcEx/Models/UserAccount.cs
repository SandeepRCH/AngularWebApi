//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcEx.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserAccount
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string GivenName { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Identifier { get; set; }
        public bool IsActive { get; set; }
    
        public virtual Roles Roles { get; set; }
    }
}

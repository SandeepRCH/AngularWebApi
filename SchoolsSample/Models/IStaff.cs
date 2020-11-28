using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public interface IStaff
    {
        public int SchoolCode { get; set; }
        public string IsSportsStaff { get; set; }
        public bool IsTeaching { get; set; }
        public bool IsActive { get; set; }
    }
}

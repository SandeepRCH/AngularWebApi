using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentApi.Models
{
    public class EducationDetails
    {
        public int Id { get; set; }
        public Nullable<int> YOS { get; set; }
        public Nullable<int> percentage { get; set; }
        public Nullable<int> backlogs { get; set; }
        public string Specialization { get; set; }
        public string College { get; set; }
    }
}
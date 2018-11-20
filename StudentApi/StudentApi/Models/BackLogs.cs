using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentApi.Models
{
    public class BackLogs
    {
        public int Id { get; set; }
        public string subject { get; set; }
        public bool current_status { get; set; }
    }
}
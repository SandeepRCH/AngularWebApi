using System.Collections.Generic;

namespace Gv1WebApi.Models
{
    public class LoanDetails
    {
        public User primaryBorrower { get; set; }
      
        public string LoanStatusDesc { get; set; }
        public string LoanStatusLabel { get; set; }
        public IEnumerable<User> borrowers { get; set; }
        public User Agent { get; set; }
    }
}
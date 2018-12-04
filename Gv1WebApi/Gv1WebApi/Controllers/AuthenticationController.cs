using System.Linq;
using System.Web.Http;
using Gv1WebApi.Models;
using System.Collections.Generic;

namespace Gv1WebApi.Controllers
{/// <summary>
/// based on the role of the currently logged in user 
/// access in restricted to certain methods 
/// using role provided in claims
/// </summary>
    [Authorize(Roles = "admin")]
    public class AuthenticationController : ApiController
    {
        SandeepDBEntities2 _db;
        public AuthenticationController()
        {
            _db = new SandeepDBEntities2();
        }
        [HttpGet]
        public IEnumerable<Loans> GetLoans(int pageNo,int size)
        {
            
            var loans = _db.tblLoan.Select(x => new Loans()
            {
                ActualLoandId = x.ActualLoanId.ToString(),
                primaryBorrower = x.tblUser.Name,
                Address = x.tblUser.Address
            }).OrderByDescending(x => x.ActualLoandId).Skip(pageNo*size).Take(size).ToList();
            return loans;
        }
        [HttpGet]
        public IEnumerable<UserAlerts> GetAlert()
        {
            int userID = User.Identity.UserID();
            var v = _db.tblUserAlert.Where(x => x.tblUserId == userID).Select(y => new UserAlerts()
            {
                Description = y.tblAlert.Description,
                createdAt = y.tblAlert.CreatedAt,
                Subject = y.tblAlert.Subject
            }).ToList();
            return v;
        }
        [HttpGet]
        public IEnumerable<LoanDetails> GetLoanDetails(long loanId)
        {
            var res = _db.tblLoan.Where(m => m.tblLoanId == loanId).Select(n => new LoanDetails()
            {
                primaryBorrower = n.tblUserLoan.Where(o => o.tblUserId == n.PrimaryBorrowerId).Select(p=>new User
                {
                     Name=p.tblUser.Name,
                      Email=p.tblUser.Email,
                       Phone=p.tblUser.Mobile,
                }).FirstOrDefault(),
                LoanStatusDesc = n.tblLoanStatus.Description,
                LoanStatusLabel = n.tblLoanStatus.Lable,
                borrowers = n.tblUserLoan.Where(x => x.tblRole.Name != "agent").SelectMany(y => n.tblUserLoan.Select(v=>new User()
                {
                    Name = y.tblUser.Name,
                    Email = y.tblUser.Email,
                    Phone = y.tblUser.Mobile
                })).ToList().Distinct(),
                Agent = n.tblUserLoan.Where(m => m.tblRole.Name == "agent").Select(z => new User
                {
                    Name = z.tblUser.Name,
                    Email = z.tblUser.Email,
                     Phone = z.tblUser.Mobile
                }).FirstOrDefault(),
                
            }).ToList();
            return res;
        }
        [HttpGet]
        public Settings GetSettings()
        {
            int userID=User.Identity.UserID();
            Settings set = new Settings();
            tblSetting setting = _db.tblSetting.First(x => x.tblUserId == userID);
            set.isAlertsEnabled = setting.IsAlertsEnabled;
            set.isallSettingsEnabled = setting.IsAllSettingsEnabled;
            set.isPushNotificationsEnabled = setting.IsPushNotificationsEnabled;
            return set;
        }
    }
}
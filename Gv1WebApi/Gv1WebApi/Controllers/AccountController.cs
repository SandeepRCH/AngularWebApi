using System.Linq;
using System.Web.Http;
using Gv1WebApi.Models;
using System.Collections.Generic;

namespace Gv1WebApi.Controllers
{
    public class AccountController : ApiController
    {
        [HttpPost]
        public string UserValidation(Validation validate)
        {
            using (SandeepDBEntities db = new SandeepDBEntities())
            {
                string reqPassword = db.tblUser.First(x => x.Name == validate.userName).Password;
                if (reqPassword == validate.password)
                {
                    return "Valid User";
                }
                return "Not a Valid User";
            }
        }
        [HttpGet]
        public IEnumerable<Loans> GetLoans()
        {
            using (SandeepDBEntities db = new SandeepDBEntities())
            {
                List<Loans> loans = new List<Loans>();
                var k = db.tblLoan.Select(x => new Loans()
                {
                    ActualLoandId = x.ActualLoanID,
                    primaryBorrower = db.tblUser.First(y => y.tblUserID == x.PrimaryBorrowerID).Name,
                    Address = db.tblUser.First(y => y.tblUserID == x.PrimaryBorrowerID).Address
                }).ToList();
                return k;
            }
        }
        [HttpGet]
        public IEnumerable<UserAlerts> GetAlert(long userID)
        {
            using (SandeepDBEntities db = new SandeepDBEntities())
            {
                List<UserAlerts> alerts = new List<UserAlerts>();
                UserAlerts userAlert = new UserAlerts();
                var v = db.tblUserAlert.Where(x => x.tblUserID == userID).Select(y => new UserAlerts()
                {
                    Description = y.tblAlerts.Description,
                    createdAt = y.tblAlerts.CreatedAt,
                    Subject = y.tblAlerts.Subject
                }).ToList();
                return v;
            }
        }
        [HttpGet]
        public LoanDetails GetLoanDetails(long loanId)
        {
            using (SandeepDBEntities db = new SandeepDBEntities())
            {
                User user = new User();
                LoanDetails details = new LoanDetails();
                List<User> list = new List<User>();
                tblLoan loan = db.tblLoan.First(x => x.tblLoanID == loanId);
                long primaryId = loan.PrimaryBorrowerID;
                int statusId = loan.tblLoanStatusID;
                tblLoanStatus status = db.tblLoanStatus.First(x => x.tblLoanStatusID == statusId);
                details.LoanStatusLabel = status.Label;
                details.LoanStatusDesc = status.Description;
                details.primaryBorrower = db.tblUser.First(x => x.tblUserID == primaryId).Name;
                foreach (var v in db.tblUserLoan)
                {
                    if (loanId == v.tblLoanID)
                    {
                        tblUser userAccount = db.tblUser.First(x => x.tblUserID == v.tblUserID);
                        if ("Agent" == db.tblRole.First(x => x.tblRoleID == v.tblRoleID).Name)
                        {
                            details.Agent = userAccount;
                        }
                        else
                        {
                            user.Email = userAccount.Email;
                            user.Name = userAccount.Name;
                            user.Phone = userAccount.Mobile;
                            list.Add(user);
                        }
                    }
                }
                details.borrowers = list;
                return details;
            }
        }
        [HttpGet]
        public Settings GetSettings(long userID)
        {
            using (SandeepDBEntities db = new SandeepDBEntities())
            {
                Settings set = new Settings();
                tblSetting setting = db.tblSetting.First(x => x.tblUserID == userID);
                set.isAlertsEnabled = setting.IsAlertsEnabled;
                set.isallSettingsEnabled = setting.IsAllSettingsEnabled;
                set.isPushNotificationsEnabled = setting.IsPushNotificationsEnabled;
                return set;
            }
        }
    }
}
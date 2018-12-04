using System.Web.Mvc;
using System.Security.Claims;
using Microsoft.Owin.Security;
using System.Web;
using MvcEx.Models;
using System.Linq;
using System.Web.Security;

namespace MvcEx.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SignIn(string type = "")
        {
            if (!Request.IsAuthenticated)
            {
                if (type == "Google")
                {
                    HttpContext.GetOwinContext().Authentication.Challenge(new AuthenticationProperties
                    {
                        RedirectUri = "Account/GoogleLoginCallback"
                    }, "Google");
                }
            }
            return View();
        }
        public ActionResult GoogleLoginCallback()
        {
            var claimsPrincipal = HttpContext.User.Identity as ClaimsIdentity;
            var loginInfo = GoogleLoginViewModel.GetLoginInfo(claimsPrincipal);
            if (loginInfo == null)
            {
                return View("SignIn");
            }
            SandeepDBEntities db = new SandeepDBEntities();
            var user = db.UserAccount.FirstOrDefault(x => x.Email == loginInfo.emailaddress);
            if (user == null)
            {
                user = new UserAccount
                {
                    Email = loginInfo.emailaddress,
                    GivenName = loginInfo.givenname,
                    Identifier = loginInfo.nameidentifier,
                    Name = loginInfo.name,
                    SurName = loginInfo.surname,
                    IsActive = true
                };
                var roleInsert = new Models.Roles
                {
                    Id = user.Id,
                    RoleName = "user"
                };
                db.UserAccount.Add(user);
                db.Roles.Add(roleInsert);
                db.SaveChanges();
            }
            
            Response.Cookies["Cookie"]["RoleName"] = db.Roles.FirstOrDefault(x => x.Id == user.Id).RoleName;
            string str = Response.Cookies["Cookie"]["RoleName"];
            return Redirect("signin");
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Products()
        {
            if (Request.Cookies["Cookie"]["RoleName"] == "admin")
            {
                return View("Products");
            }
            return View("error");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("index", "main");
        }
    }
}
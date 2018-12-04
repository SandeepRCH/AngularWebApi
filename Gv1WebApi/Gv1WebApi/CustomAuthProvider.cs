using Gv1WebApi.Models;
using Microsoft.Owin.Security.OAuth;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Gv1WebApi
{
    public class CustomAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            var _db = new SandeepDBEntities2();
            tblUser user = _db.tblUser.FirstOrDefault(m => m.Name == context.UserName);
            if (user.Name == context.UserName && user.Password == context.Password)
            {
                long userID = user.tblUserId;
                long roleID = user.tblUserLoan.FirstOrDefault(x => x.tblUserId == user.tblUserId).tblRoleId;
                string userRole = _db.tblRole.First(x => x.tblRoleId == user.roleId).Name;
                identity.AddClaim(new Claim("UserID", userID.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Role, userRole));
                context.Validated(identity);
            }
            else
            {
                context.SetError("Message", "invalid credentials");
            }
        }
    }
}
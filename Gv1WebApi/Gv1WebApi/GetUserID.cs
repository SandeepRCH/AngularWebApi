using System;
using System.Security.Claims;
using System.Security.Principal;

namespace Gv1WebApi
{
    public static class GetUserID
    {
        public static int UserID(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("UserID");
            return (claim != null) ? Convert.ToInt32(claim.Value) : 0;
        }
    }
}
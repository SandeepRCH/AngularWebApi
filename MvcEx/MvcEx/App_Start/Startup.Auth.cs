using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;

namespace MvcEx
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                LoginPath = new PathString("/Account/Index"),
                SlidingExpiration = true,
            });
         
            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "1009201390722-88dt162r8f3qks4s98sfhtq8gjq4hq9d.apps.googleusercontent.com",
                ClientSecret = "tq49Fp9NGiqdqvk5OrjdJBYF",
                CallbackPath = new PathString("/GoogleLoginCallback")
            });
        }
    }
}
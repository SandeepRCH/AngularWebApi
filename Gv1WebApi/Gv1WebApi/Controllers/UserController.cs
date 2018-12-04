using System.Web.Http;

namespace Gv1WebApi.Controllers
{
    public class UserController : ApiController
    {
        [Authorize(Roles ="user")]
        public string get()
        {
            return "user";
        }
    }
}

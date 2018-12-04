using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Gv1WebApi.Controllers
{
    public class AdminController : ApiController
    {
        [Authorize(Roles ="admin")]
        public string get()
        {
            return "admin";
        }
    }
}

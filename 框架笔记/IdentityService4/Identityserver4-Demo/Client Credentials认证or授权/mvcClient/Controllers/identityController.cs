using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace mvcClient.Controllers
{
    [Route("identity")]
    [Authorize]
    public class identityController : Controller
    {
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }

    }
}

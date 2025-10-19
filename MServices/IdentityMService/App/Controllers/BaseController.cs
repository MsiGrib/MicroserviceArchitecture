using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Net;

namespace IdentityMService.Controllers
{
    [Controller]
    public class BaseController : ControllerBase
    {
        public ActionResult InternalServerError()
            => StatusCode((int)HttpStatusCode.InternalServerError);

        public ActionResult InternalServerError([ActionResultObjectValue] object? value)
            => StatusCode((int)HttpStatusCode.InternalServerError, value);
    }
}
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizationController : ControllerBase
    {
        public AuthorizationController() { }

        [HttpPost("sign-in")]
        public async Task<ActionResult> SignInAsync()
        {

        }

        [HttpPost("sign-up")]
        public async Task<ActionResult> SignUpAsync()
        {

        }
    }
}
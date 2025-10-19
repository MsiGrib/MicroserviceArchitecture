using Business.Services.Interfaces;
using DataModel.Models.Services.Users.Inputs;
using IdentityMService.Validators;
using Microsoft.AspNetCore.Mvc;

namespace IdentityMService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizationController : BaseController
    {
        private readonly IUserService _userService;

        public AuthorizationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("sign-in")]
        public async Task<ActionResult> SignInAsync()
        {
            return Ok();
        }

        [HttpPost("sign-up")]
        public async Task<ActionResult> SignUpAsync([FromBody] UserInput input)
        {
            var validResult = AuthorizationValidator.SignUpAsync(input);
            if (!validResult.IsValid)
                return BadRequest(new { Errors = validResult.Errors! });
            if (await _userService.ExistUserAsync(input.Email))
                return BadRequest(new { Errors = "This user already exists" });

            var success = await _userService.RegistrationUserAsync(input);
            if (!success)
                return InternalServerError(new { Errors = "An error occurred on the server" });

            return Ok();
        }
    }
}
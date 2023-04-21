using Microsoft.AspNetCore.Mvc;
using Navyblue.StoreLab.User.Presentation.Requests;
using Navyblue.StoreLab.User.Presentation.Responses;

namespace Navyblue.StoreLab.User.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthorizationController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            AuthenticateResponse? response = this._userService.Authenticate(model);

            if (response == null)
                return this.BadRequest(new { message = "Username or password is incorrect" });

            return this.Ok(response);
        }
    }
}

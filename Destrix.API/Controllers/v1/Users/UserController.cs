using Destrix.API.Controllers.v1.Base;
using Destrix.Application.Interfaces.Services;
using Destrix.DTO.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Destrix.API.Controllers.v1.Users
{

    [ApiVersion("1", Deprecated =  false)]
    [Route("v{version:apiVersion}/users")]
    [ApiController]
    [Authorize]
    public class UserController : BaseController
    {
        public IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("current-user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Extract()
        {
            try
            {
                var userId = HttpContext.User.Identity.Name;
                var user = await _userService.GetUserByEmail(userId);

                return Ok(new ResultResponseModel() { Result = user });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultResponseModel() { Error = true, ErrorMessages = new string[] { ex.Message } });
            }
        }
    }
}

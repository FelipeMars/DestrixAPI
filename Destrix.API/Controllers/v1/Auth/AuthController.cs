using Destrix.API.Controllers.v1.Base;
using Destrix.Application.Interfaces.Services;
using Destrix.DTO.Request.Auth;
using Destrix.DTO.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Destrix.API.Controllers.v1.Auth
{
    [ApiVersion("1", Deprecated = false)]
    [Route("v{version:apiVersion}/auth")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) 
        {
            _authService = authService;
        }

        [HttpPost("sign-in")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(SignInRequest signInRequest)
        {
            try
            {
                var user = await _authService.SignIn(signInRequest);

                if (user is null)
                    return NotFound(new ResultResponseModel() { NotFound = true });

                return Ok(new ResultResponseModel() { Result = user });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultResponseModel() { Error = true, ErrorMessages = new string[] { ex.Message } });
            }
        }

        [HttpPost("sign-on")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [AllowAnonymous]
        public async Task<IActionResult> SignOn(SignOnRequest signOnRequest)
        {
            try
            {
                var user = await _authService.SignOn(signOnRequest);

                return Created(new ResultResponseModel () { Result = user });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultResponseModel() { Error = true, ErrorMessages = new string[] { ex.Message } });
            }
        }
    }
}

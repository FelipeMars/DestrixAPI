using Destrix.API.Controllers.v1.Base;
using Destrix.Application.Interfaces.Services;
using Destrix.DTO.Request.User;
using Destrix.DTO.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Destrix.API.Controllers.v1.Users
{
    [ApiVersion("1", Deprecated = false)]
    [Route("v{version:apiVersion}/categories")]
    [ApiController]
    [Authorize]
    public class CategoriesController : BaseController
    {
        public IUserService _userService;

        public CategoriesController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var categories = await _userService.GetCategories();

                return Ok(new ResultResponseModel() { Result = categories });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultResponseModel() { Error = true, ErrorMessages = new string[] { ex.Message } });
            }
        }

        [HttpGet("{categoryId:required}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetCategory(int categoryId)
        {
            try
            {
                var category = await _userService.GetCategory(categoryId);
                
                return Ok(new ResultResponseModel() { Result = category });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultResponseModel() { Error = true, ErrorMessages = new string[] { ex.Message } });
            }
        }

        [HttpGet("{categoryId:required}/details")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetCategoryDetails(int categoryId)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultResponseModel() { Error = true, ErrorMessages = new string[] { ex.Message } });
            }
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateCategory(UserCategoryRequest userCategoryRequest)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultResponseModel() { Error = true, ErrorMessages = new string[] { ex.Message } });
            }
        }

        [HttpPut("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateCategory(UserCategoryRequest userCategoryRequest)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultResponseModel() { Error = true, ErrorMessages = new string[] { ex.Message } });
            }
        }
    }
}

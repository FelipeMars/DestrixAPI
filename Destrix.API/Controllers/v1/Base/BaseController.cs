using Destrix.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace Destrix.API.Controllers.v1.Base
{
    public abstract class BaseController : ControllerBase
    {

        public BaseController() { }

        protected IActionResult Created(ResultResponseModel resultModel)
        {
            return StatusCode(StatusCodes.Status201Created, resultModel);
        }
    }
}

using Destrix.Application.Interfaces.Services;
using Destrix.DTO.Response.User;
using Microsoft.AspNetCore.Http;

namespace Destrix.Application.Services
{
    public class BaseService : IBaseService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;

        public BaseService(IHttpContextAccessor httpContextAccessor, IUserService userService) 
        {
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        public async Task<UserResponse> GetCurrentUser()
        {
            var identity = _httpContextAccessor.HttpContext.User.Identity;

            if (identity is null)
                throw new Exception("UserId not foun");

            var user = await _userService.GetUserByEmail(identity.Name);

            if (user == null)
                throw new Exception("User not found");

            var userDTO = new UserResponse(user.Id, user.Name, user.Email);

            return userDTO;
        }
    }
}

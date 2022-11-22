using Destrix.DTO.Response.User;

namespace Destrix.Application.Interfaces.Services
{
    public interface IBaseService
    {
        Task<UserResponse> GetCurrentUser();
    }
}

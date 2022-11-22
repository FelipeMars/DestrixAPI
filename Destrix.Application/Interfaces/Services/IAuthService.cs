using Destrix.DTO.Request.Auth;
using Destrix.DTO.Response.Auth;

namespace Destrix.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<SignInResponse> SignIn(SignInRequest signInRequest);
        Task<SignOnResponse> SignOn(SignOnRequest signOnRequest);
    }
}

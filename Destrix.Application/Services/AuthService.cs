using Destrix.Application.Interfaces.Services;
using Destrix.Core.Helpers;
using Destrix.Domain.Entities.User;
using Destrix.Domain.Interfaces.Repositories.User;
using Destrix.DTO.Geral;
using Destrix.DTO.Request.Auth;
using Destrix.DTO.Response.Auth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Destrix.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<SignInResponse> SignIn(SignInRequest signInRequest)
        {
            var user = await _userRepository.GetByAsync(u => u.Email.Equals(signInRequest.UserId));

            if (user is null)
                return null;

            signInRequest.UserSecret = Cryptography.EncryptString(signInRequest.UserSecret);

            if (!user.Password.Equals(signInRequest.UserSecret))
                throw new Exception("UserId and UserSecret not match");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Constants.JwtKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email)
                }),
                Expires = signInRequest.KeepConnected ?
                                        DateTime.UtcNow.AddYears(10) : 
                                        DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new SignInResponse() {  UserName = user.Name, UserId = user.Email, Token = tokenHandler.WriteToken(token) };
        }

        public async Task<SignOnResponse> SignOn(SignOnRequest signOnRequest)
        {
            if (await _userRepository.ExistsAsync(u => u.Active == true && u.Email.Equals(signOnRequest.Email)))
                throw new Exception("E-mail already registered");

            var user = new User(signOnRequest);

            _userRepository.Add(user);
            await _userRepository.Commit();

            return new SignOnResponse(user.Id, user.Name, user.Email);
        }
    }
}

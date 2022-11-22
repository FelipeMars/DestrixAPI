using Destrix.Application.Interfaces.Services;
using Destrix.Domain.Entities.User;
using Destrix.Domain.Interfaces.Repositories.User;
using Destrix.DTO.Response.User;

namespace Destrix.Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse> GetUserByEmail(string email)
        {
            var user = await _userRepository.GetByAsync(u => u.Email.Equals(email));

            if (user == null)
                throw new Exception("User not found");

            var userDTO = new UserResponse(user.Id, user.Name, user.Email);

            return userDTO;
        }

        public Task<User> GetCurrentUser()
        {
            throw new NotImplementedException();
        }
    }
}

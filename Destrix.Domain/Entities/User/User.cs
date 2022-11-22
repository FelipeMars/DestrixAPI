using Destrix.DTO.Geral;
using Destrix.DTO.Request.Auth;

namespace Destrix.Domain.Entities.User
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User() { }

        public User(SignOnRequest signOnRequest)
        {
            // Create new user - Sign On
            Active = true;
            Name = signOnRequest.Name;
            Email = signOnRequest.Email;
            Password = Cryptography.EncryptString(signOnRequest.Password);
        }
    }
}

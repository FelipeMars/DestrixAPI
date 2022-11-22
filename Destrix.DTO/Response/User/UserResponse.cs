namespace Destrix.DTO.Response.User
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public UserResponse()
        { }

        public UserResponse(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }
}

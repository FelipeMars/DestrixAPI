namespace Destrix.DTO.Response.Auth
{
    public class SignOnResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public SignOnResponse() { }

        public SignOnResponse(int id, string name, string email) 
        { 
            Id = id;
            Name = name;
            Email = email;
        }
    }
}

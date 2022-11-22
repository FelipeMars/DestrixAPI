namespace Destrix.Domain.Entities.User
{
    public class UserCategory : Entity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

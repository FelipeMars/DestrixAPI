namespace Destrix.DTO.Request.User
{
    public class UserCategoryRequest
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

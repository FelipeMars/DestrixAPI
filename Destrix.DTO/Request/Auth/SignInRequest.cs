namespace Destrix.DTO.Request.Auth
{
    public class SignInRequest
    {
        public string UserId { get; set; }
        public string UserSecret { get; set; }
        public bool KeepConnected { get; set; }
    }
}

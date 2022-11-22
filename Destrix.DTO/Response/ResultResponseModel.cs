namespace Destrix.DTO.Response
{
    public class ResultResponseModel
    {
        public dynamic? Result { get; set; }
        public IEnumerable<string>? ErrorMessages { get; set; }
        public bool NotFound { get; set; }
        public bool Error { get; set; }
    }
}

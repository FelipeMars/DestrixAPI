namespace Destrix.DTO.Response.Transaction
{
    public class LastMonthsResponse
    {
        public List<string> Labels { get; set; } = new List<string>();
        public List<decimal> Values { get; set; } = new List<decimal>();
    }
}

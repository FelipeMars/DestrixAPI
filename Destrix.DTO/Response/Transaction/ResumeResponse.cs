namespace Destrix.DTO.Response.Transaction
{
    public class ResumeResponse
    {
        public decimal TotalAmount { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }

        public ResumeResponse() { }

        public ResumeResponse(decimal totalAmount, decimal totalIncome, decimal totalExpense)
        {
            TotalAmount = totalAmount;
            TotalIncome = totalIncome;
            TotalExpense = totalExpense;
        }
    }
}

using Destrix.Core.Enums.Transaction;

namespace Destrix.DTO.Response.Transaction
{
    public class TransactionResponse
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? ChangedAt { get; set; }
        public Guid TransactionReference { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? Description { get; set; }

        public TransactionResponse() { }

        public TransactionResponse(dynamic transaction)
        {
            CreatedAt = transaction.CreatedAt;
            ChangedAt = transaction.ChangedAt;
            TransactionReference = transaction.TransactionReference;
            Amount = transaction.Amount;
            TransactionType = transaction.TransactionType;
            TransactionDate = transaction.TransactionDate;
            Description = transaction.Description;
        }
    }
}

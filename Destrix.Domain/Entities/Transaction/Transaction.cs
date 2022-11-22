using Destrix.Core.Enums.Transaction;
using Destrix.DTO.Request.Transaction;

namespace Destrix.Domain.Entities.Transaction
{
    public class Transaction : Entity
    {
        public int UserId { get; set; }
        public Guid TransactionReference { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? Description { get; set; }
        public List<TransactionCategory> Categories { get; set; }

        public void Update(TransactionRequest transactionRequest)
        {
            ChangedAt = DateTime.Now;
            Amount = transactionRequest.Amount;
            TransactionDate = transactionRequest.TransactionDate;
            Amount = transactionRequest.Amount;
            TransactionType = transactionRequest.TransactionType;
            Description = transactionRequest.Description;
        }

        public Transaction() { }

        public Transaction(TransactionRequest transactionRequest, int userId)
        {
            UserId = userId;
            TransactionReference = Guid.NewGuid();
            Amount = transactionRequest.Amount;
            TransactionType = transactionRequest.TransactionType;
            TransactionDate = transactionRequest.TransactionDate;
            Description = transactionRequest.Description;
        }
    }
}

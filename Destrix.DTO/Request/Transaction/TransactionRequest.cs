using Destrix.Core.Enums.Transaction;
using Destrix.DTO.Request.User;

namespace Destrix.DTO.Request.Transaction
{
    public class TransactionRequest
    {
        public Guid? TransactionReference { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? Description { get; set; }
        public UserCategoryRequest Categories { get; set; }
    }
}

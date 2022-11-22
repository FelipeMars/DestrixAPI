namespace Destrix.Domain.Entities.Transaction
{
    public class TransactionCategory
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public int UserCategoryId { get; set; }
        public Transaction Transaction { get; set; }

        public TransactionCategory() { }
    }
}

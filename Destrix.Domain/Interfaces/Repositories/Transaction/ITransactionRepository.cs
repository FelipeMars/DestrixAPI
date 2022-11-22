using Destrix.Domain.Interfaces.Repositories.Base;
using TransactionModel = Destrix.Domain.Entities.Transaction.Transaction;

namespace Destrix.Domain.Interfaces.Repositories.Transaction
{
    public interface ITransactionRepository : IBaseRepository<TransactionModel>
    {
        Task<IEnumerable<TransactionModel>> GetByDate(DateTime date, int userId);
        Task<decimal> GetTotalIncomeByDate(int year, int month, int userId);
        Task<decimal> GetTotalExpenseByDate(int year, int month, int userId);
        Task<decimal> GetTotalIncome(int userId);
        Task<decimal> GetTotalExpense(int userId);
    }
}

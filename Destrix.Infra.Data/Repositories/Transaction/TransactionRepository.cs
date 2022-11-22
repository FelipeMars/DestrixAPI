using Destrix.Core.Enums.Transaction;
using Destrix.Domain.Interfaces.Repositories.Transaction;
using Destrix.Infra.Data.Contexts;
using Destrix.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using TransactionModel = Destrix.Domain.Entities.Transaction.Transaction;

namespace Destrix.Infra.Data.Repositories.Transaction
{
    public class TransactionRepository : BaseRepository<TransactionModel>, ITransactionRepository
    {
        public TransactionRepository(DestrixPostgreContext context) 
            : base(context)
        { }

        public async Task<IEnumerable<TransactionModel>> GetByDate(DateTime date, int userId)
        {
            return await _db
                .Where(t => t.TransactionDate >= date && t.Active == true && t.UserId.Equals(userId))
                .OrderByDescending(t => t.TransactionDate)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalIncomeByDate(int year, int month, int userId)
        {
            return await _db
                .Where(t => t.UserId.Equals(userId) && t.TransactionType == TransactionType.Income && t.TransactionDate.Year == year && t.TransactionDate.Month == month)
                .SumAsync(t => t.Amount);
        }

        public async Task<decimal> GetTotalExpenseByDate(int year, int month, int userId)
        {
            return await _db
                .Where(t => t.UserId.Equals(userId) && t.TransactionType == TransactionType.Expense && t.TransactionDate.Year == year && t.TransactionDate.Month == month)
                .SumAsync(t => t.Amount);
        }

        public async Task<decimal> GetTotalIncome(int userId)
        {
            return await _db
               .Where(t => t.UserId.Equals(userId) && t.TransactionType == TransactionType.Income)
               .SumAsync(t => t.Amount);
        }

        public async Task<decimal> GetTotalExpense(int userId)
        {
            return await _db
               .Where(t => t.UserId.Equals(userId) && t.TransactionType == TransactionType.Expense)
               .SumAsync(t => t.Amount);
        }
    }
}

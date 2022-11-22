using Destrix.Application.Interfaces.Services;
using Destrix.Core.Enums.Transaction;
using Destrix.Domain.Interfaces.Repositories.Transaction;
using Destrix.DTO.Request.Transaction;
using Destrix.DTO.Response.Transaction;
using Microsoft.AspNetCore.Http;
using TransactionModel = Destrix.Domain.Entities.Transaction.Transaction;

namespace Destrix.Application.Services
{
    public class TransactionService : BaseService, ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(IHttpContextAccessor httpContextAccessor, IUserService userService, ITransactionRepository transactionRepository) 
            : base(httpContextAccessor, userService)
        {
            _transactionRepository = transactionRepository;
        }
        
        public async Task<TransactionResponse> GetByReference(string transactionReference)
        {
            var user = await GetCurrentUser();

            var transaction = _transactionRepository.GetByAsync(t => t.UserId.Equals(user.Id) && t.TransactionReference.Equals(transactionReference));

            return new TransactionResponse(transaction);
        }

        public async Task<ResumeResponse> Resume(string date)
        {
            var user = await GetCurrentUser();

            var dateSplit = date.ToString().Split('-');
            var year = int.Parse(dateSplit[0]);
            var month = int.Parse(dateSplit[1]);

            var monthIncome = await _transactionRepository.GetTotalIncomeByDate(year, month, user.Id);
            var monthExpense = await _transactionRepository.GetTotalExpenseByDate(year, month, user.Id);

            var income = await _transactionRepository.GetTotalIncome(user.Id);
            var expense = await _transactionRepository.GetTotalExpense(user.Id);

            var totalAmount = income - expense;

            return new ResumeResponse(totalAmount, monthIncome, monthExpense);
        }


        public async Task<IEnumerable<TransactionResponse>> Extract(int days)
        {
            var user = await GetCurrentUser();

            var date = DateTime.Now.AddDays(days * -1);
            if (days == 0) date = DateTime.MinValue;

            var transactions = await _transactionRepository.GetByDate(date, user.Id);

            var transactionsDTO = new List<TransactionResponse>();

            foreach (var transaction in transactions)
                transactionsDTO.Add(new TransactionResponse(transaction));

            return transactionsDTO;
        }

        public async Task<LastMonthsResponse> LastMonths(int months)
        {
            var user = await GetCurrentUser();

            var lastMonths = new LastMonthsResponse();

            for (var i = 0; i < months; i++)
            {
                var date = DateTime.Now.AddMonths(i * -1);

                var incomes = await _transactionRepository.SumByAsync(t => t.UserId.Equals(user.Id) && t.TransactionType == TransactionType.Income && t.TransactionDate.Year <= date.Year && t.TransactionDate.Month <= date.Month, t => t.Amount);
                var expenses = await _transactionRepository.SumByAsync(t => t.UserId.Equals(user.Id) && t.TransactionType == TransactionType.Expense && t.TransactionDate.Year <= date.Year && t.TransactionDate.Month <= date.Month, t => t.Amount);

                var total = incomes - expenses;

                var dateStr = string.Format("{0}/{1}", date.Month, date.Year);

                lastMonths.Labels.Add(dateStr);
                lastMonths.Values.Add(total);
            }

            lastMonths.Labels.Reverse();
            lastMonths.Values.Reverse();

            return lastMonths;
        }

        public async Task<TransactionResponse> Create(TransactionRequest transactionRequest)
        {
            var user = await GetCurrentUser();

            var transaction = new TransactionModel(transactionRequest, user.Id);

            _transactionRepository.Add(transaction);
            await _transactionRepository.Commit();

            return new TransactionResponse(transaction);
        }

        public async Task<TransactionResponse> Update(TransactionRequest transactionRequest)
        {
            var user = await GetCurrentUser();

            var transaction = await _transactionRepository.GetByAsync(t => t.UserId.Equals(user.Id) && t.TransactionReference.Equals(transactionRequest.TransactionReference));

            if (transaction is null)
                throw new Exception("Transaction not found");

            transaction.Update(transactionRequest);

            _transactionRepository.Update(transaction);
            await _transactionRepository.Commit();

            return new TransactionResponse(transaction);
        }

        public async Task<bool> Delete(Guid transactionReference)
        {
            var user = await GetCurrentUser();

            var transaction = await _transactionRepository.GetByAsync(t => t.UserId.Equals(user.Id) && t.TransactionReference.Equals(transactionReference));

            if (transaction is null)
                throw new Exception("Transaction not found");

            _transactionRepository.Delete(transaction);
            await _transactionRepository.Commit();

            return true;
        }
    }
}

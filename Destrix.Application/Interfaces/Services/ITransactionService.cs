using Destrix.DTO.Request.Transaction;
using Destrix.DTO.Response.Transaction;

namespace Destrix.Application.Interfaces.Services
{
    public interface ITransactionService : IBaseService
    {
        Task<TransactionResponse> GetByReference(string transactionReference);
        Task<ResumeResponse> Resume(string date);
        Task<IEnumerable<TransactionResponse>> Extract(int days);
        Task<LastMonthsResponse> LastMonths(int months);
        Task<TransactionResponse> Create(TransactionRequest transactionRequest);
        Task<TransactionResponse> Update(TransactionRequest transactionRequest);
        Task<bool> Delete(Guid transactionReference);
    }
}

using Destrix.API.Controllers.v1.Base;
using Destrix.Application.Interfaces.Services;
using Destrix.DTO.Request.Transaction;
using Destrix.DTO.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Destrix.API.Controllers.v1.Transactions
{
    [ApiVersion("1", Deprecated = false)]
    [Route("v{version:apiVersion}/transactions")]
    [ApiController]
    [Authorize]
    public class TransactionsController : BaseController
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        //[HttpGet("{transactionReference:required}")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesDefaultResponseType]
        //public async Task<IActionResult> GetByReference(string transactionReference)
        //{
        //    try
        //    {
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new ResultResponseModel() { Error = true, ErrorMessages = new string[] { ex.Message } });
        //    }
        //}

        [HttpGet("resume/{date:required}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Resume(string date)
        {
            try
            {
                var resume = await _transactionService.Resume(date);

                return Ok(new ResultResponseModel() { Result = resume });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultResponseModel() { Error = true, ErrorMessages = new string[] { ex.Message } });
            }
        }

        [HttpGet("extract/{days:required}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Extract(int days)
        {
            try
            {
                var transactions = await _transactionService.Extract(days);

                return Ok(new ResultResponseModel() { Result = transactions });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultResponseModel() { Error = true, ErrorMessages = new string[] { ex.Message } });
            }
        }

        [HttpGet("last-months/{months:required}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> LastMonths(int months)
        {
            try
            {
                var lastMonths = await _transactionService.LastMonths(months);

                return Ok(new ResultResponseModel() { Result = lastMonths });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultResponseModel() { Error = true, ErrorMessages = new string[] { ex.Message } });
            }
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create(TransactionRequest transactionRequest)
        {
            try
            {
                var transaction = await _transactionService.Create(transactionRequest);

                return Created(new ResultResponseModel() { Result = transaction });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultResponseModel() { Error = true, ErrorMessages = new string[] { ex.Message } });
            }
        }

        [HttpPut("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update(TransactionRequest transactionRequest)
        {
            try
            {
                var transaction = await _transactionService.Update(transactionRequest);

                return Ok(new ResultResponseModel() { Result = transaction });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultResponseModel() { Error = true, ErrorMessages = new string[] { ex.Message } });
            }
        }

        [HttpDelete("{transactionReference:required}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(Guid transactionReference)
        {
            try
            {
                var deleted = await _transactionService.Delete(transactionReference);

                return Ok(new ResultResponseModel() { Result = deleted });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultResponseModel() { Error = true, ErrorMessages = new string[] { ex.Message } });
            }
        }
    }
}

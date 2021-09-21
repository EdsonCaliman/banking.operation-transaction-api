using Banking.Operation.Transaction.Domain.Abstractions.Exceptions;
using Banking.Operation.Transaction.Domain.Abstractions.Messages;
using Banking.Operation.Transaction.Domain.Transaction.Dtos;
using Banking.Operation.Transaction.Domain.Transaction.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banking.Operation.Transaction.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("/v{version:apiVersion}/banking-operation/{clientid}/transactions")]
    [ApiController]
    public class TransactionController : Controller
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly ITransactionService _transactionService;

        public TransactionController(ILogger<TransactionController> logger, ITransactionService transactionService)
        {
            _logger = logger;
            _transactionService = transactionService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ResponseTransactionDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<ResponseTransactionDto>>> GetAll(Guid clientid)
        {
            _logger.LogInformation("Receive GetAll...");

            try
            {
                var transaction = await _transactionService.GetAll(clientid);

                if (!transaction.Any())
                {
                    return NoContent();
                }

                return Ok(transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetAll exception: {ex}");
                throw;
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponseTransactionDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetOne(Guid clientid, Guid id)
        {
            _logger.LogInformation("Receive GetOne...");

            try
            {
                var transaction = await _transactionService.GetOne(clientid, id);

                if (transaction is null)
                {
                    return NoContent();
                }

                return Ok(transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetOne exception: {ex}");
                throw;
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseTransactionDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<BussinessMessage>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Save(Guid clientid, RequestTransactionDto client)
        {
            _logger.LogInformation("Receive Save...");

            try
            {
                var transaction = await _transactionService.Save(clientid, client);

                return Ok(transaction);
            }
            catch (BussinessException bex)
            {
                return BadRequest(new BussinessMessage(bex.Type, bex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Save exception: {ex}");
                return BadRequest();
            }
        }
    }
}

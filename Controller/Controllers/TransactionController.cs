using Application.DTO;
using Application.Interface.IService;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
      private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        [HttpPost]
        public async Task<IActionResult> AddTransaction([FromBody] CommandTransactionDTO transactionDTO)
        {
            var result = await _transactionService.AddTransaction(transactionDTO);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetPagingAsync([FromQuery] SearchDTO searchDTO)
        {
            var result = await _transactionService.GetPagingAsync(searchDTO);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("count")]  
        public async Task<IActionResult> Count([FromQuery] CountDTO countDTO)
        {
            var result = await _transactionService.CountAsync(countDTO);
            return result.Success ? Ok(result) : BadRequest(result);
        }

    }
}

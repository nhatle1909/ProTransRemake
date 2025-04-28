using Application.DTO;
using Application.Interface.IService;
using Microsoft.AspNetCore.Mvc;


namespace Controller.Controllers
{
    [Route("api/[controller]")]
    public class TranslationPriceController : ControllerBase
    {
        private readonly ITranslationPriceService _service;
        public TranslationPriceController(ITranslationPriceService service)
        {
            _service = service;
        }
        [HttpGet("paging")]
        public async Task<IActionResult> Paging([FromQuery] SearchDTO searchDTO)
        {
            var result = await _service.GetPagingAsync(searchDTO);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, CommandTranslationPriceDTO commandTranslationPriceDTO)
        {
            var result = await _service.UpdateTranslationPrice(id, commandTranslationPriceDTO);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CommandTranslationPriceDTO commandTranslationPriceDTO)
        {
            var result = await _service.AddTranslationPrice(commandTranslationPriceDTO);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var result = await _service.DeleteTranslationPrice(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}

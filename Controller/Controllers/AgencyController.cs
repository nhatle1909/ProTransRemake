using Application.DTO;
using Application.Interface.IService;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgencyController : ControllerBase
    {
        private readonly IAgencyService _service;
        public AgencyController(IAgencyService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CommandAgencyDTO commandAgencyDTO)
        {
            var result = await _service.CreateAgency(commandAgencyDTO);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, CommandAgencyDTO commandAgencyDTO)
        {
            var result = await _service.UpdateAgency(id, commandAgencyDTO);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftRemove(Guid id)
        {
            var result = await _service.SoftRemoveAgency(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetPagingAgencies([FromQuery] SearchDTO searchDTO)
        {
            var result = await _service.GetPagingAgencies(searchDTO);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("count")]
        public async Task<IActionResult> CountAgencies([FromQuery] CountDTO countDTO)
        {
            var result = await _service.CountAsync(countDTO);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}

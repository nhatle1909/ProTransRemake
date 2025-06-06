using Application.DTO;
using Application.Interface.IService;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DistanceController : ControllerBase
    {
        private readonly IDistanceService _distanceService;
        public DistanceController(IDistanceService distanceService)
        {
            _distanceService = distanceService;
        }
        [HttpPost()]
        public async Task<IActionResult> CreateNewDistance([FromBody] CommandDistanceDTO distanceDTO)
        {
            var result = await _distanceService.AddDistance(distanceDTO);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDistance(Guid id, [FromBody] CommandDistanceDTO distanceDTO)
        {
            var result = await _distanceService.UpdateDistance(id, distanceDTO);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistance(Guid id)
        {
            var result = await _distanceService.DeleteDistance(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetPagingAsync([FromQuery] SearchDTO searchDTO)
        {
            var result = await _distanceService.GetPagingAsync(searchDTO);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("count")]
        public async Task<IActionResult> Count([FromQuery] CountDTO countDTO)
        {
            var result = await _distanceService.CountAsync(countDTO);
            return result.Success ? Ok(result) : BadRequest(result);
        }

    }
}

using Application.DTO;
using Application.Interface.IService;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        public EmployeeController(IEmployeeService service)
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
        public async Task<IActionResult> Update(Guid id, CommandEmployeeDTO commandEmployeeDTO)
        {
            var result = await _service.UpdateEmployeeInfo(id, commandEmployeeDTO);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _service.GetEmployeeInfo(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CommandEmployeeDTO commandEmployeeDTO)
        {
            var result = await _service.CreateNewEmployee(commandEmployeeDTO);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftRemove(Guid id)
        {
            var result = await _service.SoftRemoveEmployee(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("count")]
        public async Task<IActionResult> Count([FromQuery] CountDTO countDTO)
        {
            var result = await _service.CountAsync(countDTO);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}

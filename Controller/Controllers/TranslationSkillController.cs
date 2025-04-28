
using Application.DTO;
using Application.Interface.IService;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers
{
    [Route("api/[controller]")]
    public class TranslationSkillController : ControllerBase
    {
        private readonly ITranslationSkillService _service;
        public TranslationSkillController(ITranslationSkillService service)
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
        public async Task<IActionResult> Update(Guid id, CommandTranslationSkillDTO commandTranslationSkillDTO)
        {
            var result = await _service.UpdateTranslationSkill(id, commandTranslationSkillDTO);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CommandTranslationSkillDTO commandTranslationSkillDTO)
        {
            var result = await _service.AddTranslationSkill(commandTranslationSkillDTO);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var result = await _service.DeleteTranslationSkill(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}

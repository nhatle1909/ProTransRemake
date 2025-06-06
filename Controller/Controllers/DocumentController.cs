
using Application.DTO;
using Application.Interface.IService;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewDocument([FromBody] CommandDocumentDTO commandDocumentDTO)
        {
            var result = await _documentService.CreateNewDocument(commandDocumentDTO);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocument(Guid id, [FromBody] CommandDocumentDTO commandDocumentDTO)
        {
            var result = await _documentService.UpdateDocument(id, commandDocumentDTO);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftRemoveDocument(Guid id)
        {
            var result = await _documentService.SoftRemoveDocument(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocumentInfo(Guid id)
        {
            var result = await _documentService.GetDocumentById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetPagingDocuments([FromQuery] SearchDTO searchDTO)
        {
            var result = await _documentService.GetPagingDocuments(searchDTO);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("count")]
        public async Task<IActionResult> CountDocuments([FromQuery] CountDTO countDTO)
        {
            var result = await _documentService.CountAsync(countDTO);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}

using Application.DTO;
using Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {

            _orderService = orderService;
            // Constructor logic can be added here if needed
        }
        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] CommandOrderDTO orderDTO)
        {
            var result = await _orderService.AddOrder(orderDTO);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id, [FromBody] CommandOrderDTO orderDTO)
        {
            var result = await _orderService.UpdateOrder(id, orderDTO);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var result = await _orderService.DeleteOrder(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderInfo(Guid id)
        {
            var result = await _orderService.GetOrderInfo(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetPagingAsync([FromQuery] SearchDTO searchDTO)
        {
            var result = await _orderService.GetPagingAsync(searchDTO);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPut("{id}/soft-remove")]
        public async Task<IActionResult> SoftRemoveOrder(Guid id)
        {
            var result = await _orderService.SoftRemoveOrder(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPut("{id}/{status}")]
        public async Task<IActionResult> UpdateOrderStatus(Guid id, string status)
        {
            var result = await _orderService.UpdateOrderStatus(id, status);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpGet("count")]
        public async Task<IActionResult> CountOrders([FromQuery] CountDTO countDTO)
        {
            var result = await _orderService.CountAsync(countDTO);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}

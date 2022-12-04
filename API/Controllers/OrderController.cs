using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("Add")]
        public IActionResult AddToBasket(int userId)
        {
            var result = _orderService.Add(userId);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("GetAll")]
        public IActionResult GetAll()
        {
            var result = _orderService.GetAll();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("GetUserOrders")]
        public IActionResult GetUserOrders(int userId)
        {
            var result = _orderService.GetUserOrders(userId);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("GetActiveOrdersWithUserId")]
        public IActionResult GetActiveOrdersWithUserId(int userId)
        {
            var result = _orderService.GetActiveOrdersWithUserId(userId);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("GetOrderDtos")]
        public IActionResult GetOrderDtos()
        {
            var result = _orderService.GetOrderDto();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

    }
}

using Business.Abstract;
using Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("addToBasket")]
        public IActionResult AddToBasket(Order order)
        {
            var result = _orderService.AddToBasket(order);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getBasket")]
        public IActionResult GetBasket()
        {
            var result = _orderService.GetBaskests();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}

using Business.Abstract;
using Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        IOrderDetailService _orderDetailService;
        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpPost("addToBasket")]
        public IActionResult AddToBasket(OrderDetail orderDetail)
        {
            var result = _orderDetailService.AddToBasket(orderDetail);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }


        [HttpGet("getBasket")]
        public IActionResult GetBasket()
        {
            var result = _orderDetailService.GetBaskests();
            if (result.Success)
                return Ok(result);

            return BadRequest(result); 
        }

        [HttpGet("GetBasketWithUserId")]
        public IActionResult GetBasketWithUserId(int userId)
        {
            var result = _orderDetailService.GetBaskestWithUserId(userId);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(OrderDetail orderDetail)
        {
            var result = _orderDetailService.Delete(orderDetail);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}

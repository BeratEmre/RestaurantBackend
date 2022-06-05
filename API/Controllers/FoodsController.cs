using Business.Abstract;
using Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        IFoodService _foodService;
        public FoodsController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpPost("add")]
        public IActionResult Add(Food food)
        {
            var result = _foodService.Add(food);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Food food)
        {
            var result = _foodService.Update(food);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _foodService.GetById(id);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _foodService.GetAll();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}

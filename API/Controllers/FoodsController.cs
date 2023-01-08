using Business.Abstract;
using Core.Helpers.FileHelper;
using Entity.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        IFoodService _foodService;
        IWebHostEnvironment _environment;
        public FoodsController(IFoodService foodService, IWebHostEnvironment environment)
        {
            _foodService = foodService;
            _environment = environment;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] FoodFormData formData)
        {
            string imgUrl = "";
            if (formData.FormFile != null)
                imgUrl = Core.Helpers.FileHelper.File.FileSave(formData.FormFile, _environment.WebRootPath + "\\imgs\\foods\\");

            Food food = new Food() { Description = formData.Description, ImgUrl = imgUrl, Name = formData.Name, Price = formData.Price };

            var result = _foodService.Add(food);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm] FoodFormData formData)
        {
            string imgUrl = "";
            if (formData.FormFile != null)
                imgUrl = Core.Helpers.FileHelper.File.FileSave(formData.FormFile, _environment.WebRootPath + "\\imgs\\foods\\");

            Food food = new Food() { Id = formData.Id, Description = formData.Description, ImgUrl = imgUrl, Name = formData.Name, Price = formData.Price };

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


        [HttpGet("GetKeyValue")]
        public IActionResult GetKeyValue()
        {
            var result = _foodService.GetKeyValue();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("Remove")]
        public IActionResult Remove(int id)
        {
            var result = _foodService.RemoveFood(id);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}

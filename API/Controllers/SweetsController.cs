using Business.Abstract;
using Core.Helpers.FileHelper;
using Entity.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SweetsController : ControllerBase
    {
        ISweetService _sweetService;
        IWebHostEnvironment _environment;
        public SweetsController(ISweetService sweetService, IWebHostEnvironment environment)
        {
            _sweetService = sweetService;
            _environment = environment;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] SweetFormData formData)
        {
            string imgUrl = "";
            if (formData.FormFile != null)
                imgUrl = Core.Helpers.FileHelper.File.FileSave(formData.FormFile, _environment.WebRootPath + "\\imgs\\sweets\\");

            Sweet sweet = new Sweet() { Id = formData.Id, Description = formData.Description, ImgUrl = imgUrl, Name = formData.Name, Price = formData.Price };
            var result = _sweetService.Add(sweet);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm] SweetFormData formData)
        {
            string imgUrl = "";
            if (formData.FormFile != null)
                imgUrl = Core.Helpers.FileHelper.File.FileSave(formData.FormFile, _environment.WebRootPath + "\\imgs\\sweets\\");

            Sweet sweet = new Sweet() { Id = formData.Id, Description = formData.Description, ImgUrl = imgUrl, Name = formData.Name, Price = formData.Price };
            var result = _sweetService.Update(sweet);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _sweetService.GetById(id);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _sweetService.GetAll();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("GetKeyValue")]
        public IActionResult GetKeyValue()
        {
            var result = _sweetService.GetKeyValue();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        
        [HttpPost("Remove")]
        public IActionResult Remove(int id)
        {
            var result = _sweetService.RemoveSweet(id);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
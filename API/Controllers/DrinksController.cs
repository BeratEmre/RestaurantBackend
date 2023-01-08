using AutoMapper;
using Business.Abstract;
using Core.Helpers.FileHelper;
using Entity.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
      
        IDrinkService _drinkService;
        public static IWebHostEnvironment _environment;
        private readonly IMapper _mapper;

        public DrinksController(IDrinkService drinkService, IWebHostEnvironment environment, IMapper mapper)
        {
            _drinkService = drinkService;
            _environment = environment;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] DrinkFormData formData)
        {
            string imgUrl = "";
            if (formData.FormFile!=null)
                 imgUrl = Core.Helpers.FileHelper.File.FileSave(formData.FormFile, _environment.WebRootPath + "\\imgs\\drinks\\");
            Drink drink = _mapper.Map<Drink>(formData);
            drink.ImgUrl = imgUrl;

            var result = _drinkService.Add(drink);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm] DrinkFormData formData)
        {
            string imgUrl = "";
            if (formData.FormFile != null)
                imgUrl = Core.Helpers.FileHelper.File.FileSave(formData.FormFile, _environment.WebRootPath + "\\imgs\\drinks\\");

            Drink drink = new Drink() { Description = formData.Description, Id = formData.Id, ImgUrl = imgUrl, Name = formData.Name, Price = formData.Price };


            var result = _drinkService.Update(drink);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }



        [HttpPost("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _drinkService.GetById(id);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _drinkService.GetAll();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("GetKeyValue")]
        public IActionResult GetKeyValue()
        {
            var result = _drinkService.GetKeyValue();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("Remove")]
        public IActionResult Remove(int id)
        {
            var result = _drinkService.RemoveDrink(id);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}

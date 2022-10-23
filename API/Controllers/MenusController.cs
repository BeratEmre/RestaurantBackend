using AutoMapper;
using Business.Abstract;
using Core.Helpers.FileHelper;
using Entity.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        IMenuService _menuService;
        IWebHostEnvironment _environment;
        private readonly IMapper _mapper;
        public MenusController(IMenuService menuService, IWebHostEnvironment environment, IMapper mapper)
        {
            _menuService = menuService;
            _environment = environment;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] MenuFormData formData)
        {
            string imgUrl = "";
            if (formData.FormFile != null)
                imgUrl = Core.Helpers.FileHelper.File.FileSave(formData.FormFile, _environment.WebRootPath + "\\imgs\\menus\\");

            Menu menu = _mapper.Map<Menu>(formData);
            menu.ImgUrl = imgUrl;

            var result = _menuService.Add(menu);
            if (result.Success)
            return Ok(result); 

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Menu menu)
        {
            var result = _menuService.Update(menu);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _menuService.GetById(id);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _menuService.GetAll();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getmenus")]
        public IActionResult GetMenus()
        {
            var result = _menuService.GetMenus();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("Remove")]
        public IActionResult Remove(int id)
        {
            var result = _menuService.RemoveMenu(id, _environment.WebRootPath + "\\imgs\\menus\\");
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("AddStar")]
        public IActionResult AddStar(int menuId)
        {
            var result = _menuService.AddStar(menuId);
            if (result)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("GetStarMenus")]
        public IActionResult GetStarMenus()
        {
            var result = _menuService.GetStarMenus();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}

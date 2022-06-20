using Business.Abstract;
using Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        IMenuService _menuService;
        public MenusController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpPost("add")]
        public IActionResult Add(Menu menu)
        {
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
    }
}

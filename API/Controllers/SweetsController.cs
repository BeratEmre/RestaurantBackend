using Business.Abstract;
using Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SweetsController : ControllerBase
    {
        ISweetService _sweetService;
        public SweetsController(ISweetService sweetService)
        {
            _sweetService = sweetService;
        }

        [HttpPost("add")]
        public IActionResult Add(Sweet sweet)
        {
            var result = _sweetService.Add(sweet);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Sweet sweet)
        {
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
    }
}

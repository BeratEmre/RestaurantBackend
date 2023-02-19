using Business.Abstract;
using Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteProductsController : ControllerBase
    {
        IFavoriteProductService _favoriteService;
        public FavoriteProductsController(IFavoriteProductService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] FavoriteProduct favoriteProduct)
        {
            var result = _favoriteService.Add(favoriteProduct);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm] FavoriteProduct favoriteProduct)
        {
            var result = _favoriteService.Delete(favoriteProduct);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(FavoriteProduct favoriteProduct)
        {
            var result = _favoriteService.Update(favoriteProduct);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _favoriteService.GetAll();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("GetTopx")]
        public IActionResult GetTopx(int x)
        {
            var result = _favoriteService.GetTopx(x);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }

}

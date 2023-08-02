using Business.Abstract;
using Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        ICommentService _commentService;
        IRatedService _ratedService;

        public CommentsController(ICommentService commentService, IRatedService ratedService)
        {
            _commentService = commentService;
            _ratedService = ratedService;
        }

        [HttpPost("ListByProdut")]
        public IActionResult GetById(ProductBase product)
        {
            var result = _commentService.ListByProduct(product);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Comment comment)
        {
            var result = _commentService.Add(comment);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("AddRated")]
        public IActionResult AddRated(RatedModel rated)
        {
            var result = _ratedService.Add(rated);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}

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

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
           
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

    }
}

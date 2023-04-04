using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowsController : ControllerBase
    {
        private IBorrowService _borrowService;

        public BorrowsController(IBorrowService borrowService)
        {
            _borrowService = borrowService;
        }

        [HttpPost("add")]
        public IActionResult Add(Borrow borrow)
        {
            var result = _borrowService.Add(borrow);
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Borrow borrow)
        {
            var result = _borrowService.Delete(borrow);
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Borrow borrow)
        {
            var result = _borrowService.Update(borrow);
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _borrowService.GetAll();
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int borrowId)
        {
            var result = _borrowService.GetById(borrowId);
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCategoriesController : ControllerBase
    {
        private IBookCategoryService _bookCategoryService;

        public BookCategoriesController(IBookCategoryService bookCategoryService)
        {
            _bookCategoryService = bookCategoryService;
        }

        [HttpPost("add")]
        public IActionResult Add(BookCategory bookCategory)
        {
            var result = _bookCategoryService.Add(bookCategory);
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(BookCategory bookCategory)
        {
            var result = _bookCategoryService.Delete(bookCategory);
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(BookCategory bookCategory)
        {
            var result = _bookCategoryService.Update(bookCategory);
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _bookCategoryService.GetAll();
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int bookCategoryId)
        {
            var result = _bookCategoryService.GetById(bookCategoryId);
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

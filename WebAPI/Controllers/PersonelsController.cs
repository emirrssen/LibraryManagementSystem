using Business.Abstract;
using Core.Entity.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelsController : ControllerBase
    {
        private IPersonelService _personelService;

        public PersonelsController(IPersonelService personelService)
        {
            _personelService = personelService;
        }

        [HttpPost("add")]
        public IActionResult Add(Personel personel)
        {
            var result = _personelService.Add(personel);
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Personel personel)
        {
            var result = _personelService.Delete(personel);
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Personel personel)
        {
            var result = _personelService.Update(personel);
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _personelService.GetAll();
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int userId)
        {
            var result = _personelService.GetById(userId);
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

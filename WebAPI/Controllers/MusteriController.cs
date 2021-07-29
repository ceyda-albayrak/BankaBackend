using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer.Entities;
using EntityLayer.EntityFramework.Concrete;
using OperationLayer.Abstract;
using OperationLayer.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusteriController : Controller
    {
        private IMusteriService _musteriService;
     
      

        public MusteriController(IMusteriService musteriService)
        {
            _musteriService = musteriService;
         

        }

        [HttpGet("getall")]
        public async Task<List<Musteri>> GetAll()
        {
            return await _musteriService.GetAll();
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(string tckn)
        {
            var result = _musteriService.Get(tckn);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest("Bad Request!");
        }

        [HttpPost("add")]
        public IActionResult Add(Musteri musteri)
        {
            var result = _musteriService.Add(musteri);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest("Bad Request!");

        }

        [HttpPost("update")]
        public IActionResult Update(Musteri musteri)
        {
            var result = _musteriService.Update(musteri);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest("Bad Request!");
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Musteri musteri)
        {
            var result = _musteriService.Delete(musteri);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest("Bad Request!");

        }

    
    }
}

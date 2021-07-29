using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer.Dtos;
using EntityLayer.Entities;
using OperationLayer.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HesapController : Controller
    {
        private IHesapService _hesapService;
        

        public HesapController(IHesapService hesapService)
        {
            _hesapService = hesapService;
        }

        [HttpGet("getall")]
        public async Task<List<Hesap>> GetAll()
        {
            return await _hesapService.GetAll();
           

        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _hesapService.Get(id.ToString());
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest("Bad Request!");
        }

        [HttpPost("add")]
        public IActionResult Add(Hesap hesap)
        {
            var result = _hesapService.Add(hesap);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest("Bad Request!");
        }

        [HttpPost("update")]
        public IActionResult Update(Hesap hesap)
        {
            var result = _hesapService.Update(hesap);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest("Bad Request!");
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Hesap hesap)
        {
            var result = _hesapService.Delete(hesap);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest("Bad Request!");

        }

        [HttpGet("getbyhesapdetail")]
        public HesapDetayDto GetByHesapDetail(int ekno)
        {
            return _hesapService.GetHesapDetail(ekno);
        }

        [HttpGet("getbyekno")]
        public async Task<List<EkNoDto>> GetByEkNo(string tckn)
        {
           return await _hesapService.GetEkNo(tckn);
        }
    }
}

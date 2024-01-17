using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Models;
using System.Net.NetworkInformation;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> HangHoas = new List<HangHoa>();

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {

                return Ok(HangHoas);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var hanghoa = HangHoas.FirstOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if(hanghoa is null)
                {
                    return NotFound();
                }
                return Ok(hanghoa);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(HangHoaVM hanghoavm)
        {
            var hanghoa = new HangHoa
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hanghoavm.TenHangHoa,
                DonGia = hanghoavm.DonGia
            };

            HangHoas.Add(hanghoa);

            return StatusCode(201, hanghoa);
        }

        [HttpPut]
        public IActionResult Edit(string id, HangHoaVM hanghoavm)
        {
            try
            {
                var hanghoa = HangHoas.FirstOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if(hanghoa is null)
                {
                    return NotFound();
                }
                hanghoa.TenHangHoa = hanghoavm.TenHangHoa;
                hanghoa.DonGia = hanghoavm.DonGia;
                return Ok(hanghoa);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            try
            {
                var hanghoa = HangHoas.FirstOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hanghoa is null)
                {
                    return NotFound();
                }
                HangHoas.Remove(hanghoa);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

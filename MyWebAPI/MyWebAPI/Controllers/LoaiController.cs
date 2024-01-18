using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Data;
using MyWebAPI.Models;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private readonly MyDbContext _context;

        public LoaiController(MyDbContext context)
        {
            _context = context;
        }

        [HttpPost("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var loais = _context.Loais.ToList();
                return Ok(loais);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPost("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var loai = _context.Loais.FirstOrDefault(l => l.MaLoai == id);
                if (loai is null)
                {
                    return NotFound();
                }
                return Ok(loai);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("Create")]
        [Authorize]
        public IActionResult Create(Loai loai)
        {
            try
            {
                var l = new LoaiEntity
                {
                    TenLoai = loai.TenLoai
                };
                _context.Add(l);
                _context.SaveChanges();
                return StatusCode(201, l);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPost("Edit/{id}")]
        public IActionResult Edit(int id, Loai model)
        {
            try
            {
                var loai = _context.Loais.FirstOrDefault(l => l.MaLoai == id);
                if (loai is null)
                {
                    return NotFound();
                }
                loai.TenLoai = model.TenLoai;
                _context.SaveChanges();
                return Ok(loai);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var loai = _context.Loais.FirstOrDefault(l => l.MaLoai == id);
                if (loai is null)
                {
                    return NotFound();
                }
                _context.Loais.Remove(loai);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

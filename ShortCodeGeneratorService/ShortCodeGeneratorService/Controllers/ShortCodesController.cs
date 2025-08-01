using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShortCodeGeneratorService.Data;
using ShortCodeGeneratorService.Models;

namespace ShortCodeGeneratorService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortCodesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public ShortCodesController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShortCode>>> GetShortCodes()
        {
            return await _context.ShortCodes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShortCode>> GetShortCode(int id)
        {
            var shortCode = await _context.ShortCodes.FindAsync(id);

            if (shortCode == null)
            {
                return NotFound();
            }

            return shortCode;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutShortCode(int id, ShortCode shortCode)
        {
            if (id != shortCode.ShortCodeID)
            {
                return BadRequest();
            }

            _context.Entry(shortCode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShortCodeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<ShortCode>> PostShortCode(ShortCode shortCode)
        {
            _context.ShortCodes.Add(shortCode);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShortCode", new { id = shortCode.ShortCodeID }, shortCode);
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShortCode(int id)
        {
            var shortCode = await _context.ShortCodes.FindAsync(id);
            if (shortCode == null)
            {
                return NotFound();
            }

            _context.ShortCodes.Remove(shortCode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShortCodeExists(int id)
        {
            return _context.ShortCodes.Any(e => e.ShortCodeID == id);
        }
    }
}

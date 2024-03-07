using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TFTWebApp.Interfaces.Services;
using TFTWebApp.Models.DTOs;

namespace TFTWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZanrController : ControllerBase
    {
        private readonly IZanrService _zanrService;

        public ZanrController(IZanrService zanrService)
        {
            _zanrService = zanrService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ZanrDTO>>> GetGenres()
        {
            var zanrovi = await _zanrService.GetGenresAsync();
            return Ok(zanrovi);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ZanrDTO>> GetGenreById(int id)
        {
            var zanr = await _zanrService.GetGenreByIdAsync(id);

            if (zanr == null)
            {
                return NotFound();
            }

            return Ok(zanr);
        }

        [HttpPost]
        public async Task<ActionResult<ZanrDTO>> CreateGenre(ZanrDTO zanrDTO)
        {
            var createdZanr = await _zanrService.CreateGenreAsync(zanrDTO);
            return CreatedAtAction(nameof(GetGenreById), new { id = createdZanr.Id }, createdZanr);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre(int id, ZanrDTO zanrDTO)
        {
            var result = await _zanrService.UpdateGenreAsync(id, zanrDTO);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var result = await _zanrService.DeleteGenreAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

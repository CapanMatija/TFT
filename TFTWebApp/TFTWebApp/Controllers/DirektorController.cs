using Microsoft.AspNetCore.Mvc;
using TFTWebApp.Interfaces.Services;
using TFTWebApp.Models.DTOs;

namespace TFTWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirektorController : ControllerBase
    {
        private readonly IDirektorService _direktorService;

        public DirektorController(IDirektorService direktorService)
        {
            _direktorService = direktorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DirektorDTO>>> GetDirectors()
        {
            var direktori = await _direktorService.GetDirectorsAsync();
            return Ok(direktori);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DirektorDTO>> GetDirectorById(int id)
        {
            var direktor = await _direktorService.GetDirectorByIdAsync(id);

            if (direktor == null)
            {
                return NotFound();
            }

            return Ok(direktor);
        }

        [HttpPost]
        public async Task<ActionResult<DirektorDTO>> CreateDirector(DirektorDTO direktorDTO)
        {
            var createdDirektor = await _direktorService.CreateDirectorAsync(direktorDTO);
            return CreatedAtAction(nameof(GetDirectorById), new { id = createdDirektor.Id }, createdDirektor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDirector(int id, DirektorDTO direktorDTO)
        {
            var result = await _direktorService.UpdateDirectorAsync(id, direktorDTO);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDirector(int id)
        {
            var result = await _direktorService.DeleteDirectorAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using TFTWebApp.Interfaces.Services;
using TFTWebApp.Models.DTOs;

namespace TFTWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlumacController : ControllerBase
    {
        private readonly IGlumacService _glumacService;

        public GlumacController(IGlumacService glumacService)
        {
            _glumacService = glumacService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GlumacDTO>>> GetActors()
        {
            var glumci = await _glumacService.GetActorsAsync();
            return Ok(glumci);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GlumacDTO>> GetActorById(int id)
        {
            var glumac = await _glumacService.GetActorByIdAsync(id);

            if (glumac == null)
            {
                return NotFound();
            }

            return Ok(glumac);
        }

        [HttpPost]
        public async Task<ActionResult<GlumacDTO>> CreateActor(GlumacDTO glumacDTO)
        {
            var createdGlumac = await _glumacService.CreateActorAsync(glumacDTO);
            return CreatedAtAction(nameof(GetActorById), new { id = createdGlumac.Id }, createdGlumac);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActor(int id, GlumacDTO glumacDTO)
        {
            var result = await _glumacService.UpdateActorAsync(id, glumacDTO);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(int id)
        {
            var result = await _glumacService.DeleteActorAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

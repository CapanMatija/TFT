using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TFTWebApp.Interfaces.Services;
using TFTWebApp.Models.DTOs;

namespace TFTWebApp.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmService _filmService;

        public FilmController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        // GET: api/film
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmDTO>>> GetFilms()
        {
            var films = await _filmService.GetFilmsAsync();
            return Ok(films);
        }

        // GET: api/film/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FilmDTO>> GetFilm(int id)
        {
            var film = await _filmService.GetFilmByIdAsync(id);

            if (film == null)
            {
                return NotFound();
            }

            return film;
        }

        // POST: api/film
        [HttpPost]
        public async Task<ActionResult<FilmDTO>> CreateFilm(FilmDTO filmDTO)
        {
            var createdFilm = await _filmService.CreateFilmAsync(filmDTO);
            return CreatedAtAction(nameof(GetFilm), new { id = createdFilm.Id }, createdFilm);
        }

        // PUT: api/film/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFilm(int id, FilmDTO filmDTO)
        {
            if (id != filmDTO.Id)
            {
                return BadRequest();
            }

            var result = await _filmService.UpdateFilmAsync(id, filmDTO);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/film/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilm(int id)
        {
            var result = await _filmService.DeleteFilmAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

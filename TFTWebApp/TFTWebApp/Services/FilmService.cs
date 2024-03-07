using TFTWebApp.Interfaces.Repositories;
using TFTWebApp.Interfaces.Services;
using TFTWebApp.Models;
using TFTWebApp.Models.DTOs;


namespace TFTWebApp.Services
{
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IZanrRepository _zanrRepository;

        public FilmService(IFilmRepository filmRepository, IZanrRepository zanrRepository)
        {
            _filmRepository = filmRepository;
            _zanrRepository = zanrRepository;
        }

        public async Task<IEnumerable<FilmDTO>> GetFilmsAsync()
        {
            var films = await _filmRepository.GetFilmsAsync();
            var filmDTOs = MapToDTOs(films);
            return filmDTOs;
        }

        public async Task<FilmDTO> GetFilmByIdAsync(int id)
        {
            var film = await _filmRepository.GetFilmByIdAsync(id);
            var filmDTO = MapToDTO(film);
            return filmDTO;
        }

        public async Task<FilmDTO> CreateFilmAsync(FilmDTO filmDTO)
        {
            var film = MapToEntity(filmDTO);
            var createdFilm = await _filmRepository.CreateFilmAsync(film);
            foreach (var zanrDTO in filmDTO.Zanrovi)
            {
                var zanr = _zanrRepository.GetGenreByIdAsync(zanrDTO.Id);
                if (zanr != null)
                {
                    var filmZanr = new FilmZanr
                    {
                        FilmId = film.Id,
                        ZanrId = zanr.Id
                    };

                    //Dodaj zanr
                }
            }

            var createdFilmDTO = MapToDTO(createdFilm);
            return createdFilmDTO;
        }

        public async Task<bool> UpdateFilmAsync(int id, FilmDTO filmDTO)
        {
            var film = MapToEntity(filmDTO);
            var result = await _filmRepository.UpdateFilmAsync(id, film);
            return result;
        }

        public async Task<bool> DeleteFilmAsync(int id)
        {
            var result = await _filmRepository.DeleteFilmAsync(id);
            return result;
        }

        private FilmDTO MapToDTO(Film film)
        {
            if (film == null)
            {
                return null;
            }
            return new FilmDTO
            {
                Id = film.Id,
                Naslov = film.Naslov,
                Opis = film.Opis,
                PocetakSnimanja = film.PocetakSnimanja,
                KrajSnimanja = film.KrajSnimanja,
                Budzet = film.Budzet,
                DirektorId = film.DirektorId,
                Trajanje = film.Trajanje,
            };
        }

        private IEnumerable<FilmDTO> MapToDTOs(IEnumerable<Film> films)
        {
            var filmDTOs = new List<FilmDTO>();
            foreach (var film in films)
            {
                filmDTOs.Add(MapToDTO(film));
            }
            return filmDTOs;
        }

        private Film MapToEntity(FilmDTO filmDTO)
        {
            return new Film
            {
                Id = filmDTO.Id,
                Naslov = filmDTO.Naslov,
                Opis = filmDTO.Opis,
                PocetakSnimanja = filmDTO.PocetakSnimanja,
                KrajSnimanja = filmDTO.KrajSnimanja,
                Budzet = filmDTO.Budzet,
                DirektorId = filmDTO.DirektorId,
                Trajanje = filmDTO.Trajanje
            };
        }
    }
}

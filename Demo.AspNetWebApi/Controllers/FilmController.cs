using AutoMapper;
using Demo.AspNetWebApi.Dto;
using Demo.AspNetWebApi.Interfaces;
using Demo.DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.AspNetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : Controller
    { 
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;

        public FilmController(IFilmRepository filmRepository, IMapper mapper)
        {
            _filmRepository = filmRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Film>))]
        //[Route("GetFilms")] // not required
        public async Task<ActionResult<List<Film>>> GetFilms()
        {
            //var film = await _filmRepository.GetFilms();

            //var filmDtos = new List<FilmDto>();
            //foreach (var film in film)
            //{
            //    var newFilmDto = new FilmDto()
            //    {
            //        Id = film.Id,
            //        Name = film.Name,
            //        Date = film.Date,
            //        Budget = film.Budget
            //    };
            //    filmDtos.Add(newFilmDto);
            //}

            var films = _mapper.Map<List<FilmDto>>(await _filmRepository.GetFilms());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(films);
        }

        [HttpGet("{filmId}")]
        [ProducesResponseType(200, Type = typeof(Film))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Film>> GetFilm(int filmId)
        {
            if (!_filmRepository.FilmExists(filmId))
                return NotFound();

            //var film = _filmRepository.GetFilm(filmId);
            var film = _mapper.Map<FilmDto>(await _filmRepository.GetFilm(filmId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(film);
        }

        [HttpGet("{filmId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Film>> GetFilmRating(int filmId)
        {
            if (!_filmRepository.FilmExists(filmId))
                return NotFound();

            var rating = _filmRepository.GetFilmRating(filmId);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(rating);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateFilm([FromQuery] int creatorId, [FromQuery] int catId, [FromBody] FilmDto filmCreate)
        {
            if (filmCreate == null)
                return BadRequest(ModelState);

            // var film = _filmRepository.GetFilmTrimToUpper(filmCreate);

            var films = await _filmRepository.GetFilms();
            var film = films
               .Where(c => c.Name.Trim().ToUpper() == filmCreate.Name.TrimEnd().ToUpper())
               .FirstOrDefault();

            if (film != null)
            {
                ModelState.AddModelError("", "Creator already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var filmMap = _mapper.Map<Film>(filmCreate);


            if (!_filmRepository.CreateFilm(creatorId, catId, filmMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{filmId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateFilm(int filmId, [FromQuery] int creatorId, [FromQuery] int catId, [FromBody] FilmDto updatedFilm)
        {
            if (updatedFilm == null)
                return BadRequest(ModelState);

            if (filmId != updatedFilm.Id)
                return BadRequest(ModelState);

            if (!_filmRepository.FilmExists(filmId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var filmMap = _mapper.Map<Film>(updatedFilm);

            if (!_filmRepository.UpdateFilm(creatorId, catId, filmMap))
            {
                ModelState.AddModelError("", "Something went wrong updating film");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{filmId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteFilm(int filmId)
        {
            if (!_filmRepository.FilmExists(filmId))
            {
                return NotFound();
            }

            //var reviewsToDelete = _reviewRepository.GetReviewsOfAPokemon(filmId);
            var filmToDelete = await _filmRepository.GetFilm(filmId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //if (!_reviewRepository.DeleteReviews(reviewsToDelete.ToList()))
            //{
            //    ModelState.AddModelError("", "Something went wrong when deleting reviews");
            //}

            if (!_filmRepository.DeleteFilm(filmToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting film");
            }

            return NoContent();
        }



    }
}

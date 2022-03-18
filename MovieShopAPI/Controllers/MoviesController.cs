using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IMovieService _movieServivce;

        public MoviesController(IMovieService movieServivce)
        {
            _movieServivce = movieServivce;
        }

        [Route("{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _movieServivce.GetMovieDetails(id);

            if (movie == null)
            {
                return NotFound( new { error = $"Movie Not Found for id: {id}"});
            }
            return Ok(movie);


        }

    }
}

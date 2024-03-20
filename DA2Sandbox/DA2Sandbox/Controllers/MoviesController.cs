using DA2Sandbox.Database;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Models.In;
using MoviesApi.Models.Out;
using System.Runtime.Serialization;
using MoviesApi.BusinessLogic;


namespace MoviesApi.Controllers
{

    //URN donde se ubicará el controlador y todas sus acciones. (en este caso api/movies) (funciona para controladores con sustantivo plural que termine en S.
    // Es buena costumbre cambiar a una ruta explícita (tipo "api/movies".
    [Route("api/[controller]")]
    //Esto es lo que le dice a ASP.NET Core que este controlador es un controlador de API y le da las funcionalidades adicionales de HTTP.
    [ApiController]
    public class MoviesController : ControllerBase
    {

        private readonly Database _database;

        public MoviesController(Database database)
        {
            _database = database;
        }

        //[HttpGet]
        //public IActionResult GetMovies()
        //{
        //    // Ok es como poner Status(200, ...)
        //    return Ok("Oppenheimer, Barbie, Shrek 2, Harry Potter 2, Tierra de Osos, Tierra de Osos 2");
        //}

        [HttpGet]
        public IActionResult GetMovieByPostfix([FromQuery] string? endsWith)
        {
            List<Movie> movies = _database.Movies;
            //string[] movies = { "Shrek 2", "Harry Potter 2", "Barbie", "Oppenheimer" };
            if (endsWith is null)
            {
                return Ok(movies);
            }
            return Ok(movies.Where(x => x.Title.EndsWith(endsWith)).ToList());
        }

        [HttpGet("{title}")]
        public IActionResult GetMovieByTitle([FromRoute] string title)
        {
            List<Movie> movies = _database.Movies;
            return Ok(from movie in movies
                      where movie.Title.ToLower().Equals(title.ToLower())
                      select movie);
        }

        [HttpPost]
        public IActionResult CreateMovie([FromBody] CreateMovieRequest movie)
        {
            CreateMovieResponse response = new CreateMovieResponse()
            {
                Title = movie.Title,
                Genres = movie.Genres
            };

            _database.Movies.Add(new Movie(movie.Title, movie.Genres));
            return CreatedAtAction(nameof(GetMovieByTitle), new { title = response.Title }, response);
        }
    }
}

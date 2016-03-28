using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using HelloWebApi.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloWebApi.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        static List<Movie> _movies = new List<Movie>()
{
    new Movie() {Id = 1, Title = "Star Wars", Director = "George Lucas" },
        new Movie() {Id = 2, Title = "Transformers", Director = "Michael Bay" },
            new Movie() {Id = 3, Title = "Harry Potter", Director = "Chris Columbus" }

        };


        // GET: api/values
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return _movies;
        }

        [HttpGet("{id}")]
        public Movie Get(int id)
        {
            return _movies.Find(f => f.Id == id);
        }



        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Movie movie)
        {
            Movie dbMovie = _movies.Find(m => m.Id == id);
            dbMovie.Title = movie.Title;
            dbMovie.Director = movie.Director;
            return Ok();
        }


        [HttpPost]
        public IActionResult Post([FromBody]Movie movie)
        {
            int index = _movies.OrderByDescending(o => o.Id).Select(o => o.Id).FirstOrDefault();
            movie.Id = index + 1;
            _movies.Add(movie);
            return Ok(movie);
        }
    
    }
}

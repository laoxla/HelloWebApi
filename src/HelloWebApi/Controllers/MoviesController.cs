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
            new Movie() {Id = 3, Title = "Harry Potter", Director = "Chris Columbus" },

        };


        // GET: api/values
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return _movies;
        }
    
    }
}

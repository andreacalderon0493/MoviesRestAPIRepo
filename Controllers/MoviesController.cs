using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/Movies
        [HttpGet]
        public IActionResult Get()
        {
            var movies = _context.Movies.ToList();
            return Ok (movies);
         
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var movie = _context.Movies.Find(id);
            if(movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        // POST: api/Movies
        [HttpPost]
        public IActionResult Post([FromBody] Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return StatusCode(201, movie);
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public IActionResult Put (int id, [FromBody] Movie movie)
        {
            var changeMovie = _context.Movies.Find(id);
            changeMovie = movie;
            _context.Movies.Update(changeMovie);
            _context.SaveChanges();
            return Ok();
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            var movie = _context.Movies.Find(id);
            if(movie == null)
            {
                return NotFound();
            }
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

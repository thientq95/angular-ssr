using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularSSR.ApiModels;
using AngularSSR.Models;
using AngularSSR.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularSSR.Controllers
{
    public class MovieController : BaseAPIController
    {
        private readonly MovieContext _context;
        private readonly MovieService movieService;
        public MovieController(MovieService context)
        {
            movieService = context;
        }

        // GET: api/Movie
        [HttpGet]
        public ActionResult<List<Movie>> GetMovie()
        {
            var movies = movieService.Get();
            return movies;
        }

        // GET: api/Movie/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Movie> GetMovie(string id)
        {
            var movie = movieService.Get(id);
            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // POST: api/Movie
        [HttpPost]
        public ActionResult<Movie> Create(Movie movie)
        {
            movieService.Create(movie);
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }

        // PUT: api/Movie/5
        [HttpPut("{id}")]
        public ActionResult<Movie> Update(string id, Movie movie)
        {
            var movieUpdate = movieService.Get(id);
            movieUpdate.name = movie.name;
            movieUpdate.code = movie.code;
            movieService.Update(id, movieUpdate);
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Movie> Delete(string id)
        {
            var movie = movieService.Get(id);
            movieService.Remove(movie);
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }
    }
}

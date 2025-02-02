using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieShop.Web.Data;
using MovieShop.Web.Models;
using MovieShop.Web.ViewModels;  // Suppose your ViewModels live here

namespace MovieShop.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieShopDbContext _dbContext;

        public MoviesController(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET /Movies/Details/5
        public IActionResult Details(int id)
        {
            // Eager-load the associated Trailers and MovieCasts + Cast
            var movie = _dbContext.Movies
                .Include(m => m.Trailers)
                .Include(m => m.MovieCasts)
                    .ThenInclude(mc => mc.Cast)
                .FirstOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            // Example of mapping entity data into a ViewModel
            var movieDetailsVm = new MovieDetailsViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                OverView = movie.OverView,
                Tagline = movie.Tagline,
                Budget = movie.Budget,
                Revenue = movie.Revenue,
                ReleaseDate = movie.ReleaseDate,
                Runtime = movie.Runtime,
                PosterUrl = movie.PosterUrl,
                BackdropUrl = movie.BackdropUrl,
                
                // Trailer sub-VM
                Trailers = movie.Trailers?.Select(t => new TrailerViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    TrailerUrl = t.TrailerUrl
                }).ToList(),

                // Cast sub-VM
                Casts = movie.MovieCasts?.Select(mc => new CastViewModel
                {
                    Id = mc.Cast.Id,
                    Name = mc.Cast.Name,
                    Character = mc.Character,
                    ProfilePath = mc.Cast.ProfilePath
                }).ToList()
            };

            return View(movieDetailsVm);
        }
    }
}

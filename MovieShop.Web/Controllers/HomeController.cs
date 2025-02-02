using Microsoft.AspNetCore.Mvc;
using MovieShop.Web.Data;
using MovieShop.Web.Models;
using System;
using System.Linq;

namespace MovieShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieShopDbContext _dbContext;

        public HomeController(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: /?genreId=6&page=1&pageSize=20
        public IActionResult Index(int? genreId, int page = 1, int pageSize = 20)
        {
            // 1) Load all genres for the dropdown (only once)
            var allGenres = _dbContext.Genres
                .OrderBy(g => g.Name)
                .ToList();
            ViewBag.Genres = allGenres;

            // 2) Base query: all movies or filter by genre
            IQueryable<Movie> movieQuery = _dbContext.Movies;

            if (genreId.HasValue)
            {
                movieQuery = _dbContext.MovieGenres
                    .Where(mg => mg.GenreId == genreId.Value)
                    .Select(mg => mg.Movie);
            }

            // 3) Pagination logic
            int totalMoviesCount = movieQuery.Count();
            int totalPages = (int)Math.Ceiling(totalMoviesCount / (double)pageSize);

            // Skip/Take for paging
            var movies = movieQuery
                .OrderByDescending(m => m.Revenue)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.SelectedGenre = genreId; // so we can persist or highlight if needed

            return View(movies);
        }
    }
}
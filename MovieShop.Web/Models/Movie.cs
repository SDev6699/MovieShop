using System;
using System.Collections.Generic;

namespace MovieShop.Web.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string TmdbUrl { get; set; }
        public string Title { get; set; }
        
        // Note: The database column might be named [OverView].
        public string OverView { get; set; }

        public string Tagline { get; set; }
        public int? Runtime { get; set; }
        public decimal? Budget { get; set; }
        public decimal? Revenue { get; set; }
        public string BackdropUrl { get; set; }
        public string PosterUrl { get; set; }
        public string ImdbUrl { get; set; }
        public string OriginalLanguage { get; set; }
        public DateTime? ReleaseDate { get; set; }

        // Existing many-to-many with Genre
        public ICollection<MovieGenre> MovieGenres { get; set; }

        // NEW: Navigation properties for Trailers and MovieCasts
        public ICollection<Trailer> Trailers { get; set; }
        public ICollection<MovieCast> MovieCasts { get; set; }
    }
}
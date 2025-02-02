using System.Collections.Generic;

namespace MovieShop.Web.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation for many-to-many
        public ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
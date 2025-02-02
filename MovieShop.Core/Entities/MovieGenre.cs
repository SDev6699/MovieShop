namespace MovieShop.Core.Entities
{
    public class MovieGenre
    {
        // Composite PK: (MovieId, GenreId)
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}

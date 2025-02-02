namespace MovieShop.Web.Models
{
    public class MovieCast
    {
        // Composite key (MovieId + CastId)
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int CastId { get; set; }
        public Cast Cast { get; set; }

        // The character name that this cast plays in the movie
        public string Character { get; set; }
    }
}
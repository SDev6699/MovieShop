namespace MovieShop.Web.Models
{
    public class Trailer
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string TrailerUrl { get; set; }
        public string Name { get; set; }

        // Navigation back to Movie
        public Movie Movie { get; set; }
    }
}
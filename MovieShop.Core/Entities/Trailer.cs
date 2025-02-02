namespace MovieShop.Core.Entities
{
    public class Trailer
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string Name { get; set; }
        public string TrailerUrl { get; set; }

        // Navigation
        public Movie Movie { get; set; }
    }
}
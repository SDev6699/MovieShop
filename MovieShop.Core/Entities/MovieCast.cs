namespace MovieShop.Core.Entities
{
    public class MovieCast
    {
        // Composite PK: (MovieId, CastId, maybe "Character" if needed)
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int CastId { get; set; }
        public Cast Cast { get; set; }

        public string Character { get; set; }
    }
}
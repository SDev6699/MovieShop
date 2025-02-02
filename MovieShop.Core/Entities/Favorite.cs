namespace MovieShop.Core.Entities
{
    public class Favorite
    {
        // Composite PK: (UserId, MovieId)
        public int UserId { get; set; }
        public User User { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
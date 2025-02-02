namespace MovieShop.Core.Entities
{
    public class Review
    {
        // Composite PK: (UserId, MovieId)
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public decimal Rating { get; set; }
        public string ReviewText { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
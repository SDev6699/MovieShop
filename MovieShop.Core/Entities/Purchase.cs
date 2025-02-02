namespace MovieShop.Core.Entities
{
    public class Purchase
    {
        // Composite PK: (UserId, MovieId) or also use PurchaseNumber as PK
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime PurchaseDateTime { get; set; }
        public Guid PurchaseNumber { get; set; }   // Unique
        public decimal TotalPrice { get; set; }
    }
}
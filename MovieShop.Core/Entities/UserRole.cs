namespace MovieShop.Core.Entities
{
    public class UserRole
    {
        // Composite PK: (UserId, RoleId)
        public int UserId { get; set; }
        public User User { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
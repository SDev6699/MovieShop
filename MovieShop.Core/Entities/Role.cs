namespace MovieShop.Core.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
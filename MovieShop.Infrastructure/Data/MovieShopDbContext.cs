using Microsoft.EntityFrameworkCore;
using MovieShop.Core.Entities;

namespace MovieShop.Infrastructure.Data
{
    public class MovieShopDbContext : DbContext
    {
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options)
            : base(options)
        {
        }

        // DbSets for each entity
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite Keys
            modelBuilder.Entity<MovieGenre>().HasKey(mg => new { mg.MovieId, mg.GenreId });
            modelBuilder.Entity<MovieCast>().HasKey(mc => new { mc.MovieId, mc.CastId, mc.Character });
            modelBuilder.Entity<Favorite>().HasKey(f => new { f.MovieId, f.UserId });
            modelBuilder.Entity<Review>().HasKey(r => new { r.MovieId, r.UserId });
            modelBuilder.Entity<Purchase>().HasKey(p => new { p.MovieId, p.UserId });
            modelBuilder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });

            // ==============================================
            // DECIMAL PRECISION/SCALE VIA FLUENT API
            // ==============================================
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(m => m.Budget).HasColumnType("decimal(18,4)");
                entity.Property(m => m.Revenue).HasColumnType("decimal(18,4)");
                entity.Property(m => m.Price).HasColumnType("decimal(5,2)");
                // You can also specify max length for Title, etc., if desired
                // entity.Property(m => m.Title).HasMaxLength(256);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(r => r.Rating).HasColumnType("decimal(3,2)");
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.Property(p => p.TotalPrice).HasColumnType("decimal(5,2)");
            });

            // If you have other decimal columns, configure them likewise...
        }
    }
}
using Microsoft.EntityFrameworkCore;
using MovieShop.Web.Models;

namespace MovieShop.Web.Data
{
    public class MovieShopDbContext : DbContext
    {
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }

        // Add these:
        public DbSet<Cast> Casts { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<Trailer> Trailers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Existing:
            modelBuilder.Entity<Movie>().ToTable("Movies");
            modelBuilder.Entity<Genre>().ToTable("Genres");
            modelBuilder.Entity<MovieGenre>().ToTable("MovieGenres");
            modelBuilder.Entity<MovieGenre>()
                .HasKey(mg => new { mg.MovieId, mg.GenreId });

            modelBuilder.Entity<Movie>()
                .Property(m => m.OverView)
                .HasColumnName("OverView");

            // NEW: Map MovieCast & Trailer
            modelBuilder.Entity<MovieCast>().ToTable("MovieCasts");
            modelBuilder.Entity<MovieCast>()
                .HasKey(mc => new { mc.MovieId, mc.CastId });

            modelBuilder.Entity<Trailer>().ToTable("Trailers");
        }
    }
}
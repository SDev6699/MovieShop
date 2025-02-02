namespace MovieShop.Web.ViewModels
{
    public class MovieDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string OverView { get; set; }
        public string Tagline { get; set; }
        public decimal? Budget { get; set; }
        public decimal? Revenue { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? Runtime { get; set; }
        public string PosterUrl { get; set; }
        public string BackdropUrl { get; set; }

        public List<TrailerViewModel> Trailers { get; set; }
        public List<CastViewModel> Casts { get; set; }
    }

    public class TrailerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TrailerUrl { get; set; }
    }

    public class CastViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Character { get; set; }
        public string ProfilePath { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Movies.Web.Models
{
    public class MovieDbContext : DbContext
    {
        private readonly IConfigurationRoot _configuration;

        public MovieDbContext(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Studio> Studios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:MVCMovieContext"]);
        }
    }
}

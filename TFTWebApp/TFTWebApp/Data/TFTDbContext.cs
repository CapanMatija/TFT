using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TFTWebApp.Models;

namespace TFTWebApp.Data
{
    public class TFTDbContext : IdentityDbContext<ApplicationUser>
    {
        public TFTDbContext()
        {
            
        }
        public TFTDbContext(DbContextOptions<TFTDbContext> options) : base(options)
        {
        }

        // Dodajte DbSet za svaki entitet koji želite mapirati u bazu podataka
        public DbSet<Film> Films { get; set; }
        public DbSet<Glumac> Glumci { get; set; }
        public DbSet<Direktor> Direktori { get; set; }
        public DbSet<Zanr> Zanrovi { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<FilmZanr> FilmZanr { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FilmGlumac>()
                .HasKey(fg => new { fg.FilmId, fg.GlumacId }); // Define composite primary key

            modelBuilder.Entity<FilmZanr>()
                .HasKey(fg => new { fg.FilmId, fg.ZanrId }); // Define composite primary key
        }
    }
}

using Demo.DataLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.AspNetWebApi.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Сreator> Creators { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmСreator> FilmСreators { get; set; }
        public DbSet<FilmCategory> FilmCategories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        // two many to many relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmCategory>()
                    .HasKey(fc => new { fc.FilmId, fc.CategoryId });
            modelBuilder.Entity<FilmCategory>()
                    .HasOne(f => f.Film)
                    .WithMany(fc => fc.FilmCategories)
                    .HasForeignKey(f => f.FilmId);
            modelBuilder.Entity<FilmCategory>()
                    .HasOne(f => f.Category)
                    .WithMany(fc => fc.FilmCategories)
                    .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<FilmСreator>()
                    .HasKey(fc => new { fc.FilmId, fc.СreatorId });
            modelBuilder.Entity<FilmСreator>()
                    .HasOne(f => f.Film)
                    .WithMany(fc => fc.FilmСreators)
                    .HasForeignKey(f => f.FilmId);
            modelBuilder.Entity<FilmСreator>()
                    .HasOne(f => f.Сreator)
                    .WithMany(fc => fc.FilmСreators)
                    .HasForeignKey(c => c.СreatorId);
        }
    }
}

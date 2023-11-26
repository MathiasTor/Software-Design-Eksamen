using Microsoft.EntityFrameworkCore;
using PG3302_Eksamen.Media;
using PG3302_Eksamen.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG3302_Eksamen.Database
{
    public class MediaDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Music> Music { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<SystemUser> Users { get; set; }

        //Constructor
        /*
        public MediaDbContext(DbContextOptions<MediaDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }*/
        public MediaDbContext()
        {
        }

        public MediaDbContext(DbContextOptions options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Resources\Media.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().ToTable("Movies");
            modelBuilder.Entity<Game>().ToTable("Games");
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Music>().ToTable("Music");
            modelBuilder.Entity<SystemUser>().ToTable("Users");
        }

    }
}

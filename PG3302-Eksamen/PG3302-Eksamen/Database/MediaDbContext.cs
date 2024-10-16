﻿using Microsoft.EntityFrameworkCore;
using PG3302_Eksamen.Media;
using PG3302_Eksamen.User;
using PG3302_Eksamen.Renting;

namespace PG3302_Eksamen.Database
{
    public class MediaDbContext : DbContext
    {

        //Properties

        public DbSet<Game> Games { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Music> Music { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<SystemUser> Users { get; set; }
        public DbSet<RentedMedia> RentedMedia { get; set; }

        //Constructors
        public MediaDbContext()
        {
        }

        public MediaDbContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        //Methods

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
            modelBuilder.Entity<RentedMedia>().ToTable("RentedMedia");
        }
    }
}

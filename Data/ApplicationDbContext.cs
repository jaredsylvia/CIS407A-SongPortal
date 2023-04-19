using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SongManagement.Models;

namespace SongManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Genre> Genres { get; set; } // Genre context
        public DbSet<Song> Songs { get; set; } // Songs

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Rock and Roll", Description = "Our amps go to 11, 11 is louder than 10." },
                new Genre { Id = 2, Name = "Jazz", Description = "Like life, best when improvised." },
                new Genre { Id = 3, Name = "Hip Hop", Description = "I got 99 problems, but this genre ain't one." },
                new Genre { Id = 4, Name = "Country", Description = "This machine kills fascists." },
                new Genre { Id = 5, Name = "Punk", Description = "Anti-Reagan, pro youth."}
                );
            builder.Entity<Song>().HasData(
                new Song { Id = 1, Title = "Bohemian Rhapsody", Artist = "Queen", ReleaseDate = new DateTime(1975, 10, 31), GenreId = 1},
                new Song { Id = 2, Title = "Manteca", Artist = "Dizzy Gillespie", ReleaseDate = new DateTime(1947, 9, 29), GenreId = 2},
                new Song { Id = 3, Title = "California Love", Artist = "Tupac", ReleaseDate = new DateTime(1995, 12, 3), GenreId = 3},
                new Song { Id = 4, Title = "Country Heroes", Artist = "Hank3", ReleaseDate = new DateTime(2006, 2, 28), GenreId = 4},
                new Song { Id = 5, Title = "Maxwell Murder", Artist = "Rancid", ReleaseDate = new DateTime(1995, 8,  22), GenreId = 5}
                );
        }
    }
}
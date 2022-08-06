using System;
using Microsoft.EntityFrameworkCore;
using AlkemyChallenge.Domain.Entities;
using AlkemyChallenge.Domain.EntitiesConfiguration;

namespace AlkemyChallenge.AccessData
{
    public class APIDbContext : DbContext
    {

        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        { }

            public DbSet<Characters> Characters { get; set; }
            public DbSet<Movies> Movies { get; set; }
            public DbSet<Genres> Genres { get; set; }
            public DbSet<Users> Users { get; set; }
 
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.ApplyConfiguration<Characters>(new CharactersConfiguration());
                modelBuilder.ApplyConfiguration<Movies>(new MoviesConfiguration());
                modelBuilder.ApplyConfiguration<Genres>(new GenresConfiguration());
                modelBuilder.ApplyConfiguration<CharactersMovies>(new CharactersMoviesConfiguration());
                modelBuilder.ApplyConfiguration<Users>(new UsersConfiguration());
            }
        
    }

}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AlkemyChallenge.Domain.Entities;
using System;

namespace AlkemyChallenge.Domain.EntitiesConfiguration
{
    
    public class CharactersMoviesConfiguration : IEntityTypeConfiguration<CharactersMovies>
    {
            public void Configure(EntityTypeBuilder<CharactersMovies> builder)
            {
                builder.HasKey(c => c.CharactersMoviesId);
                builder.Property(c => c.CharactersMoviesId)
                    .ValueGeneratedOnAdd()
                    .IsRequired(true);



            builder.HasData(

                    new CharactersMovies
                    {
                        CharactersMoviesId = Guid.NewGuid(),
                        CharactersCharacterId = 1,
                        MoviesId = Guid.Parse("002A442C-C613-4B64-A788-185CFC37C0B2")
                    },

                     new CharactersMovies
                     {
                         CharactersMoviesId = Guid.NewGuid(),
                         CharactersCharacterId = 2,
                         MoviesId = Guid.Parse("6042D900-5F13-476A-886C-BD3F3EF9105F")
                     },

                      new CharactersMovies
                      {
                          CharactersMoviesId = Guid.NewGuid(),
                          CharactersCharacterId = 3,
                          MoviesId = Guid.Parse("3520916A-6ABD-46F3-D6FB-08D9BC5E7C19")
                      });

            }
        
    }

}
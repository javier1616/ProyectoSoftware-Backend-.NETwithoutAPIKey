using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AlkemyChallenge.Domain.Entities;
using System;

namespace AlkemyChallenge.Domain.EntitiesConfiguration
{
   public class MoviesConfiguration : IEntityTypeConfiguration<Movies>
   {
            public void Configure(EntityTypeBuilder<Movies> builder)
            {

                builder.HasKey(c => c.MovieId);
                builder.Property(c => c.MovieId)
                    .ValueGeneratedOnAdd()
                    .IsRequired(true);

                builder.Property(c => c.Img)
                    .HasMaxLength(255)
                    .IsRequired(true);

                builder.Property(c => c.Title)
                    .HasMaxLength(50)
                    .IsRequired(true);

                builder.Property(c => c.Date)
                    .IsRequired(true);

                builder.Property(c => c.Score)
                    .IsRequired(true);

                builder.Property(c => c.GenreId)
                    .IsRequired(true);


            builder.HasData(

                new Movies
                {
                    MovieId = Guid.Parse("002A442C-C613-4B64-A788-185CFC37C0B2"),
                    Img = "https://i.ebayimg.com/images/g/SQMAAOSwxxdZZHT0/s-l1600.jpg",
                    Title = "Alladin",
                    Date = new DateTime(1992, 12, 20, 0, 0, 0),   // (yyyy,mm,dd,hh,mm,ss)
                    Score = 5,
                    GenreId = 1
                },

                new Movies
                {
                    MovieId = Guid.Parse("6042D900-5F13-476A-886C-BD3F3EF9105F"),
                    Img = "https://i.etsystatic.com/16952472/r/il/ae1e62/1582515765/il_fullxfull.1582515765_5zfo.jpg",
                    Title = "Alice in the Wonderland",
                    Date = new DateTime(1951, 12, 25, 0, 0, 0),   // (yyyy,mm,dd,hh,mm,ss)
                    Score = 4,
                    GenreId = 2
                },

                new Movies
                {
                    MovieId = Guid.Parse("3520916A-6ABD-46F3-D6FB-08D9BC5E7C19"),
                    Img = "https://m.media-amazon.com/images/I/710gvMtoFcL._AC_SY679_.jpg",
                    Title = "Frozen",
                    Date = new DateTime(2013, 11, 22, 0, 0, 0),   // (yyyy,mm,dd,hh,mm,ss)
                    Score = 2,
                    GenreId = 2
                }

                );
            }
   }
}




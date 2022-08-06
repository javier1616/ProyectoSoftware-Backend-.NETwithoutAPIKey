using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using AlkemyChallenge.Domain.Entities;

namespace AlkemyChallenge.Domain.EntitiesConfiguration
{
   public class GenresConfiguration : IEntityTypeConfiguration<Genres>
   {
            public void Configure(EntityTypeBuilder<Genres> builder)
            {
                builder.HasKey(c => c.GenreId);
                builder.Property(c => c.GenreId)
                    .ValueGeneratedOnAdd()
                    .IsRequired(true);

                builder.Property(c => c.Img)
                    .HasMaxLength(255)
                    .IsRequired(true);

                builder.Property(c => c.Name)
                    .HasMaxLength(50)
                    .IsRequired(true);

                builder.HasData(

                        new Genres
                        {
                            GenreId = 1,
                            Img = "img1",
                            Name = "Terror",    
                        },

                        new Genres
                        {
                            GenreId = 2,
                            Img = "img1",
                            Name = "Comedy",
                        }
                );

            }

   }

}
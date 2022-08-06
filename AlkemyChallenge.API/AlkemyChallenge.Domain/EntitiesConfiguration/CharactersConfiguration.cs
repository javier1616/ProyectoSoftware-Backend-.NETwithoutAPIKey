using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AlkemyChallenge.Domain.Entities;

namespace AlkemyChallenge.Domain.EntitiesConfiguration
{
    
    public class CharactersConfiguration : IEntityTypeConfiguration<Characters>
    {
            public void Configure(EntityTypeBuilder<Characters> builder)
            {
                builder.HasKey(c => c.CharacterId);
                builder.Property(c => c.CharacterId)
                    .ValueGeneratedOnAdd()
                    .IsRequired(true);

                builder.Property(c => c.Img)
                   .IsRequired(true)
                   .HasMaxLength(255);

                builder.Property(c => c.Name)
                   .IsRequired(true)
                   .HasMaxLength(50);

                builder.Property(c => c.Age)
                    .IsRequired(true);

                builder.Property(c => c.Weight)
                    .IsRequired(true);

                builder.Property(c => c.History)
                    .IsRequired(true)
                    .HasMaxLength(255);

                //builder.HasMany(c => c.Movies)
                //       .WithMany(c => c.Characters)
                //       .UsingEntity(j => j.ToTable("CharactersMovies"));
      

            builder.HasData(

                    new Characters
                    {
                        CharacterId = 1,
                        Img = "https://cdn.s7.shopdisney.eu/is/image/ShopDisneyEMEA/33631_aladdin_character_sq_l?$characterImageSizeDesktop1x$&fit=constrain",
                        Name = "Alladin",
                        Age = 37,
                        Weight = 50,
                        History = "Un joven que vive en la ciudad de Agrabah"
                    },

                    new Characters
                    {
                        CharacterId = 2,
                        Img = "https://cdn.s7.shopdisney.eu/is/image/ShopDisneyEMEA/33631_alice_character_sq_l?$characterImageSizeDesktop1x$&fit=constrain",
                        Name = "Alicia",
                        Age = 11,
                        Weight = 30,
                        History = "Una niña que sueña despierta y ama la lectura"
                    },

                    new Characters
                    {
                        CharacterId = 3,
                        Img = "https://cdn.s7.shopdisney.eu/is/image/ShopDisneyEMEA/33631_anna_character_sq_l?$characterImageSizeDesktop1x$&fit=constrain",
                        Name = "Anna",
                        Age = 20,
                        Weight = 45,
                        History = "Una niña que tiene el poder de convertir lo que toca en hielo."
                    });

            }
        
    }

}